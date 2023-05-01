namespace TelegramTestBot.DAL.DTOs
{
    public class Teacher_TestDTO
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int TeacherId { get; set; }
        public TestDTO Test { get; set; }
        public TeacherDTO Teacher { get; set; }

        public Teacher_TestDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is Teacher_TestDTO))
            {
                flag = false;
            }

            Teacher_TestDTO testDTO = (Teacher_TestDTO)obj!;

            if (testDTO.Id != this.Id ||
                testDTO.Test!.Id != this.Test!.Id ||
                testDTO.Teacher!.Id != this.Teacher!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
