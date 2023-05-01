using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class StudentModelManager : IStudentModelManager
    {
        private IStudentManager _studentManager;

        public StudentModelManager()
        {
            _studentManager = new StudentManager();
        }

        public StudentModelManager(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        public void AddStudent(StudentModel studentModel)
        {
            StudentDTO student = MapperConfigStorage.GetInstance().Map<StudentDTO>(studentModel);
            _studentManager.AddStudent(student);
        }

        public void DeleteStudentById(int studentId)
        {
            _studentManager.DeleteStudentById(studentId);
        }

        public void UpdateStudentById(StudentModel studentModel)
        {
            StudentDTO student = MapperConfigStorage.GetInstance().Map<StudentDTO>(studentModel);
            _studentManager.UpdateStudentById(student);
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentDTO> students = _studentManager.GetAllStudents();
            return MapperConfigStorage.GetInstance().Map<List<StudentModel>>(students);
        }

        public StudentModel GetStudentById(int studentId)
        {
            StudentDTO student = _studentManager.GetStudentById(studentId);
            return MapperConfigStorage.GetInstance().Map<StudentModel>(student);
        }
    }
}
