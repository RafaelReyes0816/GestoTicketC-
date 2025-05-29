namespace SistemaTicketsSoporte.Interfaces
{
    public interface IGestionTickets
    {
        void Agregar(Clases.Ticket ticket);
        void Eliminar();
        void Mostrar();
    }
}