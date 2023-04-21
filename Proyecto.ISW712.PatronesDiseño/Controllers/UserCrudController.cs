using Microsoft.AspNetCore.Mvc;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario;
using Proyecto.ISW712.PatronesDiseño.Helpers;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

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
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);
            //usuarioFactory.DeleteUsuario(5);
            var ListUsu = usuarioFactory.GetUsuario();
            //foreach (var usuario in x)
            //{
            //WriteLine(usuario.User_id);
            //Console.WriteLine(usuario.Nombre_Usuario);
            //Console.WriteLine(usuario.Edad);
            //}
            Console.WriteLine(_configuration["ConnectionStrings:" + singleton.Bd_actual]);
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            return View(ListUsu);
        }
        public IActionResult Eliminar(int id)
        {
            var singleton = Singleton.Singleton.Instance;
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);
            //usuarioFactory.DeleteUsuario(5);
            usuarioFactory.DeleteUsuario(id);
            return RedirectToAction("Index");
        }
        public IActionResult AgregarView()
        {
            var singleton = Singleton.Singleton.Instance;
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            return View("Agregar");
        }
        public IActionResult Agregar(UsuarioModel usuario)
        {
            var singleton = Singleton.Singleton.Instance;
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);
            usuarioFactory.AgregarUsuario(usuario);

            return RedirectToAction("Index");
        }
        public IActionResult ModificarView(UsuarioModel usuario)
        {
            var singleton = Singleton.Singleton.Instance;
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            return View("ModificarView", usuario);
        }
        public IActionResult Modificar(UsuarioModel usuario)
        {
            var singleton = Singleton.Singleton.Instance;
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);
            usuarioFactory.ModificarUsuario(usuario);
            return RedirectToAction("Index");
        }
        public IActionResult DetalleView(UsuarioModel usuario)
        {
            var singleton = Singleton.Singleton.Instance;
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];
            return View("DetalleView",usuario);
        }

    } 
}
