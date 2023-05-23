using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IStudentModelManager
    {
        void AddStudent(StudentModel newStudent);
        void DeleteStudentById(int studentId);
        void UpdateStudentById(StudentModel newStudent);
        List<StudentModel> GetAllStudents();
        StudentModel GetStudentById(int studentId);
        StudentModel GetStudentByGroupId(int groupId);
        StudentModel GetStudentByChatId(long studentChatId);
    }
}
