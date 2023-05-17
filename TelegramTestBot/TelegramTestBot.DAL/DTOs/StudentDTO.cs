namespace TelegramTestBot.DAL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public long UserChatId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public StudentDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is StudentDTO))
            {
                flag = false;
            }

            StudentDTO studentDTO = (StudentDTO)obj!;

            if (studentDTO.Id != this.Id ||
                studentDTO.UserChatId != this.UserChatId ||
                studentDTO.Firstname != this.Firstname ||
                studentDTO.Lastname != this.Lastname ||
                studentDTO.Surname != this.Surname ||
                studentDTO.Username != this.Username)
            {
                flag = false;
            }

            return flag;
        }
    }
}
