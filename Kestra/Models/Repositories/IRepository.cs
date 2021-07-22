using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get();
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(int id);

    }
}
