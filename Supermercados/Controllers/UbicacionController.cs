using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercados.Models;
using UbicacionServices.Services;


namespace Supermercados.Controllers
{
    [Route("api/ubicacion/")]
    [ApiController]
    public class UbicacionController : Controller
    {
        private readonly IUbicacionServices _ubicacionService;
        public UbicacionController(IUbicacionServices ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }
        [HttpGet]
        [Route("GetProvincias")]
        public async Task<IEnumerable<Provincia>> GetProvincias()
        {
            List<Provincia> provincias = null;

            try
            {
                provincias = _ubicacionService.GetProvincias().ToList();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return provincias;
        }

        [HttpGet]
        [Route("GetLocalidades")]
        public ActionResult<IEnumerable<Localidad>> GetLocalidades()
        {
            var localidades = _ubicacionService.GetLocalidades();

            if (localidades.Equals(null))
            {

                return NotFound();
            }
            return localidades.ToList();
        }
    }
}
