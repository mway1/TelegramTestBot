using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TestingManager : ITestingManager
    {
        public void AddTesting(TestingDTO newTesting)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestingDTO>
                    (
                        StoredProcedures.Testing_Add,
                        param: new
                        {
                            Date = newTesting.Date,
                            Start = newTesting.Start,
                            End = newTesting.End,
                            GroupId = newTesting.Group!.Id,
                            TestId = newTesting.Test!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTestingById(int testingId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TestingDTO>
                    (
                        StoredProcedures.Testing_DeleteById,
                        param: new { id = testingId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTestingById(TestingDTO newTesting)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TestingDTO>
                    (
                        StoredProcedures.Testing_UpdateById,
                        param: new
                        {
                            newTesting.Id,
                            newTesting.Date,
                            newTesting.Start,
                            newTesting.End,
                            GroupId = newTesting.Group!.Id,
                            TestId = newTesting.Test!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TestingDTO> GetAllTestings()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TestingDTO>
                    (
                        StoredProcedures.Testing_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TestingDTO GetTestingById(int testingId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TestingDTO>
                    (
                        StoredProcedures.Testing_GetById,
                        param: new { id = testingId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
