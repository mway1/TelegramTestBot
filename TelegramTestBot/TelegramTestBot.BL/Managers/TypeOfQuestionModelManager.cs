using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TypeOfQuestionModelManager
    {
        private ITypeOfQuestionManager _typeOfQuestionManager;

        public TypeOfQuestionModelManager()
        {
            _typeOfQuestionManager = new TypeOfQuestionManager();
        }

        public TypeOfQuestionModelManager(ITypeOfQuestionManager typeOfQuestionManager)
        {
            _typeOfQuestionManager = typeOfQuestionManager;
        }

        public void AddTypeOfQuestion(TypeOfQuestionModel typeOfQuestionModel)
        {
            TypeOfQuestionDTO typeOfQuestion = MapperConfigStorage.GetInstance().Map<TypeOfQuestionDTO>(typeOfQuestionModel);
            _typeOfQuestionManager.AddTypeOfQuestion(typeOfQuestion);
        }

        public void DeleteTypeOfQuestionById(int typeOfQuestionId)
        {
            _typeOfQuestionManager.DeleteTypeOfQuestionById(typeOfQuestionId);
        }

        public void UpdateTypeOfQuestionById(TypeOfQuestionModel typeOfQuestionModel)
        {
            TypeOfQuestionDTO typeOfQuestion = MapperConfigStorage.GetInstance().Map<TypeOfQuestionDTO>(typeOfQuestionModel);
            _typeOfQuestionManager.UpdateTypeOfQuestionById(typeOfQuestion);
        }

        public List<TypeOfQuestionModel> GetAllTypeOfQuestions()
        {
            List<TypeOfQuestionDTO> typeOfQuestions = _typeOfQuestionManager.GetAllTypeOfQuestions();
            return MapperConfigStorage.GetInstance().Map<List<TypeOfQuestionModel>>(typeOfQuestions);
        }

        public TypeOfQuestionModel GetTypeOfQuestionById(int typeOfQuestionId)
        {
            TypeOfQuestionDTO typeOfQuestion = _typeOfQuestionManager.GetTypeOfQuestionById(typeOfQuestionId);
            return MapperConfigStorage.GetInstance().Map<TypeOfQuestionModel>(typeOfQuestion);
        }
    }
}
