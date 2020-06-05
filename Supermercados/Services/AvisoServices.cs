using AvisoRepository.Repository;
using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Supermercados.Models;
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
       
        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _avisoRepository.GetAvisoItems();
        }

        public IEnumerable<Supermercado> GetSupermercados()
        {
            return _avisoRepository.GetSupermercados();
        }
        public IEnumerable<Aviso> GetAvisoPorSupermercado(string supermercado_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Supermercado_id == supermercado_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Aviso> GetAvisoPorProvincia(string provincia_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Aviso> GetAvisoProvinciaYSupermercado(string provincia_id, string supermercado_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id && buscado.Supermercado_id == supermercado_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Aviso> GetAvisoProvinciaYLocalidad(string provincia_id, string localidad_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id && buscado.Localidad_id == localidad_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Aviso> GetAvisoProvinciaYLocalidadYSupermercado(string provincia_id, string localidad_id, string supermercado_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id && buscado.Localidad_id == localidad_id && buscado.Supermercado_id == supermercado_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Aviso> GetAvisoBuscador(string localidad_id,string supermercado_id, string palabraClave)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Producto.Contains(palabraClave) && buscado.Localidad_id==localidad_id && buscado.Supermercado_id==supermercado_id)
                {
                    encontrados.Add(buscado);
                }
            }

            return encontrados;
        }
        public IEnumerable<Provincia> GetProvincias()
        {
            return _avisoRepository.GetProvincias();
        }
        public IEnumerable<Localidad> GetLocalidades()
        {
            return _avisoRepository.GetLocalidades();
        }

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
        public async Task AddAvisoItems(Aviso items)
        {
            items.FechaCreacion = DateTime.Now;

            await _avisoRepository.AddAvisoItems(items);
            
        }

    }
}
