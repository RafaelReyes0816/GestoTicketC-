using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketPila : IGestionTickets
    {
        private Stack<Ticket> pila = new();

        public void Agregar(Ticket ticket)
        {
            pila.Push(ticket);
        }

        public void Eliminar()
        {
            if (pila.Count > 0)
            {
                Ticket ticket = pila.Pop();
                ticket.Estado = "Cerrado";
                Console.WriteLine($"Ticket cerrado: {ticket}");
            }
            else
            {
                Console.WriteLine("No hay tickets en la pila.");
            }
        }

        public void Mostrar()
        {
            if (pila.Count == 0)
            {
                Console.WriteLine("No hay tickets en la pila.");
                return;
            }

            foreach (var ticket in pila)
                Console.WriteLine(ticket);
        }
    }
}