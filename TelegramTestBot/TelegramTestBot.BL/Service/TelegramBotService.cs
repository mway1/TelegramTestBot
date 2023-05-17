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
        private TeacherModelManager _techerModelManager = new TeacherModelManager();
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

        private async void MakeActionWithBot(long id, ActionType type, string username = "User", string msg = " ")
        {
            switch (type)
            {
                case ActionType.start:
                    {                       
                        await _botClient.SendTextMessageAsync(new ChatId(id), "Hello, " + username);
                        SendActionMenu(id);                         

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
                            await _botClient.SendTextMessageAsync(new ChatId(id), 
                                username + ", вы уже зарегистрированы, ждите заданий от преподавателя! \nГлавное меню - /menu");

                        break;
                    }
                case ActionType.teachers:
                    {                       
                        if (_dateService.CheckStudentChatIdForUnique(id) == false)
                        {
                            try
                            {
                                List<TeacherModel> teachers = _techerModelManager.GetAllTeachers();
                                List<string> names = new List<string>();

                                foreach (var item in teachers)
                                {
                                    names.Add(item.Lastname + " " + item.Firstname + " " + item.Surname + " " + item.Email);
                                }

                                await _botClient.SendTextMessageAsync(new ChatId(id), string.Join('\n', names));
                            }
                            catch (Exception)
                            {
                                SendExceptionForNull(id);
                            }
                        }
                        else
                            await _botClient.SendTextMessageAsync(new ChatId(id), 
                                username + ", чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");
                        break;
                    }
                case ActionType.test:
                    {
                        break;
                    }
            }
        }

        private async void SendRegForm(long id, string? username, int numOfForm = 0)
        {
            List<string> questions = new List<string>() { "Ваше Имя:", "Ваша Фамилия:", "Ваше Отчество:" };

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

                await _botClient.SendTextMessageAsync(new ChatId(id), 
                    "Поздравляем, вы зарегистрированы, ожидайте заданий от преподавателя \nГлавное меню - /menu");
            }
        }

        private async void SendActionMenu(long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Зарегистрироваться", "/reg"),
                InlineKeyboardButton.WithCallbackData("Список преподавателей", "/teachers"),
                InlineKeyboardButton.WithCallbackData("Тестирование", "/test")
            });

            await _botClient.SendTextMessageAsync(new ChatId(chatId), "Выберите действие:", replyMarkup: inlineKeyboard);
        }

        private async void SendExceptionForNull(long id)
        {
            await _botClient.SendTextMessageAsync(new ChatId(id), "Пусто :(");
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message != null && update.Message.Text == "/start" || update.Message?.Text == "/menu")
            {
                MakeActionWithBot(update.Message!.Chat.Id, ActionType.start, update.Message.Chat.Username);
            }
            else if (update.CallbackQuery != null)
            {
                if (update.CallbackQuery.Data == "/reg")
                {
                    MakeActionWithBot(update.CallbackQuery.Message!.Chat.Id, ActionType.reg, update.CallbackQuery.Message.Chat.Username);

                    await _botClient.EditMessageTextAsync(
                      update.CallbackQuery.Message!.Chat.Id,
                      update.CallbackQuery.Message.MessageId,
                      "Ответьте на все вопросы ниже:",
                      replyMarkup: null);
                }
                else if (update.CallbackQuery.Data == "/teachers")
                {
                    MakeActionWithBot(update.CallbackQuery.Message!.Chat.Id, ActionType.teachers, update.CallbackQuery.Message.Chat.Username);

                    await _botClient.EditMessageTextAsync(
                      update.CallbackQuery.Message!.Chat.Id,
                      update.CallbackQuery.Message.MessageId,
                      "Cписок преподавателей:",
                      replyMarkup: null);
                }
            }
            else if (update.Message?.Text != null && UserAnswers.ContainsKey(update.Message.Chat.Id))
            {
                MakeActionWithBot(update.Message!.Chat.Id, ActionType.reg, update.Message.Chat.Username, update.Message.Text);
            }
            else if (update.Message != null && update.Message.Text != null)
            {
                await _botClient.SendTextMessageAsync(update.Message.Chat.Id, "Введите /menu для выбора действий");
            }
        }

        private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
