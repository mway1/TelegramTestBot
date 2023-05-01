using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TeacherTestManager : ITeacherTestManager
    {
        public void AddTeacherTest(TeacherTestDTO newTeacherTest)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TeacherTestDTO>
                    (
                        StoredProcedures.Teacher_Test_Add,
                        param: new
                        {
                            TeacherId = newTeacherTest.Teacher!.Id,
                            TestId = newTeacherTest.Test!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTeacherTestById(int teacherTestId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TeacherTestDTO>
                    (
                        StoredProcedures.Teacher_Test_DeleteById,
                        param: new { id = teacherTestId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTeacherTestById(TeacherTestDTO newTeacherTest)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TeacherTestDTO>
                    (
                        StoredProcedures.Teacher_Test_UpdateById,
                        param: new
                        {
                            newTeacherTest.Id,
                            TeacherId = newTeacherTest.Teacher!.Id,
                            TestId = newTeacherTest.Test!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TeacherTestDTO> GetAllTeacherTests()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TeacherTestDTO>
                    (
                        StoredProcedures.Teacher_Test_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TeacherTestDTO GetTeacherTestById(int teacherTestId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TeacherTestDTO>
                    (
                        StoredProcedures.Teacher_Test_GetById,
                        param: new { id = teacherTestId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
