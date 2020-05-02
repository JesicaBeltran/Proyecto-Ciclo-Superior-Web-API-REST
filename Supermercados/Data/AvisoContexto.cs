using Microsoft.EntityFrameworkCore;
using AvisoServices.Models;

namespace AvisoRepository.Data
{
    public class AvisoContexto : DbContext
    {
        public AvisoContexto(DbContextOptions<AvisoContexto> options) : base(options)
        {
        }
        //crear nuestro dbset
        public DbSet<Aviso> AvisoItems { get; set; }

    }
}
