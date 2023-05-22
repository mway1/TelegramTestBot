using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class GroupModelManager : IGroupModelManager
    {
        private IGroupManager _groupManager;

        public GroupModelManager()
        {
            _groupManager = new GroupManager();
        }

        public GroupModelManager(IGroupManager groupManager)
        {
            _groupManager = groupManager;
        }

        public void AddGroup(GroupModel groupModel)
        {
            GroupDTO group = MapperConfigStorage.GetInstance().Map<GroupDTO>(groupModel);
            _groupManager.AddGroup(group);
        }

        public void DeleteGroupById(int groupId)
        {
            _groupManager.DeleteGroupById(groupId);
        }

        public void UpdateGroupById(GroupModel groupModel)
        {
            GroupDTO group = MapperConfigStorage.GetInstance().Map<GroupDTO>(groupModel);
            _groupManager.UpdateGroupById(group);
        }

        public List<GroupModel> GetAllGroups()
        {
            List<GroupDTO> groups = _groupManager.GetAllGroups();
            return MapperConfigStorage.GetInstance().Map<List<GroupModel>>(groups);
        }

        public GroupModel GetGroupById(int groupId)
        {
            GroupDTO group = _groupManager.GetGroupById(groupId);
            return MapperConfigStorage.GetInstance().Map<GroupModel>(group);
        }
        
        public List<GroupModel> GetGroupByEnteredText(string text)
        {
            List<GroupDTO> group = _groupManager.GetGroupByEnteredText(text);
            return MapperConfigStorage.GetInstance().Map<List<GroupModel>>(group);
        }
    }
}
