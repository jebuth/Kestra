using Kestra.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Repositories
{
    public class TickerRepository : ITickerRepository
    {

        private readonly AppDbContext context;

        public TickerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Ticker> GetAll()
        {
            return context.Tickers.Where(t => !t.Deleted);
        }

    }
}
