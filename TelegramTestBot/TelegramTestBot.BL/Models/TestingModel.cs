namespace TelegramTestBot.BL.Models
{
    public class TestingModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int TestId { get; set; }
        public TestModel Test { get; set; }

        public TestingModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestingModel))
            {
                flag = false;
            }
            else
            {
                TestingModel testingDTO = (TestingModel)obj!;

                if (testingDTO.Id != this.Id ||
                    testingDTO.Date != this.Date ||
                    testingDTO.Test!.Id != this.Test!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
