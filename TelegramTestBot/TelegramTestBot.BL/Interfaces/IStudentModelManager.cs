using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IStudentModelManager
    {
        void AddStudent(StudentModel newStudent);
        void DeleteStudentById(int studentId);
        void UpdateStudentById(StudentModel newStudent);
        List<StudentModel> GetAllStudents();
        List<StudentModel> GetStudentsByGroupId(int groupId);
        StudentModel GetStudentById(int studentId);
        List<StudentModel> GetStudentByGroupId(int groupId);
        StudentModel GetStudentByChatId(long studentChatId);
    }
}
