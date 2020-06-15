using Supermercados.Models;
using System.Collections.Generic;

namespace UbicacionServices.Services
{
    public interface IUbicacionServices
    {
        IEnumerable<Provincia> GetProvincias();
        IEnumerable<Localidad> GetLocalidades();
    }
}
