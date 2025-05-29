using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TicketListaEnlazada : IGestionTickets
    {
        private NodoTicket cabeza;

        private class NodoTicket
        {
            public Ticket ticket;
            public NodoTicket siguiente;

            public NodoTicket(Ticket ticket)
            {
                this.ticket = ticket;
            }
        }

        public void Agregar(Ticket ticket)
        {
            NodoTicket nuevo = new(ticket);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoTicket actual = cabeza;
                while (actual.siguiente != null)
                    actual = actual.siguiente;
                actual.siguiente = nuevo;
            }
        }

        public void Eliminar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay tickets en la lista.");
                return;
            }

            Ticket cerrado = cabeza.ticket;
            cerrado.Estado = "Cerrado";
            cabeza = cabeza.siguiente;

            Console.WriteLine($"Ticket cerrado: {cerrado}");
        }

        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            NodoTicket actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.ticket);
                actual = actual.siguiente;
            }
        }
    }
}