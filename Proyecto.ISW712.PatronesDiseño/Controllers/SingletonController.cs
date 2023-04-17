using Microsoft.AspNetCore.Mvc;

namespace Proyecto.ISW712.PatronesDiseño.Controllers
{
    public class SingletonController : Controller
    {
        public IActionResult Index()
        {
            var singleton = Singleton.Singleton.Instance;
            Console.WriteLine(singleton.Cadenas_conexion[singleton.Bd_actual]);
            Console.WriteLine(singleton.Motores_bd[singleton.Bd_actual]);
            ViewData["CadenaConexion"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            ViewData["MotorBD"] = singleton.Motores_bd[singleton.Bd_actual];
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
