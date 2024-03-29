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
        private int _updatedGroupId;
        private int _updatedStudentId;
        private List<string> _labels;
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private TestModelManager _testModelManager = new TestModelManager();
        private QuestionModelManager _questionModelManager = new QuestionModelManager();
        private AnswerModelManager _answerModelManager = new AnswerModelManager();
        private GroupModelManager _groupModelManager = new GroupModelManager();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private TestingModelManager _testingModelManager = new TestingModelManager();
        private TestingStudentModelManager _testingStudentModelManager = new TestingStudentModelManager();
        List<AnswerModel> _answersForEditQuest = new List<AnswerModel>();
        private TelegramBotService _telegramBotService;
        private TestService testService = new TestService();
        private RegAuthService regAuthService = new RegAuthService();

        public MainWindow()
        {
            _labels = new List<string>();
            _telegramBotService = new TelegramBotService(OnMessage);
            _telegramBotService.StartBot("12345");
            InitializeComponent();

            TabItem_CreatedTest.Visibility = Visibility.Hidden;
            GridTest.Visibility = Visibility.Hidden;
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
            string enteredLogin = TB_login.Text;
            string enteredPassword = Password_login.Password;

            string resultOfAuth = regAuthService.AuthTeacher(enteredLogin, enteredPassword);

            if (resultOfAuth == "Авторизация пройдена")
            {
                TeacherModel aprovedTeacher = _teacherModelManager.GetTeacherByLogin(enteredLogin);
                _authorizedTeacher = aprovedTeacher.Id;
                MessageBox.Show("Авторизация пройдена");
                Label_helloForTeacher.Content +=  " "+ aprovedTeacher.Firstname +" "+ aprovedTeacher.Surname;
                TB_login.Clear();
                Password_login.Clear();
                TabControl_Main.SelectedItem = TabItem_StartPage;
            }
            else MessageBox.Show(resultOfAuth);


        }

        private void B_reg_Click(object sender, RoutedEventArgs e)
        {
            TabControl_Main.SelectedItem = Reg;
        }



        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string enteredLastName = TB_LastName_Teacher.Text;
            string enteredFirstName = TB_FirstName_Teacher.Text;
            string enterdSurName = TB_SurName_Teacher.Text;
            string eneterdEmail = TB_Email_Teacher.Text;
            string eneterdLogin = TB_Login_Teacher.Text;
            string enteredPassword = PasswordForRegister.Password;
            string enteredCopyPassword = PasswordForRegister_Copy.Password;

            string resultOfReg = regAuthService.RegTeacher(enteredLastName, enteredFirstName, enterdSurName, eneterdEmail, eneterdLogin, enteredPassword, enteredCopyPassword);
            if (resultOfReg == "Регистрация пройдена успешно")
            {
                MessageBox.Show(resultOfReg);
                TabControl_Main.SelectedItem = Auth;
            }
            else MessageBox.Show(resultOfReg);
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
                TestModel test = testService.CreateTest(TB_NewTestorEditName.Text, _authorizedTeacher);
                TBox_CreateEdittTest.Text = test.Name;
                _createdTestId = _testModelManager.GetLastTestAdded(_authorizedTeacher);
                GridTest.Visibility = Visibility.Visible;
                TB_NewTestorEditName.Clear();
            }
            else MessageBox.Show("Введите название теста!");
        }

        private void TB_NewTestorEditName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TB_NewTestorEditName.Text.Length > 0)
                {
                    TestModel test = testService.CreateTest(TB_NewTestorEditName.Text, _authorizedTeacher);
                    TBox_CreateEdittTest.Text = test.Name;
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
                if (TB_FirstAnswer.Text.Length > 0 && TB_SecondAnswer.Text.Length > 0 && TB_ThirdAnswer.Text.Length > 0 && TB_FourthAnswer.Text.Length > 0 && Tb_ContentQuestuon.Text.Length > 0)
                {

                    string contentQuestion = Tb_ContentQuestuon.Text;
                    string content1Answer = TB_FirstAnswer.Text;
                    string content2Answer = TB_SecondAnswer.Text;
                    string content3Answer = TB_ThirdAnswer.Text;
                    string content4Answer = TB_FourthAnswer.Text;
                    bool firstRB = false;
                    bool secondRB = false;
                    bool thirdRB = false;
                    bool fourthRB = false;

                    if (RB_RightAnswer1.IsChecked == true)
                    {
                        firstRB = true;
                        secondRB = false;
                        thirdRB = false;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer2.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = true;
                        thirdRB = false;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer3.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = false;
                        thirdRB = true;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer4.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = false;
                        thirdRB = false;
                        fourthRB = true;
                    }

                    int testId = _createdTestId;

                    testService.CreateQuestion(testId, contentQuestion);

                    testService.CreateAnswer(testId, content1Answer, content2Answer, content3Answer, content4Answer, firstRB, secondRB, thirdRB, fourthRB);

                    List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(testId);
                    LB_CreatedQuestion.ItemsSource = creatingQuest;
                    RB_RightAnswer1.IsChecked = false;
                    RB_RightAnswer2.IsChecked = false;
                    RB_RightAnswer3.IsChecked = false;
                    RB_RightAnswer4.IsChecked = false;
                    Tb_ContentQuestuon.Clear();
                    TB_FirstAnswer.Clear();
                    TB_SecondAnswer.Clear();
                    TB_ThirdAnswer.Clear();
                    TB_FourthAnswer.Clear();
                }
                else MessageBox.Show("Для создания вопроса нужно ввести содержание вопроса и все 4 ответа!");

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
            Tb_ContentQuestuon.Clear();
            //LB_CreatedQuestion.Items.Clear();
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
            if (LB_CreatedTest.SelectedItem != null)
            {
                TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
                TBox_CreateEdittTest.Text = selectedTest.Name;
                _createdTestId = selectedTest.Id;
                GridTest.Visibility = Visibility.Visible;
                List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(_createdTestId);
                LB_CreatedQuestion.ItemsSource = creatingQuest;
            }
            else MessageBox.Show("Для изменения теста, выберите или создайте его");
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
            catch (Exception)
            {
                
            }
        }

        private void But_EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TB_FirstAnswer.Text.Length > 0 && TB_SecondAnswer.Text.Length > 0 && TB_ThirdAnswer.Text.Length > 0 && TB_FourthAnswer.Text.Length > 0 && Tb_ContentQuestuon.Text.Length > 0)
                {
                    string contentQuestion = Tb_ContentQuestuon.Text;
                    string content1Answer = TB_FirstAnswer.Text;
                    string content2Answer = TB_SecondAnswer.Text;
                    string content3Answer = TB_ThirdAnswer.Text;
                    string content4Answer = TB_FourthAnswer.Text;
                    bool firstRB = false;
                    bool secondRB = false;
                    bool thirdRB = false;
                    bool fourthRB = false;
                    if (RB_RightAnswer1.IsChecked == true)
                    {
                        firstRB = true;
                        secondRB = false;
                        thirdRB = false;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer2.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = true;
                        thirdRB = false;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer3.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = false;
                        thirdRB = true;
                        fourthRB = false;
                    }
                    else if (RB_RightAnswer4.IsChecked == true)
                    {
                        firstRB = false;
                        secondRB = false;
                        thirdRB = false;
                        fourthRB = true;
                    }
                    int testId = _createdTestId;


                    testService.EditQuestion(_updatedQuestId, testId, contentQuestion);

                    testService.EditAnswer(_updatedQuestId, content1Answer, content2Answer, content3Answer, content4Answer, firstRB, secondRB, thirdRB, fourthRB);

                    List<QuestionModel> creatingQuest = _questionModelManager.GetQuestionByTestId(testId);
                    LB_CreatedQuestion.ItemsSource = creatingQuest;
                    Tb_ContentQuestuon.Clear();
                    RB_RightAnswer1.IsChecked = false;
                    RB_RightAnswer2.IsChecked = false;
                    RB_RightAnswer3.IsChecked = false;
                    RB_RightAnswer4.IsChecked = false;
                    Tb_ContentQuestuon.Clear();
                    TB_FirstAnswer.Clear();
                    TB_SecondAnswer.Clear();
                    TB_ThirdAnswer.Clear();
                    TB_FourthAnswer.Clear();
                    TB_RightAnswerForQuest.Clear();
                    _updatedQuestId = 0;
                }
                else MessageBox.Show("Для изменения вопроса нужно ввести содержание вопроса и все 4 ответа!");
            }
            catch (Exception)
            {

            }
        }


        private void Button_EditNameOfTest_Click(object sender, RoutedEventArgs e)
        {
            if (LB_CreatedTest.SelectedItem!=null)
            {
                TestModel selectedTest = (TestModel)LB_CreatedTest.SelectedItem;
                TB_NewTestorEditName.Text = selectedTest.Name;
                _updatedTestId = selectedTest.Id;
            }
            else MessageBox.Show("Для изменения теста, выберите или создайте его");
        }
        private void Button_EditNameOfTestForNew_Click(object sender, RoutedEventArgs e)
        {
            if (TB_NewTestorEditName.Text.Length > 0)
            {
                TestModel updatedtest = new TestModel { Id = _updatedTestId, Name = TB_NewTestorEditName.Text, TeacherId = _authorizedTeacher };
                _testModelManager.UpdateTestById(updatedtest);
                TB_NewTestorEditName.Clear();
                List<TestModel> test = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
                LB_CreatedTest.ItemsSource = test;
            }
            else MessageBox.Show("Введите новое название теста");
        }

        private void Button_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (TB_newGroup.Text.Length > 0)
            {
                string nameOfNewGroup = TB_newGroup.Text;
                _groupModelManager.AddGroup(new GroupModel { Name = nameOfNewGroup });
                TB_newGroup.Clear();
                LB_AllGroups.ItemsSource = _groupModelManager.GetAllGroups();
            }
        }

        private void LB_AllGroups_Loaded(object sender, RoutedEventArgs e)
        {
            List<GroupModel> groups = _groupModelManager.GetAllGroups();
            LB_AllGroups.ItemsSource = groups;
        }

        private void Button_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (LB_AllGroups.SelectedItem != null)
            {
            GroupModel selectedGroup  = (GroupModel) LB_AllGroups.SelectedItem;
            TB_newGroup.Text = selectedGroup.Name;
            _updatedGroupId = selectedGroup.Id;
            }
        }

        private void Button_UpdateGroupName_Click(object sender, RoutedEventArgs e)
        {
            if (TB_newGroup.Text.Length > 0)
            {
                GroupModel newGroupName = new GroupModel { Id = _updatedGroupId,Name=TB_newGroup.Text};
                _groupModelManager.UpdateGroupById(newGroupName);
                TB_newGroup.Clear();
                LB_AllGroups.ItemsSource = _groupModelManager.GetAllGroups();
            }
        }

        private void Button_DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
               if(LB_AllGroups.SelectedItem != null)
                {
                  GroupModel selectedGroup = (GroupModel)LB_AllGroups.SelectedItem;
                  _groupModelManager.DeleteGroupById(selectedGroup.Id);
                  LB_AllGroups.ItemsSource = _groupModelManager.GetAllGroups();
                }
            }
            catch(InvalidOperationException)
            {
                LB_AllGroups.ItemsSource = _groupModelManager.GetAllGroups();
            }

        }

        private void CB_Groups_Loaded(object sender, RoutedEventArgs e)
        {
            List<GroupModel> allGroups = _groupModelManager.GetAllGroups();
            CB_Groups.ItemsSource = allGroups;
        }

        private void CB_Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupModel selectedGroup = (GroupModel)CB_Groups.SelectedItem;
            int groupId = selectedGroup.Id;
            List<StudentModel> studentInGroup =  _studentModelManager.GetStudentByGroupId(groupId);
            LB_StudentsInGroup.ItemsSource = studentInGroup;
        }

        private void LB_StudentsInGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_StudentsInGroup.SelectedItem != null)
            {
            StudentModel selectedStudent = (StudentModel)LB_StudentsInGroup.SelectedItem;
            TB_LastName_Student.Text = selectedStudent.Surname;
            TB_FirstName_Student.Text = selectedStudent.Firstname;
            TB_SurName_Student.Text = selectedStudent.Lastname;
            TB_Username_Student.Text = selectedStudent.Username;
            _updatedStudentId = selectedStudent.Id;
            CB_GroupsForStudent.ItemsSource = _groupModelManager.GetAllGroups();
            CB_GroupsForStudent.SelectedItem = _groupModelManager.GetGroupById(selectedStudent.GroupId);
            }
        }

        private void Button_EditStudent_Click(object sender, RoutedEventArgs e)
        {
            int newSelectedGroupId = ((GroupModel)CB_GroupsForStudent.SelectedItem).Id;
            StudentModel updatedStudent = new StudentModel { Id = _updatedStudentId, Firstname = TB_FirstName_Student.Text, Lastname = TB_SurName_Student.Text, Surname = TB_LastName_Student.Text, GroupId = newSelectedGroupId};
            _studentModelManager.UpdateStudentById(updatedStudent);
            _updatedStudentId = 0;
            TB_LastName_Student.Clear();
            TB_FirstName_Student.Clear();
            TB_SurName_Student.Clear();
            TB_Username_Student.Clear();
            CB_GroupsForStudent.SelectedIndex = -1;
            CB_Groups.SelectedItem = _groupModelManager.GetGroupById(newSelectedGroupId);
            List<StudentModel> studentInGroup = _studentModelManager.GetStudentByGroupId(newSelectedGroupId);
            LB_StudentsInGroup.ItemsSource = studentInGroup;
        }

        private void CB_groupForTesting_Loaded(object sender, RoutedEventArgs e)
        {
            List<GroupModel> allGroupsForTesting = _groupModelManager.GetAllGroups();
            CB_groupForTesting.ItemsSource = allGroupsForTesting;
        }

        private void CB_allTeacherTests_Loaded(object sender, RoutedEventArgs e)
        {
            List<TestModel> allTeacherTests = _testModelManager.GetTestByTeacherId(_authorizedTeacher);
            CB_allTeacherTests.ItemsSource = allTeacherTests;
        }

        private void DP_selectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem CBitem = CB_timeSelect.SelectedItem as ComboBoxItem;
            if (CBitem.Content != null)
            {
                string time = CBitem.Content.ToString();
                string date = DP_selectDate.Text;
                DateTime datetime = DateTime.Parse(date + " " + time);
                TB_dateTimeForTesting.Text = datetime.ToString();
            }
        }
        private void DP_selectDate_stop_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem CBitem = CB_timeSelect_stop.SelectedItem as ComboBoxItem;
            if (CBitem.Content != null)
            {
                string time = CBitem.Content.ToString();
                string date = DP_selectDate_stop.Text;
                DateTime datetime = DateTime.Parse(date + " " + time);
                TB_dateTimeForTesting_stop.Text = datetime.ToString();
            }
        }

        private void StartTesting_Click(object sender, RoutedEventArgs e)
        {
            if (TB_dateTimeForTesting.Text.Length > 0 && CB_groupForTesting.SelectedItem!=null && CB_allTeacherTests.SelectedItem!=null && TB_dateTimeForTesting_stop.Text.Length>0)
            {
                GroupModel selectedGroupForTesting = (GroupModel)CB_groupForTesting.SelectedItem;
                TestModel selectedTestForTesting = (TestModel)CB_allTeacherTests.SelectedItem;
                DateTime datetimeOfStart = DateTime.Parse(TB_dateTimeForTesting.Text);
                DateTime datetimeOfStop = DateTime.Parse(TB_dateTimeForTesting_stop.Text);

                _testingModelManager.AddTesting(new TestingModel { Date = datetimeOfStart, TestId= selectedTestForTesting.Id, GroupId=selectedGroupForTesting.Id });

                _telegramBotService.StartTestForGroup(selectedGroupForTesting.Id, datetimeOfStart, datetimeOfStop);

                CB_groupForTesting.SelectedIndex = -1;
                CB_allTeacherTests.SelectedIndex = -1;
                DP_selectDate.Text = null;
                DP_selectDate_stop.Text = null;
                CB_timeSelect.SelectedIndex = -1;
                TB_dateTimeForTesting.Clear();
                TB_dateTimeForTesting_stop.Clear();
                CB_timeSelect_stop.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Для запуска теста выберите тест, группу и дату начала/конца теста");
            }
        }

        private void DG_StudentResult_Loaded(object sender, RoutedEventArgs e)
        {
            if (LB_StudentsInGroup.SelectedItem != null)
            {
            List<TestingStudentModel> studentResults = _testingStudentModelManager.GetTestingStudentByStudentId(_updatedStudentId);
            DG_StudentResult.ItemsSource = studentResults;
            }
        }

        private void DG_StartingTeacherTestings_Loaded(object sender, RoutedEventArgs e)
        {
            //if(DG_StartingTeacherTestings.SelectedItem != null)
            //{
            List<TestingModel> teacherTestings = _testingModelManager.GetLastAddedTestingByTeacherId(_authorizedTeacher);
            DG_StartingTeacherTestings.ItemsSource = teacherTestings;
            //}
        }
    }
}

