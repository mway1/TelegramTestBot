using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TeacherManager : ITeacherManager
    {
        public void AddTeacher(TeacherDTO newTeacher)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TeacherDTO>
                    (
                        StoredProcedures.Teacher_Add,
                        param: new
                        {
                            FirstName = newTeacher.Firstname,
                            LastName = newTeacher.Lastname,
                            SurName = newTeacher.Surname,
                            Email = newTeacher.Email,
                            Login = newTeacher.Login,
                            Password = newTeacher.Password
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTeacherById(int teacherId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TeacherDTO>
                    (
                        StoredProcedures.Teacher_DeleteById,
                        param: new { id = teacherId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTeacherById(TeacherDTO newTeacher)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TeacherDTO>
                    (
                        StoredProcedures.Teacher_UpdateById,
                        param: new
                        {
                            newTeacher.Id,
                            newTeacher.Firstname,
                            newTeacher.Lastname,
                            newTeacher.Surname,
                            newTeacher.Email,
                            newTeacher.Login,
                            newTeacher.Password
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TeacherDTO>
                    (
                        StoredProcedures.Teacher_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TeacherDTO GetTeacherById(int teacherId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TeacherDTO>
                    (
                        StoredProcedures.Teacher_GetById,
                        param: new { id = teacherId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
