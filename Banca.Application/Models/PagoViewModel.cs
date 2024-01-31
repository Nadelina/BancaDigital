using System.Text.Json.Serialization;

namespace Banca.Application.Models
{
    public class PagoViewModel
    {
        public int TitularTarjetaId { get; set; }
        [JsonPropertyName("fechaPago")]
        public DateTime FechaPago { get; set; }
        [JsonPropertyName("monto")]
        public decimal Monto { get; set; }
    }
}
