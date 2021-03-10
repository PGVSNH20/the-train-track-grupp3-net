using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Models
{
    class Station
    {
        // Id|StationName|EndStatio
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }

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
