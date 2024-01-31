using System.Text.Json.Serialization;

namespace Banca.Application.Models
{
	public class CompraViewModel
	{
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        [JsonPropertyName("monto")]
        public decimal Monto { get; set; }
    }
}
