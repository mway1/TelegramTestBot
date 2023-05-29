using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class AnswerModelManager : IAnswerModelManager
    {
        private IAnswerManager _answerManager;

        public AnswerModelManager()
        {
            _answerManager = new AnswerManager();
        }

        public AnswerModelManager(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public void AddAnswer(AnswerModel answerModel)
        {
            AnswerDTO answer = MapperConfigStorage.GetInstance().Map<AnswerDTO>(answerModel);
            _answerManager.AddAnswer(answer);
        }

        public void DeleteAnswerById(int answerId)
        {
            _answerManager.DeleteAnswerById(answerId);
        }

        public void UpdateAnswerById(AnswerModel answerModel)
        {
            AnswerDTO answer = MapperConfigStorage.GetInstance().Map<AnswerDTO>(answerModel);
            _answerManager.UpdateAnswerById(answer);
        }

        public List<AnswerModel> GetAllAnswers()
        {
            List<AnswerDTO> answers = _answerManager.GetAllAnswers();
            return MapperConfigStorage.GetInstance().Map<List<AnswerModel>>(answers);
        }

        public AnswerModel GetAnswerById(int answerId)
        {
            AnswerDTO answer = _answerManager.GetAnswerById(answerId);
            return MapperConfigStorage.GetInstance().Map<AnswerModel>(answer);
        }
        public int GetRightAnswer(int questionId)
        {
            int answer = _answerManager.GetRightAnswer(questionId);
            return MapperConfigStorage.GetInstance().Map<int>(answer);
        }

        public List<AnswerModel> GetAnswerByQuestionId(int questionId)
        {
            List<AnswerDTO> answer = _answerManager.GetAnswerByQuestionId(questionId);
            return MapperConfigStorage.GetInstance().Map<List<AnswerModel>>(answer);
        }
    }
}
