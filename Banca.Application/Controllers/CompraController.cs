using Banca.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Banca.Application.Controllers
{
    public class CompraController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        public CompraController(HttpClient httpClient, IConfiguration configuration)
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
        public async Task<ActionResult> Crear (CompraViewModel compra)
        {

            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}api/Compra/", compra);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","EstadoCuenta", new { id = compra.TitularTarjetaId }); 
            }

            ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la compra");
            return View(compra);

        }
    }
}
