using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Trabajo_PrimerParcial.Models;

namespace Trabajo_PrimerParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamisetasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CamisetasController> _logger;


        public CamisetasController(
            IConfiguration configuration,
            ILogger<CamisetasController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Consulta de camisetas.");

            var lista = new List<Camiseta>();

            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();


            string sql =
                @"SELECT Id, Equipo, Talla, Precio, Color, Tipo, Liga
                  FROM Camisetas";


            SqlCommand cmd = new(sql, conexion);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                lista.Add(new Camiseta
                {
                    Id = Convert.ToInt32(reader["Id"]),

                    Equipo = reader["Equipo"].ToString()!,

                    Talla = reader["Talla"].ToString()!,

                    Precio = Convert.ToDecimal(reader["Precio"]),

                    Color = reader["Color"].ToString()!,

                    Tipo = reader["Tipo"].ToString()!,

                    Liga = reader["Liga"].ToString()!
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
                @"SELECT Id, Equipo, Talla, Precio, Color, Tipo, Liga
                  FROM Camisetas
                  WHERE Id=@Id";


            SqlCommand cmd = new(sql, conexion);

            cmd.Parameters.AddWithValue("@Id", id);


            SqlDataReader reader = cmd.ExecuteReader();


            if (!reader.Read())
                return NotFound();



            Camiseta camiseta = new()
            {
                Id = Convert.ToInt32(reader["Id"]),

                Equipo = reader["Equipo"].ToString()!,

                Talla = reader["Talla"].ToString()!,

                Precio = Convert.ToDecimal(reader["Precio"]),

                Color = reader["Color"].ToString()!,

                Tipo = reader["Tipo"].ToString()!,

                Liga = reader["Liga"].ToString()!
            };


            return Ok(camiseta);
        }




        [HttpPost]
        public IActionResult Post(Camiseta camiseta)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();



            string sql =
                @"INSERT INTO Camisetas
                (Equipo, Talla, Precio, Color, Tipo, Liga)
                VALUES
                (@Equipo, @Talla, @Precio, @Color, @Tipo, @Liga)";



            SqlCommand cmd = new(sql, conexion);


            cmd.Parameters.AddWithValue("@Equipo", camiseta.Equipo);

            cmd.Parameters.AddWithValue("@Talla", camiseta.Talla);

            cmd.Parameters.AddWithValue("@Precio", camiseta.Precio);

            cmd.Parameters.AddWithValue("@Color", camiseta.Color);

            cmd.Parameters.AddWithValue("@Tipo", camiseta.Tipo);

            cmd.Parameters.AddWithValue("@Liga", camiseta.Liga);



            cmd.ExecuteNonQuery();


            return Ok("Registro insertado");
        }





        [HttpPut("{id}")]
        public IActionResult Put(int id, Camiseta camiseta)
        {
            using SqlConnection conexion =
                new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            conexion.Open();



            string sql =
                @"UPDATE Camisetas
                SET Equipo=@Equipo,
                    Talla=@Talla,
                    Precio=@Precio,
                    Color=@Color,
                    Tipo=@Tipo,
                    Liga=@Liga
                WHERE Id=@Id";



            SqlCommand cmd = new(sql, conexion);



            cmd.Parameters.AddWithValue("@Id", id);

            cmd.Parameters.AddWithValue("@Equipo", camiseta.Equipo);

            cmd.Parameters.AddWithValue("@Talla", camiseta.Talla);

            cmd.Parameters.AddWithValue("@Precio", camiseta.Precio);

            cmd.Parameters.AddWithValue("@Color", camiseta.Color);

            cmd.Parameters.AddWithValue("@Tipo", camiseta.Tipo);

            cmd.Parameters.AddWithValue("@Liga", camiseta.Liga);



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
                "DELETE FROM Camisetas WHERE Id=@Id";



            SqlCommand cmd = new(sql, conexion);


            cmd.Parameters.AddWithValue("@Id", id);


            cmd.ExecuteNonQuery();


            return Ok("Registro eliminado");
        }
    }
}