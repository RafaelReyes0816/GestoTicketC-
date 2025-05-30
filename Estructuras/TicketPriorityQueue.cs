using System;
using System.Collections.Generic;
using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketPriorityQueue : IGestionTickets
    {
        private List<Ticket> tickets = new List<Ticket>();

        public void Agregar(Ticket ticket)
        {
            tickets.Add(ticket);
            tickets.Sort((a, b) => b.Prioridad.CompareTo(a.Prioridad));
        }

        public void Eliminar()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay tickets con prioridad.");
                return;
            }

            Ticket ticket = tickets[0];
            ticket.Estado = "Cerrado";
            tickets.RemoveAt(0);
            Console.WriteLine($"Ticket cerrado (prioridad):\n{ticket}");
        }

        public void Mostrar()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay tickets con prioridad.");
                return;
            }

            Console.WriteLine("════════════ TICKETS POR PRIORIDAD ════════════\n");
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
        }
    }
}