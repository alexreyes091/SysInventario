using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Dtos;
using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;
using Academia.SemanaIntermedia.SysInventario.WebApi.Infrastucture;
using AutoMapper;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario
{
    public class UsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(UnitOfWorkBuilder unitOfWorkBuilder, IMapper mapper)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderSysInventario();
            _mapper = mapper;
        }

        public List<UsuariosDto> ObtenerListaUsuarios()
        {
            var usuarios = _unitOfWork.Repository<Usuarios>().AsQueryable().ToList();
            List<UsuariosDto> listaUsuarios = _mapper.Map<List<UsuariosDto>>(usuarios);

            return listaUsuarios;
        } 
    }
}
