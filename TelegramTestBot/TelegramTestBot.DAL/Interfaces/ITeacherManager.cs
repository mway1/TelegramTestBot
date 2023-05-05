using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITeacherManager
    {
        void AddTeacher(TeacherDTO newTeacher);
        void DeleteTeacherById(int teacherId);
        void UpdateTeacherById(TeacherDTO newTeacher);
        List<TeacherDTO> GetAllTeachers();
        TeacherDTO GetTeacherById(int teacherId);
        TeacherDTO GetTeacherByLogin(string login);
    }
}
