using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Managers;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramTestBot.BL.Service
{
    public class TelegramBotService
    {
        public static Dictionary<long, List<string>> UserAnswers { get; set; } = new Dictionary<long, List<string>>();
        protected Action<string> _onMessage;
        protected bool isReg = false;
        private DataService _dateService = new DataService();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private readonly TelegramBotClient _botClient;

        public TelegramBotService(Action<string> onMessage)
        {
            _botClient = new TelegramBotClient(_dateService.token);
            _onMessage = onMessage;
        }

        public void StartBot(string pass)
        {
            if (pass == "12345")
            _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private async void SendExceptionForNull(long id)
        {
            await _botClient.SendTextMessageAsync(new ChatId(id), "Пожалуйста, заполните поле");
        }

        private async void SendRegForm(long id, string? username, int numOfForm = 0)
        {
            List<string> questions = new List<string>() { "Ваше Имя:", "Ваша Фамилия:", "Ваше Отчество:" };
            StudentModel regStudent = new StudentModel();

            if (numOfForm <= questions.Count - 1)
            {
                string currentQuest = questions[numOfForm];

                await _botClient.SendTextMessageAsync(new ChatId(id), $"{currentQuest}");
            }
            else
            {
                regStudent = new StudentModel() { UserChatId = id, 
                    Firstname = UserAnswers[id][0], 
                    Surname = UserAnswers[id][1],
                    Lastname = UserAnswers[id][2], 
                    Username = username,
                };

                _studentModelManager.AddStudent(regStudent);
                isReg = false;

                await _botClient.SendTextMessageAsync(new ChatId(id), "Поздравляем, вы зарегистрированы, ожидайте заданий от преподавателя");
            }
        }

        private async void RegisterOfStudent(long chatId, Update update)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Зарегистрироваться", "RegButton"),
            });

            isReg = true;

            await _botClient.SendTextMessageAsync(new ChatId(chatId), "Выберите действие:", replyMarkup: inlineKeyboard);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message != null && update.Message!.Text == "/start" && _dateService.CheckStudentChatIdForUnique(update.Message.Chat.Id) == true)
            {
                await botClient.SendTextMessageAsync(update.Message!.Chat.Id, "Hello, " + update.Message.Chat.Username);
                RegisterOfStudent(update.Message.Chat.Id, update);
            }
            else if (update.CallbackQuery != null && update.CallbackQuery.Data == "RegButton")
            {
                SendRegForm(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.Chat.Username);

                UserAnswers.Add(update.CallbackQuery.Message.Chat.Id, new List<string>());

                await _botClient.EditMessageTextAsync(
                      update.CallbackQuery.Message!.Chat.Id,
                      update.CallbackQuery.Message.MessageId,
                      update.CallbackQuery.Message.Text!,
                      replyMarkup: null);
            }
            else if (update.Message?.Text != null && isReg == true)
            {
                UserAnswers[update.Message.Chat.Id].Add(update.Message.Text);
                int num = UserAnswers[update.Message.Chat.Id].Count;

                SendRegForm(update.Message.Chat.Id, update.Message.Chat.Username, num);
            }
        }

        private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        //private async void ReceivedOnMessage(object sender, Update update)
        //{
        //    var message = update.Message;

        //    if (message?.Type == MessageType.Text)
        //    {
        //        await _botClient.SendTextMessageAsync(message.Chat.Id, message.Text!);
        //    }
        //}

        // protected override async void OnMessage(Message message)
        //{
        //if (message.Type == MessageType.Text)
        //{
        //if (message.Text == "/start")
        //{
        //await _botClient.SendTextMessageAsync(message.Chat.Id, "Hello," + message.Chat.Username);
        //}
        //}
        //}
    }
}
