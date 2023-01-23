using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace Server_Api.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase database;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Facturas_Monolegal");
        }

    }
}
