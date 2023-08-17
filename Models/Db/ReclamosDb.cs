using MySql.Data.MySqlClient;

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

        public void AltaDeReclamo()
        {


            //INSERT INTO reclamos(titulo, descripcion, estado, fechaAlta)
            //VALUES('ejemplo1', 'desc1', 'nuevo', '20230817');
            
        }

        public void ActualizarReclamo()
        {
            //UPDATE reclamos SET titulo = 'nuevo titulo' WHERE id = 1;

        }

        public void BorrarReclamo(long id)
        {
            //DELETE FROM reclamos WHERE id = 1;

        }

        public void BuscarReclamoPorId()
        {
            //SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos WHERE id = 1;

        }

        public void BuscarTodoLosReclamos()
        {
            //SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos;
        }

    }
}
