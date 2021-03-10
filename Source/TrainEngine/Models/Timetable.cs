using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Models
{
    class Timetable
    {
        /*        
            TraindId,StationId,DepartureTime,ArrivalTime
            2,1,10:20,null
            2,2,10:45,10:43
            2,3,null,10:59
            3,3,10:23,null
            3,4,10:55,10:53
            3,1,null,11:15
         */
        public int Id { get; set; }
        public int StationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


    }
}
