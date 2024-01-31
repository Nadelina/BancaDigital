namespace Banca.API.Commands.Pago
{
    public class CrearPagoCommand
    {
        public int TitularTarjetaId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
    }
}
