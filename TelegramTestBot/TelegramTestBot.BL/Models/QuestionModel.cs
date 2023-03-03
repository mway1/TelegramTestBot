namespace TelegramTestBot.BL.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public TestModel Test { get; set; }
        public TypeOfQuestionModel TypeOfQuestion { get; set; }

        public QuestionModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is QuestionModel))
            {
                flag = false;
            }
            else
            {
                QuestionModel questionDTO = (QuestionModel)obj!;

                if (questionDTO.Id != this.Id ||
                    questionDTO.Content != this.Content ||
                    questionDTO.Test!.Id != this.Test!.Id ||
                    questionDTO.TypeOfQuestion!.Id != this.TypeOfQuestion!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
