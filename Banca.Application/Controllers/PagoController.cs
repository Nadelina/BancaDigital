using Banca.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Banca.Application.Controllers
{
    public class PagoController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public PagoController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["UrlSettings:ApiBaseUrl"];
        }
        public IActionResult Crear(int id)
        {
            ViewBag.TitularId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PagoViewModel pago)
        {

            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}api/Pago/", pago);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "EstadoCuenta", new { id = pago.TitularTarjetaId });
            }

            ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el pago");
            return View(pago);

        }
    }
}
