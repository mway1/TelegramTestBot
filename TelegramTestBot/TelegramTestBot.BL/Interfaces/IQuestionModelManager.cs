using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IQuestionModelManager
    {
        void AddQuestion(QuestionModel newQuestion);
        void DeleteQuestionById(int questionId);
        void UpdateQuestionById(QuestionModel newQuestion);
        List<QuestionModel> GetAllQuestions();
        QuestionModel GetQuestionById(int questionId);
        List<QuestionModel> GetQuestionByTestId(int testId);
        int GetLastQuestionAdded(int testId);
    }
}
