using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Reader;

namespace TrainEngine.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // GetPassengerData

        public Passenger()
        {

        }
        public Passenger(int passengerId, string passengerName)
        {
            Id = passengerId;
            Name = passengerName;
        }


        public List<Passenger> PopulateList()
        {
            var passengerUrl = @"..\..\..\..\..\Data\passengers.txt";
            FileReader p = new FileReader();
            List<string> result = p.StreamReader(passengerUrl);

            List<Passenger> passengerList = new List<Passenger>();

            foreach (var row in result)
            {
                passengerList.Add(GetPassengerData(row));
            }
            return passengerList;
        }

        public Passenger GetPassengerData(string dataRow)
        {
            char[] seperators = new char[] { ';', ':' };
            string[] dataCol = dataRow.Split(seperators);

            var passengerId = int.Parse(dataCol[0]);
            var passengerName = dataCol[1];
            return new Passenger(passengerId, passengerName);
        }

        // RandomizePassengerList
        public Passenger[,] RandomizePassengerList(List<Passenger> passengers)
        {
            Passenger[,] passengerArray = new Passenger[2, 0];
            return passengerArray;
        }
    }
}
