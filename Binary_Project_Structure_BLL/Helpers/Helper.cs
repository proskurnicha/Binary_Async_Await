using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Binary_Project_Structure_BLL.Helpers
{
    public class Helper
    {
        public Task<string> DoWork()
        {
            var tcs = new TaskCompletionSource<string>();

            var aTimer = new Timer();
            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            aTimer.Elapsed += (o, e) =>
            {
                if (e.SignalTime.DayOfWeek == DayOfWeek.Monday)
                {
                    tcs.SetException(new Exception("Today is monday!"));
                }
                else
                {
                    tcs.SetResult("Test");
                }
            };

            return tcs.Task;
        }
    }
}
