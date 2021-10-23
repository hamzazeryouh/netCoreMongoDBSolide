﻿

namespace Test.Presistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDataAccess<T>
    where T : class
    {
        void Add(T item);

        Task AddAsync(T item);

        void AddRange(IEnumerable<T> items);

        Task AddRangeAsync(IEnumerable<T> items);

        void Delete(object key);

        void Delete(Expression<Func<T, bool>> where);

        Task DeleteAsync(object key);

        Task DeleteAsync(Expression<Func<T, bool>> where);

        void Update(T item);

        Task UpdateAsync(T item);

        void UpdatePartial(object item);

        Task UpdatePartialAsync(object item);

        void UpdateRange(IEnumerable<T> items);

        Task UpdateRangeAsync(IEnumerable<T> items);
    }
    
}
