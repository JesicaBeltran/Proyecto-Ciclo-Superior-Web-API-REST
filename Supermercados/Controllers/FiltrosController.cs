using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisoServices.Models;
using FiltrosServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Supermercados.Controllers
{
    [Route("api/filtros/")]
    [ApiController]
    public class FiltrosController : Controller
    {
        private readonly IFiltrosServices _filtrosService;
        public FiltrosController(IFiltrosServices filtrosService)
        {
            _filtrosService = filtrosService;
        }
        [HttpGet]
        [Route("GetAvisoItems/provincia/{provincia_id}")]
        public async Task<IEnumerable<Aviso>> GetAvisoPorProvincia(string provincia_id)
        {
            List<Aviso> avisoItems = null;

            try
            {
                avisoItems= _filtrosService.GetAvisoPorProvincia(provincia_id).ToList();
                await Task.Delay(1000);
            }
            catch(Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return avisoItems;
        }

        [HttpGet]
        [Route("GetAvisoItems/pl/{provincia_id}/{localidad_id}")]
        public async Task<IEnumerable<Aviso>> GetAvisoProvinciaYLocalidad(string provincia_id, string localidad_id)
        {
            List<Aviso> avisoItems = null;
            try
            {
                avisoItems = _filtrosService.GetAvisoProvinciaYLocalidad(provincia_id, localidad_id).ToList();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return avisoItems;
        }

        [HttpPost]
        [Route("GetAvisoItemsOrdenFecha")]
        public async Task<IEnumerable<Aviso>> GetAvisoItemsOrdenFecha(List<Aviso> avisos)
        {
            List<Aviso> avisoItems = null;
            try
            {
                avisoItems = _filtrosService.GetAvisoItemsOrdenFecha(avisos).ToList();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return avisoItems;
        }

        [HttpPost]
        [Route("GetAvisoItemsOrdenAlfabetico")]
        public async Task<IEnumerable<Aviso>> GetAvisoItemsOrdenAlfabetico(List<Aviso> avisos)
        {
            List<Aviso> avisoItems = null;
            try
            {
                avisoItems = _filtrosService.GetAvisoItemsOrdenAlfabetico(avisos).ToList();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return avisoItems;
        }
    }
}
