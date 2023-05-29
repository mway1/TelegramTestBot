using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITestingStudentModelManager
    {
        void AddTestingStudent(TestingStudentModel newTestingStudent);
        void DeleteTestingStudentById(int testingStudentId);
        void UpdateTestingStudentById(TestingStudentModel newTestingStudent);
        List<TestingStudentModel> GetAllTestingStudents();
        TestingStudentModel GetTestingStudentById(int testingStudentId);
        List<TestingStudentModel> GetTestingStudentByStudentId(int studentId);
    }
}
