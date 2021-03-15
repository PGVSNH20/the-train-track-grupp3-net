using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace TrainEngine.Reader
{
    public class FileReader
    {
        public List<string> StreamReader(string url)
        {
            List<string> list = new List<string>();
            try
            {
                // Startar stream, letar rätt på fil
                using (StreamReader streamReader = new StreamReader(url))
                {
                    string line;

                    // Läser filen & skriver ut
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                        //Console.WriteLine(line);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public TrackDescription ReadTrackDesc(string url)
        {
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

            List<string> stationsList = new List<string>();
            int holdRail = 0;
            List<int> rails = new List<int>();
            List<Passages> passagesList = new List<Passages>();
            try
            {
                // Startar stream, letar rätt på fil
                using (StreamReader streamReader = new StreamReader(url))
                {
                    string line;

                    // Läser filen & skriver ut
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        int index = 0;
                        foreach (var c in line)
                        {
                            index++;
                            if (c == '[') { if (holdRail != 0) { rails.Add(holdRail); holdRail = 0; } stationsList.Add(line[index].ToString()); }
                            if (c == '-') { holdRail++; }
                            if (c == '=') 
                            { 
                                Passages myPass = new Passages(); // Den går inte att assigna.. inte när jag provade tuple innan heller . Hjälp ?
                                myPass.Station = 1; 
                                myPass.RailsFromStation = holdRail; 
                                passagesList.Add(myPass);  
                                Console.WriteLine(myPass.RailsFromStation); 
                            }

                        }
                    }
                }
                TrackDescription myTrackDesc = new TrackDescription();
                myTrackDesc.Stations = stationsList;
                myTrackDesc.Rails = rails;
                myTrackDesc.MyPassages = passagesList;
                return myTrackDesc;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

