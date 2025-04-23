using Microsoft.AspNetCore.Mvc;
using StellarShipWeb.Models;
using StellarShipWeb.Servicios;

namespace StellarShipWeb.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IRepositoryIdGuia repositoryIdGuia;

        public EnvioController(IRepositoryIdGuia repositoryIdGuia)
        {
            this.repositoryIdGuia = repositoryIdGuia;
        }

        
    }
}
