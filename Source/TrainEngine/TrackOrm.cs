using System;
using TrainEngine.Reader;

namespace TrainEngine
{
    public class TrackOrm
    {
        public TrackDescription ParseTrackDescription(string trackUrl)
        {
            FileReader myReader = new FileReader();

            var parsedData = myReader.ReadTrackDesc(trackUrl);

            return new TrackDescription();
        }
    }
}