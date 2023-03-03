namespace TelegramTestBot.BL.Models
{
    public class AnswerVariantModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool CorrectAnswer { get; set; }
        public QuestionModel Question { get; set; }

        public AnswerVariantModel(int id, string content, bool correctAnswer, QuestionModel question)
        {
            Id = id;
            Content = content;
            CorrectAnswer = correctAnswer;
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
                    answerVariantDTO.CorrectAnswer != this.CorrectAnswer ||
                    answerVariantDTO.Question!.Id != this.Question!.Id)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
