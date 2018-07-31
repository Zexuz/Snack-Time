using System;
using System.Collections.Generic;
using LiteDB;

namespace Localnetflix.Backend.Database
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity>
    {
        private LiteDatabase            _db;
        protected readonly LiteCollection<TEntity> Collection;

        protected Repository()
        {
            _db = new LiteDatabase(@"Local netflix");
            Collection = _db.GetCollection<TEntity>();
            
            DatabaseMapper.MapEntity();
        }

        public void InsertOfUpdate(TEntity entity)
        {
            Collection.Upsert(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.FindAll();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}