using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IAnswerVariantManager
    {
        void AddAnswerVariant(AnswerDTO newAnswerVariant);
        void DeleteAnswerVariantById(int answerVariantId);
        void UpdateAnswerVariantById(AnswerDTO newAnswerVariant);
        List<AnswerDTO> GetAllAnswerVariants();
        AnswerDTO GetAnswerVariantById(int answerVariantId);
    }
}
