using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlan
    {
        List<object> TimeTable { get; }

        object Train { get; }

        void Save(string path);
        void Load(string path);

        ITravelPlan HeadTowards(object station);
        ITravelPlan StartTrainAt(object time);

        ITravelPlan StopTrainAt(object station, object time);
        ITravelPlan GeneratePlan();
    }
}