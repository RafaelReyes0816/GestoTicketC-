using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTicketsSoporte.Estructuras
{
    public class GrafoTickets : IGrafo<int>
    {
        public Dictionary<int, Ticket> Tickets { get; } = new();
        private Dictionary<int, List<int>> listaAdyacencia = new();

        public void AgregarTicket(Ticket ticket)
        {
            if (!Tickets.ContainsKey(ticket.Id))
            {
                Tickets[ticket.Id] = ticket;
                listaAdyacencia[ticket.Id] = new List<int>();
                RelacionarAutomaticamente(ticket);
            }
        }

        private void RelacionarAutomaticamente(Ticket nuevoTicket)
        {
            foreach (var ticketExistente in Tickets.Values)
            {
                if (ticketExistente.Id != nuevoTicket.Id && SonProblemasSimilares(ticketExistente, nuevoTicket))
                {
                    AgregarArista(ticketExistente.Id, nuevoTicket.Id);
                }
            }
        }

        private bool SonProblemasSimilares(Ticket t1, Ticket t2)
        {
            if (t1.Categoria.Equals(t2.Categoria, StringComparison.OrdinalIgnoreCase))
                return true;

            var palabrasClave = new[] { "pc", "computadora", "monitor", "teclado", "mouse", "impresora", "red", "internet" };
            var palabrasT1 = t1.Descripcion.ToLower().Split(' ');
            var palabrasT2 = t2.Descripcion.ToLower().Split(' ');

            return palabrasClave.Any(p => palabrasT1.Contains(p) && palabrasT2.Contains(p));
        }

        public void AgregarVertice(int vertice)
        {
            if (!listaAdyacencia.ContainsKey(vertice))
                listaAdyacencia[vertice] = new List<int>();
        }

        public void EliminarVertice(int vertice)
        {
            if (!listaAdyacencia.ContainsKey(vertice)) return;

            foreach (var adyacentes in listaAdyacencia.Values)
                adyacentes.RemoveAll(v => v == vertice);

            listaAdyacencia.Remove(vertice);
            Tickets.Remove(vertice);
        }

        public void AgregarArista(int origen, int destino)
        {
            AgregarVertice(origen);
            AgregarVertice(destino);

            if (!listaAdyacencia[origen].Contains(destino))
                listaAdyacencia[origen].Add(destino);

            if (!listaAdyacencia[destino].Contains(origen))
                listaAdyacencia[destino].Add(origen);
        }

        public void EliminarArista(int origen, int destino)
        {
            if (listaAdyacencia.ContainsKey(origen))
                listaAdyacencia[origen].RemoveAll(v => v == destino);

            if (listaAdyacencia.ContainsKey(destino))
                listaAdyacencia[destino].RemoveAll(v => v == origen);
        }

        public List<int> ObtenerAdyacentes(int vertice)
        {
            return listaAdyacencia.ContainsKey(vertice) ? 
                new List<int>(listaAdyacencia[vertice]) : 
                new List<int>();
        }

        public bool ExisteVertice(int vertice) => listaAdyacencia.ContainsKey(vertice);

        public bool ExisteArista(int origen, int destino) => 
            listaAdyacencia.ContainsKey(origen) && listaAdyacencia[origen].Contains(destino);

        public void MostrarGrafo(Action<int> accion)
        {
            foreach (var vertice in listaAdyacencia.Keys)
            {
                accion(vertice);
                if (Tickets.TryGetValue(vertice, out var ticket))
                {
                    Console.WriteLine($"\nTicket #{ticket.Id} - {ticket.Categoria}");
                    Console.WriteLine($"Descripción: {ticket.Descripcion}");
                }

                if (listaAdyacencia[vertice].Count > 0)
                {
                    Console.Write("Relacionado con: ");
                    foreach (var adyacente in listaAdyacencia[vertice])
                    {
                        if (Tickets.TryGetValue(adyacente, out var ticketRel))
                            Console.Write($"#{ticketRel.Id} ({ticketRel.Categoria}) ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No tiene relaciones");
                }
                Console.WriteLine("----------------------");
            }
        }

        public List<Ticket> ObtenerTicketsRelacionados(int idTicket)
        {
            var relacionados = new List<Ticket>();
            if (listaAdyacencia.TryGetValue(idTicket, out var idsRelacionados))
            {
                foreach (var id in idsRelacionados)
                {
                    if (Tickets.TryGetValue(id, out var ticket))
                        relacionados.Add(ticket);
                }
            }
            return relacionados;
        }
    }
}