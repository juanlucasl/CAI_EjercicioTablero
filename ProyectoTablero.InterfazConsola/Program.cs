using System;
using ProyectoTablero.Servicios;

namespace ProyectoTablero.InterfazConsola
{
    internal class Program
    {
        public static void Main()
        {
            int opcionMenu;
            Tablero tablero = new Tablero("Tablero", "Tablero de tareas.");

            do
            {
                Console.Clear();
                Console.WriteLine("Agenda:");
                Console.WriteLine("1- Crear tarea");
                Console.WriteLine("2- Listar tareas por estado");
                Console.WriteLine("3- Ver tarea mas antigua");
                Console.WriteLine("4- Actualizar estado de tarea");
                Console.WriteLine("0- Salir");
                opcionMenu = InputHelper.PedirNumeroNatural("Ingresar una opcion:", 0, 4);

                switch (opcionMenu)
                {
                    case 1: // Crear tarea
                    {
                        string descripcion = InputHelper.PedirString("Ingresar descripcion:", true);
                        int orden = InputHelper.PedirNumeroNatural("Ingresar orden de prioridad (default ultima):", 1, 10000);

                        if (orden <= 0)
                        {
                            tablero.AgregarTarea(descripcion);
                        }
                        else
                        {
                            tablero.AgregarTarea(descripcion, orden);
                        }

                        InputHelper.PedirContinuacion("Tarea creada.");
                        break;
                    }

                    case 2: // Listar tareas
                    {
                        Console.WriteLine("Seleccionar estado a listar:");
                        Console.WriteLine("1- Nueva");
                        Console.WriteLine("2- En progreso");
                        Console.WriteLine("3- Finalizada");
                        Console.WriteLine("O presionar enter para listar todas.");

                        int estado = (InputHelper.PedirNumeroNatural("", 1, 3)) - 1;

                        Tarea[] tareas = estado < 0 ? tablero.TraerTareas() : tablero.TraerTareas((Estado)estado);

                        if (tareas.Length == 0)
                        {
                            InputHelper.PedirContinuacion("No se encontraron tareas.");
                            break;
                        }

                        foreach (Tarea tarea in tareas)
                        {
                            Console.WriteLine($"{tarea}\n");
                        }

                        InputHelper.PedirContinuacion();
                        break;
                    }

                    case 0: // Salir
                    {
                        Console.WriteLine("Salir del programa");
                        break;
                    }
                }
            } while (opcionMenu != 0);
        }
    }
}
