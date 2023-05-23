using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Service;

namespace TelegramTestBot.BL.Service
{
    public class RegAuthService
    {
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private DataService _dataService = new DataService();

        public RegAuthService()
        {

        }

        public string RegTeacher(string enteredLastName,string enteredFirstName,string enterdSurName,string eneterdEmail,string eneterdLogin,string eneterdPass,string copyPass)
        {
            if (enteredLastName.Length > 0)
            {
                if (enteredFirstName.Length > 0)
                {
                    if (enterdSurName.Length > 0)
                    {
                        if (eneterdEmail.Length > 0)
                        {
                            if (eneterdLogin.Length > 0)
                            {
                                if (_dataService.CheckTeacherLoginForUnique(eneterdLogin) == true)
                                {
                                    if (eneterdPass.Length > 0)
                                    {
                                        if (copyPass.Length > 0)
                                        {
                                            if (eneterdPass.Length >= 6)
                                            {
                                                bool en = true;
                                                bool number = false;

                                                for (int i = 0; i < eneterdPass.Length; i++)
                                                {
                                                    if (eneterdPass[i] >= 'А' && eneterdPass[i] <= 'Я') en = false;
                                                    if (eneterdPass[i] >= '0' && eneterdPass[i] <= '9') number = true;
                                                }

                                                if (!en)
                                                {
                                                    return "Доступна только английская раскладка";
                                                }
                                                else if (!number)
                                                {
                                                    return "Добавьте хотя бы одну цифру";
                                                }
                                                if (en && number)
                                                {
                                                    if (eneterdPass == copyPass)
                                                    {
                                                        string hashPassword = _dataService.HashedValue(eneterdPass);
                                                        TeacherModel teacher = new TeacherModel()
                                                        {
                                                            Lastname = enteredLastName,
                                                            Firstname = enteredFirstName,
                                                            Surname = enterdSurName,
                                                            Email = eneterdEmail,
                                                            Login = eneterdLogin,
                                                            Password = hashPassword
                                                        };
                                                        _teacherModelManager.AddTeacher(teacher);
                                                    }
                                                    else return "Пароли не совпадают";
                                                }
                                            }
                                            else return "пароль слишком короткий, минимум 6 символов";
                                        }
                                        else return "Повторите пароль";
                                    }
                                    else return "Укажите пароль";
                                }
                                else return "Логин уже занят, попробуйте другой";
                            }
                            else return "Укажите Login";
                        }
                        else return "Укажите Email";
                    }
                    else return "Укажите Отчество";
                }
                else return "Укажите Имя";
            }
            else return "Укажите Фамилию";

            return "Регистрация пройдена успешно";
        }
    }
}
