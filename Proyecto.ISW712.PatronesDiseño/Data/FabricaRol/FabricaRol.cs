using Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaRol
{
    public class FabricaRol
    {
        private string _motor;
        public IDbConnection _Conexion;
        public string operacion;

        public FabricaRol(string motor, IDbConnection Conexion)
        {
            this._motor = motor;
            this._Conexion = Conexion;
            Console.WriteLine(this._motor);
        }

        public IRolCruds EjecutarCrud()
        {
            switch (_motor)
            {
                case "MSSql":
                    return new SqlServerRolCrud(_Conexion);
                //conexion = new SqlServerConexion(_motor, _cadenaConexion).Conectar();
                //Console.WriteLine(conexion.ToString());
                case "PgSql":
                    return new PostgresRolCrud(_Conexion);
                //conexion = new PostgresConexion(_motor, _cadenaConexion).Conectar();
                case "MySql":
                    return new MySqlRolCrud(_Conexion);
                default:
                    throw new NotSupportedException(string.Format("El motor de base de datos '{0}' no es soportado.", _motor));
            }

            return null;
        }




    }
}
