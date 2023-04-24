using Npgsql;
using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaRol
{
    public class PostgresRolCrud:IRolCruds
    {
        public IDbConnection conexion;

        public PostgresRolCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }
        public void CrearRol(RolModel rol)
        {
            Console.WriteLine("valor");
            NpgsqlCommand comando = new NpgsqlCommand("INSERT INTO Roles (Nombre, Descripcion, Estado) VALUES (@nombre, @descripcion, @estado)", (NpgsqlConnection)conexion);
            comando.Parameters.AddWithValue("@nombre",rol.Nombre);
            comando.Parameters.AddWithValue("@descripcion", rol.Descripcion);
            comando.Parameters.AddWithValue("@estado", rol.Estado);
            comando.ExecuteNonQuery();
        }

        public void ActualizarRol(RolModel rol)
        {

            Console.WriteLine("Modi");
            var cmd = new NpgsqlCommand("UPDATE Roles SET Nombre=@nombre, Descripcion=@descrip, Estado=@estado WHERE Id_Rol=@id", (NpgsqlConnection)conexion); cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@id", rol.Id_Rol);
            cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
            cmd.Parameters.AddWithValue("@descrip", rol.Descripcion);
            cmd.Parameters.AddWithValue("@estado", rol.Estado);
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} fila(s) afectadas", rowsAffected);
        }

        public void EliminarRol(int id)
        {
            Console.WriteLine(id);
            var cmd = new NpgsqlCommand("DELETE FROM Roles WHERE Id_Rol=@id", (NpgsqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            int filasEliminadas = cmd.ExecuteNonQuery();
            Console.WriteLine($"Filas eliminadas: {filasEliminadas}");
        }


        public List<RolModel> ObtenerTodosLosRol()
        {
            List<RolModel> rol = new List<RolModel>();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Roles", (NpgsqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
            NpgsqlDataReader reader = cmd.ExecuteReader();
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
