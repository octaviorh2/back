using Microsoft.AspNetCore.Mvc;
using Server_Api.Repositories;
using Server_Api.Repositories.Interfaces;

namespace Server_Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        private IClienteCollection database = new ClienteCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllCliente() {
            return Ok(await database.GetClient());    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(string id)
        {
            return Ok(await database.GetClienteByID(id));
        }

    }
}
