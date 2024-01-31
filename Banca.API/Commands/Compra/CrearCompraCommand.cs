namespace Banca.API.Commands.Compra
{
    public class CrearCompraCommand
    {
        public int TitularTarjetaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
    }
}
