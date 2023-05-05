using TelegramTestBot.BL.Service;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IData
    {
        void AddHashedToken(string token);
        string GetHashedToken(int id);
        string HashedValue(string value);
    }
}
