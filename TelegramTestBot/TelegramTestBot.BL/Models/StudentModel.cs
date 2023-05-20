namespace TelegramTestBot.BL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public long UserChatId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int GroupId { get; set; }

        public StudentModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is StudentModel))
            {
                flag = false;
            }
            else
            {
                StudentModel studentDTO = (StudentModel)obj!;

                if (studentDTO.Id != this.Id ||
                    studentDTO.Firstname != this.Firstname ||
                    studentDTO.Lastname != this.Lastname ||
                    studentDTO.Surname != this.Surname ||
                    studentDTO.Username != this.Username ||
                    studentDTO.GroupId != this.GroupId)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
