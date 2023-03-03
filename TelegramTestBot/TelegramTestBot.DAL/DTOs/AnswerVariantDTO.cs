namespace TelegramTestBot.DAL.DTOs
{
    public class AnswerVariantDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool CorrectAnswer { get; set; }
        public int QuestionId { get; set; }
        public QuestionDTO Question { get; set; }

        public AnswerVariantDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is AnswerVariantDTO))
            {
                flag = false;
            }

            AnswerVariantDTO answerVariantDTO = (AnswerVariantDTO)obj!;

            if (answerVariantDTO.Id != this.Id ||
                answerVariantDTO.Content != this.Content ||
                answerVariantDTO.CorrectAnswer != this.CorrectAnswer ||
                answerVariantDTO.Question!.Id != this.Question!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
