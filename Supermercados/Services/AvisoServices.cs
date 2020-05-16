using AvisoRepository.Repository;
using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //VER AVISOS CON BUSCADOR
        public IEnumerable<Aviso> GetAvisoItemsBuscador(string palabraClave)
        {
            
            var todosAvisos = _avisoRepository.GetAvisoItems();

            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Supermercado.Contains(palabraClave))
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
                    

                default:
                    return avisosOrden;
            }
        }
        //AÑADIR AVISO
        public void AddAvisoItems(Aviso items)
        {
           // items.fecha...actual
            _avisoRepository.AddAvisoItems(items);
        }

    }
}
