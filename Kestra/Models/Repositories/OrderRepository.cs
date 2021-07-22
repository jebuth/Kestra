using Kestra.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.Where(o => !o.Deleted);
        }

    }
}
