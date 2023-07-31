using System;
using System.Collections.Generic;

#nullable disable

namespace TMSApi.Models
{
    public partial class TicketCategory
    {
        public TicketCategory()
        {
            Orders = new HashSet<Order>();
        }

        public int TicketCategoryId { get; set; }
        public int? EventId { get; set; }
        public string TicketCategoryDescription { get; set; }
        public decimal? TicketCategoryPrice { get; set; }

        public virtual Eventss Event { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
