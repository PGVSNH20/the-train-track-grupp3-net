using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TrainEngine.Reader
{
    public class FileReader
    {
        public void StreamReader()
        {
            try
            {
                // Startar stream, letar rätt på fil
                using (StreamReader streamReader = new StreamReader(@"C:\Users\magnu\OneDrive\Skrivbord\.NetUtveckling\Dataåtkomster i .NET\Gruppuppgift\TheTrainTrack\Source\TrainEngine\Reader\TxtFiles\passengers.txt"))
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

