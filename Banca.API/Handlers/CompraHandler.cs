using Banca.API.Commands.Compra;
using Banca.API.Queries.Compra;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banca.API.Handlers
{
    public class CompraHandler
    {

        private readonly ICompraRepository _compraRepository;

        public CompraHandler(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task CrearCompraAsync(CrearCompraCommand command)
        {
            var compra = new Compra
            {
                TitularTarjetaId = command.TitularTarjetaId,
                Fecha = command.Fecha,
                Descripcion = command.Descripcion,
                Monto = command.Monto
            };

            await _compraRepository.CreateAsync(compra);
        }
        public async Task<List<Compra>> ComprasPorTitularIdAsync(ComprasPorTitularIdQuery query)
        {
            return await _compraRepository.GetAll().Where(x => x.TitularTarjetaId == query.TitularTarjetaId).ToListAsync();
        }
    }
}
