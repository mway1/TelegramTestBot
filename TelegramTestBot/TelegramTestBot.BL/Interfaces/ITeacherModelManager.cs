using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITeacherModelManager
    {
        void AddTeacher(TeacherModel newTeacher);
        void DeleteTeacherById(int teacherId);
        void UpdateTeacherById(TeacherModel newTeacher);
        List<TeacherModel> GetAllTeachers();
        TeacherModel GetTeacherById(int teacherId);
    }
}
