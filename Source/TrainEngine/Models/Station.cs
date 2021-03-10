using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;

namespace TrainEngine.Models
{
    public class Station
    {
        public Station ()
        {            
            ListOfStations = PopulateList(_stations);
        }
        static readonly string _stations = @"..\..\..\..\..\Data\stations.txt";
        // Id|StationName|EndStatio
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }

        public List<Station> ListOfStations { get; set; }

        List<Station> PopulateList (string inputURL)
        {
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(inputURL);

            List<Station> newList = new List<Station>();
            foreach (var row in result)
            {
                newList.Add(GetStationData(row));
            }

            return newList;
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
