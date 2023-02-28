namespace TelegramTestBot.DAL.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentDTO Student { get; set; }

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
                groupDTO.Name != this.Name ||
                groupDTO.Student!.Id != this.Student!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
