using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TestingStudentManager : ITestingStudentManager
    {
        public void AddTestingStudent(TestingStudentDTO newTestingStudent)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_Add,
                        param: new
                        {
                            CountAnswers = newTestingStudent.CountAnswers,
                            IsAttendance = newTestingStudent.IsAttendance,
                            StudentId = newTestingStudent.StudentId,
                            TestingId = newTestingStudent.TestingId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTestingStudentById(int testingStudentId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_DeleteById,
                        param: new { id = testingStudentId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTestingStudentById(TestingStudentDTO newTestingStudent)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_UpdateById,
                        param: new
                        {
                            newTestingStudent.Id,
                            newTestingStudent.CountAnswers,
                            newTestingStudent.IsAttendance,
                            StudentId = newTestingStudent.StudentId,
                            TestingId = newTestingStudent.TestingId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TestingStudentDTO> GetAllTestingStudents()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TestingStudentDTO GetTestingStudentById(int testingStudentId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_GetById,
                        param: new { id = testingStudentId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        
        public int GetTestingStudentByStudentIdByTestingId(int studentId, int testingId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<int>
                    (
                        StoredProcedures.Testing_Student_GetByStudentIdByTestingId,
                        param: new { 
                            StudentId = studentId, 
                            TestingId = testingId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TestingStudentDTO> GetTestingStudentByStudentId(int studentId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TestingStudentDTO>
                    (
                        StoredProcedures.Testing_Student_GetByStudentId,
                        param: new { StudentId = studentId },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
