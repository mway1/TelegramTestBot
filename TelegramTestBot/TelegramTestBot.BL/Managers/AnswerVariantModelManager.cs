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
            
        }
    }
}
