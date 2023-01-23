using Server_Api.Models;

namespace Server_Api.Repositories.Interfaces
{
    public interface IClienteCollection
    {
       Task<List<Cliente>> GetClient();
        Task<Cliente> GetClienteByID(string id);

    }
}
