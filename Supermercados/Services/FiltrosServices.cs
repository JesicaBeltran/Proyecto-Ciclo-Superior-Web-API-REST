using AvisoRepository.Repository;
using AvisoServices.Models;
using SupermercadosRepository.Repository;
using System.Collections.Generic;
using System.Linq;
using UbicacionRepository.Repository;

namespace FiltrosServices.Services
{
    public class FiltrosServices : IFiltrosServices
    {
        private readonly IAvisoRepository _avisoRepository;
        private readonly IUbicacionRepository _ubicacionRepository;
        private readonly ISupermercadosRepository _supermercadosRepository;

        public FiltrosServices(IAvisoRepository avisoRepository, IUbicacionRepository ubicacionRepository, ISupermercadosRepository supermercadosRepository)
        {
            _avisoRepository = avisoRepository;
            _ubicacionRepository = ubicacionRepository;
            _supermercadosRepository = supermercadosRepository;
        }
        public IEnumerable<Aviso> GetAvisoPorProvincia(string provincia_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id)
                {
                    encontrados.Add(buscado);
                }
            }
            return CambiarDatosAvisos(encontrados);
        }
        public IEnumerable<Aviso> GetAvisoProvinciaYLocalidad(string provincia_id, string localidad_id)
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var encontrados = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                if (buscado.Provincia_id == provincia_id && buscado.Localidad_id == localidad_id)
                {
                    encontrados.Add(buscado);
                }
            }
            return CambiarDatosAvisos(encontrados);
        }
        public IEnumerable<Aviso> GetAvisoItemsOrdenFecha(List<Aviso> avisos)
        {

            var todosAvisos = avisos;
            var avisosOrden = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                avisosOrden.Add(buscado);
            }
            avisosOrden.Sort(
                 delegate (Aviso x, Aviso y)
                 {
                     return y.FechaCreacion.CompareTo(x.FechaCreacion);
                 });
            return CambiarDatosAvisos(avisosOrden);
        }

        public IEnumerable<Aviso> GetAvisoItemsOrdenAlfabetico(List<Aviso> avisos)
        {
            var todosAvisos = avisos;
            var avisosOrden = new List<Aviso>();

            foreach (var buscado in todosAvisos)
            {
                avisosOrden.Add(buscado);
            }
            var ordenada = avisosOrden.OrderBy(f => f.Producto).ToList();
            return CambiarDatosAvisos(ordenada);
        }

        public IEnumerable<Aviso> CambiarDatosAvisos(List<Aviso> todosAvisos)
        {
            var supermercados = _supermercadosRepository.GetSupermercados();
            var provincias = _ubicacionRepository.GetProvincias();
            var localidades = _ubicacionRepository.GetLocalidades();

            foreach (var aviso in todosAvisos)
            {
                foreach (var supermercado in supermercados)
                {
                    if (aviso.Supermercado_id == supermercado.Supermercado_id)
                    {
                        aviso.Supermercado_id = supermercado.Nombre;

                    }
                }
                foreach (var provincia in provincias)
                {
                    if (aviso.Provincia_id == provincia.Provincia_id)
                    {
                        aviso.Provincia_id = provincia.Nombre;

                    }
                }
                foreach (var localidad in localidades)
                {
                    if (aviso.Localidad_id == localidad.Localidad_id)
                    {
                        aviso.Localidad_id = localidad.Nombre;

                    }
                }
            }
            return todosAvisos;
        }
    }
}
