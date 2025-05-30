using System;

namespace SistemaTicketsSoporte.Clases
{
    public class Ticket : IComparable<Ticket>
    {
        private static int nextId = 1;
        
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public string Estado { get; set; }
        public int TecnicoAsignado { get; set; }
        public DateTime FechaCreacion { get; }
        public string Categoria { get; set; }

        public Ticket(string descripcion, int prioridad, string categoria)
        {
            Id = nextId++;
            Descripcion = descripcion;
            Prioridad = Math.Clamp(prioridad, 1, 5);
            Estado = "Abierto";
            TecnicoAsignado = -1;
            FechaCreacion = DateTime.Now;
            Categoria = categoria;
        }

        public int CompareTo(Ticket? other)
        {
            if (other == null) return 1;
            int priorityComparison = other.Prioridad.CompareTo(Prioridad);
            return priorityComparison != 0 ? priorityComparison : FechaCreacion.CompareTo(other.FechaCreacion);
        }

        public override string ToString()
        {
            return $"Ticket #{Id}\n" +
                   $"Prioridad: {Prioridad}\n" +
                   $"Estado: {Estado}\n" +
                   $"Técnico: {(TecnicoAsignado == -1 ? "No asignado" : TecnicoAsignado.ToString())}\n" +
                   $"Categoría: {Categoria}\n" +
                   $"Descripción: {Descripcion}\n" +
                   $"Creado: {FechaCreacion:g}\n" +
                   "─────────────────────────────";
        }
    }
}