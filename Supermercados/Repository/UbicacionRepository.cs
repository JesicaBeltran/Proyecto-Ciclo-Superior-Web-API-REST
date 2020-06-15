using AvisoRepository.Data;
using System.Collections.Generic;
using System.Linq;
using Supermercados.Models;

namespace UbicacionRepository.Repository
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly FoodLackContexto _context;
        public UbicacionRepository(FoodLackContexto context)
        {
            _context = context;
        }
        public IEnumerable<Provincia> GetProvincias()
        {
            return _context.Provincia.ToList();
        }
        public IEnumerable<Localidad> GetLocalidades()
        {
            return _context.Localidad.ToList();
        }
    }
}
