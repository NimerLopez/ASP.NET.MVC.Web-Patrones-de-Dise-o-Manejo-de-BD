using Proyecto.ISW712.PatronesDiseño.Models;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public interface IUsuarioCruds
    {
        void CrearUsuario(UsuarioModel usuario);
        void EliminarUsuario(int id);
        List<UsuarioModel> ObtenerTodosLosUsuarios();
        void ActualizarUsuario(UsuarioModel usuario);
    }
}
