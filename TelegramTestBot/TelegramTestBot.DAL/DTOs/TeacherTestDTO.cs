namespace TelegramTestBot.DAL.DTOs
{
    public class TeacherTestDTO
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int TeacherId { get; set; }
        public TestDTO Test { get; set; }
        public TeacherDTO Teacher { get; set; }

        public TeacherTestDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TeacherTestDTO))
            {
                flag = false;
            }

            TeacherTestDTO testDTO = (TeacherTestDTO)obj!;

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
