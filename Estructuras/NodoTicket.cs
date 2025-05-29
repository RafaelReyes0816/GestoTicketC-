namespace SistemaTicketsSoporte;

public class NodoTicket
{
    public Ticket Ticket { get; set; }
    public NodoTicket? Siguiente { get; set; }
}