using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server_Api.Models
{
    public class Facturas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? CodigoFactura { get; set; }
        public  string? Ciudad { get; set; }
        public string? Nit { get; set; }
        public string? TotalFactura { get; set; }
        public string? Subtotal { get; set; }
        public string? Iva { get; set; }
        public string? Retencion { get; set; }
        public string? FechaCreacion { get; set; }
        public string? Estado { get; set; }
        public Boolean Pagada { get; set; }
        public string? Cliente { get; set; }
        public string? FechaPago { get; set; }
    }
}
