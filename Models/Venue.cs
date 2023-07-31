using System;
using System.Collections.Generic;

#nullable disable

namespace TMSApi.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Eventsses = new HashSet<Eventss>();
        }

        public int VenueId { get; set; }
        public string LocationName { get; set; }
        public string LocationType { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Eventss> Eventsses { get; set; }
    }
}
