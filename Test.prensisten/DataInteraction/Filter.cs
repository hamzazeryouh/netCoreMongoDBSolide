
namespace Test.Presistence
{
    using MongoDB.Driver;

    public static class Filters
    {
        public static FilterDefinition<T> Id<T>(object value)
        {
            return Builders<T>.Filter.Eq(nameof(Id), value);
        }
    }
}
