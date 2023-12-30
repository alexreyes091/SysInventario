using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture;
using AutoMapper;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Sucursal
{
    public class SucursalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SucursalService(UnitOfWorkBuilder unitofWorkBuilder, IMapper mapper)
        {
            _unitOfWork = unitofWorkBuilder.BuilderSysInventario();
            _mapper = mapper;
        }

        public bool ExisteSucursal(int sucursalId)
            => _unitOfWork.Repository<Sucursale>().AsQueryable().Any(x => x.SucursalId == sucursalId);
    }
}
