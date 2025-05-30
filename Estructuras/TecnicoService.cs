using System;
using System.Collections.Generic;
using System.Linq;
using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte.Estructuras
{
    public class TecnicoService : ITecnicoService
    {
        private List<Tecnico> tecnicos = new List<Tecnico>
        {
            new Tecnico(1, "Juan Pérez", "Hardware", new List<string> { "Hardware", "Mantenimiento PC", "Monitores" }),
            new Tecnico(2, "María Gómez", "Software", new List<string> { "Software", "Sistemas Operativos", "Drivers" }),
            new Tecnico(3, "Carlos Ruiz", "Redes", new List<string> { "Redes", "Internet", "Conexiones" }),
            new Tecnico(4, "Ana López", "Seguridad", new List<string> { "Seguridad", "Antivirus", "Protección" })
        };

        public Tecnico? AsignarTecnico(string categoria)
        {
            return tecnicos.FirstOrDefault(t => t.PuedeAtender(categoria));
        }

        public void MostrarTecnicos()
        {
            Console.WriteLine("════════════ TÉCNICOS DISPONIBLES ════════════\n");
            foreach (var tecnico in tecnicos)
            {
                Console.WriteLine(tecnico);
            }
        }
    }
}