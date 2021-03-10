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
            FileReader p = new FileReader();
            p.StreamReader(_passangers);

            //testar att läsa in från tågfilen
            var trainUrl = @"..\..\..\..\..\Data\trains.txt";
            var train = new Train();
            var result = train.PopulateList(trainUrl);

            foreach (var trainTest in result)
            {
                Console.WriteLine(trainTest.TrainName);
            }

            //FileReader p = new FileReader();
            //p.StreamReader();
            Station myInstance = new Station();
            myInstance.ListOfStations.ForEach(x => Console.WriteLine(x.StationName));
        }
    }
}
