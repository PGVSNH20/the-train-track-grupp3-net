using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

