using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
        private TestingService _testingService = new TestingService();
        private LocationTrackingService _locationTrackingService = new LocationTrackingService();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private TeacherModelManager _techerModelManager = new TeacherModelManager();
        private GroupModelManager _groupModelManager = new GroupModelManager();
        private TestingModelManager _testingModelManager = new TestingModelManager();
        private TestModelManager _testModelManager = new TestModelManager();
        private AnswerModelManager _answerModelManager = new AnswerModelManager();
        private QuestionModelManager _questionModelManager = new QuestionModelManager();
        private TestingStudentModelManager _testingStudentModelManager = new TestingStudentModelManager();
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

        public void StartTestForGroup(int groupId, DateTime sendTime)
        {
            List<StudentModel> students = _studentModelManager.GetStudentsByGroupId(groupId);
            int testingId = _testingModelManager.GetLastAddedTestingByGroupId(groupId);

            foreach (var std in students)
            {
                if (!_dataService.CheckStudentChatIdForUnique(std.UserChatId))
                {
                    if (!_testingService.SchedulesGroup.ContainsKey(groupId))
                    {
                        TestingStudentModel testingStudent = new TestingStudentModel()
                        { StudentId = std.Id, TestingId = testingId };
                        _testingStudentModelManager.AddTestingStudent(testingStudent);
                    }
                }
            }

            StartTimerForStudent(groupId, sendTime);
        }

        public async void MakeActionWithBot(ActionType type, long id = 0, string username = "User", string msg = " ", int msgId = 0)
        {
            switch (type)
            {
                case ActionType.start:
                    {                       
                        await _botClient.SendTextMessageAsync(new ChatId(id), $"Здравствуйте, {username}");
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
                            EditMessagesWithKeyboard(id, msgId, 
                                "Чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");

                        break;
                    }
                case ActionType.testing:
                    {
                        if (!_dataService.CheckStudentChatIdForUnique(id))
                        {
                            StudentModel checkedStudent = _studentModelManager.GetStudentByChatId(id);

                            if (_testingService.SchedulesGroup.ContainsKey(checkedStudent.GroupId) && !_dataService.CheckTestingGroupIdForUnique(checkedStudent.GroupId))
                            {
                                int testingId = _testingModelManager.GetLastAddedTestingByGroupId(checkedStudent.GroupId);
                                TestingModel checkedTestingGroup = _testingModelManager.GetTestingById(testingId);
                                
                                EditMessagesWithKeyboard(id, msgId,
                                    $"{username}, тест начнется {checkedTestingGroup.Date.ToShortDateString()} в {checkedTestingGroup.Date.ToShortTimeString()}");
                            }
                            else
                                EditMessagesWithKeyboard(id, msgId,
                                    $"{username}, для вашей группы тестов еще не назначено! \nГлавное меню - /menu");
                        }
                        else
                            EditMessagesWithKeyboard(id, msgId,
                                "Чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");
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
                            {
                                DataService.UserAnswersForGroup.Remove(id);
                                SendMessagesForUser(id, username, ", такой группы не существует! \nГлавное меню - /menu");                                                                                     
                            }                               
                        }
                        else
                            EditMessagesWithKeyboard(id, msgId, 
                                "Чтобы использовать данную команду, зарегистрируйтесь! \nГлавное меню - /menu");

                        break;
                    }
                case ActionType.test:
                    {
                        int groupId = _studentModelManager.GetStudentByChatId(id).GroupId;
                        _testingService.UserAnswersForTest.Add(id, new List<int>());

                        if(!_testingService.TestSessions.ContainsKey(groupId))
                            _testingService.TestSessions.Add(groupId, true);

                        if (_testingService.TestSessions.ContainsKey(groupId))
                        {
                            EditMessagesWithKeyboard(id, msgId,
                                    "Выполните тестирование, выбирая кнопку с правильным ответом:");
                            SendNextQuestionOfTest(id, groupId, msgId: msgId);
                        }
                        else
                            EditMessagesWithKeyboard(id, msgId,
                                    "Тест для данной группы не начинался! \nГлавное меню - /menu");

                        break;
                    }
            }
        }

        private void CheckUserAnswerForCorrect(long userId, List<QuestionModel> questions, int testingId)
        {
            int countOfCorrectAns = 0;
            int studentId = _studentModelManager.GetStudentByChatId(userId).Id;
            List<int> answers = new List<int>();
            int testingStudentId = _testingStudentModelManager.GetTestingStudentByStudentIdByTestingId(studentId, testingId);

            foreach (var quests in questions)
            {
                int answerId = _answerModelManager.GetRightAnswer(quests.Id);
                answers.Add(answerId);
            }

            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i] == _testingService.UserAnswersForTest[userId][i])
                {
                    countOfCorrectAns++;
                }
            }

            TestingStudentModel updTestStud = _testingStudentModelManager.GetTestingStudentById(testingStudentId);
            updTestStud.CountAnswers = countOfCorrectAns;
           
            _testingStudentModelManager.UpdateTestingStudentById(updTestStud);
        }

        private async void SendNextQuestionOfTest(long id, int groupId, int msgId, int num = 0)
        {
            int testingId = _testingModelManager.GetLastAddedTestingByGroupId(groupId);
            int testId = _testingModelManager.GetTestingById(testingId).TestId;
            List<QuestionModel> questions = _questionModelManager.GetQuestionByTestId(testId);           

            if (num <= questions.Count - 1)
            {
                var answers = _answerModelManager.GetAnswerByQuestionId(questions[num].Id);

                var inlineKbrd = new InlineKeyboardMarkup(InlineKeyboardMarkupMakerForTest(answers, 2));

                await _botClient.EditMessageTextAsync(new ChatId(id), msgId,
                    $"{questions[num].Content}", replyMarkup: inlineKbrd);
            }
            else
            {
                await _botClient.EditMessageTextAsync(new ChatId(id), msgId,
                    "Поздравляем, вы завершили тестирование, ожидайте итоги! \nГлавное меню - /menu");

                CheckUserAnswerForCorrect(id, questions, testingId);
            }
            
        }

        public async void SendMessagesForUser(long chatId, string username = "User", string text = " ")
        {
            await _botClient.SendTextMessageAsync(new ChatId(chatId), username + text);
        }

        private void SendExceptionForNull(long id, int msgId)
        {
            EditMessagesWithKeyboard(id, msgId, "Произошла ошибочка, попробуйте еще раз! \nГлавное меню - /menu");
        }

        private async void EditMessagesWithKeyboard(long chatId, int msgId, string text)
        {
            await _botClient.EditMessageTextAsync(
                      chatId,
                      msgId,
                      text,
                      replyMarkup: null);
        }

        private static InlineKeyboardButton[][] InlineKeyboardMarkupMakerForTest(List<AnswerModel> answers, int btnsPerRow = 0)
        {
            var buttonsKeyboard = answers.Select(a => InlineKeyboardButton.WithCallbackData(a.Content, $"{a.Id}"));

            if (btnsPerRow == 0)
                return new InlineKeyboardButton[][] { buttonsKeyboard.ToArray() };
            else
                return buttonsKeyboard.Chunk(btnsPerRow).Select(a => a.ToArray()).ToArray();
        }

        private static InlineKeyboardButton[][] InlineKeyboardMarkupMaker(List<GroupModel> groups, int btnsPerRow = 0)
        {
            var buttonsKeyboard = groups.Select(g => InlineKeyboardButton.WithCallbackData(g.Name, $"{g.Id}"));

            if (btnsPerRow == 0)
                return new InlineKeyboardButton[][] { buttonsKeyboard.ToArray() };
            else
                return buttonsKeyboard.Chunk(btnsPerRow).Select(g => g.ToArray()).ToArray();
        }

        private async void UpdateStudentAfterConfirmAttendance(int studentId, int groupId, long userId)
        {
            int testingId = _testingModelManager.GetLastAddedTestingByGroupId(groupId);
            int testingStudentId = _testingStudentModelManager.GetTestingStudentByStudentIdByTestingId(studentId, testingId);
            TestingStudentModel test = _testingStudentModelManager.GetTestingStudentById(testingStudentId);

            test.IsAttendance = true;

            _testingStudentModelManager.UpdateTestingStudentById(test);

            var inlineKb = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Начать тестирование", "test")
            });

            await _botClient.SendTextMessageAsync(userId, 
                "Вы прошли тест с геопозицией, можете начать основное тестирование.", replyMarkup: inlineKb);
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
                InlineKeyboardButton.WithCallbackData("Тестирование", "testing"),
                InlineKeyboardButton.WithCallbackData("Группы", "groups")
            });

            await _botClient.SendTextMessageAsync(new ChatId(chatId), "Выберите действие:", replyMarkup: inlineKeyboard);
        }

        private void StartTimerForStudent(int groupId, DateTime sendTime)
        {
            _testingService.SchedulesGroup[groupId] = sendTime;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = (sendTime - DateTime.Now).TotalMilliseconds;
            timer.AutoReset = false;
            timer.Elapsed += (sender, args) => WaitForScheduleTime(groupId, sendTime);
            timer.Start();

            _testingService.TimersForGroup[groupId] = timer;
        }

        private async void WaitForScheduleTime(int groupId, DateTime sendTime)
        {          
            List<StudentModel> studentsOfTestGroup = _studentModelManager.GetStudentsByGroupId(groupId);

            if (_testingService.SchedulesGroup.ContainsKey(groupId) && _testingService.SchedulesGroup[groupId] == sendTime)
            {
                foreach (var students in studentsOfTestGroup)
                {
                    if (_dataService.UsersWithGeo.Contains(students.UserChatId))
                        _dataService.UsersWithGeo.Remove(students.UserChatId);

                    var geoButton = new ReplyKeyboardMarkup(new[]
                    {
                        KeyboardButton.WithRequestLocation(text : "Поделиться местоположением"),
                    });

                    geoButton.OneTimeKeyboard = true;
                    geoButton.ResizeKeyboard = true;
                    
                    await _botClient.SendTextMessageAsync(students.UserChatId, "Отправь геопозицию для начала теста", replyMarkup: geoButton);
                }
            }

            _testingService.SchedulesGroup.Remove(groupId);
            _testingService.TimersForGroup[groupId].Stop();
            _testingService.TimersForGroup[groupId].Dispose();
            _testingService.TimersForGroup.Remove(groupId);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message != null && update.Message.Text == "/start" || update.Message?.Text == "/menu")
            {
                MakeActionWithBot(ActionType.start, update.Message!.Chat.Id, update.Message.Chat.Username);
            }
            else if (update.CallbackQuery != null)
            {
                int groupId = _studentModelManager.GetStudentByChatId(update.CallbackQuery.Message!.Chat.Id).GroupId;
                bool checkForKeyboardNum = int.TryParse(update.CallbackQuery.Data, out int num);

                if (!checkForKeyboardNum)
                {
                    try
                    {
                        Enum.TryParse(update.CallbackQuery.Data, out ActionType type);

                        MakeActionWithBot(type, update.CallbackQuery.Message!.Chat.Id,
                              update.CallbackQuery.Message.Chat.Username,
                              msgId: update.CallbackQuery.Message.MessageId);
                    }
                    catch (Exception)
                    {
                        SendExceptionForNull(update.CallbackQuery.Message!.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                }
                else if (checkForKeyboardNum && _testingService.TestSessions.ContainsKey(groupId) && _testingService.TestSessions[groupId] == true)
                {
                    _testingService.UserAnswersForTest[update.CallbackQuery.Message.Chat.Id].Add(num);
                    int count = _testingService.UserAnswersForTest[update.CallbackQuery.Message.Chat.Id].Count;

                    SendNextQuestionOfTest(update.CallbackQuery.Message.Chat.Id, groupId, update.CallbackQuery.Message.MessageId, count);
                }
                else
                {
                    StudentModel editStudent = _studentModelManager.GetStudentByChatId(update.CallbackQuery.Message!.Chat.Id);

                    if (editStudent.GroupId == 1)
                    {
                        editStudent.GroupId = num;

                        _studentModelManager.UpdateStudentById(editStudent);

                        EditMessagesWithKeyboard(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId,
                            "Поздравляем, вы добавлены в группу! \nГлавное меню - /menu");
                    }
                    else
                        EditMessagesWithKeyboard(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId,
                            "Вы уже состоите в группе!" +
                            "\nВ случае ошибочного выбора - обратитесь к преподавателю! \nГлавное меню - /menu");
                }
            }
            else if (update.Message?.Text != null && DataService.UserAnswers.ContainsKey(update.Message.Chat.Id))
            {
                MakeActionWithBot(ActionType.reg, update.Message!.Chat.Id, update.Message.Chat.Username, update.Message.Text);
            }
            else if (update.Message?.Text != null && DataService.UserAnswersForGroup.ContainsKey(update.Message.Chat.Id))
            {
                MakeActionWithBot(ActionType.groups, update.Message!.Chat.Id, update.Message.Chat.Username, update.Message.Text);
            }
            else if (update.Message != null && update.Message.Type == MessageType.Location && !_dataService.UsersWithGeo.Contains(update.Message.Chat.Id))
            {
                _dataService.UsersWithGeo.Add(update.Message.Chat.Id);
                Location location = update.Message.Location;

                double latitude = location.Latitude;
                double longitude = location.Longitude;

                bool isAttendance = _locationTrackingService.CalculateDistance(latitude, longitude);

                if (isAttendance)
                {
                    StudentModel studentId = _studentModelManager.GetStudentByChatId(update.Message.Chat.Id);
                    UpdateStudentAfterConfirmAttendance(studentId.Id, studentId.GroupId, update.Message.Chat.Id);                  
                }
                else
                    await _botClient.SendTextMessageAsync(update.Message.Chat.Id, 
                        "Вы не прошли тест с геопозицией, основное тестирование не может быть начато!");
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
