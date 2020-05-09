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

        //AÑADIR AVISO
        public void AddAvisoItems(Aviso items)
        {
            _avisoRepository.AddAvisoItems(items);
        }

    }
}
