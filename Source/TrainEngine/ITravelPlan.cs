using System;
using System.Collections.Generic;
using System.Text;
using TrainConsole;
using TrainEngine.Models;

namespace TrainEngine
{
    public interface ITravelPlan
    {
        List<Timetable> Timeplan { get; }

        Train Train { get; }

        void Save(string path);
        void Load(string path);

        ITravelPlan HeadTowards(Station station);
        ITravelPlan StartTrainAt(object time);

        ITravelPlan StopTrainAt(Station station, object time);
        ITravelPlan GeneratePlan();

        ITravelPlan Simulate();

    }
}