using Microsoft.AspNetCore.Mvc;
using Proyecto.ISW712.PatronesDiseño.Helpers;
using Proyecto.ISW712.PatronesDiseño.Models;

namespace Proyecto.ISW712.PatronesDiseño.Controllers
{
    public class RolCrudController : Controller
    {
        private IConfiguration _configuration;
        public RolCrudController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var singleton = Singleton.Singleton.Instance;//llama a la funcion singleton para sacar la sesion
            RolHelper factory = new RolHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de rol
            var Listrol = factory.GetRol();//saca la lista de rol, mediante el helper
            Console.WriteLine(_configuration["ConnectionStrings:" + singleton.Bd_actual]);
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//pasa el nombre de la cedna de conexion en la sesion
            return View(Listrol);
        }
        public IActionResult AgregarRolView()
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//saca la bd actual
            return View("AgregarRol");
        }
        public IActionResult Agregar(RolModel rol)//metodo de agregar rol
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            RolHelper factory = new RolHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de rols
            factory.AgregarRol(rol);//del helper llama la funcion de agregar 

            return RedirectToAction("Index");//redireccion al index del rol
        }
        public IActionResult ModificarView(RolModel rol)//llama a la vista de rol y recibe por parametro al rol
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//returna el nombre de la bd actual
            return View("ModificarView", rol);
        }
        public IActionResult Modificar(RolModel rol)//funcion de modificar
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            RolHelper factory = new RolHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de rols
            factory.ModificarRol(rol);//modifica el rol
            return RedirectToAction("Index");//redireccion al index
        }
        public IActionResult Eliminar(int id)//metodo de eliminar
        {
            var singleton = Singleton.Singleton.Instance;//llama a la funcion singleton para sacar la sesion
            RolHelper factory = new RolHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de rols
            factory.DeleteRol(id);//elimina el rol por id
            return RedirectToAction("Index");//redireccion al index
        }
        public IActionResult DetalleView(RolModel rol)//vista de detalle
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual]; //retuna la bd actual
            return View("DetalleView", rol);
        }

    }
}
