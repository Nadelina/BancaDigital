using AutoMapper;
using Banca.API.Commands.Pago;
using Banca.API.Queries.Pago;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banca.API.Handlers
{
    public class PagoHandler
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public PagoHandler(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }

        public async Task CrearPagoAsync(CrearPagoCommand command)
        {
            var pago = new Pago
            {
                TitularTarjetaId = command.TitularTarjetaId,
                FechaPago = command.FechaPago,
                Monto = command.Monto
            };

            await _pagoRepository.CreateAsync(pago);
        }
        public async Task<List<Pago>> PagosPorTitularIdAsync(PagosPorTitularIdQuery query)
        {
            return await _pagoRepository.GetAll().Where(x => x.TitularTarjetaId == query.TitularTarjetaId).ToListAsync();
        }
        public async Task<Pago> ObtenerPago(PagoPorIdQuery query)
        {
            return await _pagoRepository.ObtenerPorIdAsync(query.PagoId);
        }
        public async Task EliminarPago(EliminarPagoCommand command)
        {
            await _pagoRepository.DeleteAsync(_mapper.Map<Pago>(command));
        }

    }
}
