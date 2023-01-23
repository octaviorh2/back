using MongoDB.Bson;
using MongoDB.Driver;
using Server_Api.Models;
using Server_Api.Repositories.Interfaces;
using System.Reflection;

namespace Server_Api.Repositories
{
    public class FacturaCollection : IFacturaCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Facturas> CollectionF;
        Facturas factura = new Facturas();
        private ClienteCollection db = new ClienteCollection();
        Cliente cliente = new Cliente();
        public FacturaCollection()
        {
            CollectionF = _repository.database.GetCollection<Facturas>("FacturasCollections");
        }
        public async Task<List<Facturas>> GetFactura()
        {
            return await CollectionF.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<List<Facturas>> GetFacturaClient(string Nombre)
        {
            return await CollectionF.FindAsync(
               new BsonDocument { { "Cliente", Nombre } })
               .Result.ToListAsync();
        }

        public async Task UpdateFacture( Facturas factura ,string id )
        {
            cliente =  db.GetClienteByNombre(factura.Cliente);   
            Correos correos = new Correos();
            var filter = Builders<Facturas>
                .Filter
                .Eq(s => s.Id, factura.Id);
            await CollectionF.ReplaceOneAsync(filter, factura);
            string body = correos.CorreoCambiosEstado(cliente.Correo, factura);
            correos.EnviarCorreo("oruedah@unicesar.edu.co", "cambio de estado", body, cliente.Correo);
        }
    }
}
