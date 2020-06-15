using AvisoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltrosServices.Services
{
    public interface IFiltrosServices
    {
        IEnumerable<Aviso> GetAvisoPorProvincia(string provincia_id);
        IEnumerable<Aviso> GetAvisoProvinciaYLocalidad(string provincia_id, string localidad_id);
        IEnumerable<Aviso> GetAvisoItemsOrdenFecha(List<Aviso> avisos);
        IEnumerable<Aviso> GetAvisoItemsOrdenAlfabetico(List<Aviso> avisos);
    }
}
