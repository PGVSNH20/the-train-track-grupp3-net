using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;

namespace TrainEngine.Models
{
    public class Station
    {
        public Station()
        {
            //ListOfStations = PopulateList(_stations);
        }
        static readonly string _stations = @"..\..\..\..\..\Data\stations.txt";

        // Id|StationName|EndStatio
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }

        public List<Station> ListOfStations { get; set; }

        public List<Station> PopulateList()
        {
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(_stations);

            List<Station> stationList = new List<Station>();

            bool hasSkippedFirstRow = false;
            foreach (var row in result)
            {
                if (hasSkippedFirstRow == false)
                {
                    hasSkippedFirstRow = true;
                    continue;
                }
                stationList.Add(GetStationData(row));
            }

            return stationList;
        }

        // Read a row from txt-file and split by pipes ="|"
        private static Station GetStationData(string dataRow)
        {
            string[] dataCol = dataRow.Split('|');

            return new Station
            {
                Id = int.Parse(dataCol[0]),
                StationName = dataCol[1],
                EndStation = bool.Parse(dataCol[2])
            };

        }
    }
}
