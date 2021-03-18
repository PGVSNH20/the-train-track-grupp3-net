using System;
using System.Threading;
using TrainEngine;

namespace TrainConsole
{
    class FakeClock : IClock
    {
        private Thread clockThread;
        private static bool timeIsTicking;
        public static double MinutesWhichHaveTicked;

        public FakeClock()
        {
            clockThread = new Thread(Tick);
            clockThread.IsBackground = true;
            timeIsTicking = false;
            MinutesWhichHaveTicked = 0;
            clockThread.Start();
        }

        public void Start()
        {
            timeIsTicking = true;
        }
        public void Stop()
        {
            timeIsTicking = false;
        }

        private static void Tick()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (timeIsTicking)
                {
                    MinutesWhichHaveTicked++;

                    if (MinutesWhichHaveTicked % 60 != 0)
                    {
                        string time;
                        time = (MinutesWhichHaveTicked >= 10) ?  $"[00:{MinutesWhichHaveTicked}:00]" : $"[00:0{MinutesWhichHaveTicked}:00]";
                        Console.WriteLine(time);
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
        }
    }
}
