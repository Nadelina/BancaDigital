using Banca.API.Queries.TitularTarjeta;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;

namespace Banca.API.Handlers
{
    public class TitularTarjetaHandler
    {
        private readonly ITitularTarjetaRepository _titularTarjetaRepository;

        public TitularTarjetaHandler(ITitularTarjetaRepository titularTarjetaRepository)
        {
            _titularTarjetaRepository = titularTarjetaRepository;
        }

        public async Task<TitularTarjeta> Handle(ObtenerTitularTarjetaQuery query)
        {
            return await _titularTarjetaRepository.ObtenerPorIdAsync(query.TitularTarjetaId);
        }
    }

}
