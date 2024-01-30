using Banca.Data.Data;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;

namespace Banca.Data.Repositories
{
    public class TitularTarjetaRepository : GenericRepository<TitularTarjeta>, ITitularTarjetaRepository
    {
        public TitularTarjetaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<TitularTarjeta> ObtenerPorIdAsync(int id) =>
            await context.TitularesTarjeta.FindAsync(id);
    }
}
