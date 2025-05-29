namespace SistemaTicketsSoporte.Clases
{
    public class Ticket
    {
        private static int idCounter = 1;

        public int Id { get; private set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int Prioridad { get; set; }

        public Ticket(string descripcion, int prioridad)
        {
            Id = idCounter++;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Estado = "Abierto";
        }

        public override string ToString()
        {
            return $"ID: {Id} | Descripción: {Descripcion} | Estado: {Estado} | Prioridad: {Prioridad}";
        }
    }
}