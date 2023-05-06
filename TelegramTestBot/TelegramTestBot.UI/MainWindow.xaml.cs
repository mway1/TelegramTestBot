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

namespace TelegramTestBot.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _labels;
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private TelegramBotService _telegramBotService;
        private Data _data = new Data();

        public MainWindow()
        {
            _labels = new List<string>();
            _telegramBotService = new TelegramBotService(OnMessage);
            _telegramBotService.StartBot("12345");
            InitializeComponent();
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
                    string enteredPassword = _data.HashedValue(Password_login.Password);

                    try
                    {
                        TeacherModel aprovedTeacher = _teacherModelManager.GetTeacherByLogin(enteredLogin);

                        if (enteredLogin == aprovedTeacher.Login && enteredPassword == aprovedTeacher.Password)
                        {                            
                            int authorizedTeacher = aprovedTeacher.Id;

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
                                if (_data.CheckTeacherLoginForUnique(TB_Login_Teacher.Text) == true)
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
        }
    }

