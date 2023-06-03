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
        private TestingModelManager _testingModelManager = new TestingModelManager();

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

        public bool CheckTestingGroupIdForUnique(int groupId)
        {
            try
            {
                int checkedTesting = _testingModelManager.GetLastAddedTestingByGroupId(groupId);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool CheckStudentChatIdForUnique(long studentChatId)
        {
            try
            {
                StudentModel checkedStudent = _studentModelManager.GetStudentByChatId(studentChatId);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
        
        public bool CheckStatusOfTesting(int testingId)
        {
            try
            {              
                return _testingModelManager.GetStatusOfTestById(testingId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckTeacherLoginForUnique(string enterredLogin)
        {
            try
            {
                TeacherModel approvedTeacher = _teacherModelManager.GetTeacherByLogin(enterredLogin);
                return false;
            }
            catch(Exception)
            {
                return true;
            }
        }

        public bool CheckNameOfGroupForUnique(string name)
        {
            List<GroupModel> checkedGroup = _groupModelManager.GetGroupByEnteredText(name);
            if (checkedGroup.Count > 0)
                return false;
            
            else
                return true;                      
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
