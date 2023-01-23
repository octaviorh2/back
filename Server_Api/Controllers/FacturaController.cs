using Microsoft.AspNetCore.Mvc;
using Server_Api.Repositories.Interfaces;
using Server_Api.Repositories;
using Server_Api.Models;

namespace Server_Api.Controllers
{


    [Route("api/[Controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private IFacturaCollection database = new FacturaCollection();
        
        [HttpGet]
        public async Task<IActionResult> GetAllCliente()
        {
            return Ok(await database.GetFactura());
        }

        [HttpGet("{nombre}")]
        public async Task<IActionResult> GetCliente(string nombre)
        {
            return Ok(await database.GetFacturaClient(nombre));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura([FromBody]Facturas facturas ,string id)
        {
            if (id == null)
                return BadRequest();
            if (facturas.Estado == "PrimerRecordatorio")
            {
                facturas.Estado = "SegundoRecordatorio";
            }
            else
            {
                facturas.Estado = "Desactivado";
            }
            await database.UpdateFacture(facturas,id);
            return Created("update", true);
        }
    }
}
