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
        [EnableCors("AllowOrigin")]
        
        public ActionResult<IEnumerable<Aviso>> GetAvisoItems()
        {
            var avisoItems = _avisoService.GetAvisoItems();
            
            if (!avisoItems.Equals(null))
            {
                return avisoItems.ToList();
            }
            return NotFound();
        }

<<<<<<< Updated upstream
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
=======
        [HttpGet("{orden}")]
        [Route("GetAvisoItemsOrden/{orden}")]

        public ActionResult<IEnumerable<Aviso>> GetAvisoItemsOrden(string orden)
        {
            var avisoItemsOrden = _avisoService.GetAvisoItemsOrden(orden);
            if (!avisoItemsOrden.Equals(null))
            {
                return avisoItemsOrden.ToList();
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

>>>>>>> Stashed changes

        //Peticion tipo post: api/supermercados


        /* public async Task<ActionResult<Supermercado>> PostSupermercadoItem(Supermercado item)
         {
             _acciones.SupermercadoItems.Add(item);
             await _acciones.SaveChangesAsync();

             return CreatedAtAction(nameof(GetSupermercadoItems), new { id = item.Id }, item);

         }*/


       /*[HttpPost]
        [Route("AddAvisoItems")]
        public void AddAvisoItems(Aviso items)
        {
           _avisoService.AddAvisoItems.AddAvisoItems(items);

        }*/
    }
}