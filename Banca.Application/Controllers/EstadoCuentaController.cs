using Banca.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Banca.Application.Controllers
{
    public class EstadoCuentaController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EstadoCuentaController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["UrlSettings:ApiBaseUrl"]; 
        }
        // GET: EstadoCuentaController
        public async Task<IActionResult> Index(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}api/TitularTarjeta/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estadoDeCuenta = JsonSerializer.Deserialize<EstadoDeCuentaViewModel>(content);
                return View(estadoDeCuenta);
            }
            return NotFound();
        }

        public async Task<ActionResult> ExportarPDF(int titularTarjetaId)
        {

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}api/TitularTarjeta/{titularTarjetaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estadoDeCuenta = JsonSerializer.Deserialize<EstadoDeCuentaViewModel>(content);

                var pdfResponse = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}api/TitularTarjeta/ExportarEstadoPDF", estadoDeCuenta);

                if (pdfResponse.IsSuccessStatusCode)
                {
                    var pdfData = await pdfResponse.Content.ReadAsByteArrayAsync();
                    return File(pdfData, "application/pdf", "EstadoDeCuenta.pdf");
                }
            }
            return NotFound();

        }
    }
}
