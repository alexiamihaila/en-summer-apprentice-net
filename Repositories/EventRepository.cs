using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Api.Exceptions;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly practicaContext _dbContext;

        public EventRepository()
        {
            _dbContext = new practicaContext();
        }
        int IEventRepository.Add(Eventss @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Eventss @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Eventss> GetAll()
        {
            var events = _dbContext.Eventsses.Include(e => e.Venue).Include(e => e.EventType);

            return events;
        }

        public async Task<Eventss> GetById(int id)
        {
            var @event = await _dbContext.Eventsses.Where(e => e.EventId == id).Include(e => e.Venue).Include(e => e.EventType).FirstOrDefaultAsync();

            if (@event == null)
                throw new EntityNotFoundException(id, nameof(Eventss));

            return @event;
        }

        public void Update(Eventss @event)
        {
            _dbContext.Entry(@event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
