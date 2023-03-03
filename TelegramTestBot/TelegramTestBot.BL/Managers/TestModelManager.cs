using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Models;
using TelegramTestBot.DAL.DTOs;
using TelegramTestBot.DAL.Managers;
using TelegramTestBot.DAL.Interfaces;

namespace TelegramTestBot.BL.Managers
{
    public class TestModelManager
    {
        private ITestManager _testManager;

        public TestModelManager()
        {
            _testManager = new TestManager();
        }

        public TestModelManager(ITestManager testManager)
        {
            _testManager = testManager;
        }

        public void AddTest(TestModel testModel)
        {
            TestDTO test = MapperConfigStorage.GetInstance().Map<TestDTO>(testModel);
            _testManager.AddTest(test);
        }

        public void DeleteTestById(int testId)
        {
            _testManager.DeleteTestById(testId);
        }

        public void UpdateTestById(TestModel testModel)
        {
            TestDTO test = MapperConfigStorage.GetInstance().Map<TestDTO>(testModel);
            _testManager.UpdateTestById(test);
        }

        public List<TestModel> GetAllTests()
        {
            List<TestDTO> tests = _testManager.GetAllTests();
            return MapperConfigStorage.GetInstance().Map<List<TestModel>>(tests);
        }

        public TestModel GetTestById(int testId)
        {
            TestDTO test = _testManager.GetTestById(testId);
            return MapperConfigStorage.GetInstance().Map<TestModel>(test);
        }
    }
}
