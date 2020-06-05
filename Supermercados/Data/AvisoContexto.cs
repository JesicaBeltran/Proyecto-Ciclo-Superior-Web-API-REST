using Microsoft.EntityFrameworkCore;
using AvisoServices.Models;

using System;
using Supermercados.Models;
using System.Reflection;
using System.IO;
using CsvHelper;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvisoRepository.Data
{
    public class AvisoContexto : DbContext
    {
        public AvisoContexto(DbContextOptions<AvisoContexto> options) : base(options)
        {
        }
        public DbSet<Aviso> AvisoItems { get; set; }
        public DbSet<Supermercado> Supermercado { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Localidad> Localidad { get; set; }

        //Datos insertados automáticamente en la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aviso>().HasData(new Aviso
            {
                Id = 1,
                Supermercado_id = "01",
                Provincia_id = "01",
                Localidad_id="01",
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
                Producto = "galletas",
                Comentario = "No queda galletas de avena",
                FechaCreacion = DateTime.Now
            },
            new Aviso
            {
                Id = 3,
                Supermercado_id = "03",
                Provincia_id = "03",
                Localidad_id = "07",
                Producto = "servilletas",
                Comentario = "No quedan servilletas blancas",
                FechaCreacion = DateTime.Now
            });

            //Cargar contenido de tabla Supermercados desde archivo .csv
            /* using var readerSupermercado = new StreamReader("Domain/SeedData/supermercados.csv");
             using var csvSupermercado = new CsvReader(readerSupermercado, System.Globalization.CultureInfo.InvariantCulture);
             csvSupermercado.Configuration.HasHeaderRecord = false;
             while (csvSupermercado.Read())
             {
                 try
                 {
                     var records = csvSupermercado.GetRecords<Supermercado>();
                     modelBuilder.Entity<Supermercado>().HasData(records);
                 }
                 catch (Exception ex)
                 {
                     //ex.Data.Values has more info...
                 }
             }*/
            modelBuilder.Entity<Supermercado>().HasData(
                new Supermercado { Supermercado_id="01",Nombre="Dia"},
                new Supermercado { Supermercado_id="02",Nombre="Aldi"},
                new Supermercado { Supermercado_id="03",Nombre="Mercadona"},
                new Supermercado { Supermercado_id="04",Nombre="El Jamon"},
                new Supermercado { Supermercado_id="05",Nombre="Carrefour"}
                );


            //Cargar contenido de tabla Provincias desde archivo .csv
            /* var reader = new StreamReader("Domain/SeedData/provincias.csv");
             var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);

             csv.Configuration.HasHeaderRecord = false;
             csv.Configuration.MissingFieldFound = null;

             while (csv.Read())
             {
                     var records = csv.GetRecords<Provincia>();
                     modelBuilder.Entity<Provincia>().HasData(records);
             }

             //Cargar contenido de tabla Localidades desde archivo .csv
             var readerLocalidad = new StreamReader("Domain/SeedData/municipios.csv");
             var csvLocalidad = new CsvReader(readerLocalidad, System.Globalization.CultureInfo.InvariantCulture);
             csvLocalidad.Configuration.HasHeaderRecord = false;
             csvLocalidad.Configuration.MissingFieldFound = null;

             while (csvLocalidad.Read())
             {
                 try
                 {
                     var records = csvLocalidad.GetRecords<Localidad>();
                     modelBuilder.Entity<Localidad>().HasData(records);
                 }
                 catch (Exception e) { }
             }*/

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
