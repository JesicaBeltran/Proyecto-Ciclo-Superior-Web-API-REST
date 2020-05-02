using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
namespace AvisoRepository.Repository
{
    public interface IAvisoRepository
    {
        //Task<ActionResult<IEnumerable<Supermercado>>> GetSupermercadoItems();
        IEnumerable<Aviso> GetAvisoItems();
    }
}
