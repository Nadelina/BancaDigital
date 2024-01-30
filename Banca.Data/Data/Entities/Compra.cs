namespace Banca.Data.Data.Entities
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }

        public int TitularTarjetaId { get; set; }
        public TitularTarjeta TitularTarjeta { get; set; } = null!;
    }

}

