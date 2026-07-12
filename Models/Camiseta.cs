namespace Trabajo_PrimerParcial.Models
{
    public class Camiseta
    {
        public int Id { get; set; }

        public string Equipo { get; set; } = string.Empty;

        public string Talla { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string Color { get; set; }

        public string Tipo { get; set; }

        public string Liga { get; set; }

    }
}