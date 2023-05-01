using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IGroupModelManager
    {
        void AddGroup(GroupModel newGroup);
        void DeleteGroupById(int groupId);
        void UpdateGroupById(GroupModel newGroup);
        List<GroupModel> GetAllGroups();
        GroupModel GetGroupById(int groupId);
    }
}
