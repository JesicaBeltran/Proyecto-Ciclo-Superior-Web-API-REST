using AvisoRepository.Repository;
using System.Collections;
using System.Linq;

namespace EstadisticasServices.Services
{
    public class EstadisticasServices : IEstadisticasServices
    {
        private readonly IAvisoRepository _avisoRepository;

        public EstadisticasServices(IAvisoRepository avisoRepository)
        {
            _avisoRepository = avisoRepository;
        }
        public ArrayList GetDatosEstadisticasSupermercados()
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            ArrayList arraysuper = new ArrayList();
            int dia = 0;
            int aldi = 0;
            int mercadona = 0;
            int eljamon = 0;
            int carrefour = 0;

            foreach (var a in todosAvisos)
            {
                switch (a.Supermercado_id)
                {
                    case "01":
                        dia++;
                        break;
                    case "02":
                        aldi++;
                        break;
                    case "03":
                        mercadona++;
                        break;
                    case "04":
                        eljamon++;
                        break;
                    case "05":
                        carrefour++;
                        break;
                    default:
                        break;
                }

            }
            arraysuper.Add(dia);
            arraysuper.Add(aldi);
            arraysuper.Add(mercadona);
            arraysuper.Add(eljamon);
            arraysuper.Add(carrefour);

            return arraysuper;
        }
        public ArrayList GetDatosEstadisticasProductos()
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();

            ArrayList arrayproducto = new ArrayList();
            int pan = 0;
            int leche = 0;
            int huevos = 0;
            int papel = 0;

            foreach (var aviso in todosAvisos)
            {
                switch (aviso.Producto)
                {
                    case "pan":
                        pan++;
                        break;
                    case "leche":
                        leche++;
                        break;
                    case "huevos":
                        huevos++;
                        break;
                    case "papel":
                        papel++;
                        break;

                    default:
                        break;
                }

            }
            arrayproducto.Add(pan);
            arrayproducto.Add(leche);
            arrayproducto.Add(huevos);
            arrayproducto.Add(papel);

            return arrayproducto;
        }
        public int getEstadisticasTotalAvisos()
        {
            var todosAvisos = _avisoRepository.GetAvisoItems();
            var total = todosAvisos.Count();
            return total;
        }
    }
}
