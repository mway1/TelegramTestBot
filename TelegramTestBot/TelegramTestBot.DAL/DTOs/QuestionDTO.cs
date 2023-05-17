namespace TelegramTestBot.DAL.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TestId { get; set; }

        public QuestionDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is QuestionDTO))
            {
                flag = false;
            }

            QuestionDTO questionDTO = (QuestionDTO)obj!;

            if (questionDTO.Id != this.Id ||
                questionDTO.Content != this.Content ||
                questionDTO.TestId != this.TestId)
            {
                flag = false;
            }

            return flag;
        }
    }
}
