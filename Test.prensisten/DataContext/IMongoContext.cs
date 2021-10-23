


namespace Test.Presistence.DataContext
{
    using MongoDB.Driver;
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
