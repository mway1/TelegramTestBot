﻿using System.Text;
using System.Security.Cryptography;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.BL.Service
{
    public class DataService : IDataService
    {
        public readonly string token = "6237629540:AAErGQgxalLVu5W9RKenTd9UYGpx4tnqVNE";
        private TelegramBotModelManager _telegramBotModelManager = new TelegramBotModelManager();
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private TelegramBotService _telegramBotService;


        public DataService()
        {
            
        }

       

        public bool CheckStudentChatIdForUnique(long studentChatId)
        {
            bool IsUnique;

            try
            {
                StudentModel checkedStudent = _studentModelManager.GetStudentByChatId(studentChatId);
                IsUnique = false;
            }
            catch (Exception)
            {
                IsUnique = true;
            }

            return IsUnique;
        }

        public bool CheckTeacherLoginForUnique(string enterredLogin)
        {
            bool IsUnique;

            try
            {
                TeacherModel approvedTeacher = _teacherModelManager.GetTeacherByLogin(enterredLogin);
                IsUnique = false;
            }
            catch(Exception)
            {
                IsUnique = true;
            }

            return IsUnique;
        }

        public string HashedValue(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}