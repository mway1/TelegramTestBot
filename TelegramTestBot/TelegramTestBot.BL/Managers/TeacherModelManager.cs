using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TeacherModelManager
    {
        private ITeacherManager _teacherManager;

        public TeacherModelManager()
        {
            _teacherManager = new TeacherManager();
        }

        public TeacherModelManager(ITeacherManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        public void AddTeacher(TeacherModel teacherModel)
        {
            TeacherDTO teacher = MapperConfigStorage.GetInstance().Map<TeacherDTO>(teacherModel);
            _teacherManager.AddTeacher(teacher);
        }

        public void DeleteTeacherById(int teacherId)
        {
            _teacherManager.DeleteTeacherById(teacherId);
        }

        public void UpdateTeacherById(TeacherModel teacherModel)
        {
            TeacherDTO teacher = MapperConfigStorage.GetInstance().Map<TeacherDTO>(teacherModel);
            _teacherManager.UpdateTeacherById(teacher);
        }

        public List<TeacherModel> GetAllTeachers()
        {
            List<TeacherDTO> teachers = _teacherManager.GetAllTeachers();
            return MapperConfigStorage.GetInstance().Map<List<TeacherModel>>(teachers);
        }

        public TeacherModel GetTeacherById(int teacherId)
        {
            TeacherDTO teacher = _teacherManager.GetTeacherById(teacherId);
            return MapperConfigStorage.GetInstance().Map<TeacherModel>(teacher);
        }
    }
}
