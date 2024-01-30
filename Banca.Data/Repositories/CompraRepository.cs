using Banca.Data.Data;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;

namespace Banca.Data.Repositories
{
    public class CompraRepository : GenericRepository<Compra>, ICompraRepository
    {
        public CompraRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Compra> ObtenerPorIdAsync(int id) =>
            await context.Compras.FindAsync(id);
    }
}
