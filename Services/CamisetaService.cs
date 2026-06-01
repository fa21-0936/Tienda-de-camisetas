using Trabajo_PrimerParcial.Interfaces;

namespace Trabajo_PrimerParcial.Services
{
    public class CamisetaService : ICamisetaService
    {
        public IEnumerable<object> GetCamisetas()
        {
            return new List<object>
            {
                new
                {
                    Id = 1,
                    Equipo = "Ninguno",
                    Talla = "M",
                    Precio = 3500
                },
                new
                {
                    Id = 2,
                    Equipo = "Barcelona",
                    Talla = "L",
                    Precio = 3400
                }
            };
        }
    }
}