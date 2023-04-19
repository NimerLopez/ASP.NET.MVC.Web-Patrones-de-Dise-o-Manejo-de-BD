using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion
{
    public interface IConectar
    {
        IDbConnection Conectar();
    }
}
