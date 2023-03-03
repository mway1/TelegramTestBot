using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITestModelManager
    {
        void AddTest(TestModel newTest);
        void DeleteTestById(int testId);
        void UpdateTestById(TestModel newTest);
        List<TestModel> GetAllTests();
        TestModel GetTestById(int testId);
    }
}
