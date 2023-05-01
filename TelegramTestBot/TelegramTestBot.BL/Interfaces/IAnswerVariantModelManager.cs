using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface IAnswerVariantModelManager
    {
        void AddAnswerVariant(AnswerVariantModel newAnswerVariant);
        void DeleteAnswerVariantById(int answerVariantId);
        void UpdateAnswerVariantById(AnswerVariantModel newAnswerVariant);
        List<AnswerVariantModel> GetAllAnswerVariants();
        AnswerVariantModel GetAnswerVariantById(int answerVariantId);
    }
}
