using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IAnswerManager
    {
        void AddAnswer(AnswerDTO newAnswer);
        void DeleteAnswerById(int answerId);
        void UpdateAnswerById(AnswerDTO newAnswer);
        List<AnswerDTO> GetAllAnswers();
        AnswerDTO GetAnswerById(int answerId);
        int GetRightAnswer(int questionId);
        List<AnswerDTO> GetAnswerByQuestionId(int answerId);
    }
}
