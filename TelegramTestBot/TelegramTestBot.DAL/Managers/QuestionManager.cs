using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class QuestionManager : IQuestionManager
    {
        public void AddQuestion(QuestionDTO newQuestion)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<QuestionDTO>
                    (
                        StoredProcedures.Question_Add,
                        param: new
                        {
                            Content = newQuestion.Content,
                            TestId = newQuestion.TestId,
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    ); ;
            }
        }

        public void DeleteQuestionById(int questionId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<QuestionDTO>
                    (
                        StoredProcedures.Question_DeleteById,
                        param: new { id = questionId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateQuestionById(QuestionDTO newQuestion)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<QuestionDTO>
                    (
                        StoredProcedures.Question_UpdateById,
                        param: new
                        {
                            newQuestion.Id,
                            newQuestion.Content,
                            newQuestion.TestId,
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<QuestionDTO> GetAllQuestions()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<QuestionDTO>
                    (
                        StoredProcedures.Question_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public QuestionDTO GetQuestionById(int questionId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<QuestionDTO>
                    (
                        StoredProcedures.Question_GetById,
                        param: new { id = questionId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
