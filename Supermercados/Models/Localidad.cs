using System.ComponentModel.DataAnnotations;

namespace Supermercados.Models
{
    public class Localidad
    {
        [Key]
        public string Localidad_id { get; set; }
        public string Nombre { get; set; }
        public string Provincia_id { get; set; }
    }
}