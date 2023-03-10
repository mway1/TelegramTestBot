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
                            FirstName = newStudent.FirstName,
                            LastName = newStudent.LastName,
                            SurName = newStudent.SurName,
                            Username = newStudent.Username,
                            Attendance = newStudent.Attendance
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
                            newStudent.FirstName,
                            newStudent.LastName,
                            newStudent.SurName,
                            newStudent.Username,
                            newStudent.Attendance
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
    }
}
