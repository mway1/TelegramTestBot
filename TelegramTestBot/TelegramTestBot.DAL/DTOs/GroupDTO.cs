namespace TelegramTestBot.DAL.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is GroupDTO))
            {
                flag = false;
            }

            GroupDTO groupDTO = (GroupDTO)obj!;

            if (groupDTO.Id != this.Id ||
                groupDTO.Name != this.Name)
            {
                flag = false;
            }

            return flag;
        }
    }
}
