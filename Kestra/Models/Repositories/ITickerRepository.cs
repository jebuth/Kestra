using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Repositories
{
    public interface ITickerRepository
    {
        IEnumerable<Ticker> GetAll();
    }
}
