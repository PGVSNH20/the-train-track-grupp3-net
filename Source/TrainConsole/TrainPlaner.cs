using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEngine;
using TrainEngine.Models;

namespace TrainConsole
{
    class TrainPlaner : ITravelPlan
    {

        public List<object> TimeTable { get; set; }

        public object Train { get; set; }

        public object Trainstation { get; set; }


        public Station StartStation { get; set; }

        public Station EndStation { get; set; } 
       


        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public TrainPlaner(Train train, Station station)
        {
            Train = train;
            Trainstation = station;
        }

        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }

        public ITravelPlan HeadTowards(object station2)
        {

            return this;
        }

        public ITravelPlan StartTrainAt(object time)
        {
            return this;
        }
        public ITravelPlan StopTrainAt(object station, object time)
        {
            //Station endStation = new Station();
            var endStation = station as Station;

            this.EndStation = endStation.EndStation == true ?  station as Station : null;

            this.ArrivalTime = TimeSpan.Parse(time.ToString());
            return this;
            //if ((station as Station).EndStation)
            //{
            //    this.EndStation = endStation;
            //    return this;
            //}
            //else
            //{
            //    return null;
            //    Console.WriteLine("Ingen slutstation");
            //}
            // Tar in tågstation och kollar genom stations.stationlist ifall stationen är en slutstation och returnerar isf annars så skrivs felmeddelande ut
           
        }

        public ITravelPlan GeneratePlan()
        {
            // Implement depaturetime later;
            string startTime = "10:45:00";

            Station startStation = this.Trainstation as Station;

            Console.WriteLine("Avgång:");
            Console.WriteLine(startStation.StationName + " - " + this.EndStation.StationName);
            Console.WriteLine();
            Console.WriteLine($"{startTime}\t{startStation.StationName}" +
                $"\t{ (this.Train as Train).TrainName}");
            Console.WriteLine($"{this.ArrivalTime.ToString()}\t{this.EndStation.StationName}" +
                 $"\t{ (this.Train as Train).TrainId}");
            return this;
        }
    }
}
