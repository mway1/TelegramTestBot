namespace TelegramTestBot.BL.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public TestModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestModel))
            {
                flag = false;
            }
            else
            {
                TestModel testDTO = (TestModel)obj!;

                if (testDTO.Id != this.Id ||
                    testDTO.Name != this.Name ||
                    testDTO.Teacher!.Id != this.Teacher!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
