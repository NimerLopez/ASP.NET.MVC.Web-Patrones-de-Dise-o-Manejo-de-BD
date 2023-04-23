using MySql.Data.MySqlClient;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public class SqlServerUsuarioCrud:IUsuarioCruds
    {
        public IDbConnection conexion;



        public SqlServerUsuarioCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }

        public  void CrearUsuario(UsuarioModel usuario)
        {
            SqlCommand cmd = new SqlCommand("Exec AgregarUsuario @Nombre_Usuario, @Nombre_Completo, @Edad, @Correo", (SqlConnection)conexion);
            cmd.Parameters.AddWithValue("@Nombre_Usuario", usuario.Nombre_Usuario);
            cmd.Parameters.AddWithValue("@Nombre_Completo", usuario.Nombre_Completo);
            cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
            cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
            cmd.ExecuteNonQuery();
        }

        public  void ActualizarUsuario(UsuarioModel usuario)
        {
            Console.WriteLine("Modi");
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Edad=@edad, Nombre_Usuario=@nombreUsuario, Nombre_Completo=@nombreCompleto, Correo=@correo WHERE User_id=@userId", (SqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@edad", usuario.Edad);
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Nombre_Usuario);
            cmd.Parameters.AddWithValue("@nombreCompleto", usuario.Nombre_Completo);
            cmd.Parameters.AddWithValue("@correo", usuario.Correo);
            cmd.Parameters.AddWithValue("@userId", usuario.User_id);
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} fila(s) afectadas", rowsAffected);
        }

        public  void EliminarUsuario(int id)
        {
            Console.WriteLine(id);
            SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE User_id = @id", (SqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }


        public  List<UsuarioModel> ObtenerTodosLosUsuarios()
        {
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();
            
            SqlCommand cmd = new SqlCommand("exec GetUsuarios", (SqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
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
