using HustleFarmServer.Controllers.Model.DailyGift;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

namespace HustleFarmServer.Controllers.Model.RepeatedTask
{
    public class DailyGiftResetController
    {

        private System.Timers.Timer _timer;

        private static DailyGiftResetController instance;

        private const float durationReset = 24*60*60*1000;

        public static DailyGiftResetController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DailyGiftResetController();
                }

                return instance;
            }
        }


        private DailyGiftResetController()
        {
            
           
        }


        public void ResetDailyGifts() {

            _timer = new System.Timers.Timer(durationReset);
            _timer.Elapsed += (sender, e) => DailyGiftController.Instance.ResetDailyGift();
            _timer.AutoReset = true;
            _timer.Start();
        }
    }
}
