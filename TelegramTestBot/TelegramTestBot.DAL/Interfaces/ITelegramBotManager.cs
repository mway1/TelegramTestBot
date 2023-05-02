using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITelegramBotManager
    {
        void AddTelegramBot(TelegramBotDTO newTelegramBot);
        void DeleteByIdTelegramBot(int telegramBotId);
        TelegramBotDTO GetTelegramBotById(int telegramBotId);
    }
}
