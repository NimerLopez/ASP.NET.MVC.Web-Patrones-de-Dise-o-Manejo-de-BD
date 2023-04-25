using Proyecto.ISW712.PatronesDiseño.Conexion;
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

        public UsuarioHelper(string motor, string cadenaConexion)//intacia de objetos
        {
            this.motor = motor;
            this.cadenaConexion = cadenaConexion;
        }

        private  void ObtenerConexion()//genera y crea la conexion y la abre
        {
            FabricaConexion fabricaConexion = new FabricaConexion(motor, cadenaConexion,"C");//genera la conexion abierta,C de CONECTAR
            this.conexion = fabricaConexion.CrearConexion();//crea la conexion
            Console.WriteLine("Abriendo");     
        }

        public List<UsuarioModel> GetUsuario()//returna la lista de usuarios
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);//genera los datos de consulta sql
            IUsuarioCruds getUsu = usuarioFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            var lista = getUsu.ObtenerTodosLosUsuarios();//realiza la consulta sql y returna la lista de usuarios
            CerrarConexion();//cierra la conexion
            return lista;//returna la lista de usuarios
        }
        public void DeleteUsuario(int id)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);//genera los datos de consulta sql
            IUsuarioCruds deliteUsu = usuarioFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            deliteUsu.EliminarUsuario(id);//realiza delete a la base de datos
            CerrarConexion();//cierra la conexion
        }
        public void AgregarUsuario(UsuarioModel usu)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaUsuario usuarioFactory = new FabricaUsuario(this.motor, this.conexion);//genera los datos de consulta sql
            IUsuarioCruds addUsu = usuarioFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            addUsu.CrearUsuario(usu);//realiza consulta insert a la base de datos
            CerrarConexion();//cierra la conexion
        }
        public void ModificarUsuario(UsuarioModel usuario)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaUsuario usuarioFactory = new FabricaUsuario(motor, conexion);//genera los datos de consulta sql
            IUsuarioCruds modificarUsu = usuarioFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            modificarUsu.ActualizarUsuario(usuario);
            //dificarUsu.ModificarUsuario(usuario);
            CerrarConexion();//cierra la conexion
        }



        private void CerrarConexion()//cerrar conexion
        {
            FabricaConexion fabricaConexion = new FabricaConexion(motor, cadenaConexion, "D");//genera la conexion abierta,D de Desconectar
            this.conexion = fabricaConexion.CrearConexion();//Devulve la Conexion Cerrada
            Console.WriteLine("Cerrando");

        }
    }
}
