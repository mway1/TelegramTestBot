using TelegramTestBot.DAL.DTOs;

namespace TelegramTestBot.DAL.Interfaces
{
    public interface ITestingManager
    {
        void AddTesting(TestingDTO newTesting);
        void DeleteTestingById(int testingId);
        void UpdateTestingById(TestingDTO newTesting);
        List<TestingDTO> GetAllTestings();
        TestingDTO GetTestingById(int testingId);
        int GetLastAddedTestingByGroupId(int groupId);
        TestingDTO GetTestingByGroupId(int groupId);
    }
}
