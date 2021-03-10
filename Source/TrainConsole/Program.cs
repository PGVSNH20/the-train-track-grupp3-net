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

            //testar att läsa in från tågfilen
            var train = new Train();
            var result = train.PopulateList();

            foreach (var trainTest in result)
            {
                Console.WriteLine(trainTest.TrainName);
            }

            var myStation = new Station();
            var result2 = myStation.PopulateList();

            result2.ForEach(x => Console.WriteLine(x.StationName));

        }
    }
}
