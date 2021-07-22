using Kestra.Models.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext context;

        public TransactionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Transaction Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.Transactions.Include(t => t.Order).Include(t => t.Ticker);
        }

        public void Create(Transaction entity)
        {
            context.Transactions.Add(entity);
            context.SaveChanges();
        }

        public Transaction Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
