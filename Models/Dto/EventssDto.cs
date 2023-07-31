using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMSApi.Models.Dto
{
    public class EventssDto
    {   public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string Venue { get; set; }
        public  string EventType { get; set; }
       
    }
}
