using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Conexion
{
    public class PostgresConexion : IConectar
    {
        private string _motor;
        private string _cadenaConexion;
        private NpgsqlConnection conexion;
        public PostgresConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
            conexion = new NpgsqlConnection(_cadenaConexion);
        }
        public IDbConnection Conectar()
        {
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
