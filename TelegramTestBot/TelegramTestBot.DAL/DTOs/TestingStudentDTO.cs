namespace TelegramTestBot.DAL.DTOs
{
    public class TestingStudentDTO
    {
        public int Id { get; set; }
        public int CountAnswers { get; set; }
        public int TestingId { get; set; }
        public int StudentId { get; set; }
        public bool IsAttendance { get; set; }
        //public TestingDTO Testing { get; set; }
        public DateTime DateOfTesting { get; set; }
        public string SurnameOfStudent { get; set; }
        public string FirstnameOfStudent { get; set; }

        public TestingStudentDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestingStudentDTO))
            {
                flag = false;
            }

            TestingStudentDTO testing_StudentDTO = (TestingStudentDTO)obj!;

            if (testing_StudentDTO.Id != this.Id ||
                testing_StudentDTO.CountAnswers != this.CountAnswers ||
                testing_StudentDTO.IsAttendance != this.IsAttendance ||
                testing_StudentDTO.StudentId != this.StudentId ||
                testing_StudentDTO.TestingId != this.TestingId)
            {
                flag = false;
            }

            return flag;
        }
    }
}
