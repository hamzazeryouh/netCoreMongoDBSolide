using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Presistence.DataContext
{
    interface IRepository<T> :IDataRequest<T>,IDataAccess<T> where T : class
    {
    }
}
