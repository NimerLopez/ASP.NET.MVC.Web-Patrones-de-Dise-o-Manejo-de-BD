using Microsoft.AspNetCore.Mvc;
using Proyecto.ISW712.PatronesDiseño.Models;
using Proyecto.ISW712.PatronesDiseño.Singleton;
using System.Diagnostics;

namespace Proyecto.ISW712.PatronesDiseño.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var singleton = Singleton.Singleton.Instance;
            ViewData["CadenaConexion"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            ViewData["MotorBD"] = singleton.Motores_bd[singleton.Bd_actual];
            return View();
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