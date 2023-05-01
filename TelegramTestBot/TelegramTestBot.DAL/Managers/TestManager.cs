using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TestManager : ITestManager
    {
        public void AddTest(TestDTO newTest)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestDTO>
                    (
                        StoredProcedures.Test_Add,
                        param: new
                        {
                            Name = newTest.Name,
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTestById(int testId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestDTO>
                    (
                        StoredProcedures.Test_DeleteById,
                        param: new { id = testId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTestById(TestDTO newTest)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TestDTO>
                    (
                        StoredProcedures.Test_UpdateById,
                        param: new
                        {
                            newTest.Id,
                            newTest.Name,
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TestDTO> GetAllTests()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TestDTO>
                    (
                        StoredProcedures.Test_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TestDTO GetTestById(int testId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TestDTO>
                    (
                        StoredProcedures.Test_GetById,
                        param: new { id = testId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
