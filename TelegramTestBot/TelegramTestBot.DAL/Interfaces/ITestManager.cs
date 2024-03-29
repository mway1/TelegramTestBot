﻿using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITestManager
    {
        void AddTest(TestDTO newTest);
        void DeleteTestById(int testId);
        void UpdateTestById(TestDTO newTest);
        List<TestDTO> GetAllTests();
        TestDTO GetTestById(int testId);
        int GetLastTestAdded(int teacherId);
        List<TestDTO> GetTestByTeacherId(int teacherId);
    }
}
