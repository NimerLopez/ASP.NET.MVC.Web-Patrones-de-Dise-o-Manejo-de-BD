using Proyecto.ISW712.PatronesDiseño.Models;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.ISW712.PatronesDiseño.Data.FabricaRol
{
    public class SqlServerRolCrud:IRolCruds
    {
        public IDbConnection conexion;
        public SqlServerRolCrud(IDbConnection conexion)
        {
            this.conexion = conexion;
        }
        public void CrearRol(RolModel rol)
        {
            SqlCommand cmd = new SqlCommand("Exec AgregarRol @nombre, @descrip, @estado", (SqlConnection)conexion);
            cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
            cmd.Parameters.AddWithValue("@descrip", rol.Descripcion);
            cmd.Parameters.AddWithValue("@estado", rol.Estado);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarRol(RolModel rol)
        {
            Console.WriteLine(rol.Id_Rol);
            Console.WriteLine(rol.Estado);
            Console.WriteLine(rol.Nombre);
            Console.WriteLine(rol.Descripcion);

            Console.WriteLine("Modi");
            SqlCommand cmd = new SqlCommand("EXEC ActualizarRol @id, @nombre, @descrip, @estado", (SqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
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
            SqlCommand cmd = new SqlCommand("exec EliminarRol @id", (SqlConnection)conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }


        public List<RolModel> ObtenerTodosLosRol()
        {
            List<RolModel> rol = new List<RolModel>();

            SqlCommand cmd = new SqlCommand("exec GetRol", (SqlConnection)conexion);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
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
