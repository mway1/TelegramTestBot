using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITypeOfQuestionModelManager
    {
        void AddTypeOfQuestion(TypeOfQuestionModel newTypeOfQuestion);
        void DeleteTypeOfQuestionById(int typeOfQuestionId);
        void UpdateTypeOfQuestionById(TypeOfQuestionModel newTypeOfQuestion);
        List<TypeOfQuestionModel> GetAllTypeOfQuestions();
        TypeOfQuestionModel GetTypeOfQuestionById(int typeOfQuestionId);
    }
}
