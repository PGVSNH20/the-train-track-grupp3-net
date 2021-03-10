using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEngine;
using TrainEngine.Models;

namespace TrainConsole
{
    class TrainPlaner : ITravelPlan
    {
        public List<object> TimeTable { get; set; }

        public object Train { get; set; }

        public object Trainstation { get; set; }

        public TrainPlaner(Train train, Station station)
        {
            Train = train;
            Trainstation = station;
        }

        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }

        public ITravelPlan HeadTowards(object station2)
        {
            return this;
        }

        public ITravelPlan StartTrainAt(object time)
        {
            return this;
        }
        public ITravelPlan StopTrainAt(object station, object time)
        {
            return this;
        }

        public ITravelPlan GeneratePlan()
        {
            return this;
        }
    }
}
