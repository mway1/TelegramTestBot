namespace TelegramTestBot.BL.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
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
                    teacherDTO.FirstName != this.FirstName ||
                    teacherDTO.LastName != this.LastName ||
                    teacherDTO.SurName != this.SurName ||
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
