﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMSApi.Models.Dto
{
    public class OrderPatchDto
    {
        public int OrderId { get; set; }
        public int? TicketCategoryId { get; set; }
        public int? NumberOfTickets { get; set; }
    }
}
