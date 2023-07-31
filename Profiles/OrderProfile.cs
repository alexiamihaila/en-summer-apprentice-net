using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;
using TMSApi.Models.Dto;
using AutoMapper;

namespace TMSApi.Profiles
{
    public class OrderProfile: Profile
    {         
        public OrderProfile()
        {
            CreateMap<Order, OrdersDto>().ReverseMap();
            CreateMap<OrderPatchDto, Order>().ReverseMap();
        }
        
    }
}
