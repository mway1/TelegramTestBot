using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class AnswerVariantManager : IAnswerVariantManager
    {
        public void AddAnswerVariant(AnswerVariantDTO newAnswerVariant)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AnswerVariantDTO>
                    (
                        StoredProcedures.AnswerVariant_Add,
                        param: new
                        {
                            Content = newAnswerVariant.Content,
                            IsCorrectAnswer = newAnswerVariant.IsCorrectAnswer,
                            QuestionId = newAnswerVariant.Question!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteAnswerVariantById(int answerVariantId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AnswerVariantDTO>
                    (
                        StoredProcedures.AnswerVariant_DeleteById,
                        param: new { id = answerVariantId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateAnswerVariantById(AnswerVariantDTO newAnswerVariant)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AnswerVariantDTO>
                    (
                        StoredProcedures.AnswerVariant_UpdateById,
                        param: new
                        {
                            newAnswerVariant.Id,
                            newAnswerVariant.Content,
                            newAnswerVariant.IsCorrectAnswer,
                            QuestionId = newAnswerVariant.Question!.Id
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<AnswerVariantDTO> GetAllAnswerVariants()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<AnswerVariantDTO>
                    (
                        StoredProcedures.AnswerVariant_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public AnswerVariantDTO GetAnswerVariantById(int answerVariantId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<AnswerVariantDTO>
                    (
                        StoredProcedures.AnswerVariant_GetById,
                        param: new { id = answerVariantId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
