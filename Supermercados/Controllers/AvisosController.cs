using Microsoft.AspNetCore.Mvc;
using AvisoServices.Models;
using AvisoServices.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AvisoService.Controllers
{
    [Route("api/avisos/")]
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
        public async Task<IEnumerable<Aviso>> GetAvisoItems()
          {
            List<Aviso> result = null;
            try
            {
                var avisoItems = _avisoService.GetAvisoItems();
                await Task.Delay(1000);
                return avisoItems.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return result;
          }

        [HttpPost]
        [Route("AddAvisoItems")]
        public async Task<IActionResult> AddAvisoItems(Aviso items)
         {
            try
            {
                await _avisoService.AddAvisoItems(items);
                return CreatedAtAction(nameof(GetAvisoItems), new { id = items.Id }, items);
            }
            catch
            {
                return BadRequest();
            }
            
         }
    }
}