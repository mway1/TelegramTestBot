using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IGroupManager
    {
        void AddGroup(GroupDTO newGroup);
        void DeleteGroupById(int groupId);
        void UpdateGroupById(GroupDTO newGroup);
        List<GroupDTO> GetAllGroups();
        GroupDTO GetGroupById(int groupId);
    }
}
