using AutoMapper;
using Banca.API.Commands.Compra;
using Banca.API.Handlers;
using Banca.API.Queries.Compra;
using Banca.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly CompraHandler _compraHandler;
        private readonly IMapper _mapper;


        public CompraController(CompraHandler compraHandler, IMapper mapper)
        {
            _compraHandler = compraHandler;
            _mapper = mapper;
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
        [HttpDelete]
        public async Task<IActionResult> EliminarCompra(EliminarCompraCommand command)
        {
            await _compraHandler.EliminarCompra(command);
            return Ok();
        }
    }

}
