using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainEngine;
using TrainEngine.Models;

namespace TrainConsole
{
    class TrainPlaner : ITravelPlan
    {
        private Timetable timetable = new Timetable();
        public List<Timetable> Timeplan { get; set; } = new List<Timetable>();


        public Train Train { get; set; }

        public Station Trainstation { get; set; } = new Station();

        // Cuttar dem här
        public Station StartStation { get; set; }

        public List<Station> StationsBeetween { get; set; }
        public List<TimeSpan> StopTimes { get; set; } = new List<TimeSpan>();
        public Station EndStation { get; set; }

        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public TrainPlaner(Train train, Station station)
        {
            Train = train;
            Trainstation = station;
            StartStation = station; // Remooooooove later aligator!

            timetable.Id = train.TrainId;
            timetable.StationId = station.Id;


            Timeplan.Add(timetable);


        }

        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(this, options);

            Console.WriteLine("Sparar...");

            string fullPath = @$"{path}travelPlans-{Train.TrainId}-{Train.TrainName}-{DateTime.Now.ToString("dd/MM/yyyy")}.json";
            File.WriteAllText(fullPath, jsonString);
        }

        public ITravelPlan HeadTowards(Station station2)
        {
            // Slustation
            var endStation = station2 as Station;
            this.EndStation = endStation.EndStation == true ? station2 as Station : null;

            if (station2.EndStation)
            {
                Timetable endstation = new Timetable();

                endstation.Id = this.Train.TrainId;
                endstation.StationId = station2.Id;
                Timeplan.Add(endstation);
            }
            else Console.WriteLine("Ingen ändstation det här inte");

            return this;
        }

        public ITravelPlan StartTrainAt(object time)
        {
            this.DepartureTime = TimeSpan.Parse(time.ToString());

            foreach (var train in Timeplan)
            {
                if (train.DepartureTime == null)
                {
                    train.DepartureTime = TimeSpan.Parse(time.ToString());
                    break;
                }
            }
            return this;
        }
        public ITravelPlan StopTrainAt(Station station, object time)
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

            foreach (var train in Timeplan)
            {
                if (train.DepartureTime == null) // Är det inte startstationen och 
                {
                    train.ArrivalTime = TimeSpan.Parse(time.ToString());
                    break;
                }
            }


            return this;

        }

        public ITravelPlan GeneratePlan()
        {

            Station startStation = this.Trainstation as Station;

            Console.WriteLine("Avgång:");
            Console.WriteLine(StartStation.StationName + " - " + this.EndStation.StationName);
            Console.WriteLine();
            Console.WriteLine($"{this.DepartureTime}\t{StartStation.StationName}" +
                $"\t{ (this.Train as Train).TrainName}");

            Console.WriteLine($"{this.ArrivalTime.ToString()}\t{this.EndStation.StationName}" +
                 $"\t{ (this.Train as Train).TrainId}");
            Console.WriteLine("\n");

            // Skriver ut bäst från lista istället för att initera massa propertyes

            string endstation = Timeplan[Timeplan.Count - 1].StationId.ToString() ;

            foreach (var station in Trainstation.PopulateList())
            {
                if (endstation == station.Id.ToString())
                {
                    endstation = station.StationName;
                    break;
                }
            }

            Console.WriteLine(Trainstation.StationName + " - " + endstation);
            Console.WriteLine(Train.TrainName);
            Console.WriteLine($"[{Train.TrainId}]".PadLeft(Train.TrainName.Length));
            Console.WriteLine("--------------------------------------------------");

            foreach (var trainTimePlan in Timeplan)
            {
   
                foreach (var station in Trainstation.PopulateList())
                {
                    if (trainTimePlan.StationId == station.Id)
                    {
                        Console.WriteLine(station.StationName);
                        break;
                    }
                }
                if (trainTimePlan.DepartureTime.HasValue)   Console.WriteLine("Avgång: " + trainTimePlan.DepartureTime);
                if(trainTimePlan.ArrivalTime.HasValue)      Console.WriteLine("Ankomst: " + trainTimePlan.ArrivalTime);
                
                Console.WriteLine();
            }


            return this;
        }
        public ITravelPlan Simulate()
        {
            // loadPlan laddar StartStation - Slutstation respektive start & sluttid samt Tågnamn + Id

            const int aDayInMinutes = 1440;
            //TimeSpan openingTime = new TimeSpan(5, 30, 0).TotalMinutes;
            int openHours = (int)new TimeSpan(5, 30, 0).TotalMinutes;


            string train = (this.Train as Train).TrainName;

            string station1 = this.StartStation.StationName;
            string station2 = this.EndStation.StationName;



            for (int min = openHours; min < aDayInMinutes; min++)
            {
                bool IsInWholeHour = min % 60 == 0;
                int hour = min / 60;

                if (IsInWholeHour) Console.WriteLine("Kl:" + hour + ":00");

                if (min == this.DepartureTime.TotalMinutes)
                {
                    Console.WriteLine("Kl:" + this.DepartureTime.ToString() + ":00");
                    Console.WriteLine($"{train} kör från {station1} till {station2}");
                }
                if (min == this.ArrivalTime.TotalMinutes)
                {
                    Console.WriteLine("Kl:" + this.ArrivalTime.ToString() + ":00");
                    Console.WriteLine($"{train} anlände till {station2} till {station1}");
                }
            }
            Console.ReadKey();
            return this;
        }
    }
}
