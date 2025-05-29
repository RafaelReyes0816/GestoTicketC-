using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketCola : IGestionTickets
    {
        private Queue<Ticket> cola = new();

        public void Agregar(Ticket ticket)
        {
            cola.Enqueue(ticket);
        }

        public void Eliminar()
        {
            if (cola.Count > 0)
            {
                Ticket ticket = cola.Dequeue();
                ticket.Estado = "Cerrado";
                Console.WriteLine($"Ticket cerrado: {ticket}");
            }
            else
            {
                Console.WriteLine("No hay tickets en cola.");
            }
        }

        public void Mostrar()
        {
            if (cola.Count == 0)
            {
                Console.WriteLine("No hay tickets en cola.");
                return;
            }

            foreach (var ticket in cola)
                Console.WriteLine(ticket);
        }
    }
}