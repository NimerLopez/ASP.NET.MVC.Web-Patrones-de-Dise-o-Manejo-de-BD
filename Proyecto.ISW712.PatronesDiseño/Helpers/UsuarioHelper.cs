using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Proyecto.ISW712.PatronesDiseño.Helpers
{
    public class UsuarioHelper
    {
        private string motor;
        private string cadenaConexion;
        private IDbConnection conexion;

        public UsuarioHelper(string motor, string cadenaConexion)
        {
            this.motor = motor;
            this.cadenaConexion = cadenaConexion;
        }

        public  void ObtenerConexion()
        {
            FabricaConexion fabricaConexion = new FabricaConexion(motor, cadenaConexion);
            this.conexion = fabricaConexion.CrearConexion();
            conexion.Open();
            Console.WriteLine("Abriendo");     
        }

        public List<UsuarioModel> GetUsuario()
        {
            ObtenerConexion();
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);
            IUsuarioCruds getUsu = usuarioFactory.EjecutarCrud();
            var lista = getUsu.ObtenerTodosLosUsuarios();
            CerrarConexion();
            return lista;
        }
        public void DeleteUsuario(int id)
        {
            ObtenerConexion();
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);
            IUsuarioCruds deliteUsu = usuarioFactory.EjecutarCrud();
            deliteUsu.EliminarUsuario(id);
            CerrarConexion();
        }
        public void AgregarUsuario(UsuarioModel usu)
        {
            ObtenerConexion();
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);
            IUsuarioCruds addUsu = usuarioFactory.EjecutarCrud();
            addUsu.CrearUsuario(usu);
        }
        public void ModificarUsuario(UsuarioModel usuario)
        {
            ObtenerConexion();
            FabricaUsuario usuarioFactory = new FabricaUsuario(motor, conexion);
            IUsuarioCruds modificarUsu = usuarioFactory.EjecutarCrud();
            modificarUsu.ActualizarUsuario(usuario);
            //dificarUsu.ModificarUsuario(usuario);
            CerrarConexion();
        }



        public void CerrarConexion()
        {
            
                Console.WriteLine("Cerrando");
                this.conexion.Close();
                Console.WriteLine(this.conexion);
        }
    }
}
