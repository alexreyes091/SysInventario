using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi.Domain;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture;
using Academia.SemanaIntermedia.SysInventario.WebApi.Utility.MensajesRespuesta;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Producto
{
    public class ProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductosDomain _validar;

        public ProductoService(UnitOfWorkBuilder unitofWorkBuilder, IMapper mapper, ProductosDomain validar)
        {
            _unitOfWork = unitofWorkBuilder.BuilderSysInventario();
            _mapper = mapper;
            _validar = validar;
        }

        public Respuesta<ProductoDto> ObtenerProductoPorId(int productoId)
        {
            if (!ExisteProducto(productoId)) return Respuesta<ProductoDto>.Fault(Mensaje.REGISTRO_NO_EXISTE);
            var respuesta = _unitOfWork.Repository<Productos>().FirstOrDefault(x => x.ProductosId == productoId);
            
            ProductoDto productoDto = _mapper.Map<ProductoDto>(respuesta);
            return Respuesta<ProductoDto>.Success(productoDto, Mensaje.REGISTRO_COMPLETADO, "200");
        }

        public Respuesta<ProductosLoteDto> ObtenerLotePorId(int loteId)
        {
            if(!ExisteLote(loteId)) return Respuesta<ProductosLoteDto>.Fault(Mensaje.REGISTRO_NO_EXISTE);
            var datosLote = _unitOfWork.Repository<ProductosLote>().FirstOrDefault(x => x.LoteId == loteId);

            ProductosLoteDto datoLoteDto = _mapper.Map<ProductosLoteDto>(datosLote);
            return Respuesta<ProductosLoteDto>.Success(datoLoteDto, Mensaje.REGISTRO_COMPLETADO, "200");
        }

        public Respuesta<ProductosLoteDetalleDto> ObtenerProductosPorLote(int loteId)
        {
            ProductosLoteDto datosLote = ObtenerLotePorId(loteId).Data;
            if(_validar.EsDatoNulo(datosLote)) Respuesta<ProductosLoteDto>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            ProductoDto datosProducto = ObtenerProductoPorId(datosLote.ProductosId).Data;
            if(_validar.EsDatoNulo(datosProducto)) Respuesta<ProductosLoteDto>.Fault(Mensaje.REGISTRO_NO_EXISTE);

            ProductosLoteDetalleDto loteDetalle = new()
            {
                LoteId = datosLote.LoteId,
                Producto = datosProducto,
                CantidadIngreso = datosLote.CantidadIngreso,
                CostoUnitario = datosLote.CostoUnitario,
                FechaVencimiento = datosLote.FechaVencimiento,
                InventarioDisponible = datosLote.InventarioDisponible,
                EstaActivo = datosLote.EstaActivo
            };

            return Respuesta<ProductosLoteDetalleDto>.Success(loteDetalle, Mensaje.REGISTRO_EXITOSO, "200");
        }

        public Respuesta<LotesProductoDetalleDto> ObtenerLotesPorProducto(int productoId)
        {
            ProductoDto datosProducto = ObtenerProductoPorId(productoId).Data;
            if(_validar.EsDatoNulo(datosProducto)) Respuesta<LotesProductoDetalleDto>.Fault(Mensaje.REGISTRO_NO_EXISTE, "400", null!);

            var datosLotes = (from lote in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                              where (lote.ProductosId == productoId && lote.EstaActivo && lote.InventarioDisponible > 0)
                              select lote).OrderBy(x => x.FechaVencimiento).ToList();

            List<ProductosLoteDto> datoLotesDto = _mapper.Map<List<ProductosLoteDto>>(datosLotes);
            LotesProductoDetalleDto lotesProducto = new()
            {
                ProductosId = datosProducto.ProductosId,
                Nombre = datosProducto.Nombre,
                lotes = datoLotesDto,
            };

            return Respuesta<LotesProductoDetalleDto>.Success(lotesProducto, Mensaje.REGISTRO_EXITOSO, "200");
        }

        public Respuesta<ProductosDetalleDto> ActualizarRegistroLotesPorProducto(int productoId, int cantidadSolicitada)
        {

            int cantidadPendiente = cantidadSolicitada;
            if (_validar.EsNumerosPositivo(cantidadSolicitada)) Respuesta<ProductosDetalleDto>.Fault(Mensaje.VALOR_NO_ACEPTADO, "400", null!);

            LotesProductoDetalleDto lotesPorProducto = ObtenerLotesPorProducto(productoId).Data;
            if(_validar.EsDatoNulo(lotesPorProducto)) Respuesta<ProductosDetalleDto>.Fault(Mensaje.VALOR_NO_ACEPTADO, "400", null!);

            ProductosDetalleDto productosDetalleDto = new() 
            {
                ProductosId = lotesPorProducto.ProductosId,
                Nombre = lotesPorProducto.Nombre,
                CantidadSolicitada = cantidadSolicitada,
            };
            
            if (!_validar.InventarioDisponible(lotesPorProducto.lotes, cantidadSolicitada))
                return Respuesta<ProductosDetalleDto>.Fault(Mensaje.INVENTARIO_INSUFICIENTE, "400", null!);
            
            foreach(var lote in lotesPorProducto.lotes)
            {
                if (_validar.EsNumerosPositivo(cantidadSolicitada))
                {
                    ProductosLote? productoLote = _unitOfWork.Repository<ProductosLote>().FirstOrDefault(x => x.LoteId == lote.LoteId);
                    if(productoLote == null) break;
                    cantidadPendiente = productoLote.InventarioDisponible - cantidadSolicitada;

                    LoteDetalleDto loteDetalleDto = new() 
                    {
                        LoteId = lote.LoteId,
                        CostoUnitario = lote.CostoUnitario,
                        FechaVencimiento = lote.FechaVencimiento,
                        CantidadTomada = (cantidadPendiente > 0) ? cantidadSolicitada : productoLote.InventarioDisponible
                    };

                    productosDetalleDto.LotesDetalle.Add(loteDetalleDto);
                    productosDetalleDto.CostoTotal += (loteDetalleDto.CostoUnitario * loteDetalleDto.CantidadTomada);

                    cantidadSolicitada = (cantidadPendiente > 0) ? 0 : Math.Abs(cantidadPendiente);

                    productoLote.InventarioDisponible = (cantidadPendiente <= 0) ? 0 : cantidadPendiente;
                    productoLote.EstaActivo = !(productoLote.InventarioDisponible == 0);

                    _unitOfWork.Repository<ProductosLote>().Update(productoLote);
                    _unitOfWork.SaveChanges();
                }
                if (!_validar.EsNumerosPositivo(cantidadSolicitada)) break;
            }
            return Respuesta<ProductosDetalleDto>.Success(productosDetalleDto, Mensaje.REGISTRO_EXITOSO, "200");
        }

        private bool ExisteProducto(int productoId)
            => _unitOfWork.Repository<Productos>().AsQueryable().Any(x => x.ProductosId == productoId && x.EstaActivo);

        private bool ExisteLote(int loteId)
            => _unitOfWork.Repository<ProductosLote>().AsQueryable().Any(x => x.LoteId == loteId && x.EstaActivo);
    }
}
