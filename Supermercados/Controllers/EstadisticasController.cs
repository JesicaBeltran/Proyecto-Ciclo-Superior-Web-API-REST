using System;
using System.Collections;
using System.Threading.Tasks;
using EstadisticasServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Supermercados.Controllers
{
    [Route("api/estadisticas/")]
    [ApiController]
    public class EstadisticasController : Controller
    {
        private readonly IEstadisticasServices _estadisticaService;
        public EstadisticasController(IEstadisticasServices estadisticaService)
        {
            _estadisticaService = estadisticaService;
        }
        [HttpGet]
        [Route("estadisticasSupermercados")]
        public ArrayList getDatosEstadisticas()
        {
            ArrayList result = null;
            try
            {
                result = _estadisticaService.GetDatosEstadisticasSupermercados();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return result;
        }
        [HttpGet]
        [Route("estadisticasProductos")]
        public ArrayList getDatosEstadisticasProductos()
        {
            ArrayList result = null;
            try
            {
                result = _estadisticaService.GetDatosEstadisticasProductos();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return result;
        }
        [HttpGet]
        [Route("estadisticasTotalAvisos")]
        public int getEstadisticasTotalAvisos()
        {
            int result = 0;
            try
            {
                result = _estadisticaService.getEstadisticasTotalAvisos();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay datos", ex);
                BadRequest();
            }
            return result;
        }
    }
}
