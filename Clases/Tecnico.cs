using System;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Clases
{
    public class Tecnico : IComparable<Tecnico>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public List<string> Categorias { get; set; }

        public Tecnico(int id, string nombre, string especialidad, List<string> categorias)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;
            Categorias = categorias;
        }

        public int CompareTo(Tecnico? other)
        {
            if (other == null) return 1;
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"════════════ Técnico #{Id} ════════════\n" +
                   $"• Nombre: {Nombre}\n" +
                   $"• Especialidad: {Especialidad}\n" +
                   $"• Categorías: {string.Join(", ", Categorias)}\n" +
                   "══════════════════════════════════\n";
        }

        public bool PuedeAtender(string categoria)
        {
            return Categorias.Contains(categoria);
        }
    }
}