namespace Banca.API.Commands.Compra
{
    public class EliminarCompraCommand
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public int TitularTarjetaId { get; set; }
    }
}
