using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Train
    {
        public int TrainId { get; set; }

        public string TrainName { get; set; }

        public int MaxSpeed { get; set; }

        public bool IsOperated { get; set; }
        public Train(int trainId, string trainName, int maxSpeed, bool isOperated)
        {
            TrainId = trainId;
            TrainName = trainName;
            MaxSpeed = maxSpeed;
            IsOperated = isOperated;
        }

    } 
}   

