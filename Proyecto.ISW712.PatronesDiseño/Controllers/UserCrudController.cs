using Microsoft.AspNetCore.Mvc;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;

namespace Proyecto.ISW712.PatronesDiseño.Controllers
{
    public class UserCrudController : Controller
    {
        private IConfiguration _configuration;
        public UserCrudController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var singleton = Singleton.Singleton.Instance;
            var conexion = new FabricaConexion(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:"+ singleton.Bd_actual]);
            var cone=conexion.CrearConexion();
            Console.WriteLine("La Conexion es:");
            //Console.WriteLine(cone);
            //Console.WriteLine(cone.GetType().GetProperty("ServerVersion").GetValue(cone));
            cone.Open();
            Console.WriteLine("La Conexion es:");
            Console.WriteLine(cone.GetType().GetProperty("ServerVersion").GetValue(cone));
            cone.Close();


            Console.WriteLine(_configuration["ConnectionStrings:" + singleton.Bd_actual]);



            return View();
        }
    }
}
