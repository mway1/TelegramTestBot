namespace TelegramTestBot.DAL.DTOs
{
    public class TestingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TestId { get; set; }

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
                testingDTO.TestId != this.TestId)
            {
                flag = false;
            }

            return flag;
        }
    }
}
