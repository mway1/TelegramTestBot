namespace TelegramTestBot.DAL.DTOs
{
    public class Testing_StudentDTO
    {
        public int Id { get; set; }
        public int CountAnswers { get; set; }
        public int TestingId { get; set; }
        public int StudentId { get; set; }
        public bool IsAttendance { get; set; }
        public StudentDTO Student { get; set; }
        public TestingDTO Testing { get; set; }

        public Testing_StudentDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is Testing_StudentDTO))
            {
                flag = false;
            }

            Testing_StudentDTO testing_StudentDTO = (Testing_StudentDTO)obj!;

            if (testing_StudentDTO.Id != this.Id ||
                testing_StudentDTO.CountAnswers != this.CountAnswers ||
                testing_StudentDTO.IsAttendance != this.IsAttendance ||
                testing_StudentDTO.Student!.Id != this.Student!.Id ||
                testing_StudentDTO.Testing!.Id != this.Testing!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
