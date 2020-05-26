using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvisoServices.Services
{
   public interface IAvisoServices
    {
        Task AddAvisoItems(Aviso items);
        IEnumerable<Aviso> GetAvisoItems();
        IEnumerable<Aviso> GetAvisoSupermercado(string localidad, string supermercado);
        IEnumerable<Aviso> GetAvisoProducto(string localidad, string producto);
        IEnumerable<Aviso> GetAvisoItemsBuscador(string palabraClave);
        IEnumerable<Aviso> GetAvisoItemsOrden(string orden);
    }
}
