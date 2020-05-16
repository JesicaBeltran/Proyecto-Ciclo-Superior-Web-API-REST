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
        public string Supermercado { get; set; }
        [Required]
        public int CodigoPostal { get; set; }
        [Required]
        public string Producto { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
