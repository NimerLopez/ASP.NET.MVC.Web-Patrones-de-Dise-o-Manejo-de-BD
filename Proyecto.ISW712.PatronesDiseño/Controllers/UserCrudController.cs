using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()//vista principal
        {
            var singleton = Singleton.Singleton.Instance;//llama a la funcion singleton para sacar la sesion
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de usuarios
            var ListUsu = usuarioFactory.GetUsuario();//saca la lista de usuarios, mediante el helper
            Console.WriteLine(_configuration["ConnectionStrings:" + singleton.Bd_actual]);
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//pasa el nombre de la cedna de conexion en la sesion
            return View(ListUsu);//retorna la vista y la lista de usuarios
        }
        public IActionResult Eliminar(int id)//metodo de eliminar
        {
            var singleton = Singleton.Singleton.Instance;//llama a la funcion singleton para sacar la sesion
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de usuarios
            usuarioFactory.DeleteUsuario(id);//elimina el usuario por id
            return RedirectToAction("Index");//redireccion al index
        }
        public IActionResult AgregarView()//vista de agregar usuarios
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//saca la bd actual
            return View("Agregar");
        }
        public IActionResult Agregar(UsuarioModel usuario)//metodo de agregar usuario
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de usuarios
            usuarioFactory.AgregarUsuario(usuario);//del helper llama la funcion de agregar 

            return RedirectToAction("Index");//redireccion al index del usuario
        }
        public IActionResult ModificarView(UsuarioModel usuario)//llama a la vista de usuario y recibe por parametro al usuario
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual];//returna el nombre de la bd actual
            return View("ModificarView", usuario);
        }
        public IActionResult Modificar(UsuarioModel usuario)//funcion de modificar
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            UsuarioHelper usuarioFactory = new UsuarioHelper(singleton.Motores_bd[singleton.Bd_actual], _configuration["ConnectionStrings:" + singleton.Bd_actual]);//llama al helper de usuarios
            usuarioFactory.ModificarUsuario(usuario);//modifica el usuario
            return RedirectToAction("Index");//redireccion al index
        }
        public IActionResult DetalleView(UsuarioModel usuario)//vista de detalle
        {
            var singleton = Singleton.Singleton.Instance;//llama a la sesion
            ViewData["cadena1"] = singleton.Cadenas_conexion[singleton.Bd_actual]; //retuna la bd actual
            return View("DetalleView",usuario);
        }

    } 
}
