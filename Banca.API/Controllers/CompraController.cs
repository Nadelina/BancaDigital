using Banca.API.Commands.Compra;
using Banca.API.Handlers;
using Banca.API.Queries.Compra;
using Banca.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly CompraHandler _compraHandler;

        public CompraController(CompraHandler compraHandler)
        {
            _compraHandler = compraHandler;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Compra>>> ObtenerComprasPorTitularId(int id)
        {
            var query = new ComprasPorTitularIdQuery { TitularTarjetaId = id };
            return await _compraHandler.ComprasPorTitularIdAsync(query);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCompra([FromBody] CrearCompraCommand command)
        {
            await _compraHandler.CrearCompraAsync(command);
            return Ok();
        }
    }

}
