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
                .ForMember("IsCorrectAnswer", opt => opt.MapFrom(a => a.IsCorrectAnswer))
                .ForMember("QuestionId", opt => opt.MapFrom(a => a.QuestionId))
                .ReverseMap();

                cfg.CreateMap<QuestionDTO, QuestionModel>()
                .ForMember("Id", opt => opt.MapFrom(q => q.Id))
                .ForMember("Content", opt => opt.MapFrom(q => q.Content))
                .ForMember("TestId", opt => opt.MapFrom(q => q.TestId))
                .ForMember("TypeOfQuestionId", opt => opt.MapFrom(q => q.TypeOfQuestionId))
                .ReverseMap();

                cfg.CreateMap<GroupDTO, GroupModel>()
                .ForMember("Id", opt => opt.MapFrom(g => g.Id))
                .ForMember("Name", opt => opt.MapFrom(g => g.Name))
                .ForMember("StudentId", opt => opt.MapFrom(g => g.StudentId))
                .ReverseMap();

                cfg.CreateMap<StudentDTO, StudentModel>()
                .ForMember("Id", opt => opt.MapFrom(s => s.Id))
                .ForMember("FirstName", opt => opt.MapFrom(s => s.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(s => s.LastName))
                .ForMember("SurName", opt => opt.MapFrom(s => s.SurName))
                .ForMember("Username", opt => opt.MapFrom(s => s.Username))
                .ForMember("IsAttendance", opt => opt.MapFrom(s => s.IsAttendance))
                .ReverseMap();

                cfg.CreateMap<TeacherDTO, TeacherModel>()
                .ForMember("Id", opt => opt.MapFrom(t => t.Id))
                .ForMember("FirstName", opt => opt.MapFrom(t => t.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(t => t.LastName))
                .ForMember("SurName", opt => opt.MapFrom(t => t.SurName))
                .ForMember("Email", opt => opt.MapFrom(t => t.Email))
                .ForMember("Login", opt => opt.MapFrom(t => t.Login))
                .ForMember("Password", opt => opt.MapFrom(t => t.Password))
                .ReverseMap();

                cfg.CreateMap<TestDTO, TestModel>()
                .ForMember("Id", opt => opt.MapFrom(tt => tt.Id))
                .ForMember("Name", opt => opt.MapFrom(tt => tt.Name))
                .ForMember("TeacherId", opt => opt.MapFrom(tt => tt.TeacherId))
                .ReverseMap();

                cfg.CreateMap<TestingDTO, TestingModel>()
                .ForMember("Id", opt => opt.MapFrom(tg => tg.Id))
                .ForMember("Date", opt => opt.MapFrom(tg => tg.Date))
                .ForMember("Start", opt => opt.MapFrom(tg => tg.Start))
                .ForMember("End", opt => opt.MapFrom(tg => tg.End))
                .ForMember("GroupId", opt => opt.MapFrom(tg => tg.GroupId))
                .ForMember("TestId", opt => opt.MapFrom(tg => tg.TestId))
                .ReverseMap();

                cfg.CreateMap<TypeOfQuestionDTO, TypeOfQuestionModel>()
                .ForMember("Id", opt => opt.MapFrom(toq => toq.Id))
                .ForMember("Name", opt => opt.MapFrom(toq => toq.Name))
                .ReverseMap();
            }));
        }
    }
}