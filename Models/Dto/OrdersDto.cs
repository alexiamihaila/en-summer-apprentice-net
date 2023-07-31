using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMSApi.Models.Dto
{
    public class OrdersDto
    {
        public int OrderId { get; set; }
        public string? TicketCategoryDescription { get; set; }
        public int? NumberOfTickets { get; set; }
        public decimal? OrderTotalPrice { get; set; }
      
    }

}
