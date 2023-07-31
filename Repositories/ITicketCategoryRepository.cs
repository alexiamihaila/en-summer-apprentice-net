using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;

namespace TMSApi.Repositories
{
    public interface ITicketCategoryRepository
    {
        public Task<TicketCategory> GetById(int id);
    }
}
