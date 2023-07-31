using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;
using TMSApi.Models.Dto;
using TMSApi.Repositories;

namespace TMSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public ActionResult<List<OrdersDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(e => new OrdersDto()
            {
               OrderId = e.OrderId,
               TicketCategoryDescription = e.TicketCategory?.TicketCategoryDescription?? string.Empty,
               NumberOfTickets = e.NumberOfTickets,
               OrderTotalPrice = e.OrderTotalPrice,
            });

            return Ok(dtoOrders);
        }

        [HttpGet]

        public async Task<ActionResult<OrdersDto>> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var dtoOrder = _mapper.Map<OrdersDto>(order);

            return Ok(dtoOrder);
        }

        
        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatchDto)
        {
            var orderEntity = await _orderRepository.GetById(orderPatchDto.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }

            if (orderPatchDto.TicketCategoryId != 0)
            {
                var ticketCategory = await _ticketCategoryRepository.GetById((int)orderPatchDto.TicketCategoryId);

                if (ticketCategory == null)
                {
                    return NotFound("Ticket category not found");
                }

                float orderTotalPrice = (float)(ticketCategory.TicketCategoryPrice * orderPatchDto.NumberOfTickets);
                orderEntity.OrderTotalPrice = (decimal?)orderTotalPrice;
            }
            else
            {
                return NotFound("Ticket category ID is missing or invalid");
            }

            _mapper.Map(orderPatchDto, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}
