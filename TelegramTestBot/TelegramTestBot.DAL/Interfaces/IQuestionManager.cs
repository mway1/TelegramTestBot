using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IQuestionManager
    {
        void AddQuestion(QuestionDTO newQuestion);
        void DeleteQuestionById(int questionId);
        void UpdateQuestionById(QuestionDTO newQuestion);
        List<QuestionDTO> GetAllQuestions();
        QuestionDTO GetQuestionById(int questionId);
    }
}
