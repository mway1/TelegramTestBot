namespace TelegramTestBot.DAL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }
        public bool Attendance { get; set; }

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
                studentDTO.FirstName != this.FirstName ||
                studentDTO.LastName != this.LastName ||
                studentDTO.SurName != this.SurName ||
                studentDTO.Username != this.Username ||
                studentDTO.Attendance != this.Attendance)
            {
                flag = false;
            }

            return flag;
        }
    }
}
