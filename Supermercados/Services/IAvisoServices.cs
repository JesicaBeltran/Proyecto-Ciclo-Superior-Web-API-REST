using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Supermercados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvisoServices.Services
{
   public interface IAvisoServices
    {
        Task AddAvisoItems(Aviso items);
        IEnumerable<Aviso> GetAvisoItems();
        IEnumerable<Aviso> GetAvisoPorSupermercado(string supermercado_id);
        IEnumerable<Aviso> GetAvisoPorProvincia(string provincia_id);
        IEnumerable<Aviso> GetAvisoProvinciaYLocalidad(string provincia_id, string localidad_id);
        IEnumerable<Aviso> GetAvisoProvinciaYSupermercado(string provincia_id, string supermercado_id);
        IEnumerable<Aviso> GetAvisoProvinciaYLocalidadYSupermercado(string provincia_id, string localidad_id, string supermercado_id);
        IEnumerable<Aviso> GetAvisoBuscador(string localidad_id,string supermercado_id, string palabraClave);
        IEnumerable<Provincia> GetProvincias();
        IEnumerable<Localidad> GetLocalidades();
        IEnumerable<Supermercado> GetSupermercados();
        IEnumerable<Aviso> GetAvisoItemsOrden(string orden);
    }
}
