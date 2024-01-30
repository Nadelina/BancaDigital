using Banca.Data.Data.Entities;

namespace Banca.Data.Repositories.Interfaces
{
    public interface ICompraRepository : IGenericRepository<Compra>
    {
        Task<Compra> ObtenerPorIdAsync(int id);
    }
}
