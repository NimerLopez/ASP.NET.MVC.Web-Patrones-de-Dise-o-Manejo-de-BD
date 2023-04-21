using MySql.Data.MySqlClient;
using Npgsql;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public class MySqlUsuarioCrud:IUsuarioCruds
    {
        public IDbConnection conexion;
        public MySqlUsuarioCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }
        //MySqlConnection
        public void CrearUsuario(UsuarioModel usuario)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Usuarios (Nombre_Usuario, Nombre_Completo, Edad, Correo) VALUES (@nombre, @nombreCompleto, @edad, @correo)", (MySqlConnection)conexion);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre_Usuario);
            cmd.Parameters.AddWithValue("@nombreCompleto", usuario.Nombre_Completo);
            cmd.Parameters.AddWithValue("@edad", usuario.Edad);
            cmd.Parameters.AddWithValue("@correo", usuario.Correo);
            int filasInsertadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas insertadas: {filasInsertadas}");
        }

        public void ActualizarUsuario(UsuarioModel usuario)
        {
            var cmd = new MySqlCommand("UPDATE Usuarios SET Nombre_Usuario=@nombreUsuario, Nombre_Completo=@nombreCompleto, Edad=@edad, Correo=@correo WHERE User_id=@id", (MySqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", usuario.User_id);
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Nombre_Usuario);
            cmd.Parameters.AddWithValue("@nombreCompleto", usuario.Nombre_Completo);
            cmd.Parameters.AddWithValue("@edad", usuario.Edad);
            cmd.Parameters.AddWithValue("@correo", usuario.Correo);
            int filasActualizadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas actualizadas: {filasActualizadas}");
        }

        public void EliminarUsuario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Usuarios WHERE User_id = @id", (MySqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            int filasEliminadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas eliminadas: {filasEliminadas}");
        }


        public List<UsuarioModel> ObtenerTodosLosUsuarios()
        {
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuarios", (MySqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
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
