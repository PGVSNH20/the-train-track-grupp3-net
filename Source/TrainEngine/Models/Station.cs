using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;

namespace TrainEngine.Models
{
    public class Station
    {
        static readonly string _stations = @"..\..\..\..\..\Data\stations.txt";
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
        public Station()
        {

        }
        public Station (int id, string stationsName, bool endStationName)
        {
            Id = id;
            StationName = stationsName;
            EndStation = endStationName;
        }
        
        public List<Station> PopulateList()
        {
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(_stations);

            List<Station> ListOfStations = new List<Station>();

            bool hasSkippedFirstRow = false;
            foreach (var row in result)
            {

                if (hasSkippedFirstRow == false)
                {
                    hasSkippedFirstRow = true;
                    continue;
                }

                ListOfStations.Add(GetStationData(row));

            }
            return ListOfStations;
        }


        // Read a row from txt-file and split by pipes ="|"
        private static Station GetStationData(string dataRow)
        {
            string[] dataCol = dataRow.Split('|');

            var id = int.Parse(dataCol[0]);
            var StationName = dataCol[1];
            var EndStation = bool.Parse(dataCol[2]);

            return new Station(id, StationName, EndStation);
        }
    }
}
