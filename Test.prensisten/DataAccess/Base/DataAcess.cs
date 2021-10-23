

using MongoDB.Driver;


namespace Test.Presistence
{
    using System;
    using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Task AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(object key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void UpdatePartial(object item)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePartialAsync(object item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
