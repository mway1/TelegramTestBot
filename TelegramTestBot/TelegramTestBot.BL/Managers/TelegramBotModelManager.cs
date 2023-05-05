using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TelegramBotModelManager : ITelegramBotModelManager
    {
        private ITelegramBotManager _telegramBotManager;

        public TelegramBotModelManager()
        {
            _telegramBotManager = new TelegramBotManager();
        }

        public TelegramBotModelManager(ITelegramBotManager telegramBotManager)
        {
            _telegramBotManager = telegramBotManager;
        }

        public void AddTelegramBot(TelegramBotModel telegramBotModel)
        {
            TelegramBotDTO telegramBot = MapperConfigStorage.GetInstance().Map<TelegramBotDTO>(telegramBotModel);
            _telegramBotManager.AddTelegramBot(telegramBot);
        }

        public void DeleteTelegramBotById(int telegramBotId)
        {
            _telegramBotManager.DeleteTelegramBotById(telegramBotId);
        }

        public TelegramBotModel GetTelegramBotById(int telegramBotId)
        {
            TelegramBotDTO telegramBot = _telegramBotManager.GetTelegramBotById(telegramBotId);
            return MapperConfigStorage.GetInstance().Map<TelegramBotModel>(telegramBot);
        }
    }
}
