using Server_Api.Models;

namespace Server_Api.Repositories.Interfaces
{
    public interface IFacturaCollection
    {
        Task<List<Facturas>> GetFactura();
        Task<List<Facturas>> GetFacturaClient(string Nombre);
        Task UpdateFacture(Facturas factura, string id);
    }
}
