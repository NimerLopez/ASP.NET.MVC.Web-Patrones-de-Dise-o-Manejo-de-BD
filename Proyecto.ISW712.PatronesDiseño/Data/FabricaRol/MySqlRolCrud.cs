using MySql.Data.MySqlClient;
using Npgsql;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaRol
{
    public class MySqlRolCrud:IRolCruds
    {
        public IDbConnection conexion;

        public MySqlRolCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }
        public void CrearRol(RolModel rol)
        {
            Console.WriteLine("valor");
            MySqlCommand comando = new MySqlCommand("INSERT INTO Roles (Nombre, Descripcion, Estado) VALUES (@nombre, @descripcion, @estado)", (MySqlConnection)conexion);
            comando.Parameters.AddWithValue("@nombre", rol.Nombre);
            comando.Parameters.AddWithValue("@descripcion", rol.Descripcion);
            comando.Parameters.AddWithValue("@estado", rol.Estado);
            comando.ExecuteNonQuery();
        }

        public void ActualizarRol(RolModel rol)
        {

            Console.WriteLine("Modi");
            var cmd = new MySqlCommand("UPDATE Roles SET Nombre=@nombre, Descripcion=@descrip, Estado=@estado WHERE Id_Rol=@id", (MySqlConnection)conexion); cmd.Parameters.AddWithValue("@id", rol.Id_Rol);
            cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
            cmd.Parameters.AddWithValue("@descrip", rol.Descripcion);
            cmd.Parameters.AddWithValue("@estado", rol.Estado);
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} fila(s) afectadas", rowsAffected);
        }

        public void EliminarRol(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Roles WHERE Id_Rol = @id", (MySqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            int filasEliminadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas eliminadas: {filasEliminadas}");
        }


        public List<RolModel> ObtenerTodosLosRol()
        {
            List<RolModel> rol = new List<RolModel>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Roles", (MySqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rol.Add(new RolModel
                {
                    Id_Rol = Convert.ToInt32(reader["Id_Rol"]),
                    Nombre = reader["Nombre"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    Estado = reader["Estado"].ToString(),
                });
            }
            //conexion.Close();
            //Console.WriteLine("Usuarios");
            //Console.WriteLine(Usuarios[0].Nombre_Usuario);
            return rol;
        }





    }
}
