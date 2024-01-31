using System.Text.Json.Serialization;

namespace Banca.Application.Models
{
    public class TitularTarjetaViewModel
    {
        [JsonPropertyName("titularTarjetaId")]
        public int TitularTarjetaId { get; set; }

        [JsonPropertyName("nombreTitular")]
        public string NombreTitular { get; set; } = string.Empty;

        [JsonPropertyName("numeroTarjeta")]
        public string NumeroTarjeta { get; set; } = string.Empty;

        [JsonPropertyName("saldoActual")]
        public decimal SaldoActual { get; set; }

        [JsonPropertyName("limiteCredito")]
        public decimal LimiteCredito { get; set; }
    }
}
