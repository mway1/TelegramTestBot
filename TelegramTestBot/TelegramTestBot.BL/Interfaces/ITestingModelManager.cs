using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Interfaces
{
    public interface ITestingModelManager
    {
        void AddTesting(TestingModel newTesting);
        void DeleteTestingById(int testingId);
        void UpdateTestingById(TestingModel newTesting);
        List<TestingModel> GetAllTestings();
        List<TestingModel> GetLastAddedTestingByTeacherId(int teacherId);
        TestingModel GetTestingById(int testingId);
        int GetLastAddedTestingByGroupId(int groupId);
        TestingModel GetTestingByGroupId(int groupId);
    }
}
