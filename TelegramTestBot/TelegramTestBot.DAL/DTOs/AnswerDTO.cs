namespace TelegramTestBot.DAL.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public QuestionDTO Question { get; set; }

        public AnswerDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is AnswerDTO))
            {
                flag = false;
            }

            AnswerDTO answerVariantDTO = (AnswerDTO)obj!;

            if (answerVariantDTO.Id != this.Id ||
                answerVariantDTO.Content != this.Content ||
                answerVariantDTO.Question!.Id != this.Question!.Id ||
                answerVariantDTO.IsCorrect != this.IsCorrect)
            {
                flag = false;
            }

            return flag;
        }
    }
}
