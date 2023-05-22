using Dapper;
using System.Data.SqlClient;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.DAL.Managers
{
    public class GroupManager : IGroupManager
    {
        public void AddGroup(GroupDTO newGroup)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<GroupDTO>
                    (
                        StoredProcedures.Group_Add,
                        param: new
                        {
                            Name = newGroup.Name
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteGroupById(int groupId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<GroupDTO>
                    (
                        StoredProcedures.Group_DeleteById,
                        param: new { id = groupId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateGroupById(GroupDTO newGroup)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<GroupDTO>
                    (
                        StoredProcedures.Group_UpdateById,
                        param: new
                        {
                            newGroup.Id,
                            newGroup.Name
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<GroupDTO> GetAllGroups()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<GroupDTO>
                    (
                        StoredProcedures.Group_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public GroupDTO GetGroupById(int groupId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<GroupDTO>
                    (
                        StoredProcedures.Group_GetById,
                        param: new { id = groupId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        
        public List<GroupDTO> GetGroupByEnteredText(string text)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<GroupDTO>
                    (
                        StoredProcedures.Group_GetByEnteredText,
                        param: new { text = text },
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
