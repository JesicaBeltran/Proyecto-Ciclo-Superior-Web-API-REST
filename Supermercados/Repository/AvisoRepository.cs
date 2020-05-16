using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvisoRepository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AvisoServices.Models;

namespace AvisoRepository.Repository
{
    public class AvisoRepository : IAvisoRepository
    {
        private readonly AvisoContexto _context;

        public AvisoRepository(AvisoContexto context)
        {
            _context = context;
          
        }

        /* public async Task<ActionResult<IEnumerable<Supermercado>>> GetSupermercadoItems()
         {

             return await _context.ToListAsync();
         }*/

        public IEnumerable<Aviso> GetAvisoItems()
        {
            return _context.AvisoItems.ToList();
        }
<<<<<<< Updated upstream
=======
        public void AddAvisoItems(Aviso items)
        {
            items.FechaCreacion = DateTime.Now;
            _context.AvisoItems.Add(items);
            _context.SaveChanges();
        }
        
>>>>>>> Stashed changes
    }
    
}
