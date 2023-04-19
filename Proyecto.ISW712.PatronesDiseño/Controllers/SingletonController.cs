using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Proyecto.ISW712.PatronesDiseño.Controllers
{
    public class SingletonController : Controller
    {
        private IConfiguration _configuration;
        public SingletonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var singleton = Singleton.Singleton.Instance;
            Console.WriteLine(singleton.Cadenas_conexion[singleton.Bd_actual]);
            Console.WriteLine(singleton.Motores_bd[singleton.Bd_actual]);
            ViewData["CadenaConexion"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            ViewData["MotorBD"] = singleton.Motores_bd[singleton.Bd_actual];
            var connectionStrings1 = _configuration["ConnectionStrings:db1"];
            var connectionStrings2 = _configuration["ConnectionStrings:db2"];
            var connectionStrings3 = _configuration["ConnectionStrings:db3"];
            ViewData["cadena1"] = connectionStrings1;
            ViewData["cadena2"] = connectionStrings2;
            ViewData["cadena3"] = connectionStrings3;
            //Console.WriteLine(connectionStrings1);
            //Console.WriteLine(connectionStrings2);
            //Console.WriteLine(connectionStrings3);

            return View();
        }
        [HttpPost]
        public IActionResult CambiarBD(string bd)
        {
            var singleton = Singleton.Singleton.Instance;
            singleton.Bd_actual = bd;
            return RedirectToAction("Index");
        }
    }
}
