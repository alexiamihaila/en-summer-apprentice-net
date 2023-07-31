using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private practicaContext _dbContext;
        public TicketCategoryRepository()
        {
            _dbContext = new practicaContext();
        }

        public async Task<TicketCategory> GetById(int id)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();
            return ticketCategory;
        }
    
    }
}
