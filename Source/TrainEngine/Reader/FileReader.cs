using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TrainEngine.Reader
{
    public class FileReader
    {
        public void StreamReader(string url)
        {
            try
            {
                // Startar stream, letar rätt på fil
                using (StreamReader streamReader = new StreamReader(url))
                {
                    string line;

                    // Läser filen & skriver ut
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}

