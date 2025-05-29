using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Estructuras;
using SistemaTicketsSoporte.Interfaces;

IGestionTickets sistema = new TicketPriorityQueue(); // O cambiás a la que quieras usar

int opcionMenu;
do
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════╗");
    Console.WriteLine("║        GESTIÓN DE TICKETS          ║");
    Console.WriteLine("╠════════════════════════════════════╣");
    Console.WriteLine("║ 1. Agregar nuevo ticket            ║");
    Console.WriteLine("║ 2. Cerrar ticket                   ║");
    Console.WriteLine("║ 3. Mostrar todos los tickets       ║");
    Console.WriteLine("║ 4. Salir del sistema               ║");
    Console.WriteLine("╚════════════════════════════════════╝");
    Console.Write("Seleccione una opción: ");

    string? entrada = Console.ReadLine();
    int.TryParse(entrada, out opcionMenu);
    Console.Clear();

    switch (opcionMenu)
    {
        case 1:
            Console.WriteLine(">> AGREGAR NUEVO TICKET");
            Console.Write("Descripción del problema: ");
            string descripcion = Console.ReadLine() ?? "Sin descripción";
            Console.Write("Prioridad [1 (baja) - 5 (alta)]: ");
            int.TryParse(Console.ReadLine(), out int prioridad);
            prioridad = Math.Clamp(prioridad, 1, 5);
            sistema.Agregar(new Ticket(descripcion, prioridad));
            Console.WriteLine("\nTicket agregado exitosamente.");
            break;

        case 2:
            Console.WriteLine(">> CERRAR PRÓXIMO TICKET");
            sistema.Eliminar();
            break;

        case 3:
            Console.WriteLine(">> TICKETS EN SISTEMA");
            sistema.Mostrar();
            break;

        case 4:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

    if (opcionMenu != 4)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (opcionMenu != 4);