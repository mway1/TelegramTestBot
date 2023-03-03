using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TypeOfQuestionManager : ITypeOfQuestionManager
    {
        public void AddTypeOfQuestion(TypeOfQuestionDTO newTypeOfQuestion)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TypeOfQuestionDTO>
                    (
                        StoredProcedures.TypeOfQuestion_Add,
                        param: new
                        {
                            Name = newTypeOfQuestion.Name
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTypeOfQuestionById(int typeOfQuestionId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TypeOfQuestionDTO>
                    (
                        StoredProcedures.TypeOfQuestion_DeleteById,
                        param: new { id = typeOfQuestionId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateTypeOfQuestionById(TypeOfQuestionDTO newTypeOfQuestion)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<TypeOfQuestionDTO>
                    (
                        StoredProcedures.TypeOfQuestion_UpdateById,
                        param: new
                        {
                            newTypeOfQuestion.Id,
                            newTypeOfQuestion.Name
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<TypeOfQuestionDTO> GetAllTypeOfQuestions()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<TypeOfQuestionDTO>
                    (
                        StoredProcedures.TypeOfQuestion_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public TypeOfQuestionDTO GetTypeOfQuestionById(int typeOfQuestionId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TypeOfQuestionDTO>
                    (
                        StoredProcedures.TypeOfQuestion_GetById,
                        param: new { id = typeOfQuestionId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
