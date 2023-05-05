using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITelegramBotManager
    {
        void AddTelegramBot(TelegramBotDTO newTelegramBot);
        void DeleteTelegramBotById(int telegramBotId);
        TelegramBotDTO GetTelegramBotById(int telegramBotId);
    }
}
