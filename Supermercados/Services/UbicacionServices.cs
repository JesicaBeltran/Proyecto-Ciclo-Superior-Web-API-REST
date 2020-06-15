using Supermercados.Models;
using System.Collections.Generic;
using UbicacionRepository.Repository;

namespace UbicacionServices.Services
{
    public class UbicacionServices : IUbicacionServices
    {
        private readonly IUbicacionRepository _ubicacionRepository;

        public UbicacionServices(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }
        public IEnumerable<Provincia> GetProvincias()
        {
            return _ubicacionRepository.GetProvincias();
        }
        public IEnumerable<Localidad> GetLocalidades()
        {
            return _ubicacionRepository.GetLocalidades();
        }
    }
}
