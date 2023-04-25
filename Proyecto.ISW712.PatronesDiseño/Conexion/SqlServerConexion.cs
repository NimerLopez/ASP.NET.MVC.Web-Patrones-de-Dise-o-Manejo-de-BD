using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Conexion
{
    public class SqlServerConexion : IConectar
    {
        private string _motor;
        private string _cadenaConexion;
        private SqlConnection conexion;
        public SqlServerConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
            conexion = new SqlConnection(_cadenaConexion);
        }
        public IDbConnection Conectar()
        {
            Console.WriteLine(_cadenaConexion);
            conexion.Open();
            return conexion;
        }
        public IDbConnection Desconectar()
        {
            conexion.Close();
            return conexion;
        }

    }
}
