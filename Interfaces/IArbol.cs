namespace SistemaTicketsSoporte.Interfaces
{
    public interface IArbol<T> where T : IComparable<T>
    {
        void Insertar(T valor);
        bool Existe(T valor);
        T? Buscar(T valor);
        void RecorrerInOrden(Action<T> accion);
        void RecorrerPreOrden(Action<T> accion);
        void RecorrerPostOrden(Action<T> accion);
        int Altura();
        int CantidadNodos();
    }
}