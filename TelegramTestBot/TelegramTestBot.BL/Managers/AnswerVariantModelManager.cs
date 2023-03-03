using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;
using AutoMapper;

namespace TelegramTestBot.BL.Managers
{
    public class AnswerVariantModelManager : IAnswerVariantModelManager
    {
        private IAnswerVariantManager _answerVariantManager;

        public AnswerVariantModelManager()
        {
            _answerVariantManager = new AnswerVariantManager();
        }

        public AnswerVariantModelManager(IAnswerVariantManager answerVariantManager)
        {
            _answerVariantManager = answerVariantManager;
        }

        public void AddAnswerVariant(AnswerVariantModel answerVariantModel)
        {
            AnswerVariantDTO answerVariant = MapperConfigStorage.GetInstance().Map<AnswerVariantDTO>(answerVariantModel);
            _answerVariantManager.AddAnswerVariant(answerVariant);
        }

        public void DeleteAnswerVariantById(int answerVariantId)
        {
            _answerVariantManager.DeleteAnswerVariantById(answerVariantId);
        }

        public void UpdateAnswerVariantById(AnswerVariantModel answerVariantModel)
        {
            AnswerVariantDTO answerVariant = MapperConfigStorage.GetInstance().Map<AnswerVariantDTO>(answerVariantModel);
            _answerVariantManager.UpdateAnswerVariantById(answerVariant);
        }

        public List<AnswerVariantModel> GetAllAnswerVariants()
        {
            List<AnswerVariantDTO> answerVariants = _answerVariantManager.GetAllAnswerVariants();
            return MapperConfigStorage.GetInstance().Map<List<AnswerVariantModel>>(answerVariants);
        }

        public AnswerVariantModel GetAnswerVariantById(int answerVariantId)
        {
            AnswerVariantDTO answerVariants = _answerVariantManager.GetAnswerVariantById(answerVariantId);
            return MapperConfigStorage.GetInstance().Map<AnswerVariantModel>(answerVariants);
        }
    }
}
