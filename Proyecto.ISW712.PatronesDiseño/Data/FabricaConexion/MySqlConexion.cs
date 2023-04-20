using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion
{
    public class MySqlConexion:IConectar
    {
        private string _motor;
        private string _cadenaConexion;
        public MySqlConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
        }
        public IDbConnection Conectar()
        {
            Console.WriteLine(_cadenaConexion);
            MySqlConnection conexion = new MySqlConnection(_cadenaConexion);
            return conexion;
        }
    }
}
