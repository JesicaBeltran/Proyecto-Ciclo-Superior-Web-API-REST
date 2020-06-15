using AvisoRepository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AvisoServices.Models;

namespace AvisoRepository.Repository
{
    public class AvisoRepository : IAvisoRepository
    {
        private readonly FoodLackContexto _context;
        public AvisoRepository(FoodLackContexto context)
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
