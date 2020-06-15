using System.ComponentModel.DataAnnotations;

namespace Supermercados.Models
{
    public class Supermercado
    {
        [Key]
        public string Supermercado_id { get; set; }
        public string Nombre { get; set; }
    }
}
