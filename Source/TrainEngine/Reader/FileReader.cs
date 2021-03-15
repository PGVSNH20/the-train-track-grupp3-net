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

        public List<string> ReadTrackDesc(string url)
        {
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

            List<string> stationsList = new List<string>();
            int rail1 = 0;

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
                            if (c == '[')
                            {
                                stationsList.Add(line[index + 1].ToString());
                            }
                        }
                    }
                }
                return new List<string>();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return new List<string>();
            }
        }
    }
}

