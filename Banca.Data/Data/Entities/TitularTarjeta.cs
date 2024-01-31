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
        public List<Pago> Pagos { get; set; } = null!;
        public decimal PorcentajeInteresConfigurable { get; set; } = 25;
        public decimal PorcentajeSaldoMinimoConfigurable { get; set; } = 5;
    }

}



