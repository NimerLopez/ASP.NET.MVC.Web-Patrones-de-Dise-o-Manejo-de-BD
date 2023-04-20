using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion
{
    public class FabricaConexion
    {
        private string _motor;
        public string _cadenaConexion;

        public FabricaConexion(string motor, string cadenaConexion)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
            Console.WriteLine(_motor);
        }


        public IDbConnection CrearConexion()
        {
            IDbConnection conexion;
            switch (_motor)
            {
                case "MSSql":
                    conexion = new SqlServerConexion(_motor, _cadenaConexion).Conectar();
                    Console.WriteLine(conexion.ToString());
                    break;
                case "PgSql":
                    conexion = new PostgresConexion(_motor, _cadenaConexion).Conectar();
                    break;
                case "MySql":
                    conexion = new MySqlConexion(_motor, _cadenaConexion).Conectar();
                    break;
                default:
                    throw new NotSupportedException(string.Format("El motor de base de datos '{0}' no es soportado.", _motor));
            }

            return conexion;
        }

    }
}
