using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion
{
    public class PostgresConexion:IConectar
    {
        private string _motor;
        private string _cadenaConexion;
        public PostgresConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
        }
        public IDbConnection Conectar()
        {
            Console.WriteLine(_cadenaConexion);
            NpgsqlConnection conexion = new NpgsqlConnection(_cadenaConexion);

            return conexion;
        }
    }
}
