using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi.Domain;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture;
using Academia.SemanaIntermedia.SysInventario.WebApi.Utility.MensajesRespuesta;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Inventario
{
    public class InventarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductoService _serviceProducto;
        private readonly SucursalService _sucursalService;
        private readonly InventarioDomain _validar;

        public InventarioService(UnitOfWorkBuilder unitofWorkBuilder, IMapper mapper, ProductoService service, InventarioDomain validar, SucursalService sucursalService)
        {
            _unitOfWork = unitofWorkBuilder.BuilderSysInventario();
            _mapper = mapper;
            _serviceProducto = service;
            _validar = validar;
            _sucursalService = sucursalService;
        }

        public Respuesta<string> RegistrarSalidaInventario(SalidaInventarioDto datoSolicitudSalida)
        {
            if(_validar.DatosDeSolicitud(datoSolicitudSalida)) Respuesta<string>.Fault(Mensaje.REGISTTRO_FALLIDO);

            var datosEncabezado = RegistrarSalidaEncabezado(datoSolicitudSalida).Data;
            if(_validar.EsDatoNulo(datosEncabezado)) Respuesta<string>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            var listaProductos = ActualizarListaLotesPorProducto(datoSolicitudSalida.listaProductos).Data;
            if(_validar.EsDatoNulo(listaProductos)) Respuesta<string>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            foreach (var producto in listaProductos)
            {
                ProductosDetalleDto productoDetalle = new()
                {
                    ProductosId = producto.ProductosId,
                    Nombre = producto.Nombre,
                    CantidadSolicitada = producto.CantidadSolicitada,
                    CostoTotal = producto.CostoTotal,
                    LotesDetalle = producto.LotesDetalle
                };
                RegistrarSalidaDetalle(productoDetalle, datosEncabezado.SalidaInventarioId);
            }

            return Respuesta<string>.Success(Mensaje.REGISTRO_COMPLETADO);
        }


        public Respuesta<Salidasinventario> RegistrarSalidaEncabezado(SalidaInventarioDto datoSolicitudSalida)
        {
            Salidasinventario registroEncabezado = new()
            {
                SucursalId = datoSolicitudSalida.SucursalId,
                UsuarioId = datoSolicitudSalida.UsuarioId,
                Total = 0,
                EstadoId = 2
            };

            _unitOfWork.Repository<Salidasinventario>().Add(registroEncabezado);
            _unitOfWork.SaveChanges();

            return Respuesta<Salidasinventario>.Success(registroEncabezado, Mensaje.REGISTRO_COMPLETADO, "200");
        }


        public Respuesta<string> RegistrarSalidaDetalle(ProductosDetalleDto productoDetlle, int salidaInventarioId)
        {
            foreach(var detalle in productoDetlle.LotesDetalle)
            {
                SalidasInventarioDetalle registroSalidaDetalle = new()
                {
                    SalidaInventarioId = salidaInventarioId,
                    LoteId = detalle.LoteId,
                    CantidadProducto = detalle.CantidadTomada,
                };
            
                _unitOfWork.Repository<SalidasInventarioDetalle>().Add(registroSalidaDetalle);
                _unitOfWork.SaveChanges();
            }
            return Respuesta<string>.Success(Mensaje.REGISTRO_COMPLETADO);
        }


        public Respuesta<List<ProductosDetalleDto>> ActualizarListaLotesPorProducto(List<SalidaInventarioProductoDto> listaProductos)
        {
            List<ProductosDetalleDto> listaProductosDetalle = new List<ProductosDetalleDto>();
            
            foreach (var productoDetalle in listaProductos)
            {
                var producto = _serviceProducto.ActualizarRegistroLotesPorProducto(productoDetalle.ProductoId, productoDetalle.Cantidad);
                if (producto.Data == null) return Respuesta<List<ProductosDetalleDto>>.Fault(Mensaje.REGISTTRO_FALLIDO);

                listaProductosDetalle.Add(producto.Data);
            }
            return Respuesta<List<ProductosDetalleDto>>.Success(listaProductosDetalle, Mensaje.REGISTRO_COMPLETADO, "200");
        }


        public Respuesta<SalidaInventarioDetalleDto> RecibirInventarioPorSucursal(int sucursal, int salidaInventarioId)
        {

            Salidasinventario? salidaInventario = _unitOfWork.Repository<Salidasinventario>().FirstOrDefault(x => x.SalidaInventarioId == salidaInventarioId);
            if(salidaInventario == null) return Respuesta<SalidaInventarioDetalleDto>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            salidaInventario.EstadoId = 3;
            salidaInventario.FechaRecibido = DateTime.Now;
          
            _unitOfWork.Repository<Salidasinventario>().Update(salidaInventario);
            _unitOfWork.SaveChanges();

            return Respuesta<SalidaInventarioDetalleDto>.Success(null!, Mensaje.REGISTRO_COMPLETADO, "200");
        }


        public Respuesta<Salidasinventario> ObtenerDetalleInventarioPorSucursal(int sucursalId, int salidaInventarioId)
        {
            var listadoInventarioPorSucursal = ObtenerListadoInventarioPorSucursal(sucursalId).Data;
            if (_validar.EsDatoNulo(listadoInventarioPorSucursal)) return Respuesta<Salidasinventario>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            var datoInventario = (from inventario in listadoInventarioPorSucursal
                                  where inventario.SalidaInventarioId == salidaInventarioId && inventario.EstadoId == 2
                                  select inventario).FirstOrDefault();
            if (datoInventario == null) return Respuesta<Salidasinventario>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            Salidasinventario? salidaInventario = _unitOfWork.Repository<Salidasinventario>().FirstOrDefault(x => x.SalidaInventarioId == salidaInventarioId);
            if (salidaInventario == null) return Respuesta<Salidasinventario>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            return Respuesta<Salidasinventario>.Success(salidaInventario, Mensaje.REGISTRO_EXITOSO, "200");
        }


        public Respuesta<List<SalidaInventarioListadoDto>> ObtenerListadoInventarioPorSucursal(int sucursalId)
        {
            if (!_sucursalService.ExisteSucursal(sucursalId)) Respuesta<string>.Fault(Mensaje.REGISTRO_NO_EXISTE);
            List<Salidasinventario> listadoInventarioPorSucursal = _unitOfWork.Repository<Salidasinventario>().Where(x => x.SucursalId == sucursalId).AsQueryable().ToList();
            List<SalidaInventarioListadoDto> listadoDto = _mapper.Map<List<SalidaInventarioListadoDto>>(listadoInventarioPorSucursal);

            foreach(var item in listadoDto)
            {
                item.listadoInventarioDetalle = ObtenerListadoDetallePorInventario(item.SalidaInventarioId).Data;
            }
            return Respuesta<List<SalidaInventarioListadoDto>>.Success(listadoDto, Mensaje.REGISTRO_EXITOSO, "200");
        }


        public Respuesta<List<SalidaInventarioDetalleDto>> ObtenerListadoDetallePorInventario(int inventarioId)
        {
            var listadoDetalle = _unitOfWork.Repository<SalidasInventarioDetalle>().AsQueryable().Where(x => x.SalidaInventarioId == inventarioId).ToList();
            if(_validar.EsDatoNulo(listadoDetalle)) Respuesta<List<SalidaInventarioDetalleDto>>.Fault(Mensaje.REGISTRO_EXITOSO);

            List<SalidaInventarioDetalleDto> listadoDetalleInventario = new();

            foreach(var detalle in listadoDetalle)
            {
                SalidaInventarioDetalleDto detalleInventario = new()
                {
                    DetalleId = detalle.DetalleId,
                    SalidaInventarioId = detalle.SalidaInventarioId,
                    LoteId = detalle.LoteId,
                    CantidadProducto = detalle.CantidadProducto,
                };

                var detalleLote = _serviceProducto.ObtenerProductosPorLote(detalle.LoteId).Data;
                if (_validar.EsDatoNulo(listadoDetalle)) break;

                detalleInventario.Producto = new()
                {
                    Producto = detalleLote.Producto.Nombre,
                    Cantidad = detalle.CantidadProducto,
                };
                 
                listadoDetalleInventario.Add(detalleInventario);
            }
            return Respuesta<List<SalidaInventarioDetalleDto>>.Success(listadoDetalleInventario, Mensaje.REGISTRO_EXITOSO, "200");
        }


        private bool ExisteInventario(int inventarioId) 
            => _unitOfWork.Repository<Salidasinventario>().AsQueryable().Any(x => x.SalidaInventarioId == inventarioId);



    }
}
;