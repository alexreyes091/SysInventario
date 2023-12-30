using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using AutoMapper;

namespace Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Usuarios, UsuariosDto>().ReverseMap();
            CreateMap<Productos, ProductoDto>().ReverseMap();
            CreateMap<ProductosLote, ProductosLoteDto>().ReverseMap();
            CreateMap<Salidasinventario, SalidaInventarioListadoDto>().ReverseMap();
            CreateMap<ProductosLote, ProductosLoteDetalleDto>()
                .ForMember(d => d.Producto, o => o.MapFrom(s => s.Productos))
                .ReverseMap();
        }
    }
}
