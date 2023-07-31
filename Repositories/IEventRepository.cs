using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public interface IEventRepository
    {
        public IEnumerable<Eventss> GetAll();
        public Task<Eventss> GetById(int id);
        public int Add(Eventss @event);
        public void Update(Eventss @event);
        public void Delete(Eventss @event);

    }
}
