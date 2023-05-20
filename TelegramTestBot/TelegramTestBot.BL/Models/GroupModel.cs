namespace TelegramTestBot.BL.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is GroupModel))
            {
                flag = false;
            }
            else
            {
                GroupModel groupDTO = (GroupModel)obj!;

                if (groupDTO.Id != this.Id ||
                    groupDTO.Name != this.Name)
                {
                    flag = false;
                }

            }

            return flag;
        }
    }
}
