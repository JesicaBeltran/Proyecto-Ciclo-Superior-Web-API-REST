using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
using AvisoServices.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Supermercados.Models;
using Microsoft.EntityFrameworkCore.Internal;

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
        [Route("GetAvisoItems/provincia/{provincia_id}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoPorProvincia(string provincia_id)
        {
            var avisoItems = _avisoService.GetAvisoPorProvincia(provincia_id);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }
        [HttpGet]
        [Route("GetAvisoItems/pl/{provincia_id}/{localidad_id}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoProvinciaYLocalidad(string provincia_id,string localidad_id)
        {
            var avisoItems = _avisoService.GetAvisoProvinciaYLocalidad(provincia_id, localidad_id);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }

        [HttpGet]
        [Route("GetAvisoItems/pls/{provincia_id}/{localidad_id}/{supermercado_id}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoProvinciaYLocalidadYSupermercado(string provincia_id, string localidad_id, string supermercado_id)
        {
            var avisoItems = _avisoService.GetAvisoProvinciaYLocalidadYSupermercado(provincia_id, localidad_id,supermercado_id);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }
        [HttpGet]
        [Route("GetAvisoItems/supermercado/{supermercado_id}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoPorSupermercado(string supermercado_id)
        {
            var avisoItems = _avisoService.GetAvisoPorSupermercado(supermercado_id);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }
        [HttpGet]
        [Route("GetAvisoItems/ps/{provincia_id}/{supermercado_id}")]
        public ActionResult<IEnumerable<Aviso>> GetAvisoProvinciaYSupermercado(string provincia_id,string supermercado_id)
        {
            var avisoItems = _avisoService.GetAvisoProvinciaYSupermercado(provincia_id, supermercado_id);

            if (avisoItems.Equals(null))
            {

                return NotFound();
            }
            return avisoItems.ToList();
        }
        [HttpGet]
        [Route("GetSupermercados")]
        public ActionResult<IEnumerable<Supermercado>> GetSupermercados()
        {
            var supermercados = _avisoService.GetSupermercados();

            if (supermercados.Equals(null))
            {

                return NotFound();
            }
            return supermercados.ToList();
        }
        [HttpGet]
        [Route("GetProvincias")]
        public ActionResult<IEnumerable<Provincia>> GetProvincias()
        {
            var provincias = _avisoService.GetProvincias();

            if (provincias.Equals(null))
            {

                return NotFound();
            }
            return provincias.ToList();
        }

        [HttpGet]
        [Route("GetLocalidades")]
        public ActionResult<IEnumerable<Localidad>> GetLocalidades()
        {
            var localidades = _avisoService.GetLocalidades();

            if (localidades.Equals(null))
            {

                return NotFound();
            }
            return localidades.ToList();
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