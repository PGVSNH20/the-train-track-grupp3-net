using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEngine.Reader;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainConsole
{
    public class Train
    {

        public int TrainId { get; set; }

        public string TrainName { get; set; }

        public int MaxSpeed { get; set; }

        public bool IsOperated { get; set; }
        public Train()
        {

        }
        public Train(int trainId, string trainName, int maxSpeed, bool isOperated)
        {
            TrainId = trainId;
            TrainName = trainName;
            MaxSpeed = maxSpeed;
            IsOperated = isOperated;
        }

        public List<Train> PopulateList()
        {
            var trainUrl = @"..\..\..\..\..\Data\trains.txt";
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(trainUrl);

            List<Train> trainList = new List<Train>();

            bool hasSkippedFirstRow = false;
            foreach (var row in result)
            {

                if (hasSkippedFirstRow == false)
                {
                    hasSkippedFirstRow = true;
                    continue;
                }

                trainList.Add(GetTrainData(row));

            }
            return trainList;
        }

        private Train GetTrainData(string dataRow)
        {
            string[] dataCol = dataRow.Split(',');

            var trainId = int.Parse(dataCol[0]);
            var trainName = dataCol[1];
            var maxSpeed = int.Parse(dataCol[2]);
            var isOperated = bool.Parse(dataCol[3]);

            return new Train(trainId, trainName, maxSpeed, isOperated);
        }

        public Train GetTrainByIdThroughList(int? id, List<Train> list)
        {
            foreach (var train in list)
            {
                if (id.Equals(train.TrainId)) return train;
            }
            return null;

        }
        //public Func<int, List<Train>, Train> GetTrainByIdThroughList = (id, list) =>
        //    id.Equals(list.ForEach(x => id == x.TrainId))





    }
}

