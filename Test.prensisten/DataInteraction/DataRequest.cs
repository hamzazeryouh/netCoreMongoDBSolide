using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Presistence.DataContext;

namespace Test.Presistence.DataInteraction
{
    public class DataRequest<T> : IDataRequest<T> where T   : class
    {

        private readonly IMongoCollection<T> _collection;
        private readonly IMongoQueryable<T> _queryable;

        public DataRequest(IMongoContext context)
        {
            _collection = context.Database.GetCollection<T>(typeof(T).Name);
            _queryable = _collection.AsQueryable();
        }
        public IQueryable<T> Queryable => _collection.AsQueryable();

        public bool Any()
        {
            return _queryable.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _queryable.Where(where).Any();
        }

        public async Task<bool> AnyAsync()
        {
            return await _queryable.AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await _queryable.Where(where).AnyAsync();
        }

        public long Count()
        {
            return _queryable.LongCount();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return _queryable.Where(where).LongCount();
        }

        public async Task<long> CountAsync()
        {
            return await _queryable.LongCountAsync();
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return await _queryable.Where(where).LongCountAsync();
        }

        public T Get(object key)
        {
            return _collection.Find(Filters.Id<T>(key)).SingleOrDefault();
        }

        public async Task<T> GetAsync(object key)
        {
            return await _collection.Find(Filters.Id<T>(key)).SingleOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return _queryable.ToList();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
              return await _queryable.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await _queryable.Where(where).ToListAsync().ConfigureAwait(false);
        }
    }
}
