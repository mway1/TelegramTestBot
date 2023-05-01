namespace TelegramTestBot.BL.Models
{
    public class TestingStudentModel
    {
        public int Id { get; set; }
        public int CountAnswers { get; set; }
        public bool IsAttendance { get; set; }
        public int StudentId { get; set; }
        public int TestingId { get; set; }
        public StudentModel Student { get; set; }
        public TestingModel Testing { get; set; }

        public TestingStudentModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestingStudentModel))
            {
                flag = false;
            }
            else
            {
                TestingStudentModel testingStudentDTO = (TestingStudentModel)obj!;

                if (testingStudentDTO.Id != this.Id ||
                    testingStudentDTO.CountAnswers != this.CountAnswers ||
                    testingStudentDTO.IsAttendance != this.IsAttendance ||
                    testingStudentDTO.Student!.Id != this.Student!.Id ||
                    testingStudentDTO.Testing!.Id != this.Testing!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
