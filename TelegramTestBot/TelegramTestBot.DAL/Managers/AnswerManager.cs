using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class AnswerManager : IAnswerManager
    {
        public void AddAnswer(AnswerDTO newAnswer)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AnswerDTO>
                    (
                        StoredProcedures.Answer_Add,
                        param: new
                        {
                            Content = newAnswer.Content,
                            IsCorrect = newAnswer.IsCorrect,
                            QuestionId = newAnswer.QuestionId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteAnswerById(int answerId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AnswerDTO>
                    (
                        StoredProcedures.Answer_DeleteById,
                        param: new { id = answerId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateAnswerById(AnswerDTO newAnswer)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AnswerDTO>
                    (
                        StoredProcedures.Answer_UpdateById,
                        param: new
                        {
                            newAnswer.Id,
                            newAnswer.Content,
                            newAnswer.IsCorrect,
                            newAnswer.QuestionId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<AnswerDTO> GetAllAnswers()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<AnswerDTO>
                    (
                        StoredProcedures.Answer_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public AnswerDTO GetAnswerById(int answerId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<AnswerDTO>
                    (
                        StoredProcedures.Answer_GetById,
                        param: new { id = answerId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public List<AnswerDTO> GetAnswerByQuestionId(int questionId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<AnswerDTO>
                    (
                        StoredProcedures.Answer_GetByQuestionId,
                        param: new { QuestionId = questionId },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
