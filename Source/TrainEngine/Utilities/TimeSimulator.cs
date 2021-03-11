using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Utilities
{
    public class TimeSimulator
    {

        private static readonly int aDayInMinutes = 1440;

        private static TimeSpan _departureTime = new TimeSpan(0, 0, 0);
        private static TimeSpan _arrivalTime = new TimeSpan(0, 0, 0);

        // Bas för hur timespan implementeras
        //private static TimeSpan departureTime = new TimeSpan(10, 30, 0);
        //private static TimeSpan arrivalTime = new TimeSpan(12, 45, 0);

        public TimeSimulator(TimeSpan departure, TimeSpan arrival)
        {
            _departureTime = departure;
            _arrivalTime = _arrivalTime;
        }

        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }


        public static void Run(string train, string station1, string station2, string loadPlan = "Default")
        {
            // loadPlan laddar StartStation - Slutstation respektive start & sluttid samt Tågnamn + Id

            for (int min = 0; min < aDayInMinutes; min++)
            {
                bool IsInWholeHour = min % 60 == 0;
                int hour = min / 60;

                if (IsInWholeHour) Console.WriteLine("Kl:" + hour + ":00");

                if (min == _departureTime.TotalMinutes)
                {
                    Console.WriteLine("Kl:" + _departureTime.ToString() + ":00");
                    Console.WriteLine($"{train} kör från {station1} till {station2}");
                }
                if (min == _arrivalTime.TotalMinutes)
                {
                    Console.WriteLine("Kl:" + _arrivalTime.ToString() + ":00");
                    Console.WriteLine($"{train} anlände till {station2} till {station1}");
                }
            }
            Console.ReadKey();
        }
    }
}
