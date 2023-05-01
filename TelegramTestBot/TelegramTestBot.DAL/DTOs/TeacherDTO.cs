namespace TelegramTestBot.DAL.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public TeacherDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TeacherDTO))
            {
                flag = false;
            }

            TeacherDTO teacherDTO = (TeacherDTO)obj!;

            if (teacherDTO.Id != this.Id ||
                teacherDTO.Firstname != this.Firstname ||
                teacherDTO.Lastname != this.Lastname ||
                teacherDTO.Surname != this.Surname ||
                teacherDTO.Email != this.Email ||
                teacherDTO.Login != this.Login ||
                teacherDTO.Password != this.Password)
            {
                flag = false;
            }

            return flag;
        }
    }
}
