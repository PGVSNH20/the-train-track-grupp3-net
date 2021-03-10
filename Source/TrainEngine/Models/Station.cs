using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Utilities;

namespace TrainEngine.Models
{
    public class Station
    {
        // Id|StationName|EndStatio

        public Station[] Stations { get; set; } = populateStationArr();



        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }

        }
        public Station (int id, string stationsName, bool endStationName)
        {
            Id = id;
            StationName = stationsName;
            EndStation = endStationName;
        }
        
        public List<Station> PopulateList()
        {

            string[] dataCol = dataRow.Split('|');

            return new Station
            {
                Id = int.Parse(dataCol[0]),
                StationName = dataCol[1],
                EndStation = bool.Parse(dataCol[2])

            };

        }

       
        public static Station[] populateStationArr()
        {
            var dataCollection = TextParser.StreamReader(@"C:\Users\joand\Documents\GitHub\the-train-track-grupp3-net\Source\TrainEngine\Reader\TxtFiles\stations.txt");

            List<Station> dataToOutput = new List<Station>();

            foreach (var line in dataCollection)
            {
               dataToOutput.Add( GetStationData(line));
            }
            return dataToOutput.ToArray();

            //this.Stations;

        }
    }
}
