using System.Text;
using System.Security.Cryptography;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Service
{
    public class Data
    {
        protected readonly string token = "6237629540:AAErGQgxalLVu5W9RKenTd9UYGpx4tnqVNE";
        private TelegramBotModelManager _telegramBotModelManager = new TelegramBotModelManager();

        public Data()
        {
            string hashToken = HashedToken(token);

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

        private string HashedToken(string token)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
