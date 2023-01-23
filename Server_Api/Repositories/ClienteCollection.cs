using MongoDB.Bson;
using MongoDB.Driver;
using Server_Api.Models;
using Server_Api.Repositories.Interfaces;

namespace Server_Api.Repositories
{
    public class ClienteCollection : IClienteCollection
    {
        internal MongoDBRepository _repository =  new MongoDBRepository();
        private IMongoCollection<Cliente> Collection;

        public ClienteCollection()
        {
            Collection = _repository.database.GetCollection<Cliente>("ClientesCollections");
        }
        public  async Task<List<Cliente>> GetClient()
        {
            return await Collection.FindAsync(d=>true).Result.ToListAsync();
        }

        public async Task<Cliente> GetClienteByID(string id)
        {
            return await Collection.FindAsync(d => d.Id == id).Result.FirstAsync();
        }

        public  Cliente GetClienteByNombre(string nombre)
        {
            return  Collection.FindAsync(
                new BsonDocument { { "Nombre", nombre } })
                .Result.First();
        }
    }
}
