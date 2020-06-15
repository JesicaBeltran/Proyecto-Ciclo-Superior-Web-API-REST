using AvisoServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvisoServices.Services
{
   public interface IAvisoServices
    {
        Task AddAvisoItems(Aviso items);
        IEnumerable<Aviso> GetAvisoItems();
    }
}
