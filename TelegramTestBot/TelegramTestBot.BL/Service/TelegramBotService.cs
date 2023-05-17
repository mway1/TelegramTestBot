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

        private async void ActionWithBot(long id, string? username, ActionType type, string msg = " ")
        {
            switch (type)
            {
                case ActionType.start:
                    {
                        if(_dateService.CheckStudentChatIdForUnique(id) == true)
                        {
                            await _botClient.SendTextMessageAsync(new ChatId(id), "Hello, " + username);
                            RegisterOfStudent(id);                         
                        }
                        else
                            await _botClient.SendTextMessageAsync(new ChatId(id), username + ", ожидайте заданий от преподавателя");

                        break;
                    }
                case ActionType.reg:
                    {
                        if (_dateService.CheckStudentChatIdForUnique(id) == true)
                        {
                            if (!UserAnswers.ContainsKey(id))
                            {
                                UserAnswers.Add(id, new List<string>());
                                SendRegForm(id, username);
                            }
                            else
                            {
                                UserAnswers[id].Add(msg);
                                int num = UserAnswers[id].Count;

                                SendRegForm(id, username, num);
                            }
                        }
                        else
                            await _botClient.SendTextMessageAsync(new ChatId(id), username + ", вы уже зарегистрированы");

                        break;
                    }
                case ActionType.next:
                    {                       

                        break;
                    }
            }
        }

        private async void SendRegForm(long id, string? username, int numOfForm = 0)
        {
            List<string> questions = new List<string>() { "Ваше Имя:", "Ваша Фамилия:", "Ваше Отчество:" };
            //StudentModel regStudent = new StudentModel();

            if (numOfForm <= questions.Count - 1)
            {
                string currentQuest = questions[numOfForm];

                await _botClient.SendTextMessageAsync(new ChatId(id), $"{currentQuest}");
            }
            else
            {
                StudentModel regStudent = new StudentModel() { UserChatId = id, 
                    Firstname = UserAnswers[id][0], 
                    Surname = UserAnswers[id][1],
                    Lastname = UserAnswers[id][2], 
                    Username = username,
                };

                _studentModelManager.AddStudent(regStudent);
                UserAnswers.Remove(id);

                await _botClient.SendTextMessageAsync(new ChatId(id), "Поздравляем, вы зарегистрированы, ожидайте заданий от преподавателя");
            }
        }

        private async void RegisterOfStudent(long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Зарегистрироваться", "/reg"),
            });

            await _botClient.SendTextMessageAsync(new ChatId(chatId), "Выберите действие:", replyMarkup: inlineKeyboard);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message != null && update.Message.Text == "/start")
            {
                ActionWithBot(update.Message!.Chat.Id, update.Message.Chat.Username, ActionType.start);
            }
            else if (update.CallbackQuery != null && update.CallbackQuery.Data == "/reg")
            {
                ActionWithBot(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.Chat.Username, ActionType.reg);

                await _botClient.EditMessageTextAsync(
                      update.CallbackQuery.Message!.Chat.Id,
                      update.CallbackQuery.Message.MessageId,
                      update.CallbackQuery.Message.Text!,
                      replyMarkup: null);
            }
            else if (update.Message?.Text != null && UserAnswers.ContainsKey(update.Message.Chat.Id))
            {
                ActionWithBot(update.Message!.Chat.Id, update.Message.Chat.Username, ActionType.reg, update.Message.Text);
            }

            //if (update.Message != null && update.Message!.Text == "/start" && _dateService.CheckStudentChatIdForUnique(update.Message.Chat.Id) == true)
            //{
            //    await botClient.SendTextMessageAsync(update.Message!.Chat.Id, "Hello, " + update.Message.Chat.Username);
            //    RegisterOfStudent(update.Message.Chat.Id);
            //}
            //else if (update.CallbackQuery != null && update.CallbackQuery.Data == "RegButton")
            //{
            //    SendRegForm(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.Chat.Username);

            //    UserAnswers.Add(update.CallbackQuery.Message.Chat.Id, new List<string>());

            //    await _botClient.EditMessageTextAsync(
            //          update.CallbackQuery.Message!.Chat.Id,
            //          update.CallbackQuery.Message.MessageId,
            //          update.CallbackQuery.Message.Text!,
            //          replyMarkup: null);
            //}
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
