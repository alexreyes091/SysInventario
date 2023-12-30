namespace Academia.SemanaIntermedia.SysInventario.WebApi._Features.Usuario.Dtos
{
    public class PerfilDto
    {
        public int PerfilId { get; set; }

        public string Nombre { get; set; } = null!;

        public bool? EstaActivo { get; set; }
    }
}
