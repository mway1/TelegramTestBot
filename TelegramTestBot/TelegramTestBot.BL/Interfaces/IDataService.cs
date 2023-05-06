using TelegramTestBot.BL.Service;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IDataService
    {
        void AddHashedToken(string token);
        string GetHashedToken(int id);
        string HashedValue(string value);
        bool CheckTeacherLoginForUnique(string enterredLogin);
    }
}
