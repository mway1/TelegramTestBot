using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class QuestionModelManager : IQuestionModelManager
    {
        private IQuestionManager _questionManager;

        public QuestionModelManager()
        {
            _questionManager = new QuestionManager();
        }

        public QuestionModelManager(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public void AddQuestion(QuestionModel questionModel)
        {
            QuestionDTO question = MapperConfigStorage.GetInstance().Map<QuestionDTO>(questionModel);
            _questionManager.AddQuestion(question);
        }

        public void DeleteQuestionById(int questionId)
        {
            _questionManager.DeleteQuestionById(questionId);
        }

        public void UpdateQuestionById(QuestionModel questionModel)
        {
            QuestionDTO question = MapperConfigStorage.GetInstance().Map<QuestionDTO>(questionModel);
            _questionManager.UpdateQuestionById(question);
        }

        public List<QuestionModel> GetAllQuestions()
        {
            List<QuestionDTO> questions = _questionManager.GetAllQuestions();
            return MapperConfigStorage.GetInstance().Map<List<QuestionModel>>(questions);
        }

        public QuestionModel GetQuestionById(int questionId)
        {
            QuestionDTO question = _questionManager.GetQuestionById(questionId);
            return MapperConfigStorage.GetInstance().Map<QuestionModel>(question);
        }
    }
}
