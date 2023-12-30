using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Domain
{
    public class InventarioDomain
    {
        public const double COSTO_LIMITE_PENDIETNE = 5000;

        public bool DatosDeSolicitud(SalidaInventarioDto datos)
        {
            if(datos == null) return false;

            if(datos.listaProductos == null) return false;
 
            return true;
        }

        public bool LimitePendientePorRecibir(List<string> solicitudesPorScursal)
        {


            return true;
        }

        public bool EsDatoNulo<T>(T datos) => datos == null;
    }
}
