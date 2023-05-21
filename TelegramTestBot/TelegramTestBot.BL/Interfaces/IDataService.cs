using TelegramTestBot.BL.Service;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IDataService
    {
        string HashedValue(string value);
        bool CheckStudentChatIdForUnique(long id);
        bool CheckTeacherLoginForUnique(string enterredLogin);
        bool CheckNameOfGroupForUnique(string name);
    }
}
