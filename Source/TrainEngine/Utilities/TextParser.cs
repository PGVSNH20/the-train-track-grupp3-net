using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainEngine.Utilities
{
    public class TextParser
    {

        public static List<string> StreamReader(string path)
        {
            try
            {
                List<string> row = new List<string>();
                // Startar stream, letar rätt på fil
                using (StreamReader streamReader = new StreamReader(path))
                {

                    string line;
                    // Läser filen & skriver ut
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        row.Add(line);
                    }
                    return row;
                }
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

