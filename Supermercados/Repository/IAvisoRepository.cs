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
        IEnumerable<Aviso> GetAvisoItems();
       // void AddAvisoItems(Aviso items);
        //Task<ActionResult<Aviso>> AddAvisoItems(Aviso items);
        void AddAvisoItems(Aviso items);
    }
}
