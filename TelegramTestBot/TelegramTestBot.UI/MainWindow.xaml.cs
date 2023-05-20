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
        public MainWindow()
        {
            InitializeComponent();

            TabItem_CreatedTest.Visibility = Visibility.Hidden;
            GridTest.Visibility = Visibility.Hidden;
        }

        private int _authorizedTeacher;

        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private TestModelManager _testModelManager = new TestModelManager();
        private QuestionModelManager _questionModelManager = new QuestionModelManager();
        private List<QuestionModel> _allQuest = new List<QuestionModel>();
        private List<AnswerModel> _allAnswer = new List<AnswerModel>();
        private TestService testService = new TestService();

        private Data _data = new Data();

        private List<QuestionModel> GetQuestionsFromUI()
        {
                List<QuestionModel> questions = new List<QuestionModel>();
                foreach (var questionItem in LB_CreatedQuestion.Items)
                {
                string questionText = questionItem.ToString();

               QuestionModel question = new QuestionModel
               {
                   Content = questionText
               };

                questions.Add(question);
                }
                return questions;
        }


        private void B_signin_Click(object sender, RoutedEventArgs e)
        {
            if (TB_login.Text.Length > 0)     
            {
                if (Password_login.Password.Length > 0)         
                {
                    string enteredLogin = TB_login.Text;
                    string enteredPassword = _data.HashedValue(Password_login.Password);

                    try
                    {
                        TeacherModel aprovedTeacher = _teacherModelManager.GetTeacherByLogin(enteredLogin);

                        if (enteredLogin == aprovedTeacher.Login && enteredPassword == aprovedTeacher.Password)
                        {
                            _authorizedTeacher = aprovedTeacher.Id;
                            MessageBox.Show("Авторизация пройдена");                            
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
                               if(PasswordForRegister.Password.Length > 0)
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
                                                    string hashPassword = _data.HashedValue(PasswordForRegister.Password);
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
                                                else MessageBox.Show("Пароли не совподают");
                                        }
                                      }
                                      else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                                }
                                    else MessageBox.Show("Повторите пароль");
                                }
                               else MessageBox.Show("Укажите пароль");
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
            //    var nameOfNewTest = TB_NewTestorEditName.Text;
            //    if (TB_NewTestorEditName.Text.Length > 0)
            //    {
            //        TBox_CreateEdittTest.Text = nameOfNewTest;
            //        TestModel test = new TestModel()
            //        {
            //        Name = TB_NewTestorEditName.Text,
            //        TeacherId = _authorizedTeacher 
            //        };
            //        _testModelManager.AddTest(test);
            //        TB_NewTestorEditName.Clear();
            //        LB_CreatedTest.Items.Refresh();
            //        List<TestModel> Updatetest = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
            //        LB_CreatedTest.ItemsSource = Updatetest;
            //        GridTest.Visibility = Visibility.Visible;
            //    }
            //    else MessageBox.Show("Введите название теста");
            }


            private void LB_CreatedTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
            
            //TBox_CreateEdittTest.Text = selectedTest.Name;

            //if (Tb_ContentQuestuon.Text.Length > 0)
            //{

            //}
            //else MessageBox.Show("");
            
        }

        private void TB_NewTestorEditName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TB_NewTestorEditName.Text.Length > 0)
                {
                    TBox_CreateEdittTest.Text = TB_NewTestorEditName.Text;
                    GridTest.Visibility = Visibility.Visible;
                    TB_NewTestorEditName.Clear();
                }
                else MessageBox.Show("Введите вопрос!");
            }
        }

        private void Button_SaveEditQuestion_Click(object sender, RoutedEventArgs e)
        {
            //_allQuest.Add(Tb_ContentQuestuon.Text);
            string contentQuestion = Tb_ContentQuestuon.Text;
            string content1Answer = TB_FirstAnswer.Text;
            string content2Answer = TB_SecondAnswer.Text;
            string content3Answer = TB_ThirdAnswer.Text;
            string content4Answer = TB_FourthAnswer.Text;
            AnswerModel answer1 = new AnswerModel { Content = content1Answer };
            AnswerModel answer2 = new AnswerModel { Content = TB_SecondAnswer.Text };
            AnswerModel answer3 = new AnswerModel { Content = TB_ThirdAnswer.Text };
            AnswerModel answer4 = new AnswerModel { Content = TB_FourthAnswer.Text };

            QuestionModel question = new QuestionModel
            {
                Content = contentQuestion
            };
            _allAnswer.Add(answer1);
            _allQuest.Add(question);
        }



        private void But_EndTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string testName = TBox_CreateEdittTest.Text;
                int teacherId = _authorizedTeacher; 
                List<QuestionModel> questions = _allQuest;
                List<AnswerModel> answers = _allAnswer;

                testService.CreateTest(testName, teacherId, questions);


                foreach (var question in questions)
                {
                    testService.CreateQuestion(question.Content,question.TestId,answers);
                    foreach (var answer in answers)
                    {
                        testService.CreateAnswer(answer.Content,false);
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}

