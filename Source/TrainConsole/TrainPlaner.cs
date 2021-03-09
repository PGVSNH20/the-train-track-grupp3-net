using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEngine;

namespace TrainConsole
{
    class TrainPlaner : ITravelPlan
    {
        public List<object> TimeTable => throw new NotImplementedException();

        public object Train => throw new NotImplementedException();

        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }
    }
}
