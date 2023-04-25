using Proyecto.ISW712.PatronesDiseño.Conexion;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaRol;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Helpers
{
    public class RolHelper
    {
        private string motor;
        private string cadenaConexion;
        private IDbConnection conexion;

        public RolHelper(string motor, string cadenaConexion)
        {
            this.motor = motor;
            this.cadenaConexion = cadenaConexion;
        }

        private void ObtenerConexion()//genera y crea la conexion y la abre
        {
            FabricaConexion fabricaConexion = new FabricaConexion(motor, cadenaConexion, "C");//genera la conexion C de Conectar
            this.conexion = fabricaConexion.CrearConexion();//crea la conexion
            Console.WriteLine("Abriendo");
        }
        public void AgregarRol(RolModel rol)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaRol rolFactory = new FabricaRol(this.motor, this.conexion);//genera los datos de consulta sql
            IRolCruds addRol = rolFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            addRol.CrearRol(rol);//realiza consulta insert a la base de datos
            CerrarConexion();//cierra la conexion
        }
        public List<RolModel> GetRol()//returna la lista de usuarios
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaRol rolFactory = new FabricaRol(this.motor, this.conexion);//genera los datos de consulta sql
            IRolCruds getrol = rolFactory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            var lista = getrol.ObtenerTodosLosRol();//realiza la consulta sql y returna la lista de usuarios
            CerrarConexion();//cierra la conexion
            return lista;//returna la lista de usuarios
        }
        public void ModificarRol(RolModel rol)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaRol rolFact = new FabricaRol(motor, conexion);//genera los datos de consulta sql
            IRolCruds modificar = rolFact.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            modificar.ActualizarRol(rol);
            CerrarConexion();//cierra la conexion
        }
        public void DeleteRol(int id)
        {
            ObtenerConexion();//llama a la conexion abierta
            FabricaRol factory = new FabricaRol(this.motor, this.conexion);//genera los datos de consulta sql
            IRolCruds delite = factory.EjecutarCrud();//validacin del motor de bd y genera, intacia a la clase crud de la bd actual
            delite.EliminarRol(id);//realiza delete a la base de datos
            CerrarConexion();//cierra la conexion
        }



        private void CerrarConexion()//cerrar conexion
        {
            FabricaConexion fabricaConexion = new FabricaConexion(motor, cadenaConexion, "D");//genera la conexion D de Desconectar
            this.conexion = fabricaConexion.CrearConexion();//Devuelve la Conecion Cerrada
            Console.WriteLine("Cerrando");

        }


    }
}
