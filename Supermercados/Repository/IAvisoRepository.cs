using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
using Supermercados.Models;

namespace AvisoRepository.Repository
{
    public interface IAvisoRepository
    {
        Task AddAvisoItems(Aviso items); 
        IEnumerable<Aviso> GetAvisoItems();
        IEnumerable<Supermercado> GetSupermercados();
        IEnumerable<Provincia> GetProvincias();
        IEnumerable<Localidad> GetLocalidades();
    }
}
