using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITeacherTestManager
    {
        void AddTeacherTest(TeacherTestDTO newTeacherTest);
        void DeleteTeacherTestById(int teacherTestId);
        void UpdateTeacherTestById(TeacherTestDTO newTeacherTest);
        List<TeacherTestDTO> GetAllTeacherTests();
        TeacherTestDTO GetTeacherTestById(int teacherTestId);
    }
}
