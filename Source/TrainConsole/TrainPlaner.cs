﻿using System;
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

        public List<Station> StationsBeetween { get; set; } = new List<Station>();
        public List<TimeSpan> StopTimes { get; set; } = new List<TimeSpan>();
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
            // Slustation
            var endStation = station2 as Station;
            this.EndStation = endStation.EndStation == true ? station2 as Station : null;

            return this;
        }

        public ITravelPlan StartTrainAt(object time)
        {
            this.DepartureTime = TimeSpan.Parse(time.ToString());
            return this;
        }
        public ITravelPlan StopTrainAt(object station, object time)
        {
            //Station endStation = new Station();
            Station stopStation = station as Station;

            if (stopStation.StationName == this.EndStation.StationName)
            {
                this.EndStation = stopStation;
                this.ArrivalTime = TimeSpan.Parse(time.ToString());
            }
            // Mellanliggande station sparas i en lista
            else
            {
                this.StationsBeetween.Add(stopStation);
                this.StopTimes.Add(TimeSpan.Parse(time.ToString()));
            }
            
            return this;
 
        }

        public ITravelPlan GeneratePlan()
        {
            // Implement depaturetime later;
            string startTime = "10:45:00";

            Station startStation = this.Trainstation as Station;

            Console.WriteLine("Avgång:");
            Console.WriteLine(startStation.StationName + " - " + this.EndStation.StationName);
            Console.WriteLine();
            Console.WriteLine($"{this.DepartureTime}\t{startStation.StationName}" +
                $"\t{ (this.Train as Train).TrainName}");
            if (StationsBeetween.Count > 0)
            {
                Console.WriteLine("Massa mellanligande stationer");
                for (int i = 0; i < StationsBeetween.Count; i++)
                {
                    Console.WriteLine(StationsBeetween[i]);
                    Console.WriteLine(StopTimes[i]);
                }
            }
            Console.WriteLine($"{this.ArrivalTime.ToString()}\t{this.EndStation.StationName}" +
                 $"\t{ (this.Train as Train).TrainId}");
            return this;
        }

    }
}
