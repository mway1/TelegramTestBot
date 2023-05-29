using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TestingStudentModelManager : ITestingStudentModelManager
    {
        private ITestingStudentManager _testingStudentManager;

        public TestingStudentModelManager()
        {
            _testingStudentManager = new TestingStudentManager();
        }

        public TestingStudentModelManager(ITestingStudentManager testingStudentManager)
        {
            _testingStudentManager = testingStudentManager;
        }

        public void AddTestingStudent(TestingStudentModel testingStudentModel)
        {
            TestingStudentDTO testingStudent = MapperConfigStorage.GetInstance().Map<TestingStudentDTO>(testingStudentModel);
            _testingStudentManager.AddTestingStudent(testingStudent);
        }

        public void DeleteTestingStudentById(int testingStudentId)
        {
            _testingStudentManager.DeleteTestingStudentById(testingStudentId);
        }

        public void UpdateTestingStudentById(TestingStudentModel testingStudentModel)
        {
            TestingStudentDTO testingStudent = MapperConfigStorage.GetInstance().Map<TestingStudentDTO>(testingStudentModel);
            _testingStudentManager.UpdateTestingStudentById(testingStudent);
        }

        public List<TestingStudentModel> GetAllTestingStudents()
        {
            List<TestingStudentDTO> testingStudents = _testingStudentManager.GetAllTestingStudents();
            return MapperConfigStorage.GetInstance().Map<List<TestingStudentModel>>(testingStudents);
        }

        public TestingStudentModel GetTestingStudentById(int testingStudentId)
        {
            TestingStudentDTO testingStudent = _testingStudentManager.GetTestingStudentById(testingStudentId);
            return MapperConfigStorage.GetInstance().Map<TestingStudentModel>(testingStudent);
        }
        public List<TestingStudentModel> GetTestingStudentByStudentId(int studentId)
        {
            List<TestingStudentDTO> testingStudent = _testingStudentManager.GetTestingStudentByStudentId(studentId);
            return MapperConfigStorage.GetInstance().Map<List<TestingStudentModel>>(testingStudent);
        }
    }
}
