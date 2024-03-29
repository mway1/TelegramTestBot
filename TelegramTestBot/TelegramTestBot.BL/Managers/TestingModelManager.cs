﻿using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TestingModelManager : ITestingModelManager
    {
        private ITestingManager _testingManager;

        public TestingModelManager()
        {
            _testingManager = new TestingManager();
        }

        public TestingModelManager(ITestingManager testingManager)
        {
            _testingManager = testingManager;
        }

        public void AddTesting(TestingModel testingModel)
        {
            TestingDTO testing = MapperConfigStorage.GetInstance().Map<TestingDTO>(testingModel);
            _testingManager.AddTesting(testing);
        }

        public void DeleteTestingById(int testingId)
        {
            _testingManager.DeleteTestingById(testingId);
        }

        public void UpdateTestingById(TestingModel testingModel)
        {
            TestingDTO testing = MapperConfigStorage.GetInstance().Map<TestingDTO>(testingModel);
            _testingManager.UpdateTestingById(testing);
        }

        public List<TestingModel> GetAllTestings()
        {
            List<TestingDTO> testings = _testingManager.GetAllTestings();
            return MapperConfigStorage.GetInstance().Map<List<TestingModel>>(testings);
        }
        public List<TestingModel> GetLastAddedTestingByTeacherId(int teacherId)
        {
            List<TestingDTO> testings = _testingManager.GetLastAddedTestingByTeacherId(teacherId);
            return MapperConfigStorage.GetInstance().Map<List<TestingModel>>(testings);
        }

        public TestingModel GetTestingById(int testingId)
        {
            TestingDTO testing = _testingManager.GetTestingById(testingId);
            return MapperConfigStorage.GetInstance().Map<TestingModel>(testing);
        }
        
        public int GetLastAddedTestingByGroupId(int groupId)
        {
            int testingId = _testingManager.GetLastAddedTestingByGroupId(groupId);
            return MapperConfigStorage.GetInstance().Map<int>(testingId);
        }
        
        public bool GetStatusOfTestById(int testingId)
        {
            bool isActive = _testingManager.GetStatusOfTestById(testingId);
            return MapperConfigStorage.GetInstance().Map<bool>(isActive);
        }
        
        public TestingModel GetTestingByGroupId(int groupId)
        {
            TestingDTO testing = _testingManager.GetTestingByGroupId(groupId);
            return MapperConfigStorage.GetInstance().Map<TestingModel>(testing);
        }
    }
}
