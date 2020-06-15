using Supermercados.Models;
using System.Collections.Generic;

namespace SupermercadosServices.Services
{
    public interface ISupermercadosServices
    {
        IEnumerable<Supermercado> GetSupermercados();
    }
}
