using Banca.API.Handlers;
using Banca.API.Queries.TitularTarjeta;
using Banca.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitularTarjetaController : ControllerBase
    {
        private readonly TitularTarjetaHandler _handler;

        public TitularTarjetaController(TitularTarjetaHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TitularTarjeta>> Get(int id)
        {
            var query = new ObtenerTitularTarjetaQuery { TitularTarjetaId = id };
            var titularTarjeta = await _handler.Handle(query);

            if (titularTarjeta == null)
                return NotFound();

            return titularTarjeta;
        }
    }
}

