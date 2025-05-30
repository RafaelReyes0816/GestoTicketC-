using SistemaTicketsSoporte.Clases;

namespace SistemaTicketsSoporte.Interfaces
{
    public interface IGestionTickets
    {
        void Agregar(Ticket ticket);
        void Eliminar();
        void Mostrar();
    }
}