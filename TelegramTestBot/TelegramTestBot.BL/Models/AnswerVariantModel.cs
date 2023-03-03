namespace TelegramTestBot.BL.Models
{
    public class AnswerVariantModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public QuestionModel Question { get; set; }

        public AnswerVariantModel(int id, string content, bool isCorrectAnswer, QuestionModel question)
        {
            Id = id;
            Content = content;
            IsCorrectAnswer = isCorrectAnswer;
            Question = question;
        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is AnswerVariantModel))
            {
                flag = false;
            }
            else
            {
                AnswerVariantModel answerVariantDTO = (AnswerVariantModel)obj!;

                if (answerVariantDTO.Id != this.Id ||
                    answerVariantDTO.Content != this.Content ||
                    answerVariantDTO.IsCorrectAnswer != this.IsCorrectAnswer ||
                    answerVariantDTO.Question!.Id != this.Question!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
