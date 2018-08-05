using System;
using System.Collections.Generic;
using LiteDB;

namespace MediaHelper.Backend
{
    public abstract class Repository<TEntity> : IDisposable
    {
        private            LiteDatabase            _db;
        protected readonly LiteCollection<TEntity> Collection;

        protected Repository()
        {
            _db = new LiteDatabase(@"Local netflix");
            Collection = _db.GetCollection<TEntity>();

            DatabaseMapper.MapEntity();
        }

        public void AddOrUpdate(TEntity entity)
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