using System.Collections;

namespace EstadisticasServices.Services
{
    public interface IEstadisticasServices
    {
        ArrayList GetDatosEstadisticasSupermercados();
        ArrayList GetDatosEstadisticasProductos();
        int getEstadisticasTotalAvisos();
    }
}
