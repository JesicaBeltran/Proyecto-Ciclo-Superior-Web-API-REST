using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
using AvisoServices.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("GetAvisoItems")]
       public ActionResult<IEnumerable<Aviso>> GetAvisoItems()
        {
            var avisoItems = _avisoService.GetAvisoItems();

            if (avisoItems.Equals(null))
             {
                 
                return NotFound();
            }
            return avisoItems.ToList();
        }

        [HttpGet]
        [Route("GetAvisoSupermercado/{localidad}/{supermercado}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoSupermercado(string localidad, string supermercado)
        {
            var avisoItems = _avisoService.GetAvisoSupermercado(localidad,supermercado);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }

        [HttpGet("{orden}")]
        [Route("GetAvisoItemsOrden/{orden}")]

        public ActionResult<IEnumerable<Aviso>> GetAvisoItemsOrden(string orden)
        {
            var avisoItemsOrden = _avisoService.GetAvisoItemsOrden(orden);
            if (!avisoItemsOrden.Equals(null))
            {
                //estooo
                return Ok(avisoItemsOrden.ToList());
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

    
      [HttpPost]
        [Route("AddAvisoItems")]
        public async Task<IActionResult> AddAvisoItems(Aviso items)
         {
            try
            {
                await _avisoService.AddAvisoItems(items);
                return CreatedAtAction(nameof(GetAvisoItems), new { id = items.Id }, items);
                //return Ok(items);
            }
            catch
            {
                return BadRequest();
            }
            
         }
       
    }
}