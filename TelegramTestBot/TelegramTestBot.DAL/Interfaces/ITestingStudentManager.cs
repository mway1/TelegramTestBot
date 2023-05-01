using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITestingStudentManager
    {
        void AddTestingStudent(TestingStudentDTO newTestingStudent);
        void DeleteTestingStudentById(int testingStudentId);
        void UpdateTestingStudentById(TestingStudentDTO newTestingStudent);
        List<TestingStudentDTO> GetAllTestingStudents();
        TestingStudentDTO GetTestingStudentById(int testingStudentId);
    }
}
