using System.Text;
using System.Security.Cryptography;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.BL.Service
{
    public class DataService : IDataService
    {
        public static Dictionary<long, List<string>> UserAnswersForGroup { get; set; } = new Dictionary<long, List<string>>();
        public static Dictionary<long, List<string>> UserAnswers { get; set; } = new Dictionary<long, List<string>>();
        public List<long> UsersWithGeo { get; set; } = new List<long>();
        public readonly string token = "6237629540:AAErGQgxalLVu5W9RKenTd9UYGpx4tnqVNE";
        private TelegramBotModelManager _telegramBotModelManager = new TelegramBotModelManager();
        private TeacherModelManager _teacherModelManager = new TeacherModelManager();
        private StudentModelManager _studentModelManager = new StudentModelManager();
        private GroupModelManager _groupModelManager = new GroupModelManager();

        public DataService()
        {
            
        }

        public bool CheckStudentForPresenceInGroup(long id, int groupId)
        {
            List<long> userIds = new List<long>();
            List<StudentModel> checkedStudents = _studentModelManager.GetStudentsByGroupId(groupId);

            foreach (var students in checkedStudents)
            {
                userIds.Add(students.UserChatId);
            }

            if (userIds.Contains(id))
                return true;

            return false;
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

        public bool CheckNameOfGroupForUnique(string name)
        {
            bool IsUnique;

            List<GroupModel> checkedGroup = _groupModelManager.GetGroupByEnteredText(name);
            if (checkedGroup.Count > 0)
                IsUnique = false;
            
            else
                IsUnique = true;                      

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
