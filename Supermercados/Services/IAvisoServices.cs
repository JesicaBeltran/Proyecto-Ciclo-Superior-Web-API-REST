using AvisoServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AvisoServices.Services
{
   public interface IAvisoServices
    {
        //public void AddAvisoItems(Aviso items);
        IEnumerable<Aviso> GetAvisoItems();
<<<<<<< Updated upstream
=======
        IEnumerable<Aviso> GetAvisoItemsBuscador(string palabraClave);
        IEnumerable<Aviso> GetAvisoItemsOrden(string orden);
>>>>>>> Stashed changes
    }
}
