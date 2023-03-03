using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITypeOfQuestionManager
    {
        void AddTypeOfQuestion(TypeOfQuestionDTO newTypeOfQuestion);
        void DeleteTypeOfQuestionById(int typeOfQuestionId);
        void UpdateTypeOfQuestionById(TypeOfQuestionDTO newTypeOfQuestion);
        List<TypeOfQuestionDTO> GetAllTypeOfQuestions();
        GroupDTO GetTypeOfQuestionById(int typeOfQuestionId);
    }
}
