namespace Banca.API.DTOs
{
    public class EstadoDeCuentaDto
    {
        public int TitularTarjetaId { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoDisponible => LimiteCredito - SaldoActual;
        public List<CompraDto> ComprasDelMes { get; set; }
        public decimal MontoTotalComprasMesActual { get; set; }
        public decimal MontoTotalComprasMesAnterior { get; set; }
        public decimal PorcentajeInteresConfigurable { get; set; } 
        public decimal InteresBonificable => SaldoActual * PorcentajeInteresConfigurable / 100;
        public decimal PorcentajeSaldoMinimoConfigurable { get; set; } 
        public decimal CuotaMinimaAPagar => SaldoActual * PorcentajeSaldoMinimoConfigurable / 100;
        public decimal MontoTotalAPagar => SaldoActual;
        public decimal PagoContadoConIntereses => SaldoActual + InteresBonificable;
    }
}
