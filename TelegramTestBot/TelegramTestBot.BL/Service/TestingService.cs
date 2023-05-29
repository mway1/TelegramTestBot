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

        public TestingService()
        {
            foreach (var timer in TimersForGroup.Values)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        //public void StartTimerForStudent(long id, DateTime sendTime)
        //{
        //    Schedules[id] = sendTime;

        //    System.Timers.Timer timer = new System.Timers.Timer();
        //    timer.Interval = (sendTime - DateTime.Now).TotalMilliseconds;
        //    timer.AutoReset = false;
        //    timer.Elapsed += (sender, args) => WaitForScheduleTime(id, sendTime);
        //    timer.Start();

        //    Timers[id] = timer;
        //}

        //public bool WaitForScheduleTime(long id, DateTime sendTime)
        //{
        //    bool IsTimeForSend = false;
        //    if (Schedules.ContainsKey(id) && Schedules[id] == sendTime)
        //    {
        //        IsTimeForSend = true;
        //    }

        //    Schedules.Remove(id);
        //    Timers[id].Stop();
        //    Timers[id].Dispose();
        //    Timers.Remove(id);

        //    return IsTimeForSend;
        //}
    }
}
