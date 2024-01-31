using System.Text.Json.Serialization;

namespace Banca.Application.Models
{
	public class EstadoDeCuentaViewModel
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
        [JsonPropertyName("saldoDisponible")]
        public decimal SaldoDisponible { get; set; }
        [JsonPropertyName("comprasDelMes")]
        public List<CompraViewModel> ComprasDelMes { get; set; } = new List<CompraViewModel>();
        [JsonPropertyName("pagos")]
        public List<PagoViewModel> Pagos { get; set; } = new List<PagoViewModel>();
        [JsonPropertyName("montoTotalComprasMesActual")]
        public decimal MontoTotalComprasMesActual { get; set; }
        [JsonPropertyName("montoTotalComprasMesAnterior")]
        public decimal MontoTotalComprasMesAnterior { get; set; }
        [JsonPropertyName("porcentajeInteresConfigurable")]
        public decimal PorcentajeInteresConfigurable { get; set; }
        [JsonPropertyName("interesBonificable")]
        public decimal InteresBonificable { get; set; }
        [JsonPropertyName("porcentajeSaldoMinimoConfigurable")]
        public decimal PorcentajeSaldoMinimoConfigurable { get; set; }
        [JsonPropertyName("cuotaMinimaAPagar")]
        public decimal CuotaMinimaAPagar { get; set; }
        [JsonPropertyName("montoTotalAPagar")]
        public decimal MontoTotalAPagar { get; set; }
        [JsonPropertyName("pagoContadoConIntereses")]
        public decimal PagoContadoConIntereses { get; set; }

    }
}
