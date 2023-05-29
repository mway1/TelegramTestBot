using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IAnswerModelManager
    {
        void AddAnswer(AnswerModel newAnswer);
        void DeleteAnswerById(int answerId);
        void UpdateAnswerById(AnswerModel newAnswer);
        List<AnswerModel> GetAllAnswers();
        AnswerModel GetAnswerById(int answerId);
        List<AnswerModel> GetAnswerByQuestionId(int answerId);
        int GetRightAnswer(int questionId);
    }
}
