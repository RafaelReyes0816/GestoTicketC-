using SistemaTicketsSoporte;

var colaTickets = new TicketCola();
var pilaCerrados = new TicketPila();
int _nextId = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine("🚀 Gestor de Tickets con Estructuras Diversas");
    Console.WriteLine("1. Crear ticket");
    Console.WriteLine("2. Asignar ticket (FIFO)");
    Console.WriteLine("3. Cerrar ticket");
    Console.WriteLine("4. Ver último cerrado (LIFO)");
    Console.WriteLine("5. Mostrar todos");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? "";
            Console.Write("Descripción: ");
            colaTickets.CrearTicket(new Ticket { Id = _nextId++, Titulo = titulo, Descripcion = Console.ReadLine() ?? "" });
            break;

        case "2":
            var ticketAsignado = colaTickets.AsignarTicket();
            Console.WriteLine(ticketAsignado != null 
                ? $"✅ Ticket #{ticketAsignado.Id} asignado." 
                : "❌ No hay tickets en espera.");
            break;

        case "3":
            Console.Write("ID del ticket a cerrar: ");
            if (int.TryParse(Console.ReadLine(), out int idCerrar))
            {
                var ticket = colaTickets.BuscarTicket(idCerrar);
                if (ticket != null)
                {
                    pilaCerrados.Agregar(ticket);
                    colaTickets.CerrarTicket(idCerrar);
                    Console.WriteLine($"✅ Ticket #{idCerrar} cerrado.");
                }
                else
                {
                    Console.WriteLine($"❌ Ticket #{idCerrar} no encontrado.");
                }
            }
            break;

        case "4":
            var ultimoCerrado = pilaCerrados.ObtenerUltimoCerrado();
            Console.WriteLine(ultimoCerrado != null
                ? $"📌 Último cerrado: #{ultimoCerrado.Id} - {ultimoCerrado.Titulo}"
                : "No hay tickets cerrados.");
            break;

        case "5":
            Console.WriteLine("\n📋 Tickets Activos:");
            colaTickets.MostrarTickets("EnEspera");
            Console.WriteLine("\n🛠️ Tickets en Progreso:");
            colaTickets.MostrarTickets("EnProgreso");
            break;

        case "6":
            return;
    }
    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}