namespace TelegramTestBot.BL.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }

        public AnswerModel()
        {
            
        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is AnswerModel))
            {
                flag = false;
            }
            else
            {
                AnswerModel answerDTO = (AnswerModel)obj!;

                if (answerDTO.Id != this.Id ||
                    answerDTO.Content != this.Content ||
                    answerDTO.IsCorrect != this.IsCorrect ||
                    answerDTO.QuestionId != this.QuestionId)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
