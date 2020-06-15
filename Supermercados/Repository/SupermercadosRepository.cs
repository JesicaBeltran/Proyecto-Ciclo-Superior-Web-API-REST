using AvisoRepository.Data;
using Supermercados.Models;
using System.Collections.Generic;
using System.Linq;

namespace SupermercadosRepository.Repository
{
    public class SupermercadosRepository : ISupermercadosRepository
    {
        private readonly FoodLackContexto _context;
        public SupermercadosRepository(FoodLackContexto context)
        {
            _context = context;
        }
        public IEnumerable<Supermercado> GetSupermercados()
        {
            return _context.Supermercado.ToList();
        }
    }
}
