using AvisoRepository.Repository;
using AvisoServices.Models;
using SupermercadosRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UbicacionRepository.Repository;

namespace AvisoServices.Services
{
    public class AvisoServices : IAvisoServices
    {
        private readonly IAvisoRepository _avisoRepository;
        private readonly IUbicacionRepository _ubicacionRepository;
        private readonly ISupermercadosRepository _supermercadosRepository;

        public AvisoServices(IAvisoRepository avisoRepository, ISupermercadosRepository supermercadosRepository, IUbicacionRepository ubicacionRepository)
        {
            _avisoRepository = avisoRepository;
            _ubicacionRepository = ubicacionRepository;
            _supermercadosRepository = supermercadosRepository;
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
        public IEnumerable<Aviso> GetAvisoItems()
        {
            var todosAvisos= _avisoRepository.GetAvisoItems();
            todosAvisos=CambiarDatosAvisos(todosAvisos.ToList());
            return todosAvisos;
        }
        public async Task AddAvisoItems(Aviso items)
        {
            items.FechaCreacion = DateTime.Now;
            
            var supermercados = _supermercadosRepository.GetSupermercados();
            var provincias = _ubicacionRepository.GetProvincias();
            var localidades = _ubicacionRepository.GetLocalidades();

            foreach(var s in supermercados)
            {
                if (items.Supermercado_id == s.Nombre)
                {
                    items.Supermercado_id = s.Supermercado_id;
                }
            }
            foreach(var p in provincias)
            {
                if(items.Provincia_id == p.Nombre)
                {
                    items.Provincia_id = p.Provincia_id;
                }
            }
            foreach(var l in localidades)
            {
                if (items.Localidad_id == l.Nombre)
                {
                    items.Localidad_id = l.Localidad_id;
                }
            }

            await _avisoRepository.AddAvisoItems(items);
            
        }
    }
}
