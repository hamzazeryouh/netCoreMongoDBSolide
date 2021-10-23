

namespace Test.Presistence.DataContext
{
    using MongoDB.Driver;
    public class MongoContext : IMongoContext
    {
        protected MongoContext(string connectionString)
        {
            Database = new MongoClient(connectionString).GetDatabase(new MongoUrl(connectionString).DatabaseName);
        }
        public IMongoDatabase Database { get; }
    }
}
