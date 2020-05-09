using Microsoft.EntityFrameworkCore;
using AvisoServices.Models;
using System;

namespace AvisoRepository.Data
{
    public class AvisoContexto : DbContext
    {
        public AvisoContexto(DbContextOptions<AvisoContexto> options) : base(options)
        {
        }
        //crear nuestro dbset
        public DbSet<Aviso> AvisoItems { get; set; }

        //Datos insertados automáticamente en la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aviso>().HasData(new Aviso
            {
                Id = 1,
                Supermercado =  "Dia",
                CodigoPostal =  21110,
                Producto =  "leche",
                Comentario =  "No queda leche puleva"
            });


        }

    }
}
