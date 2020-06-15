using Supermercados.Models;
using System.Collections.Generic;

namespace SupermercadosRepository.Repository
{
    public interface ISupermercadosRepository
    {
        IEnumerable<Supermercado> GetSupermercados();
    }
}
