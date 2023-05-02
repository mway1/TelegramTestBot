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
            return _instance!;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnswerDTO, AnswerModel>()
                .ForMember("Id", opt => opt.MapFrom(a => a.Id))
                .ForMember("Content", opt => opt.MapFrom(a => a.Content))
                .ForMember("IsCorrect", opt => opt.MapFrom(a => a.IsCorrect))
                .ForMember("QuestionId", opt => opt.MapFrom(a => a.QuestionId))
                .ReverseMap();

                cfg.CreateMap<QuestionDTO, QuestionModel>()
                .ForMember("Id", opt => opt.MapFrom(q => q.Id))
                .ForMember("Content", opt => opt.MapFrom(q => q.Content))
                .ForMember("TestId", opt => opt.MapFrom(q => q.TestId))                
                .ReverseMap();

                cfg.CreateMap<GroupDTO, GroupModel>()
                .ForMember("Id", opt => opt.MapFrom(g => g.Id))
                .ForMember("Name", opt => opt.MapFrom(g => g.Name))
                .ForMember("StudentId", opt => opt.MapFrom(g => g.StudentId))
                .ReverseMap();

                cfg.CreateMap<StudentDTO, StudentModel>()
                .ForMember("Id", opt => opt.MapFrom(s => s.Id))
                .ForMember("Firstname", opt => opt.MapFrom(s => s.Firstname))
                .ForMember("Lastname", opt => opt.MapFrom(s => s.Lastname))
                .ForMember("Surname", opt => opt.MapFrom(s => s.Surname))
                .ForMember("Username", opt => opt.MapFrom(s => s.Username))
                .ReverseMap();

                cfg.CreateMap<TeacherDTO, TeacherModel>()
                .ForMember("Id", opt => opt.MapFrom(t => t.Id))
                .ForMember("Firstname", opt => opt.MapFrom(t => t.Firstname))
                .ForMember("Lastname", opt => opt.MapFrom(t => t.Lastname))
                .ForMember("Surname", opt => opt.MapFrom(t => t.Surname))
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
                .ForMember("TestId", opt => opt.MapFrom(tg => tg.TestId))
                .ReverseMap();

                cfg.CreateMap<TestingStudentDTO, TestingStudentModel>()
                .ForMember("Id", opt => opt.MapFrom(ts => ts.Id))
                .ForMember("CountAnswers", opt => opt.MapFrom(ts => ts.CountAnswers))
                .ForMember("IsAttendance", opt => opt.MapFrom(ts => ts.IsAttendance))
                .ForMember("StudentId", opt => opt.MapFrom(ts => ts.StudentId))
                .ForMember("TestingId", opt => opt.MapFrom(ts => ts.TestingId))
                .ReverseMap();

                cfg.CreateMap<TelegramBotDTO, TelegramBotModel>()
                .ForMember("Id", opt => opt.MapFrom(tb => tb.Id))
                .ForMember("HashToken", opt => opt.MapFrom(tb => tb.HashToken))
                .ReverseMap();
            }));
        }
    }
}