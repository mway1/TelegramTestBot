using System.Text;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;
using TelegramTestBot.BL.Interfaces;

namespace TelegramTestBot.BL.Service
{
    public class TestingService
    {
        public Dictionary<int, bool> TestSessions { get; set; } = new Dictionary<int, bool>();
        public Dictionary<long, List<int>> UserAnswersForTest { get; set; } = new Dictionary<long, List<int>>();
        public Dictionary<int, DateTime> SchedulesGroup { get; set; } = new Dictionary<int, DateTime>();
        public Dictionary<int, System.Timers.Timer> TimersForGroup { get; set; } = new Dictionary<int, System.Timers.Timer>();
        public Dictionary<int, System.Timers.Timer> TimersForTestSession { get; set; } = new Dictionary<int, System.Timers.Timer>();
        TestingModelManager _testingModelManager = new TestingModelManager();
        

        public TestingService()
        {
            TestSessions.Clear();
            UserAnswersForTest.Clear();

            foreach (var timer in TimersForGroup.Values)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        public void StartTimerForTest(int groupId, int testingId, DateTime finishTime)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = (finishTime - DateTime.Now).TotalMilliseconds;
            timer.AutoReset = false;
            timer.Elapsed += (sender, args) => WaitForFinishTime(groupId, testingId, finishTime);
            timer.Start();

            TimersForTestSession[groupId] = timer;
        }

        public void WaitForFinishTime(int groupId, int testingId, DateTime finishTime)
        {
            TimersForTestSession[groupId].Stop();
            TimersForTestSession[groupId].Dispose();
            TimersForTestSession.Remove(groupId);

            
        }
    }
}
