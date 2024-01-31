namespace Banca.Data.Data.Entities
{
    public class Pago
    {
        public int PagoId { get; set; } 
        public int TitularTarjetaId { get; set; } 
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public TitularTarjeta TitularTarjeta { get; set; } = null!;
    }
}
