using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Dtos
{
    public class UsuariosDto
    {
        public int UsuarioId { get; set; }

        public string Usuario { get; set; } = null!;

        public int? EmpleadoId { get; set; }

        public int? PerfilId { get; set; }

        public bool? EstaActivo { get; set; }
    }
}
