namespace Banca.API.Commands.TitularTarjeta
{
    public class ActualizarTitularTarjetaCommand
    {
        public int TitularTarjetaId { get; set; }
        public string NombreTitular { get; set; } = string.Empty;
        public string NumeroTarjeta { get; set; } = string.Empty;
        public decimal SaldoActual { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}
