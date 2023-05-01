namespace TelegramTestBot.BL.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public TeacherModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TeacherModel))
            {
                flag = false;
            }
            else
            {
                TeacherModel teacherDTO = (TeacherModel)obj!;

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
            }

            return flag;
        }
    }
}
