using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class AnswerVariantModelManager : IAnswerVariantModelManager
    {
        private IAnswerManager _answerVariantManager;

        public AnswerVariantModelManager()
        {
            _answerVariantManager = new AnswerManager();
        }

        public AnswerVariantModelManager(IAnswerManager answerVariantManager)
        {
            _answerVariantManager = answerVariantManager;
        }

        public void AddAnswerVariant(AnswerVariantModel answerVariantModel)
        {
            AnswerDTO answerVariant = MapperConfigStorage.GetInstance().Map<AnswerDTO>(answerVariantModel);
            _answerVariantManager.AddAnswerVariant(answerVariant);
        }

        public void DeleteAnswerVariantById(int answerVariantId)
        {
            _answerVariantManager.DeleteAnswerVariantById(answerVariantId);
        }

        public void UpdateAnswerVariantById(AnswerVariantModel answerVariantModel)
        {
            AnswerDTO answerVariant = MapperConfigStorage.GetInstance().Map<AnswerDTO>(answerVariantModel);
            _answerVariantManager.UpdateAnswerVariantById(answerVariant);
        }

        public List<AnswerVariantModel> GetAllAnswerVariants()
        {
            List<AnswerDTO> answerVariants = _answerVariantManager.GetAllAnswerVariants();
            return MapperConfigStorage.GetInstance().Map<List<AnswerVariantModel>>(answerVariants);
        }

        public AnswerVariantModel GetAnswerVariantById(int answerVariantId)
        {
            AnswerDTO answerVariant = _answerVariantManager.GetAnswerVariantById(answerVariantId);
            return MapperConfigStorage.GetInstance().Map<AnswerVariantModel>(answerVariant);
        }
    }
}
