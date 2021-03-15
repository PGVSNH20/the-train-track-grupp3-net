using System;
using System.Threading;
using TrainEngine;
using TrainEngine.Models;
using TrainEngine.Reader;
using TrainEngine.Utilities;

namespace TrainConsole
{
    class Program
    {
        static readonly string _defaultSavePath = @"..\..\..\..\..\Data\";
        static void Main(string[] args)
        {
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)
            TrackOrm track = new TrackOrm();
            var result = track.ParseTrackDescription(@"..\..\..\..\..\Data\traintrack1.txt");
            result.Stations.ForEach(x => Console.WriteLine($"Station: {x}"));
            Console.WriteLine("Amount of rail between stations:");
            foreach(var rail in result.Rails) { Console.WriteLine(rail); }

            // Step 2:
            // Make the trains run in treads
            // Test 
            //Andreas testar

            //Train train1 = new Train("Name of train");
            //Trainstation station1 = new Trainstation("Gothenburg");
            //Trainstation station2 = new Trainstation("Stockholm");

            //ITravelPlan travelPlan = new TrainPlaner(train1, station1)
            //        .HeadTowards(station2)
            //        .StartTrainAt("10:23")
            //        .StopTrainAt(station2, "14:53")
            //    .GeneratePlan();

            // Daniel
            Train goldenArrow = new Train() { TrainId = 2, TrainName = "Golden Arrow", MaxSpeed = 120, IsOperated = true };

            //Station mountJuanceo = new Station() { Id = 2, StationName = "Mount Juanceo", EndStation = false };
            //Station grandRetro = new Station() { Id = 3, StationName = "Grand Retro", EndStation = true };
            Station stonecro = new Station("Stonecro");
            Station mountJuanceo = new Station("Mount Juanceo");
            Station grandRetro = new Station("Grand Retro");


            //ITravelPlan travelPlan = new TrainPlaner(goldenArrow, stonecro)
            //    .HeadTowards(grandRetro)
            //    .StartTrainAt("10:20")
            //    .StopTrainAt(mountJuanceo, "10:43")
            //    .StartTrainAt("10:45")
            //    .StopTrainAt(grandRetro, "10:59")
            //    .GeneratePlan();

            ITravelPlan travelPlan = new TrainPlaner();

            //travelPlan.Save(_defaultSavePath);
            travelPlan.Load(_defaultSavePath + "travelPlans-2-Golden Arrow-15-03-2021.json");

            travelPlan.GeneratePlan();
            travelPlan.Simulate();


        }
    }
}
