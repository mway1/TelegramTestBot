using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Service;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int _authorizedTeacher;
        private int _createdTestId;
        private int _updatedQuestId;
        private int _updatedTestId;
        private List<string> _labels;
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private TestModelManager _testModelManager = new TestModelManager();
        private QuestionModelManager _questionModelManager = new QuestionModelManager();
        private AnswerModelManager _answerModelManager = new AnswerModelManager();
        private List<QuestionModel> _allQuest = new List<QuestionModel>();
        private List<AnswerModel> _allAnswer = new List<AnswerModel>();
        List<AnswerModel> _answersForEditQuest = new List<AnswerModel>();
        private TelegramBotService _telegramBotService;
        private TestService testService = new TestService();
        private DataService _dataService = new DataService();

        public MainWindow()
        {
            _labels = new List<string>();
            _telegramBotService = new TelegramBotService(OnMessage);
            _telegramBotService.StartBot("12345");
            InitializeComponent();

            TabItem_CreatedTest.Visibility = Visibility.Hidden;
            GridTest.Visibility = Visibility.Hidden;
            //TabControl_Main.SelectedItem = Auth;
            TabItem_CreatedTest.Visibility = Visibility.Hidden;
            TabItem_StartPage.Visibility = Visibility.Hidden;
            TabItem_Test.Visibility = Visibility.Hidden;
            Auth.Visibility = Visibility.Hidden;
            Reg.Visibility = Visibility.Hidden;
            Groups.Visibility = Visibility.Hidden;
        }

        public void OnMessage(string s)
        {
            _labels.Add(s);
        }


        private void B_signin_Click(object sender, RoutedEventArgs e)
        {
            if (TB_login.Text.Length > 0)     
            {
                if (Password_login.Password.Length > 0)         
                {
                    string enteredLogin = TB_login.Text;
                    string enteredPassword = _dataService.HashedValue(Password_login.Password);

                    try
                    {
                        TeacherModel aprovedTeacher = _teacherModelManager.GetTeacherByLogin(enteredLogin);

                        if (enteredLogin == aprovedTeacher.Login && enteredPassword == aprovedTeacher.Password)
                        {
                            _authorizedTeacher = aprovedTeacher.Id;
                            MessageBox.Show("Авторизация пройдена");
                            TB_login.Clear();
                            Password_login.Clear();
                            TabControl_Main.SelectedItem = TabItem_StartPage;
                        }
                        else MessageBox.Show("Неверный логин или пароль");
                    }
                    catch(Exception)
                    {                    
                        MessageBox.Show("Пользователь не найден");
                    }                                   
                }
                else MessageBox.Show("Введите пароль");    
            }
            else MessageBox.Show("Введите логин"); 
        }

        private void B_reg_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = Reg;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (TB_LastName_Teacher.Text.Length > 0)
            {
                if (TB_FirstName_Teacher.Text.Length > 0)
                {
                    if (TB_SurName_Teacher.Text.Length > 0)
                    {
                        if(TB_Email_Teacher.Text.Length > 0)
                        {
                            if(TB_Login_Teacher.Text.Length > 0)
                            {
                                if (_dataService.CheckTeacherLoginForUnique(TB_Login_Teacher.Text) == true)
                                {
                                    if (PasswordForRegister.Password.Length > 0)
                                    {
                                        if (PasswordForRegister_Copy.Password.Length > 0)
                                        {
                                            if (PasswordForRegister.Password.Length >= 6)
                                            {
                                                bool en = true;
                                                bool number = false;

                                                for (int i = 0; i < PasswordForRegister.Password.Length; i++)
                                                {
                                                    if (PasswordForRegister.Password[i] >= 'А' && PasswordForRegister.Password[i] <= 'Я') en = false;
                                                    if (PasswordForRegister.Password[i] >= '0' && PasswordForRegister.Password[i] <= '9') number = true;
                                                }

                                                if (!en)
                                                    MessageBox.Show("Доступна только английская раскладка");
                                                else if (!number)
                                                    MessageBox.Show("Добавьте хотя бы одну цифру");
                                                if (en && number)
                                                {
                                                    if (PasswordForRegister.Password == PasswordForRegister_Copy.Password)
                                                    {
                                                        string hashPassword = _dataService.HashedValue(PasswordForRegister.Password);
                                                        TeacherModel teacher = new TeacherModel()
                                                        {
                                                            Lastname = TB_LastName_Teacher.Text,
                                                            Firstname = TB_FirstName_Teacher.Text,
                                                            Surname = TB_SurName_Teacher.Text,
                                                            Email = TB_Email_Teacher.Text,
                                                            Login = TB_Login_Teacher.Text,
                                                            Password = hashPassword
                                                        };
                                                        _teacherModelManager.AddTeacher(teacher);
                                                        MessageBox.Show("Пользователь зарегистрирован");
                                                        TabControl_Main.SelectedItem = Auth;
                                                    }
                                                    else MessageBox.Show("Пароли не совпадают");
                                                }
                                            }
                                            else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                                        }
                                        else MessageBox.Show("Повторите пароль");
                                    }
                                    else MessageBox.Show("Укажите пароль");
                                }
                                else MessageBox.Show("Логин уже занят, попробуйте другой");
                            }
                            else MessageBox.Show("Укажите Login");
                        }
                        else MessageBox.Show("Укажите Email");
                    }
                    else MessageBox.Show("Укажите Отчество");
                }
                else MessageBox.Show("Укажите Имя");
            }
            else MessageBox.Show("Укажите Фамилию");
           }
        private void LB_CreatedTest_Loaded(object sender, RoutedEventArgs e)
        {
            List<TestModel> test = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
            LB_CreatedTest.ItemsSource = test;
        }

        private void Button_SaveNameOfTest_Click(object sender, RoutedEventArgs e)
        {
            if (TB_NewTestorEditName.Text.Length > 0)
            {
                TestModel newTest = new TestModel { Name = TB_NewTestorEditName.Text, TeacherId = _authorizedTeacher };
                _testModelManager.AddTest(newTest);
                TBox_CreateEdittTest.Text = newTest.Name;
                _createdTestId = _testModelManager.GetLastTestAdded(_authorizedTeacher);
                GridTest.Visibility = Visibility.Visible;
                TB_NewTestorEditName.Clear();
            }
            else MessageBox.Show("Введите название теста!");
        }


            private void LB_CreatedTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
            
            //TBox_CreateEdittTest.Text = selectedTest.Name;
            
        }

        private void TB_NewTestorEditName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TB_NewTestorEditName.Text.Length > 0)
                {
                    TestModel newTest = new TestModel { Name = TB_NewTestorEditName.Text, TeacherId = _authorizedTeacher };
                    _testModelManager.AddTest(newTest);
                    TBox_CreateEdittTest.Text = newTest.Name;
                    _createdTestId = _testModelManager.GetLastTestAdded(_authorizedTeacher);
                    GridTest.Visibility = Visibility.Visible;
                    TB_NewTestorEditName.Clear();
                }
                else MessageBox.Show("Введите название теста!");
            }
        }
        private void But_EndTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string contentQuestion = Tb_ContentQuestuon.Text;
                string content1Answer = TB_FirstAnswer.Text;
                string content2Answer = TB_SecondAnswer.Text;
                string content3Answer = TB_ThirdAnswer.Text;
                string content4Answer = TB_FourthAnswer.Text;
                _allQuest.Add(new QuestionModel { Content = contentQuestion });
                if (RB_RightAnswer1.IsChecked == true)
                {
                    TB_RightAnswerForQuest.Text = content1Answer;
                    _allAnswer.Add(new AnswerModel { Content = content1Answer, IsCorrect = true });
                    _allAnswer.Add(new AnswerModel { Content = content2Answer });
                    _allAnswer.Add(new AnswerModel { Content = content3Answer });
                    _allAnswer.Add(new AnswerModel { Content = content4Answer });
                }
                else if (RB_RightAnswer2.IsChecked == true)
                {
                    TB_RightAnswerForQuest.Text = content2Answer;
                    _allAnswer.Add(new AnswerModel { Content = content1Answer});
                    _allAnswer.Add(new AnswerModel { Content = content2Answer,IsCorrect = true });
                    _allAnswer.Add(new AnswerModel { Content = content3Answer });
                    _allAnswer.Add(new AnswerModel { Content = content4Answer });
                }
                else if (RB_RightAnswer3.IsChecked == true)
                {
                    TB_RightAnswerForQuest.Text = content3Answer;
                    _allAnswer.Add(new AnswerModel { Content = content1Answer});
                    _allAnswer.Add(new AnswerModel { Content = content2Answer });
                    _allAnswer.Add(new AnswerModel { Content = content3Answer,IsCorrect = true });
                    _allAnswer.Add(new AnswerModel { Content = content4Answer });
                }
                else if (RB_RightAnswer4.IsChecked == true)
                {
                    TB_RightAnswerForQuest.Text = content4Answer;
                    _allAnswer.Add(new AnswerModel { Content = content1Answer });
                    _allAnswer.Add(new AnswerModel { Content = content2Answer });
                    _allAnswer.Add(new AnswerModel { Content = content3Answer });
                    _allAnswer.Add(new AnswerModel { Content = content4Answer, IsCorrect = true });
                }
                else MessageBox.Show("Выберите правильный вариант ответа");

                int testId = _createdTestId;
                List<QuestionModel> questions = _allQuest;
                List<AnswerModel> answers = _allAnswer;

                testService.CreateQuestion(testId,questions);

                    foreach (var question in questions)
                    {
                        testService.CreateAnswer(question.TestId, answers);
                    }

                List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(testId);
                LB_CreatedQuestion.ItemsSource = creatingQuest;
                _allQuest.Clear();
                _allAnswer.Clear();
                Tb_ContentQuestuon.Clear();
                TB_FirstAnswer.Clear();
                TB_SecondAnswer.Clear();
                TB_ThirdAnswer.Clear();
                TB_FourthAnswer.Clear();
        
            }
            catch (Exception)
            {

            }
  
        }

        private void LB_CreatedQuestion_Loaded(object sender, RoutedEventArgs e)
        {
            List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(_createdTestId);
            LB_CreatedQuestion.ItemsSource = creatingQuest;
        }

        private void But_EndCreatingTest_Click(object sender, RoutedEventArgs e)
        {
            GridTest.Visibility = Visibility.Hidden;
            List<TestModel> test = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
            LB_CreatedTest.ItemsSource = test;
            _createdTestId = 0;
        }

        private void Button_GoToTest_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = TabItem_Test;
        }

        private void Button_GoToGroups_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = Groups;
        }

        private void But_GoStartGroups_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = TabItem_StartPage;
        }

        private void But_GoStartTest_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = TabItem_StartPage;
        }

        private void Button_SignIn_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = Auth;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            _authorizedTeacher = 0;
            TabControl_Main.SelectedItem = Auth;
        }

        private void Button_EditTest_Click(object sender, RoutedEventArgs e)
        {
            TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
            TBox_CreateEdittTest.Text = selectedTest.Name;
            _createdTestId = selectedTest.Id;
            GridTest.Visibility = Visibility.Visible;
            List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(_createdTestId);
            LB_CreatedQuestion.ItemsSource = creatingQuest;
        }

        private void LB_CreatedQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            if(LB_CreatedQuestion.SelectedItem != null)
            {
            QuestionModel selectedQuestion = (QuestionModel)LB_CreatedQuestion.SelectedItem;
            Tb_ContentQuestuon.Text = selectedQuestion.Content;
            _updatedQuestId=selectedQuestion.Id;
            _answersForEditQuest = _answerModelManager.GetAnswerByQuestionId(selectedQuestion.Id);
            TB_FirstAnswer.Text = _answersForEditQuest[0].Content;
            TB_SecondAnswer.Text = _answersForEditQuest[1].Content;
            TB_ThirdAnswer.Text = _answersForEditQuest[2].Content;
            TB_FourthAnswer.Text = _answersForEditQuest[3].Content;
            foreach(var answer in _answersForEditQuest)
            {
                if (answer.IsCorrect == true)
                {
                    TB_RightAnswerForQuest.Text=answer.Content;
                }
            }
            }

            }
            catch (NullReferenceException)
            {
                
            }
        }

        private void But_EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string contentQuestion = Tb_ContentQuestuon.Text;
                string content1Answer = TB_FirstAnswer.Text;
                string content2Answer = TB_SecondAnswer.Text;
                string content3Answer = TB_ThirdAnswer.Text;
                string content4Answer = TB_FourthAnswer.Text;
                _allQuest.Add(new QuestionModel { Content = contentQuestion });
            if (RB_RightAnswer1.IsChecked == true)
            {
                TB_RightAnswerForQuest.Text = content1Answer;
                _answersForEditQuest[0].IsCorrect = true;
                _answersForEditQuest[0].Content = TB_FirstAnswer.Text;
                _answersForEditQuest[1].Content = TB_SecondAnswer.Text;
                _answersForEditQuest[2].Content = TB_ThirdAnswer.Text;
                _answersForEditQuest[3].Content = TB_FourthAnswer.Text;
            }
            else if (RB_RightAnswer2.IsChecked == true)
            {
                TB_RightAnswerForQuest.Text = content2Answer;
                _answersForEditQuest[1].IsCorrect = true;
                _answersForEditQuest[0].Content = TB_FirstAnswer.Text;
                _answersForEditQuest[1].Content = TB_SecondAnswer.Text;
                _answersForEditQuest[2].Content = TB_ThirdAnswer.Text;
                _answersForEditQuest[3].Content = TB_FourthAnswer.Text;
            }
            else if (RB_RightAnswer3.IsChecked == true)
            {
                TB_RightAnswerForQuest.Text = content3Answer;
                _answersForEditQuest[2].IsCorrect = true;
                _answersForEditQuest[0].Content = TB_FirstAnswer.Text;
                _answersForEditQuest[1].Content = TB_SecondAnswer.Text;
                _answersForEditQuest[2].Content = TB_ThirdAnswer.Text;
                _answersForEditQuest[3].Content = TB_FourthAnswer.Text;
            }
            else if (RB_RightAnswer4.IsChecked == true)
            {
                TB_RightAnswerForQuest.Text = content4Answer;
                _answersForEditQuest[3].IsCorrect = true;
                _answersForEditQuest[0].Content = TB_FirstAnswer.Text;
                _answersForEditQuest[1].Content = TB_SecondAnswer.Text;
                _answersForEditQuest[2].Content = TB_ThirdAnswer.Text;
                _answersForEditQuest[3].Content = TB_FourthAnswer.Text;
            }
                int testId = _createdTestId;
                List<QuestionModel> questions = _allQuest;
                List<AnswerModel> answers = _answersForEditQuest;

                testService.EditQuestion(_updatedQuestId,testId, questions);

                foreach(var answer in answers)
                {
                testService.EditAnswer( answer.Id,_updatedQuestId,answer.Content,answer.IsCorrect);
                }

                List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(testId);
                LB_CreatedQuestion.ItemsSource = creatingQuest;
                _allQuest.Clear();
                _answersForEditQuest.Clear();
                Tb_ContentQuestuon.Clear();
                Tb_ContentQuestuon.Clear();
                TB_FirstAnswer.Clear();
                TB_SecondAnswer.Clear();
                TB_ThirdAnswer.Clear();
                TB_FourthAnswer.Clear();
                TB_RightAnswerForQuest.Clear();
                _updatedQuestId = 0;


        }
            catch (Exception)
            {

            }
}



        private void Button_EditNameOfTest_Click(object sender, RoutedEventArgs e)
        {
            TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
            TB_NewTestorEditName.Text = selectedTest.Name;
            _updatedTestId = selectedTest.Id;
        }
        private void Button_EditNameOfTestForNew_Click(object sender, RoutedEventArgs e)
        {
            TestModel updatedtest = new TestModel { Id = _updatedTestId, Name = TB_NewTestorEditName.Text,TeacherId=_authorizedTeacher };
            _testModelManager.UpdateTestById(updatedtest);
            TB_NewTestorEditName.Clear();
            List<TestModel> test = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
            LB_CreatedTest.ItemsSource = test;
        }
    }
}

