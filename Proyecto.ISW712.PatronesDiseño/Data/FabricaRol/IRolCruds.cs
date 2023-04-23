using Proyecto.ISW712.PatronesDiseño.Models;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaRol
{
    public interface IRolCruds
    {
        void CrearRol(RolModel rol);//metodo crear
        void EliminarRol(int id);//metodo eliminar
        List<RolModel> ObtenerTodosLosRol();//metodo obtener
        void ActualizarRol(RolModel rol);//metodo actualizar
    }
}
