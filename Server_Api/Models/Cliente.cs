using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Server_Api.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? CC { get; set; }
        public string? Correo { get; set; }
    }
}
