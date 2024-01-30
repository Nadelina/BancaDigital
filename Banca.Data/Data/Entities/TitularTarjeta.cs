using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca.Data.Data.Entities
{
    public class TitularTarjeta
    {
        public int TitularTarjetaId { get; set; }
        public string NombreTitular { get; set; } = string.Empty;
        public string NumeroTarjeta { get; set; } = string.Empty;
        public decimal SaldoActual { get; set; }
        public decimal LimiteCredito { get; set; }

        // Relación uno a muchos con Compra
        public List<Compra> Compras { get; set; } = null!;
    }

}



