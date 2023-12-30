using Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Entities;

namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Dtos
{
    public class EmpleadoDto
    {
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Direccion { get; set; }

        public int? Edad { get; set; }

    }
}
