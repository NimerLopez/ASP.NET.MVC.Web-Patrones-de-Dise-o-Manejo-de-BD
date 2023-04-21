using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public class FabricaUsuario
    {
        private string _motor;
        public IDbConnection _Conexion;
        public string operacion;


        public FabricaUsuario(string motor, IDbConnection Conexion)
        {
            this._motor = motor;
            this._Conexion = Conexion;
            Console.WriteLine(this._motor);
        }
        public IUsuarioCruds EjecutarCrud()
        {
            switch (_motor)
            {
                case "MSSql":                 
                        return new SqlServerUsuarioCrud(_Conexion);                   
                    //conexion = new SqlServerConexion(_motor, _cadenaConexion).Conectar();
                    //Console.WriteLine(conexion.ToString());
                case "PgSql":
                    //conexion = new PostgresConexion(_motor, _cadenaConexion).Conectar();
                    break;
                case "MySql":
                    //conexion = new MySqlConexion(_motor, _cadenaConexion).Conectar();
                    break;
                default:
                    throw new NotSupportedException(string.Format("El motor de base de datos '{0}' no es soportado.", _motor));
            }

            return null;
        }
    }
}
