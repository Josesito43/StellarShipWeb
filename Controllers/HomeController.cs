using Microsoft.AspNetCore.Mvc;
using StellarShipWeb.Models;
using StellarShipWeb.Servicios;
using System.Diagnostics;

namespace StellarShipWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryIdGuia repositoryIdGuia;

        public HomeController(ILogger<HomeController> logger, IRepositoryIdGuia repositoryIdGuia)
        {
            _logger = logger;
            this.repositoryIdGuia = repositoryIdGuia;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BusquedaPaquete busquedaPaquete)
        {
            if (!ModelState.IsValid)
            {
                return View(busquedaPaquete);
            }

            if (true)
            {

            }
            var IdEnvio = busquedaPaquete.IdEnvio;
            return RedirectToAction("Seguimiento_envio", "Home" , new { IdEnvio });
        }
        [HttpGet]
        public async Task<IActionResult> Seguimiento_envio(long idEnvio)
        {
            var EstadoEnvio = await repositoryIdGuia.ObtenerGuia(idEnvio);
            if (EstadoEnvio is null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(EstadoEnvio);
        }

        [HttpGet]

        public async Task<IActionResult> VerificarExisteTipoCuenta(long idEnvio)
        {
            var Existe = await repositoryIdGuia.Existe(idEnvio);

            if (Existe)
            {
                return Json(true);
                
            }
            return Json($"El numero de guia no existe.");

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