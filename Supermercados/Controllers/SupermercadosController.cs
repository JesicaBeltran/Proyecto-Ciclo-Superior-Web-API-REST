using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercados.Models;
using SupermercadosServices.Services;

namespace Supermercados.Controllers
{
    [Route("api/supermercados/")]
    [ApiController]
    public class SupermercadosController : Controller
    {
        private readonly ISupermercadosServices _supermercadosService;
        public SupermercadosController(ISupermercadosServices supermercadosService)
        {
            _supermercadosService = supermercadosService;
        }

        [HttpGet]
        [Route("GetSupermercados")]
        public async Task<IEnumerable<Supermercado>> GetSupermercados()
        {
            List<Supermercado> supermercados = null;

            try
            {
                supermercados = _supermercadosService.GetSupermercados().ToList();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return supermercados;
        }
    }
}
