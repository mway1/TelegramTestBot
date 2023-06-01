using System.Text;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.BL.Service
{
    public class TestingService
    {
        public Dictionary<long, List<int>> UserAnswersForTest { get; set; } = new Dictionary<long, List<int>>();
        public Dictionary<int, DateTime> SchedulesGroup { get; set; } = new Dictionary<int, DateTime>();
        public Dictionary<int, System.Timers.Timer> TimersForGroup { get; set; } = new Dictionary<int, System.Timers.Timer>();
        public Dictionary<int, System.Timers.Timer> TimersForTestSession { get; set; } = new Dictionary<int, System.Timers.Timer>();
        TestingModelManager _testingModelManager = new TestingModelManager();
        

        public TestingService()
        {
            UserAnswersForTest.Clear();

            foreach (var timer in TimersForGroup.Values)
            {
                timer.Stop();
                timer.Dispose();
            }

            foreach(var timer in TimersForTestSession.Values)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        public void StartTimerForTest(int groupId, int testingId, DateTime finishTime)
        {
            if (_testingModelManager.GetStatusOfTestById(testingId))
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = (finishTime - DateTime.Now).TotalMilliseconds;
                timer.AutoReset = false;
                timer.Elapsed += (sender, args) => WaitForFinishTime(groupId, testingId);
                timer.Start();

                TimersForTestSession[groupId] = timer;
            }
        }

        public void WaitForFinishTime(int groupId, int testingId)
        {
            if (TimersForTestSession.ContainsKey(groupId))
            {
                TimersForTestSession[groupId].Stop();
                TimersForTestSession[groupId].Dispose();
                TimersForTestSession.Remove(groupId);
            }

            TestingModel updTesting = _testingModelManager.GetTestingById(testingId);
            updTesting.isActive = false;

            _testingModelManager.UpdateTestingById(updTesting);
        }
    }
}
