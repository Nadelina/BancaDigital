using Banca.Data.Data.Entities;
using Banca.Data.Data;
using Banca.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca.Data.Repositories
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {
        public PagoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Pago> ObtenerPorIdAsync(int id) =>
            await context.Pagos.FindAsync(id);
    }
}
