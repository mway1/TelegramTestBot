using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITelegramBotModelManager
    {
        void AddTelegramBot(TelegramBotModel newTelegramBot);
        void DeleteTelegramBotById(int telegramBotId);
        TelegramBotModel GetTelegramBotById(int telegramBotId);
    }
}
