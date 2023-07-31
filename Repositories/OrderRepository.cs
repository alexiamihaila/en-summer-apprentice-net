using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly practicaContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new practicaContext();
        }
      
        public int Add(Order @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefaultAsync();

            return order;
        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
