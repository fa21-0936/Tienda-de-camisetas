using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Trabajo_PrimerParcial.Models;

namespace Trabajo_PrimerParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CategoriasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<Categoria>();

            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();

            string sql =
                "SELECT * FROM Categorias";

            SqlCommand cmd = new(sql, conexion);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Categoria
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString()!
                });
            }

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();

            string sql =
                "SELECT * FROM Categorias WHERE Id=@Id";

            SqlCommand cmd = new(sql, conexion);

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
                return NotFound();

            Categoria categoria = new()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombre = reader["Nombre"].ToString()!
            };

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();

            string sql =
                "INSERT INTO Categorias(Nombre) VALUES(@Nombre)";

            SqlCommand cmd = new(sql, conexion);

            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);

            cmd.ExecuteNonQuery();

            return Ok("Registro insertado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();

            string sql =
                "UPDATE Categorias SET Nombre=@Nombre WHERE Id=@Id";

            SqlCommand cmd = new(sql, conexion);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);

            cmd.ExecuteNonQuery();

            return Ok("Registro actualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();

            string sql =
                "DELETE FROM Categorias WHERE Id=@Id";

            SqlCommand cmd = new(sql, conexion);

            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            return Ok("Registro eliminado");
        }
    }
}