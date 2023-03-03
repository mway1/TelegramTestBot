using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITypeOfQuestionManager
    {
        void AddTypeOfQuestion(TypeOfQuestionDTO newTypeOfQuestion);
        void DeleteTypeOfQuestionById(int typeOfQuestionId);
        void UpdateTypeOfQuestionById(TypeOfQuestionDTO newTypeOfQuestion);
        List<TypeOfQuestionDTO> GetAllTypeOfQuestions();
        TypeOfQuestionDTO GetTypeOfQuestionById(int typeOfQuestionId);
    }
}
