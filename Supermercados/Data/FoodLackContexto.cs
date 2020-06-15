using Microsoft.EntityFrameworkCore;
using AvisoServices.Models;
using System;
using Supermercados.Models;

namespace AvisoRepository.Data
{
    public class FoodLackContexto : DbContext
    {
        public FoodLackContexto(DbContextOptions<FoodLackContexto> options) : base(options) { }
        public DbSet<Aviso> AvisoItems { get; set; }
        public DbSet<Supermercado> Supermercado { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Aviso>().HasData(new Aviso
            {
                Id = 1,
                Supermercado_id = "01",
                Provincia_id = "01",
                Localidad_id = "01",
                Producto = "leche",
                Comentario = "No queda leche puleva",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 2,
                Supermercado_id = "02",
                Provincia_id = "02",
                Localidad_id = "04",
                Producto = "pan",
                Comentario = "No queda pan de molde",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 3,
                Supermercado_id = "03",
                Provincia_id = "03",
                Localidad_id = "07",
                Producto = "huevos",
                Comentario = "No quedan huevos M",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 4,
                Supermercado_id = "04",
                Provincia_id = "03",
                Localidad_id = "09",
                Producto = "huevos",
                Comentario = "No quedan huevos XL",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 5,
                Supermercado_id = "03",
                Provincia_id = "02",
                Localidad_id = "04",
                Producto = "huevos",
                Comentario = "No quedan huevos M",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 6,
                Supermercado_id = "03",
                Provincia_id = "03",
                Localidad_id = "07",
                Producto = "pan",
                Comentario = "No quedan baguettes",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 7,
                Supermercado_id = "01",
                Provincia_id = "01",
                Localidad_id = "02",
                Producto = "pan",
                Comentario = "No queda pan de molde bimbo",
                FechaCreacion = DateTime.Now
            }) ;
            modelBuilder.Entity<Supermercado>().HasData(
                new Supermercado { Supermercado_id="01",Nombre="Dia"},
                new Supermercado { Supermercado_id="02",Nombre="Aldi"},
                new Supermercado { Supermercado_id="03",Nombre="Mercadona"},
                new Supermercado { Supermercado_id="04",Nombre="El Jamon"},
                new Supermercado { Supermercado_id="05",Nombre="Carrefour"}
                );

            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Provincia_id = "01", Nombre = "Huelva" },
                new Provincia { Provincia_id = "02", Nombre = "Sevilla" },
                new Provincia { Provincia_id = "03", Nombre = "Cadiz"}
                );

            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Localidad_id="01",Nombre="Aljaraque",Provincia_id="01"},
                new Localidad { Localidad_id = "02", Nombre = "Bonares", Provincia_id = "01" },
                new Localidad { Localidad_id = "03", Nombre = "Cartaya", Provincia_id = "01" },

                new Localidad { Localidad_id = "04", Nombre = "Aguadulce", Provincia_id = "02" },
                new Localidad { Localidad_id = "05", Nombre = "Bormujos", Provincia_id = "02" },
                new Localidad { Localidad_id = "06", Nombre = "Cantillana", Provincia_id = "02" },

                new Localidad { Localidad_id = "07", Nombre = "Algeciras", Provincia_id = "03" },
                new Localidad { Localidad_id = "08", Nombre = "Barbate", Provincia_id = "03" },
                new Localidad { Localidad_id = "09", Nombre = "Ciudad Real", Provincia_id = "03" }
                );

            modelBuilder.Entity<Localidad>()
                      .HasOne<Provincia>()
                      .WithMany()
                      .HasForeignKey(p => p.Provincia_id);

            modelBuilder.Entity<Aviso>()
                     
                      .HasOne<Supermercado>()
                      .WithMany()
                      .HasForeignKey(p => p.Supermercado_id);

            modelBuilder.Entity<Aviso>()
                     .HasOne<Provincia>()
                     .WithMany()
                     .HasForeignKey(p => p.Provincia_id);

            modelBuilder.Entity<Aviso>()
                     .HasOne<Localidad>()
                     .WithMany()
                     .HasForeignKey(p => p.Localidad_id);
        }
        }
    }
