namespace TelegramTestBot.BL.Models
{
    public class TestingModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TestId { get; set; }
        public int GroupId { get; set; }
        public bool isActive { get; set; }
        public string Testname { get; set; }
        public string Groupname { get; set; }

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
                    testingDTO.TestId != this.TestId ||
                    testingDTO.isActive != this.isActive ||
                    testingDTO.GroupId != this.GroupId)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
