using Npgsql;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public class PostgresUsuarioCrud:IUsuarioCruds
    {
        public IDbConnection conexion;
        public PostgresUsuarioCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }
        //NpgsqlConnection
        public void CrearUsuario(UsuarioModel usuario)
        {
            Console.WriteLine("valor");
            NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO Usuarios (nombre_usuario, nombre_completo, correo, edad) VALUES (@nombre_usuario, @nombre_completo, @correo, @edad)", (NpgsqlConnection)conexion);
            comando.Parameters.AddWithValue("@nombre_usuario", usuario.Nombre_Usuario);
            comando.Parameters.AddWithValue("@nombre_completo", usuario.Nombre_Completo);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@edad", usuario.Edad);
            comando.ExecuteNonQuery();
        }

        public void ActualizarUsuario(UsuarioModel usuario)
        {
                var cmd = new NpgsqlCommand("UPDATE Usuarios SET Nombre_Usuario=@nombre, Edad=@edad, Correo=@correo,Nombre_Completo=@nombreCompleto WHERE User_id=@id", (NpgsqlConnection)conexion);
                cmd.Parameters.AddWithValue("@id", usuario.User_id);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@nombreCompleto", usuario.Nombre_Completo);
            
                int filasActualizadas = cmd.ExecuteNonQuery();
                Console.WriteLine($"Filas actualizadas: {filasActualizadas}");
         }

        public void EliminarUsuario(int id)
        {
            var cmd = new NpgsqlCommand("DELETE FROM Usuarios WHERE User_id=@id", (NpgsqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            int filasEliminadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas eliminadas: {filasEliminadas}");
        }


        public List<UsuarioModel> ObtenerTodosLosUsuarios()
        {
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Usuarios", (NpgsqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Usuarios.Add(new UsuarioModel
                {
                    User_id = Convert.ToInt32(reader["User_id"]),
                    Edad = Convert.ToInt32(reader["Edad"]),
                    Nombre_Usuario = reader["Nombre_Usuario"].ToString(),
                    Nombre_Completo = reader["Nombre_Completo"].ToString(),
                    Correo = reader["Correo"].ToString(),
                });
            }
            //conexion.Close();
            //Console.WriteLine("Usuarios");
            //Console.WriteLine(Usuarios[0].Nombre_Usuario);
            return Usuarios;
        }

    }
}
