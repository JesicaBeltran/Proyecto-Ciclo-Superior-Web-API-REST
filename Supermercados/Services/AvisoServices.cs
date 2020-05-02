using AvisoRepository.Repository;
using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _avisoRepository.GetAvisoItems();
        }

        public void AddAvisoItems(Aviso items)
        {
            _avisoRepository.AddAvisoItems(items);
        }

    }
}
