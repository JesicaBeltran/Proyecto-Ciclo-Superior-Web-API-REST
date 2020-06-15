using Supermercados.Models;
using System.Collections.Generic;

namespace UbicacionRepository.Repository
{
    public interface IUbicacionRepository
    {
       IEnumerable<Provincia> GetProvincias();
       IEnumerable<Localidad> GetLocalidades();
    }
}
