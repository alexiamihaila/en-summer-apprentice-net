using System;
using System.Collections.Generic;

#nullable disable

namespace TMSApi.Models
{
    public partial class Eventss
    {
        public Eventss()
        {
            TicketCategories = new HashSet<TicketCategory>();
        }

        public int EventId { get; set; }
        public int? VenueId { get; set; }
        public int? EventTypeId { get; set; }
        public string EventDescription { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<TicketCategory> TicketCategories { get; set; }
    }
}
