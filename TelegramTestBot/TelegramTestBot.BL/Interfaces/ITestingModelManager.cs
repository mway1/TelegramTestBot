using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITestingModelManager
    {
        void AddTesting(TestingModel newTesting);
        void DeleteTestingById(int testingId);
        void UpdateTestingById(TestingModel newTesting);
        List<TestingModel> GetAllTestings();
        TestingModel GetTestingById(int testingId);
        TestingModel GetTestingByGroupId(int groupId);
    }
}
