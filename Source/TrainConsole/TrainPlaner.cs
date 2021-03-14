using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TrainEngine;
using TrainEngine.Models;

namespace TrainConsole
{
    class TrainPlaner : ITravelPlan
    {
        public List<Timetable> Timeplan { get; set; } = new List<Timetable>();

        public Train Train { get; set; }

        public Station Trainstation { get; set; } = new Station();

        public TrainPlaner(Train train, Station station)
        {
            Train = train;
            Trainstation = station;

            // Kollar om tåget är en slutstation för då kan det även vara en startstation
            Timetable startstation = new Timetable();
            startstation.Id = train.TrainId;
            startstation.StationId = station.Id;
            
            Timeplan.Add(startstation);
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
            //this.DepartureTime = TimeSpan.Parse(time.ToString());

            foreach (var train in Timeplan)
            {
                if (train.DepartureTime == null)
                {
                    train.DepartureTime = DateTime.Parse(time.ToString());
                    break;
                }
            }
            return this;
        }

        public ITravelPlan StopTrainAt(Station station, object time)
        {
            Station startStation = this.Trainstation;


            /*
             61

            List<int> initializers = new List <int>();

            initializers.Add(1);
            initializers.Add(3);

            int index = initializers.IndexOf(3);
            initializers.Insert(index, 2);
             
             */
           
            if (station.EndStation == false)
            {
                Timetable middlestation = new Timetable();

                int endstationIndex = Timeplan.Count - 1;
                int index = (Timeplan.Count > 1) ? endstationIndex : 0;

                middlestation.Id = this.Train.TrainId;
                middlestation.StationId = station.Id;
                middlestation.ArrivalTime = DateTime.Parse(time.ToString());
                Timeplan.Insert(endstationIndex, middlestation);

            }

            foreach (var location in Timeplan)
            {
                if (location.StationId == startStation.Id) continue; // Enligt unittest ska den skriva ut tågnnamn och id om den är ensam

                if (station.EndStation == true && location.DepartureTime == null) // Är det inte startstationen och 
                {
                    location.ArrivalTime = DateTime.Parse(time.ToString());
                    break;
                }
                else if (station.Id != startStation.Id && location.ArrivalTime == null) // Får kika senare m den ska ta bort
                {
                    location.ArrivalTime = DateTime.Parse(time.ToString());
                    break;
                }
            }

            return this;

        }
        private string ReturnNameFromId(int stationId, List<Station> stations)
        {
            foreach (var station in stations)
            {
                if (stationId.Equals(station.Id))
                {
                    return station.StationName;
                }
            }
            return "Station not found";  
   
        }


        public ITravelPlan GeneratePlan()
        {
            var trainstations = Trainstation.PopulateList();

            int endStationId = this.Timeplan[Timeplan.Count - 1].StationId;
            string endStationName = ReturnNameFromId(endStationId, trainstations);


            Console.WriteLine(Trainstation.StationName + " - " + endStationName );
            Console.WriteLine(Train.TrainName);
            Console.WriteLine($"[{Train.TrainId}]".PadLeft(Train.TrainName.Length));
            Console.WriteLine("--------------------------------------------------");

            foreach (var row in Timeplan)
            {
                Console.WriteLine(row.Id + " " + ReturnNameFromId(row.StationId, trainstations) + " " +  row.DepartureTime + " " +  row.ArrivalTime);
            }

            Console.WriteLine("============================================================");

         

            foreach (var trainTimePlan in Timeplan)
            {
                string station = ReturnNameFromId(trainTimePlan.StationId, trainstations);


                Console.WriteLine(station);
                if (trainTimePlan.ArrivalTime.HasValue) 
                    Console.WriteLine("Ankomst: ".PadRight(10) + 
                        DateToDisplayShort(trainTimePlan.ArrivalTime));
                
                if (trainTimePlan.DepartureTime.HasValue)  
                    Console.WriteLine("Avgång: ".PadRight(10) + 
                        DateToDisplayShort(trainTimePlan.DepartureTime));
               
                Console.WriteLine();
            }

            return this;
        }
        public ITravelPlan Simulate()
        {
            // loadPlan laddar StartStation - Slutstation respektive start & sluttid samt Tågnamn + Id


            var trainstations = Trainstation.PopulateList();
            int endStationId = this.Timeplan[Timeplan.Count - 1].StationId;
            string endStationName = ReturnNameFromId(endStationId, trainstations);

            const int aDayInMinutes = 1440;
            //TimeSpan openingTime = new TimeSpan(5, 30, 0).TotalMinutes;
            int openHours = (int)new TimeSpan(5, 30, 0).TotalMinutes;

            string train = Train.TrainName;

            string station1 = this.Trainstation.StationName;
            string station2 = endStationName;


            Timetable stationOne = new Timetable();
            Timetable stationTwo = new Timetable();
            stationOne = Timeplan[0];
            stationTwo = Timeplan[1];

            //DateTime minutos = stationOne.DepartureTime.Value;
            //DateTime dygn = new DateTime(24, 0, 0);

            //////Func<DateTime, DateTime, TimeSpan> GetTotalMinutes = (DateTime time, DateTime day) => day - time;
            //double inMinutes = GetTotalMinutes(minutos, dygn).TotalMinutes;
            
            for (int min = openHours; min < aDayInMinutes; min++)
            {
                bool IsInWholeHour = min % 60 == 0;
                int hour = min / 60;

                if (IsInWholeHour) Console.WriteLine("Kl:" + hour + ":00");

                if (min == GetTotalMinutes(stationOne.DepartureTime))
                {
                    Console.WriteLine("Kl:" + DateToDisplayShort(stationOne.DepartureTime) + ":00");
                    Console.WriteLine($"{train} kör från {station1} till {station2}");
                }
                if (min == GetTotalMinutes(stationTwo.ArrivalTime))
                {
                    Console.WriteLine("Kl:" + DateToDisplayShort(stationTwo.ArrivalTime) + ":00");
                    Console.WriteLine($"{train} anlände till {station2} till {station1}");
                }

            }
            Console.ReadKey();
            return this;
        }

        Func<DateTime?, int> GetTotalMinutes = x => (x.Value.Hour * 60) + x.Value.Minute;
        Func<DateTime?, string> DateToDisplayShort = d => d.Value.ToString("t").PadLeft(10);
    }
}
