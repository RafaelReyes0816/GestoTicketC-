using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketPriorityQueue : IGestionTickets
    {
        private List<Ticket> tickets = new();

        public void Agregar(Ticket ticket)
        {
            tickets.Add(ticket);
            tickets.Sort((a, b) => b.Prioridad.CompareTo(a.Prioridad));
        }

        public void Eliminar()
        {
            if (tickets.Count > 0)
            {
                Ticket ticket = tickets[0];
                ticket.Estado = "Cerrado";
                tickets.RemoveAt(0);
                Console.WriteLine($"Ticket cerrado (prioridad): {ticket}");
            }
            else
            {
                Console.WriteLine("No hay tickets con prioridad.");
            }
        }

        public void Mostrar()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay tickets con prioridad.");
                return;
            }

            foreach (var ticket in tickets)
                Console.WriteLine(ticket);
        }
    }
}