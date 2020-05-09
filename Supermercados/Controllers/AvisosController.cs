using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
using AvisoServices.Services;
using System.Collections.Generic;
using System.Linq;

namespace AvisoService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AvisosController : ControllerBase
    {
        private readonly IAvisoServices _avisoService;

        public AvisosController(IAvisoServices avisoService)
        {
            _avisoService = avisoService;
        }

        //peticion tipo get: api/GetSupermercadoItems
        [HttpGet]
        [Route("GetAvisoItems")]
        
        public ActionResult<IEnumerable<Aviso>> GetAvisoItems()
        {
            var avisoItems = _avisoService.GetAvisoItems();
            
            if (!avisoItems.Equals(null))
            {
                return avisoItems.ToList();
            }
            return NotFound();
        }

        [HttpGet("{palabraClave}")]
        [Route("GetAvisoItemsBuscador/{palabraClave}")]

        public ActionResult<IEnumerable<Aviso>> GetAvisoItemsBuscador(string palabraClave)
        {
            var avisoItemsBuscado = _avisoService.GetAvisoItemsBuscador(palabraClave);

            if (!avisoItemsBuscado.Equals(null))
            {
                return avisoItemsBuscado.ToList();
            }
            return NotFound();
        }

        //Peticion tipo get: un solo registro api/supermercados/4
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Supermercado>> GetSupermercadoItem(int id)
        {
            var supermercadoItem = await _acciones.SupermercadoItems.FindAsync(id);
           
            if (supermercadoItem == null)
            {
                return NotFound();
            }
            return supermercadoItem;

        }*/

        [HttpPost]
        [Route("AddAvisoItems")]
        public void AddAvisoItems(Aviso items)
        {
            _avisoService.AddAvisoItems(items);

        }
    }
}