using Banca.Data.Data.Entities;

namespace Banca.Data.Repositories.Interfaces
{
    public interface ITitularTarjetaRepository : IGenericRepository<TitularTarjeta>
    {
        Task<TitularTarjeta> ObtenerPorIdAsync(int id);
    }
}
