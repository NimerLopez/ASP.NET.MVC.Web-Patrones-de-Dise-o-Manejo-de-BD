using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Conexion
{
    public class FabricaConexion
    {
        private string _motor;
        public string _cadenaConexion;
        public string servicio;

        public FabricaConexion(string motor, string cadenaConexion, string servicio)
        {
            _motor = motor;
            _cadenaConexion = cadenaConexion;
            Console.WriteLine(_motor);
            this.servicio = servicio;
        }


        public IDbConnection CrearConexion()
        {
            IDbConnection conexion;
            switch (_motor)
            {
                case "MSSql":
                    if (servicio == "C")//para conectar
                    {
                        conexion = new SqlServerConexion(_motor, _cadenaConexion).Conectar();//abre Conexion
                        break;
                    }
                    else//para Desconectar
                    {
                        conexion = new SqlServerConexion(_motor, _cadenaConexion).Desconectar();//Cierra Conexion
                        break;
                    }
                   
                case "PgSql":
                    if(servicio == "C")
                    {
                        conexion = new PostgresConexion(_motor, _cadenaConexion).Conectar();//abre Conexion
                        break;
                    }
                    else
                    {
                        conexion = new PostgresConexion(_motor, _cadenaConexion).Desconectar();//Cierra Conexion
                        break;
                    }

                case "MySql":
                    if (servicio == "C")
                    {
                        conexion = new MySqlConexion(_motor, _cadenaConexion).Conectar();//abre Conexion
                        break;
                    }
                    else
                    {
                        conexion = new MySqlConexion(_motor, _cadenaConexion).Desconectar();//Cierra Conexion
                        break;
                    }

                default:
                    throw new NotSupportedException(string.Format("El motor de base de datos '{0}' no es soportado.", _motor));
            }

            return conexion;
        }

    }
}
