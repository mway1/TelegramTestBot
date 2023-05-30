namespace TelegramTestBot.DAL.DTOs
{
    public class TestingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TestId { get; set; }
        public int GroupId { get; set; }
        public bool isActive { get; set; }
        public string Testname { get; set; }
        public string Groupname { get; set; }

        public TestingDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestingDTO))
            {
                flag = false;
            }

            TestingDTO testingDTO = (TestingDTO)obj!;

            if (testingDTO.Id != this.Id ||
                testingDTO.Date != this.Date ||
                testingDTO.TestId != this.TestId ||
                testingDTO.isActive != this.isActive ||
                testingDTO.GroupId != this.GroupId)
            {
                flag = false;
            }

            return flag;
        }
    }
}
