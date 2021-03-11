using System;
using TrainEngine;
using TrainEngine.Models;
using TrainEngine.Reader;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

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


            Train goldenArrow = new Train() { TrainId = 2, TrainName = "Golden Arrow", MaxSpeed = 120, IsOperated = true };

            Station mountJuanceo = new Station() { Id = 2, StationName = "Mount Juanceo", EndStation = false };
            Station grandRetro = new Station() { Id = 3, StationName = "Grand Retro", EndStation = true };

            //2|Mount Juanceo|false
            //3 | Grand Retro | true

            ITravelPlan travelPlan = new TrainPlaner(goldenArrow, mountJuanceo).StopTrainAt(grandRetro, "14:53").GeneratePlan();


            //FileReader p = new FileReader();
            //var result = p.StreamReader(trainUrl);

            // Testar att skriva ut stationer
            Console.WriteLine();
            var station = new Station();
            var stationResult = station.PopulateList();
            foreach (var stationTest in stationResult)
            {
                Console.WriteLine(stationTest.StationName);
            }

            // Testar att skriva ut tåg
            Console.WriteLine();
            var train = new Train();
            var trainResult = train.PopulateList();

            foreach (var trainTest in trainResult)
            {
                Console.WriteLine(trainTest.TrainName);
            }

            // Testar att skriva ut passagerare
            Console.WriteLine();
            var passenger = new Passenger();
            var passengerResult = passenger.PopulateList();

            foreach (var passengerTest in passengerResult)
            {
                Console.WriteLine(passengerTest.Name);
            }

            //FileReader p = new FileReader();
            //p.StreamReader();
            //Station myInstance = new Station();
            //myInstance.ListOfStations.ForEach(x => Console.WriteLine(x.StationName));
        }
    }
}
