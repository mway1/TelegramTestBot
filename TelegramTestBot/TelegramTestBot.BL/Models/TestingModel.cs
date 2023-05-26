namespace TelegramTestBot.BL.Models
{
    public class TestingModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TestId { get; set; }

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
                    testingDTO.TestId != this.TestId)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
