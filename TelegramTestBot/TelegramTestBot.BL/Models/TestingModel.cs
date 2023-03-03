namespace TelegramTestBot.BL.Models
{
    public class TestingModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public GroupModel Group { get; set; }
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
                    testingDTO.Start != this.Start ||
                    testingDTO.End != this.End ||
                    testingDTO.Group!.Id != this.Group!.Id ||
                    testingDTO.Test!.Id != this.Test!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
