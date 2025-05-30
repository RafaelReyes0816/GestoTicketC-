using System;
using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketListaEnlazada : IGestionTickets
    {
        private class Nodo
        {
            public Ticket Ticket { get; set; }
            public Nodo? Siguiente { get; set; }

            public Nodo(Ticket ticket)
            {
                Ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
                Siguiente = null;
            }
        }

        private Nodo? cabeza = null;

        public void Agregar(Ticket ticket)
        {
            Nodo nuevoNodo = new Nodo(ticket);
            
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public void Eliminar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay tickets en la lista.");
                return;
            }

            Ticket ticketEliminado = cabeza.Ticket;
            ticketEliminado.Estado = "Cerrado";
            cabeza = cabeza.Siguiente;

            Console.WriteLine($"Ticket cerrado:\n{ticketEliminado}");
        }

        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            Console.WriteLine("════════════ TICKETS EN LISTA ════════════");
            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Ticket);
                actual = actual.Siguiente;
            }
        }
    }
}