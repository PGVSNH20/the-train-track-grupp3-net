using System;
using System.Threading;
using TrainEngine;
using TrainConsole;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TrainEngine.Models;

namespace TrainConsole
{
    public class TrainRunner : ITrainRunner
    {
        private Thread simulatorThread;
        private Train trainToSimulate;
        private static bool simulatorIsRunning;

        private static Station stopStation;

        public static int StationsPassed;

        private ITravelPlan simulateFromTimePlan;


        public TrainRunner(ITravelPlan schedule)
        {

            this.trainToSimulate = schedule.Train;
            this.simulateFromTimePlan = schedule;

            simulatorIsRunning = false;
        }
        public void Start(Timetable startSta, Timetable endSta)
        {

            double realisticTrainSpeed = Math.Floor((double)trainToSimulate.MaxSpeed / 100);

            double distance = GetTotalMinutes(endSta.ArrivalTime) - GetTotalMinutes(startSta.DepartureTime) * realisticTrainSpeed;

            string startStation = TrainPlaner.ReturnStationFromId(startSta.StationId).StationName;
            string endStation = TrainPlaner.ReturnStationFromId(endSta.StationId).StationName;

            stopStation = TrainPlaner.ReturnStationFromId(endSta.StationId);

            simulatorIsRunning = true;

            Console.WriteLine($"Tåg {trainToSimulate.TrainName} avgår från {startStation} till {endStation}");
            simulatorThread = new Thread(() => Simulate(trainToSimulate, (int)distance));
            simulatorThread.Start();


        }

        public void Stop()
        {

            Console.WriteLine($"Nu stannar {trainToSimulate.TrainName}...");
            simulatorIsRunning = true;

        }
        private static void Simulate(Train simulatedTrain, int distanceToDrive)
        {
            while (simulatorIsRunning)
            {

                double moreRealisticSpeed = Math.Round((double)simulatedTrain.MaxSpeed / 100); // result 1.7???


                double distanceDrived = moreRealisticSpeed * FakeClock.MinutesWhichHaveTicked; //  tts.MaxSpeed
                if (distanceDrived > 1)
                {
                    Console.WriteLine($"Hittils har {simulatedTrain.TrainName} kört {distanceDrived} km i {FakeClock.MinutesWhichHaveTicked} minuter");
                }


                if (distanceDrived >= distanceToDrive)
                {

                    simulatorIsRunning = false;
                    Console.WriteLine("Hittils kört:" + distanceDrived + "km");
                    Console.WriteLine($"Efter {distanceToDrive} km har nu tåget anlänt till sin {stopStation.StationName}");

                }
                Thread.Sleep(200);
            }
        }
        private double CheckIfTimeNotNull(DateTime? time)
        {
            double parsedTime = 0;
            parsedTime = (time != null) ? GetTotalMinutes(time) : 0.0;
            return parsedTime;

        }
        Func<DateTime?, double> GetTotalMinutes = x => (x.Value.Hour * 60) + x.Value.Minute;

    }
}
