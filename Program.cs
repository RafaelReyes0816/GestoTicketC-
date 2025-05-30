using System;
using SistemaTicketsSoporte.Estructuras;
using SistemaTicketsSoporte.Clases;
using SistemaTicketsSoporte.Interfaces;

namespace SistemaTicketsSoporte
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración inicial
            IGestionTickets sistemaTickets = new TicketPriorityQueue();
            ITecnicoService tecnicoService = new TecnicoService();
            IArbol<Ticket> arbolTickets = new ArbolBinarioPrioridad<Ticket>();
            GrafoTickets grafoTickets = new GrafoTickets();

            bool salir = false;
            while (!salir)
            {
                try
                {
                    Console.Clear();
                    MostrarMenuPrincipal();
                    
                    if (!int.TryParse(Console.ReadLine(), out int opcionSeleccionada))
                    {
                        MostrarError("Entrada no válida. Debe ingresar un número.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Clear();
                    switch (opcionSeleccionada)
                    {
                        case 1:
                            CrearNuevoTicket(sistemaTickets, tecnicoService, arbolTickets, grafoTickets);
                            break;
                        case 2:
                            CerrarTicket(sistemaTickets);
                            break;
                        case 3:
                            MostrarTodosLosTickets(sistemaTickets);
                            break;
                        case 4:
                            MostrarTecnicos(tecnicoService);
                            break;
                        case 5:
                            MostrarArbolTickets(arbolTickets);
                            break;
                        case 6:
                            MostrarRelacionesTickets(grafoTickets);
                            break;
                        case 7:
                            salir = true;
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            MostrarError("Opción no válida. Por favor, seleccione 1-7.");
                            break;
                    }

                    if (!salir && opcionSeleccionada != 7)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    MostrarError($"Error inesperado: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("       SISTEMA DE GESTIÓN DE TICKETS");
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("1. Crear nuevo ticket");
            Console.WriteLine("2. Cerrar ticket");
            Console.WriteLine("3. Mostrar todos los tickets");
            Console.WriteLine("4. Mostrar técnicos");
            Console.WriteLine("5. Mostrar árbol de tickets");
            Console.WriteLine("6. Mostrar relaciones entre tickets");
            Console.WriteLine("7. Salir");
            Console.WriteLine("════════════════════════════════════");
            Console.Write("Seleccione una opción (1-7): ");
        }

        static void CrearNuevoTicket(IGestionTickets sistema, ITecnicoService tecnicos, IArbol<Ticket> arbol, GrafoTickets grafo)
        {
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("         CREAR NUEVO TICKET");
            Console.WriteLine("════════════════════════════════════");

            try
            {
                Console.Write("\nIngrese descripción del problema: ");
                string descripcion = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    MostrarError("La descripción no puede estar vacía.");
                    return;
                }

                Console.WriteLine("\nCategorías disponibles:");
                Console.WriteLine("1. Hardware");
                Console.WriteLine("2. Software");
                Console.WriteLine("3. Redes");
                Console.WriteLine("4. Seguridad");
                Console.Write("Seleccione categoría (1-4): ");
                
                string categoria = Console.ReadLine() switch
                {
                    "1" => "Hardware",
                    "2" => "Software",
                    "3" => "Redes",
                    "4" => "Seguridad",
                    _ => "General"
                };

                int prioridad;
                bool prioridadValida;
                do
                {
                    Console.Write("\nIngrese prioridad (1-5, donde 5 es la más alta): ");
                    prioridadValida = int.TryParse(Console.ReadLine(), out prioridad) && prioridad >= 1 && prioridad <= 5;
                    if (!prioridadValida)
                    {
                        MostrarError("Prioridad debe ser un número entre 1 y 5");
                    }
                } while (!prioridadValida);

                var nuevoTicket = new Ticket(descripcion, prioridad, categoria);
                
                // Asignar técnico
                var tecnico = tecnicos.AsignarTecnico(categoria);
                if (tecnico != null)
                {
                    nuevoTicket.TecnicoAsignado = tecnico.Id;
                    Console.WriteLine($"\nTicket asignado al técnico: {tecnico.Nombre}");
                }

                // Almacenar en estructuras
                sistema.Agregar(nuevoTicket);
                arbol.Insertar(nuevoTicket);
                grafo.AgregarTicket(nuevoTicket);

                Console.WriteLine("\n✅ Ticket creado exitosamente:");
                Console.WriteLine(nuevoTicket);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al crear ticket: {ex.Message}");
            }
        }

        static void CerrarTicket(IGestionTickets sistema)
        {
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("          CERRAR TICKET");
            Console.WriteLine("════════════════════════════════════");
            
            try
            {
                sistema.Eliminar();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cerrar ticket: {ex.Message}");
            }
        }

        static void MostrarTodosLosTickets(IGestionTickets sistema)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("        LISTADO DE TICKETS");
            Console.WriteLine("════════════════════════════════════\n");
            
            try
            {
                sistema.Mostrar();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al mostrar tickets: {ex.Message}");
            }
        }

        static void MostrarTecnicos(ITecnicoService tecnicos)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("        TÉCNICOS DISPONIBLES");
            Console.WriteLine("════════════════════════════════════\n");
            
            try
            {
                tecnicos.MostrarTecnicos();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al mostrar técnicos: {ex.Message}");
            }
        }

        static void MostrarArbolTickets(IArbol<Ticket> arbol)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("       ÁRBOL DE PRIORIDADES");
            Console.WriteLine("════════════════════════════════════\n");
            
            try
            {
                arbol.RecorrerInOrden(ticket => Console.WriteLine(ticket));
            }
            catch (Exception ex)
            {
                MostrarError($"Error al mostrar árbol: {ex.Message}");
            }
        }

        static void MostrarRelacionesTickets(GrafoTickets grafo)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("      RELACIONES ENTRE TICKETS");
            Console.WriteLine("════════════════════════════════════\n");
            
            try
            {
                grafo.MostrarGrafo(id => {
                    if (grafo.Tickets.TryGetValue(id, out var ticket))
                    {
                        Console.WriteLine($"Ticket #{ticket.Id} - {ticket.Categoria}");
                        Console.WriteLine($"Descripción: {ticket.Descripcion}\n");
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError($"Error al mostrar relaciones: {ex.Message}");
            }
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error: {mensaje}");
            Console.ResetColor();
        }
    }
}