using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion
{
    public class SqlServerConexion:IConectar
    {
        private  string _motor;
        private  string _cadenaConexion;
        public SqlServerConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
        }
        public IDbConnection Conectar()
        {
            Console.WriteLine(_cadenaConexion);
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            return conexion;
        }

    }
}
