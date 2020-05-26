using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvisoRepository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AvisoServices.Models;
using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Controllers;

namespace AvisoRepository.Repository
{
    public class AvisoRepository : IAvisoRepository
    {
        private readonly AvisoContexto _context;

        public AvisoRepository(AvisoContexto context)
        {
            _context = context;
          
        }

        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _context.AvisoItems.ToList();
        }
       
        public async Task AddAvisoItems(Aviso items)
        {
            _context.AvisoItems.Add(items);
            await _context.SaveChangesAsync();
        }
       

    }
    
}
