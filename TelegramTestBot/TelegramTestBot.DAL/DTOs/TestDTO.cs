namespace TelegramTestBot.DAL.DTOs
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherDTO Teacher { get; set; }

        public TestDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestDTO))
            {
                flag = false;
            }

            TestDTO testDTO = (TestDTO)obj!;

            if (testDTO.Id != this.Id ||
                testDTO.Name != this.Name ||
                testDTO.Teacher!.Id != this.Teacher!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
