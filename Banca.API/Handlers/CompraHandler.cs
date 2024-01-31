using AutoMapper;
using Banca.API.Commands.Compra;
using Banca.API.Queries.Compra;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories;
using Banca.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banca.API.Handlers
{
    public class CompraHandler
    {

        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraHandler(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
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
        public async Task<Compra> ObtenerCompra(ObtenerCompraPorIdQuery query)
        {
            return await _compraRepository.ObtenerPorIdAsync(query.CompraId);
        }
        public async Task EliminarCompra(EliminarCompraCommand command)
        {
            await _compraRepository.DeleteAsync(_mapper.Map<Compra>(command));
        }
    }
}
