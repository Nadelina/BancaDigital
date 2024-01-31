using AutoMapper;
using Banca.API.Commands.Pago;
using Banca.API.Handlers;
using Banca.API.Queries.Pago;
using Banca.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly PagoHandler _pagoHandler;
        private readonly IMapper _mapper;


        public PagoController(PagoHandler pagoHandler, IMapper mapper)
        {
            _pagoHandler = pagoHandler;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pago>>> ObtenerPagosPorTitularId(int id)
        {
            var query = new PagosPorTitularIdQuery { TitularTarjetaId = id };
            return await _pagoHandler.PagosPorTitularIdAsync(query);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] CrearPagoCommand command)
        {
            await _pagoHandler.CrearPagoAsync(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarPago(EliminarPagoCommand command)
        {
            await _pagoHandler.EliminarPago(command);
            return Ok();
        }
    }
}
