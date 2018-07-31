using System;
using System.Collections.Generic;
using LiteDB;

namespace Localnetflix.Backend.Database
{
    public class Repository<TEntity> : IDisposable
    {
        private LiteDatabase            _db;
        private LiteCollection<TEntity> _collection;

        public Repository()
        {
            _db = new LiteDatabase(@"Local netflix");
            _collection = _db.GetCollection<TEntity>();
            
            DatabaseMapper.MapEntity();
        }

        public void InsertOfUpdate(TEntity entity)
        {
            _collection.Upsert(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.FindAll();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}