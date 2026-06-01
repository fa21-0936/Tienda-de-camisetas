using Microsoft.Data.SqlClient;

namespace Trabajo_PrimerParcial.Services
{
    public class DatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ProbarConexion()
        {
            try
            {
                string? connectionString =
                    _configuration.GetConnectionString("DefaultConnection");

                using SqlConnection conexion =
                    new SqlConnection(connectionString);

                conexion.Open();

                return "Se realizó la conexión a SQL Server";
            }
            catch (Exception ex)
            {
                return $"Error de conexión: {ex.Message}";
            }
        }
    }
}