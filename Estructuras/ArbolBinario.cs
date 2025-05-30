using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte.Estructuras
{
    public class ArbolBinarioPrioridad<T> : IArbol<T> where T : IComparable<T>
    {
        private class NodoArbol
        {
            public T Valor { get; set; }
            public NodoArbol? Izquierdo { get; set; }
            public NodoArbol? Derecho { get; set; }

            public NodoArbol(T valor)
            {
                Valor = valor;
                Izquierdo = null;
                Derecho = null;
            }
        }

        private NodoArbol? raiz;
        private int count;

        public void Insertar(T valor)
        {
            bool insertado = false;
            raiz = InsertarRec(raiz, valor, ref insertado);
            if (insertado) count++;
        }

        private NodoArbol InsertarRec(NodoArbol? nodo, T valor, ref bool insertado)
        {
            if (nodo == null)
            {
                insertado = true;
                return new NodoArbol(valor);
            }

            if (valor.CompareTo(nodo.Valor) < 0)
            {
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor, ref insertado);
            }
            else if (valor.CompareTo(nodo.Valor) > 0)
            {
                nodo.Derecho = InsertarRec(nodo.Derecho, valor, ref insertado);
            }
            // Si es igual, no se inserta y no se incrementa el contador
            return nodo;
        }

        public bool Existe(T valor)
        {
            return BuscarRec(raiz, valor) != null;
        }

        public T? Buscar(T valor)
        {
            var nodo = BuscarRec(raiz, valor);
            return nodo != null ? nodo.Valor : default;
        }

        private NodoArbol? BuscarRec(NodoArbol? nodo, T valor)
        {
            if (nodo == null || valor.CompareTo(nodo.Valor) == 0)
            {
                return nodo;
            }

            if (valor.CompareTo(nodo.Valor) < 0)
            {
                return BuscarRec(nodo.Izquierdo, valor);
            }

            return BuscarRec(nodo.Derecho, valor);
        }

        public void RecorrerInOrden(Action<T> accion)
        {
            RecorrerInOrdenRec(raiz, accion);
        }

        private void RecorrerInOrdenRec(NodoArbol? nodo, Action<T> accion)
        {
            if (nodo != null)
            {
                RecorrerInOrdenRec(nodo.Izquierdo, accion);
                accion(nodo.Valor);
                RecorrerInOrdenRec(nodo.Derecho, accion);
            }
        }

        public void RecorrerPreOrden(Action<T> accion)
        {
            RecorrerPreOrdenRec(raiz, accion);
        }

        private void RecorrerPreOrdenRec(NodoArbol? nodo, Action<T> accion)
        {
            if (nodo != null)
            {
                accion(nodo.Valor);
                RecorrerPreOrdenRec(nodo.Izquierdo, accion);
                RecorrerPreOrdenRec(nodo.Derecho, accion);
            }
        }

        public void RecorrerPostOrden(Action<T> accion)
        {
            RecorrerPostOrdenRec(raiz, accion);
        }

        private void RecorrerPostOrdenRec(NodoArbol? nodo, Action<T> accion)
        {
            if (nodo != null)
            {
                RecorrerPostOrdenRec(nodo.Izquierdo, accion);
                RecorrerPostOrdenRec(nodo.Derecho, accion);
                accion(nodo.Valor);
            }
        }

        public int Altura()
        {
            return CalcularAltura(raiz);
        }

        private int CalcularAltura(NodoArbol? nodo)
        {
            if (nodo == null)
            {
                return 0;
            }

            int alturaIzquierda = CalcularAltura(nodo.Izquierdo);
            int alturaDerecha = CalcularAltura(nodo.Derecho);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        public int CantidadNodos()
        {
            return count;
        }
    }
}