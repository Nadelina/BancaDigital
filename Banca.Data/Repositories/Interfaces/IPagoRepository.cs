using Banca.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca.Data.Repositories.Interfaces
{
    public interface IPagoRepository : IGenericRepository<Pago>
    {
        Task<Pago> ObtenerPorIdAsync(int id);
    }
}
