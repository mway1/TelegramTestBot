using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class StudentManager : IStudentManager
    {
        public void AddStudent(StudentDTO newStudent)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<StudentDTO>
                    (
                        StoredProcedures.Student_Add,
                        param: new
                        {
                            UserChatId = newStudent.UserChatId,
                            FirstName = newStudent.Firstname,
                            LastName = newStudent.Lastname,
                            SurName = newStudent.Surname,
                            Username = newStudent.Username,
                            GroupId = newStudent.GroupId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteStudentById(int studentId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<StudentDTO>
                    (
                        StoredProcedures.Student_DeleteById,
                        param: new { id = studentId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateStudentById(StudentDTO newStudent)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<StudentDTO>
                    (
                        StoredProcedures.Student_UpdateById,
                        param: new
                        {
                            newStudent.Id,
                            newStudent.Firstname,
                            newStudent.Lastname,
                            newStudent.Surname,
                            newStudent.GroupId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<StudentDTO> GetAllStudents()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<StudentDTO>
                    (
                        StoredProcedures.Student_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public List<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<StudentDTO>
                    (
                        StoredProcedures.Student_GetStudentsByGroupId,
                        param: new { GroupId = groupId },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public StudentDTO GetStudentById(int studentId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<StudentDTO>
                    (
                        StoredProcedures.Student_GetById,
                        param: new { id = studentId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public List<StudentDTO> GetStudentByGroupId(int groupId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<StudentDTO>
                    (
                        StoredProcedures.Student_GetByGroupId,
                        param: new { GroupId = groupId },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public StudentDTO GetStudentByChatId(long studentChatId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<StudentDTO>
                    (
                        StoredProcedures.Student_GetByChatId,
                        param: new { UserChatId = studentChatId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
