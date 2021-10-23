

using MongoDB.Driver;


namespace Test.Presistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Test.Presistence.DataContext;
    public class DataAcess<T> : IDataAccess<T> where T : class
    {

        private readonly IMongoCollection<T> _collection;

        public DataAcess(IMongoContext context)
        {
            _collection = context.Database.GetCollection<T>(typeof(T).Name);
        }
        public void Add(T item)
        {
            _collection.InsertOne(item);
        }

        public async Task AddAsync(T item)
        {
            await _collection.InsertOneAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _collection.InsertMany(items);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
             await _collection.InsertManyAsync(items);
        }

        public void Delete(object key)
        {
            _collection.DeleteOne(Filters.Id<T>(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
             _collection.DeleteManyAsync(where);
        }

        public async Task DeleteAsync(object key)
        {
            await _collection.DeleteOneAsync(Filters.Id<T>(key));
        }

        public async Task  DeleteAsync(Expression<Func<T, bool>> where)
        {
             await _collection.DeleteManyAsync(where);
        }

        public void Update(T item)
        {
            _collection.ReplaceOne(Filters.Id<T>(GetKey(item)),item);
        }

        public async Task UpdateAsync(T item)
        {
            await _collection.ReplaceOneAsync(Filters.Id<T>(GetKey(item)), item);
        }

        public void UpdatePartial(object item)
        {
            _collection.ReplaceOne(Filters.Id<T>(GetKey(item)), item as T);
        }

        public async Task UpdatePartialAsync(object item)
        {
             await _collection.ReplaceOneAsync(Filters.Id<T>(GetKey(item)), item as T);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _collection.BulkWrite(CreateUpdates(items));
        }

        public Task UpdateRangeAsync(IEnumerable<T> items)
        {
            return _collection.BulkWriteAsync(CreateUpdates(items));
        }
        private static IEnumerable<WriteModel<T>> CreateUpdates(IEnumerable<T> items)
        {
            return (from item in items let key = GetKey(item) where key != null  select new ReplaceOneModel<T>(Filters.Id<T>(key), item)).Cast<WriteModel<T>>().ToList();
        }

        private static object GetKey(object item) => item.GetType().GetProperty("Id")?.GetValue(item, default);
    }
}
