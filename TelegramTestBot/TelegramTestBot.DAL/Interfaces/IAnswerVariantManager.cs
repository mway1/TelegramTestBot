using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface IAnswerVariantManager
    {
        void AddAnswerVariant(AnswerVariantDTO newAnswerVariant);
        void DeleteAnswerVariantById(int answerVariantId);
        void UpdateAnswerVariantById(AnswerVariantDTO newAnswerVariant);
        List<AnswerVariantDTO> GetAllAnswerVariants();
        AnswerVariantDTO GetAnswerVariantById(int answerVariantId);
    }
}
