using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Conexion
{
    public interface IConectar
    {
        IDbConnection Conectar();
        IDbConnection Desconectar();
    }
}
