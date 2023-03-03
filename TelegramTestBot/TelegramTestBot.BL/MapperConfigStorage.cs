using AutoMapper;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.BL
{
    public class MapperConfigStorage
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if(_instance == null)            
                InitializeInstance();
            return _instance;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerVariantDTO, AnswerVariantModel>()
                .ForMember("Id", opt => opt.MapFrom(a => a.Id))
                .ForMember("Content", opt => opt.MapFrom(a => a.Content))
                .ForMember("CorrectAnswer", opt => opt.MapFrom(a => a.CorrectAnswer))
                .ForMember("QuestionId", opt => opt.MapFrom(a => a.QuestionId))
                .ReverseMap();
            }));
        }
    }
}