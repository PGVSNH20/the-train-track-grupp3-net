using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;
using TrainConsole;

namespace TrainEngine.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public Timetable()
        {

        }
        public Timetable(int id, int stationId, DateTime departureTimne, DateTime arrivalTime)
        {
            Id = id;
            StationId = stationId;
            DepartureTime = departureTimne;
            ArrivalTime = arrivalTime;
        }
        public List<Timetable> PopulateList(string inputURL)
        {
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(inputURL);

            List<Timetable> trainList = new List<Timetable>();

            bool hasSkippedFirstRow = false;
            foreach (var row in result)
            {
                if (hasSkippedFirstRow == false)
                {
                    hasSkippedFirstRow = true;
                    continue;
                }

                trainList.Add(GetTimeTableData(row));
            }
            return trainList;
        }

        private Timetable GetTimeTableData(string dataRow)
        {
            string[] dataCol = dataRow.Split(',');

            var id = int.Parse(dataCol[0]);
            var stationId = int.Parse(dataCol[1]);
            var departureTime = DateTime.Parse(dataCol[2]);
            var arrivalTime = DateTime.Parse(dataCol[3]);

            return new Timetable(id, stationId, departureTime, arrivalTime);
        }


    }
}
