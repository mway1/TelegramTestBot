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
        protected Action<string> _onMessage;
        private DataService _dataService = new DataService();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private TeacherModelManager _techerModelManager = new TeacherModelManager();
        private GroupModelManager _groupModelManager = new GroupModelManager();
        private readonly TelegramBotClient _botClient;

        public TelegramBotService(Action<string> onMessage)
        {
            _botClient = new TelegramBotClient(_dataService.token);
            _onMessage = onMessage;
        }

        public void StartBot(string pass)
        {
            if (pass == "12345")
                _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private void SendExceptionForNull(long id, int msgId)
        {
            EditMessagesWithKeyboard(id, msgId, "Произошла ошибочка, попробуйте еще раз! \nГлавное меню - /menu");
        }

        private static InlineKeyboardButton[][] InlineKeyboardMarkupMaker(List<GroupModel> groups, int btnsPerRow = 0)
        {
            var buttonsKeyboard = groups.Select(g => InlineKeyboardButton.WithCallbackData(g.Name, $"{g.Id}"));

            if (btnsPerRow == 0)
                return new InlineKeyboardButton[][] { buttonsKeyboard.ToArray() };
            else
                return buttonsKeyboard.Chunk(btnsPerRow).Select(g => g.ToArray()).ToArray();
        }

        private async void MakeActionWithBot(long id, ActionType type, string username = "User", string msg = " ", int msgId = 0)
        {
            switch (type)
            {
                case ActionType.start:
                    {                       
                        await _botClient.SendTextMessageAsync(new ChatId(id), $"Hello, {username}");
                        SendActionMenu(id);                         

                        break;
                    }
                case ActionType.reg:
                    {

                        if (_dataService.CheckStudentChatIdForUnique(id))
                        {
                            if (!DataService.UserAnswers.ContainsKey(id))
                            {
                                EditMessagesWithKeyboard(id, msgId,
                                "Ответьте на все вопросы ниже:");
                                DataService.UserAnswers.Add(id, new List<string>());
                                SendRegForm(id, username);
                            }
                            else
                            {
                                DataService.UserAnswers[id].Add(msg);
                                int num = DataService.UserAnswers[id].Count;

                                SendRegForm(id, username, num);
                            }
                        }
                        else
                            EditMessagesWithKeyboard(id, msgId, "Вы уже зарегистрированы, ждите заданий от преподавателя! \nГлавное меню - /menu");

                        break;
                    }
                case ActionType.teachers:
                    {                       
                        if (!_dataService.CheckStudentChatIdForUnique(id))
                        {
                            try
                            {
                                EditMessagesWithKeyboard(id, msgId,
                                "Список преподавателей:");

                                List<TeacherModel> teachers = _techerModelManager.GetAllTeachers();
                                List<string> names = new List<string>();

                                foreach (var item in teachers)
                                {
                                    names.Add(item.Lastname + " " + item.Firstname + " " + item.Surname + " " + item.Email);
                                }

                                await _botClient.SendTextMessageAsync(new ChatId(id), 
                                    string.Join('\n', names) + "\n\nГлавное меню - /menu");
                            }
                            catch (Exception)
                            {
                                SendExceptionForNull(id, msgId);
                            }
                        }
                        else
                            SendMessagesForUser(id, username, ", чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");

                        break;
                    }
                case ActionType.test:
                    {
                        break;
                    }
                case ActionType.groups:
                    {                            
                        if (!_dataService.CheckStudentChatIdForUnique(id))
                        {
                            if (!DataService.UserAnswersForGroup.ContainsKey(id))
                            {
                                DataService.UserAnswersForGroup.Add(id, new List<string>());
                                EditMessagesWithKeyboard(id, msgId,
                                "Введите Вашу группу полностью (Пр: 1234) или часть (Пр: 12):");
                            }
                            else if (!_dataService.CheckNameOfGroupForUnique(msg))
                            {
                                int num;
                                List<GroupModel> groups = _groupModelManager.GetGroupByEnteredText(msg);
                                DataService.UserAnswersForGroup.Remove(id);

                                if (groups.Count <= 2)
                                    num = 0;
                                else
                                    num = 3;
                                
                                var inlineKeyboard = new InlineKeyboardMarkup(InlineKeyboardMarkupMaker(groups, num));

                                await _botClient.SendTextMessageAsync(new ChatId(id), 
                                    "Выберите вашу группу:\n" + "\n\nГлавное меню - /menu", replyMarkup: inlineKeyboard);
                            }
                            else                                
                                SendMessagesForUser(id, username, ", такой группы не существует! \nГлавное меню - /menu");                                                                                     
                        }
                        else
                            SendMessagesForUser(id, username, ", чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");

                        break;
                    }
            }
        }

        private async void EditMessagesWithKeyboard(long chatId, int msgId, string text)
        {
            await _botClient.EditMessageTextAsync(
                      chatId,
                      msgId,
                      text,
                      replyMarkup: null);
        }

        private async void SendMessagesForUser(long chatId, string username = "User", string text = " ")
        {
            await _botClient.SendTextMessageAsync(new ChatId(chatId), username + text);
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
                    Firstname = DataService.UserAnswers[id][0], 
                    Surname = DataService.UserAnswers[id][1],
                    Lastname = DataService.UserAnswers[id][2], 
                    Username = username,
                    GroupId = 1
                };

                _studentModelManager.AddStudent(regStudent);
                DataService.UserAnswers.Remove(id);
                SendMessagesForUser(id, "Поздравляем, вы зарегистрированы, ожидайте заданий от преподавателя \nГлавное меню - /menu");
            }
        }

        private async void SendActionMenu(long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Зарегистрироваться", "reg"),
                InlineKeyboardButton.WithCallbackData("Список преподавателей", "teachers"),
                InlineKeyboardButton.WithCallbackData("Тестирование", "test"),
                InlineKeyboardButton.WithCallbackData("Группы", "groups")
            });

            await _botClient.SendTextMessageAsync(new ChatId(chatId), "Выберите действие:", replyMarkup: inlineKeyboard);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message != null && update.Message.Text == "/start" || update.Message?.Text == "/menu")
            {
                MakeActionWithBot(update.Message!.Chat.Id, ActionType.start, update.Message.Chat.Username);
            }
            else if (update.CallbackQuery != null)
            {
                bool checkForKeyboardGroup = int.TryParse(update.CallbackQuery.Data, out int groupId);               

                if (!checkForKeyboardGroup)
                {
                    try
                    {
                        Enum.TryParse(update.CallbackQuery.Data, out ActionType type);

                        MakeActionWithBot(update.CallbackQuery.Message!.Chat.Id, type, 
                            update.CallbackQuery.Message.Chat.Username, 
                            msgId: update.CallbackQuery.Message.MessageId);
                    }
                    catch(Exception)
                    {
                        SendExceptionForNull(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }

                }              
                else if (checkForKeyboardGroup)
                {
                    StudentModel editStudent = _studentModelManager.GetStudentByChatId(update.CallbackQuery.Message!.Chat.Id);

                    if (editStudent.GroupId == 1)
                    {                  
                        editStudent.GroupId = groupId;

                        _studentModelManager.UpdateStudentById(editStudent);

                        EditMessagesWithKeyboard(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId,
                            "Поздравляем, вы добавлены в группу! \nГлавное меню - /menu");
                    }
                    else
                        EditMessagesWithKeyboard(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, 
                            "Вы уже состоите в группе!" +
                            "\nВ случае ошибочного выбора - обратитесь к преподавателю! \nГлавное меню - /menu");
                }
                else
                {
                    SendExceptionForNull(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.MessageId);
                }
            }
            else if (update.Message?.Text != null && DataService.UserAnswers.ContainsKey(update.Message.Chat.Id))
            {
                MakeActionWithBot(update.Message!.Chat.Id, ActionType.reg, update.Message.Chat.Username, update.Message.Text);
            }
            else if (update.Message?.Text != null && DataService.UserAnswersForGroup.ContainsKey(update.Message.Chat.Id))
            {
                MakeActionWithBot(update.Message!.Chat.Id, ActionType.groups, update.Message.Chat.Username, update.Message.Text);
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
