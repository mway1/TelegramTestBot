using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IStudentManager
    {
        void AddStudent(StudentDTO newStudent);
        void DeleteStudentById(int studentId);
        void UpdateStudentById(StudentDTO newStudent);
        List<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int studentId);
        List<StudentDTO> GetStudentByGroupId(int groupId);
        StudentDTO GetStudentByChatId(long studentChatId);
    }
}
