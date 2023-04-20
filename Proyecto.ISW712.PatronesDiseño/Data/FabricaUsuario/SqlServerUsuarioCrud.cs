using MySql.Data.MySqlClient;
using Proyecto.ISW712.PatronesDiseño.Data.FabricaConexion;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaUsuario
{
    public class SqlServerUsuarioCrud:IUsuarioCruds
    {
        public SqlConnection conexion;



        public SqlServerUsuarioCrud(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public  void CrearUsuario(UsuarioModel usuario)
        {
            // Implementación específica de MySQL para crear un usuario
        }

        public  void ActualizarUsuario(int id)
        {
            // Implementación específica de MySQL para actualizar un usuario
        }

        public  void EliminarUsuario(int id)
        {
            // Implementación específica de MySQL para eliminar un usuario
        }


        public  List<UsuarioModel> ObtenerTodosLosUsuarios()
        {
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", conexion);
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
            conexion.Close();
            Console.WriteLine("Usuarios");
            Console.WriteLine(Usuarios[0].Nombre_Usuario);
            return Usuarios;
        }


    }
}
