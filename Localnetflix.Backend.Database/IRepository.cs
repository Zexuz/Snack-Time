using System.Collections.Generic;

namespace Localnetflix.Backend.Database
{
    public interface IRepository<TEntity>
    {
        void                 InsertOfUpdate(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void                 Dispose();
    }
}