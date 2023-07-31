using System;
using System.Collections.Generic;

#nullable disable

namespace TMSApi.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? TicketCategoryId { get; set; }
        public DateTime? OrderedAt { get; set; }
        public int? NumberOfTickets { get; set; }
        public decimal? OrderTotalPrice { get; set; }

        public virtual TicketCategory TicketCategory { get; set; }
        public virtual User User { get; set; }
    }
}
