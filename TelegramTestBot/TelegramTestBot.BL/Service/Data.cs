using System.Text;
using System.Security.Cryptography;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.BL.Service
{
    public class Data : IData
    {
        public readonly string token = "6237629540:AAErGQgxalLVu5W9RKenTd9UYGpx4tnqVNE";
        private TelegramBotModelManager _telegramBotModelManager = new TelegramBotModelManager();

        public Data()
        {
            
        }

        public void AddHashedToken(string token)
        {
            string hashToken = HashedValue(token);

            TelegramBotModel telegramBot = new TelegramBotModel()
            {
                HashToken = hashToken
            };

            _telegramBotModelManager.AddTelegramBot(telegramBot);
        }

        public string GetHashedToken(int id)
        {
            string hashedToken = _telegramBotModelManager.GetTelegramBotById(id).HashToken;

            return hashedToken;
        }

        public string HashedValue(string value)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
