namespace Banca.API.Commands.Pago
{
    public class EliminarPagoCommand
    {
        public int CompraId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int TitularTarjetaId { get; set; }
    }
}
