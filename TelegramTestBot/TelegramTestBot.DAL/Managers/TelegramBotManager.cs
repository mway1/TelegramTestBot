using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class TelegramBotManager : ITelegramBotManager
    {
        public void AddTelegramBot(TelegramBotDTO newTelegramBot)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TelegramBotDTO>
                    (
                        StoredProcedures.TelegramBot_Add,
                        param: new
                        {
                            Name = newTelegramBot.Name,
                            HashToken = newTelegramBot.HashToken
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteTelegramBotById(int telegramBotId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<TelegramBotDTO>
                    (
                        StoredProcedures.TelegramBot_DeleteById,
                        param: new { id = telegramBotId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public TelegramBotDTO GetTelegramBotById(int telegramBotId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<TelegramBotDTO>
                    (
                        StoredProcedures.TelegramBot_GetById,
                        param: new { id = telegramBotId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
