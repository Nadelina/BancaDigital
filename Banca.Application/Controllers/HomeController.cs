using Banca.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Banca.Application.Controllers
{
	public class HomeController : Controller
	{
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public HomeController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["UrlSettings:ApiBaseUrl"]; 
        }
        public async Task<IActionResult> Index()
		{
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}api/TitularTarjeta");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var titularesTarjeta = JsonSerializer.Deserialize<List<TitularTarjetaViewModel>>(content);
                return View(titularesTarjeta);
            }

            return NotFound();
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
