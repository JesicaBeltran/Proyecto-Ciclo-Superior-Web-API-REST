using System.Collections.Generic;
using System.Threading.Tasks;
using AvisoServices.Models;

namespace AvisoRepository.Repository
{
    public interface IAvisoRepository
    {
        Task AddAvisoItems(Aviso items); 
        IEnumerable<Aviso> GetAvisoItems();
    }
}
