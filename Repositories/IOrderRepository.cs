using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();
        public Task<Order> GetById(int id);
        public int Add(Order @event);
        public void Update(Order @event);
        public void Delete(Order @event);
    }
}
