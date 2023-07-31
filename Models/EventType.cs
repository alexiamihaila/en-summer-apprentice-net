using System;
using System.Collections.Generic;

#nullable disable

namespace TMSApi.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Eventsses = new HashSet<Eventss>();
        }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }

        public virtual ICollection<Eventss> Eventsses { get; set; }
    }
}
