using SistemaTicketsSoporte.Clases;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Interfaces
{
    public interface ITecnicoService
    {
        Tecnico? AsignarTecnico(string categoria);
        void MostrarTecnicos();
    }
}