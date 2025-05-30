using System;
using System.Collections.Generic;

namespace SistemaTicketsSoporte.Interfaces
{
    public interface IGrafo<T>
    {
        void AgregarVertice(T vertice);
        void EliminarVertice(T vertice);
        void AgregarArista(T origen, T destino);
        void EliminarArista(T origen, T destino);
        List<T> ObtenerAdyacentes(T vertice);
        bool ExisteVertice(T vertice);
        bool ExisteArista(T origen, T destino);
        void MostrarGrafo(Action<T> accion);
    }
}