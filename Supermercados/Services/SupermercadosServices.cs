using Supermercados.Models;
using SupermercadosRepository.Repository;
using System.Collections.Generic;

namespace SupermercadosServices.Services
{
    public class SupermercadosServices : ISupermercadosServices
    {
        private readonly ISupermercadosRepository _supermercadosRepository;
        public SupermercadosServices(ISupermercadosRepository supermercadosRepository)
        {
            _supermercadosRepository = supermercadosRepository;
        }
        public IEnumerable<Supermercado> GetSupermercados()
        {
            return _supermercadosRepository.GetSupermercados();
        }
    }
}
