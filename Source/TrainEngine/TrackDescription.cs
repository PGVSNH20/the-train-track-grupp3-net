using System;
using System.Collections.Generic;

namespace TrainEngine
{
    public class TrackDescription
    {
        public int NumberOfTrackParts { get; set; }
        public List<string> Stations { get; set; }
        public List<int> Rails { get; set; }
        public List<Passages> MyPassages { get; set; }
    }
}
