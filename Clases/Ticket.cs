public class Ticket
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public required string Descripcion { get; set; }
    public string Estado { get; set; } = "EnEspera"; // EnEspera/EnProgreso/Cerrado
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string? UsuarioAsignado { get; set; }
}