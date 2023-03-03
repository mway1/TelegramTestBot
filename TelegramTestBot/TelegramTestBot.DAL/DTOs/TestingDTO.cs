namespace TelegramTestBot.DAL.DTOs
{
    public class TestingDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int GroupId { get; set; }
        public int TestId { get; set; }
        public GroupDTO Group { get; set; }
        public TestDTO Test { get; set; }

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
                testingDTO.Start != this.Start ||
                testingDTO.End != this.End ||
                testingDTO.Group!.Id != this.Group!.Id ||
                testingDTO.Test!.Id != this.Test!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
