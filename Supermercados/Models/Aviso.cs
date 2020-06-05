using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvisoServices.Models
{
    public class Aviso
    {
        public int Id { get; set; }
        [Required]
        public string Supermercado_id { get; set; }
        [Required]
        public string Provincia_id { get; set; }
        public string Localidad_id { get; set; }
        public string Producto { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
