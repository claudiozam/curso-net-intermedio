using MySql.Data.MySqlClient;
using WebApplicationSistemaReclamosV2.Models.ViewModels;

namespace WebApplicationSistemaReclamosV2.Models.Db
{
    public class ReclamosDb
    {
        private MySqlConnection crearNuevaConexion()
        {
            string connectionString = "Server=127.0.0.1;Database=sistema_reclamos;Uid=root;Pwd=root;";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public void AltaDeReclamo(string titulo, string descripcion, string estado, DateTime fechaAlta)
        {
            MySqlConnection connection = crearNuevaConexion();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO reclamos(titulo, descripcion, estado, fechaAlta) " +
                " VALUES(@titulo, @descripcion, @estado, @fechaAlta);";
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@fechaAlta", fechaAlta);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void ActualizarReclamo(long id, string titulo, string descripcion, string estado, DateTime fechaAlta)
        {
            //UPDATE reclamos SET titulo = 'nuevo titulo' WHERE id = 1;
            MySqlConnection connection = crearNuevaConexion();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE reclamos SET titulo = @titulo, descripcion = @descripcion, " +
                " estado = @estado, fechaAlta = @fechaAlta WHERE id = @id;";
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@fechaAlta", fechaAlta);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void BorrarReclamo(long id)
        {
            MySqlConnection connection = crearNuevaConexion();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM reclamos WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public ReclamoViewModel BuscarReclamoPorId(long id)
        {
            ReclamoViewModel reclamosViewModel = null;
            MySqlConnection connection = crearNuevaConexion();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                reclamosViewModel = new ReclamoViewModel() {
                    Id = dr.GetInt64("id"),
                    Titulo = dr.GetString("titulo"),
                    Descripcion = dr.GetString("descripcion"),
                    Estado = dr.GetString("estado"),
                    FechaAlta = dr.GetDateTime("fechaAlta")
                };
            }
            return reclamosViewModel;
        }

        public List<ReclamoViewModel> BuscarTodoLosReclamos()
        {
            List<ReclamoViewModel> reclamosViewModel = new List<ReclamoViewModel>();
            MySqlConnection connection = crearNuevaConexion();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos";
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                reclamosViewModel.Add(new ReclamoViewModel()
                {
                    Id = dr.GetInt64("id"),
                    Titulo = dr.GetString("titulo"),
                    Descripcion = dr.GetString("descripcion"),
                    Estado = dr.GetString("estado"),
                    FechaAlta = dr.GetDateTime("fechaAlta")
                });
            }

            return reclamosViewModel;

        }

    }
}
