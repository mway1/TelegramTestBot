namespace TelegramTestBot.BL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }
        public bool IsAttendance { get; set; }

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
                    studentDTO.FirstName != this.FirstName ||
                    studentDTO.LastName != this.LastName ||
                    studentDTO.SurName != this.SurName ||
                    studentDTO.Username != this.Username ||
                    studentDTO.IsAttendance != this.IsAttendance)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
