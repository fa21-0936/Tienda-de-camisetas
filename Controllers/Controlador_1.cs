using Microsoft.AspNetCore.Mvc;

namespace Trabajo_PrimerParcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API funcionando");
        }
    }
}