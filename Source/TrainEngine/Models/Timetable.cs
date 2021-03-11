using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;

namespace TrainEngine.Models
{
    public class Timetable
    {
        /*        
            TraindId,StationId,DepartureTime,ArrivalTime
            2,1,10:20,null
            2,2,10:45,10:43
            2,3,null,10:59
            3,3,10:23,null
            3,4,10:55,10:53
            3,1,null,11:15
         */
        public int Id { get; set; }
        public int StationId { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public Timetable()
        {

        }
        public Timetable(int id, int stationId, TimeSpan departureTimne, TimeSpan arrivalTime)
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
            var departureTime = TimeSpan.Parse(dataCol[2]);
            var arrivalTime = TimeSpan.Parse(dataCol[3]);

            return new Timetable(id, stationId, departureTime, arrivalTime);
        }


    }
}
