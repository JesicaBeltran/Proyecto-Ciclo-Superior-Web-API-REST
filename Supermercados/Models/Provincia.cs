using System.ComponentModel.DataAnnotations;

namespace Supermercados.Models
{
    public class Provincia
    {
        [Key]
        public string Provincia_id { get; set; }
        public string Nombre { get; set; }
    }
}
