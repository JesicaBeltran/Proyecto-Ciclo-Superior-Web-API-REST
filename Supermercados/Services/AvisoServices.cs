using AvisoRepository.Repository;
using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace AvisoServices.Services
{
    public class AvisoServices : IAvisoServices
    {
        private readonly Aviso _avisoItems;
        private readonly IAvisoRepository _avisoRepository;

        public AvisoServices(IAvisoRepository avisoRepository)
        {
            _avisoItems = new Aviso();
            _avisoRepository = avisoRepository;
        }
        //VER TODOS LOS AVISOS
        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _avisoRepository.GetAvisoItems();
        }
        //VER POR SUPERMERCADO

        public IEnumerable<Aviso> GetAvisoSupermercado(string localidad, string supermercado)
        {
            //operaciones
            var todosAvisos = _avisoRepository.GetAvisoItems();
            supermercado.ToUpperInvariant();

            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Localidad==localidad && buscado.Supermercado==supermercado)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        

    //VER AVISOS CON BUSCADOR POR SUPER/PRODUCTO
    public IEnumerable<Aviso> GetAvisoItemsBuscador(string palabraClave)
        {
            
            var todosAvisos = _avisoRepository.GetAvisoItems();

            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Producto.Contains(palabraClave) || buscado.Supermercado.Contains(palabraClave))
                {
                    encontrados.Add(buscado);
                }
            }
          
            return encontrados;

        }
        
        //Ordenar avisos
        public IEnumerable<Aviso> GetAvisoItemsOrden(string orden)
        {

            var todosAvisos = _avisoRepository.GetAvisoItems();

            var avisosOrden = new List<Aviso>();

            switch (orden)
            {
                case "fecha":
                    foreach (var buscado in todosAvisos)
                    {
                        avisosOrden.Add(buscado);
                    }
                    avisosOrden.Sort(
                         delegate (Aviso x, Aviso y)
                         {
                             return y.FechaCreacion.CompareTo(x.FechaCreacion);
                         });


                    return avisosOrden;
            
                case "alfabetico":
                    foreach (var buscado in todosAvisos)
                    {
                        avisosOrden.Add(buscado);
                    }
                    var ordenada=avisosOrden.OrderBy(f => f.Producto).ToList();
                    return ordenada;

                default:
                    return avisosOrden;
            }
        }
        //AÑADIR AVISO
        public async Task AddAvisoItems(Aviso items)
        {
            items.FechaCreacion = DateTime.Now;

            await _avisoRepository.AddAvisoItems(items);
            
        }

    }
}
