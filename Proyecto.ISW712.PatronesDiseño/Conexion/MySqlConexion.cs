using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Conexion
{
    public class MySqlConexion : IConectar
    {
        private string _motor;
        private string _cadenaConexion;
        private MySqlConnection conexion;
        public MySqlConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
            conexion= new MySqlConnection(_cadenaConexion);
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
