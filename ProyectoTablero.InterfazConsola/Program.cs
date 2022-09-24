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
                Console.WriteLine("Tablero:");
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
                        bool especial = (InputHelper.PedirNumeroNatural("Es tarea especial? (1: Si, 0: No)", 0, 1)) == 1;

                        if (orden <= 0)
                        {
                            tablero.AgregarTarea(descripcion, especial:especial);
                        }
                        else
                        {
                            tablero.AgregarTarea(descripcion, orden, especial);
                        }

                        InputHelper.PedirContinuacion($"Tarea '{descripcion}' creada.");
                        break;
                    }

                    case 2: // Listar tareas
                    {
                        Console.WriteLine("Seleccionar estado a listar:");
                        Console.WriteLine("1- Nueva");
                        Console.WriteLine("2- Activa");
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
                            if (tarea.GetType() == typeof(TareaEspecial))
                            {
                                TareaEspecial tareaEspecial = (TareaEspecial)tarea;
                                Console.ForegroundColor = (ConsoleColor)tareaEspecial.Color;
                            }
                            Console.WriteLine($"{tarea}\n");
                            Console.ResetColor();
                        }

                        InputHelper.PedirContinuacion();
                        break;
                    }

                    case 3: // Ver tarea mas antigua
                    {
                        Tarea tareaMasAntigua = tablero.TraerTareaMasAntigua();

                        if (tareaMasAntigua == null)
                        {
                            InputHelper.PedirContinuacion("No se encontraron tareas.");
                            break;
                        }
                        Console.WriteLine("Tarea mas antigua:");
                        Console.WriteLine(tareaMasAntigua);
                        InputHelper.PedirContinuacion();
                        break;
                    }

                    case 4: // Actualizar estado de tarea
                    {
                        int codigoTarea = InputHelper.PedirNumeroNatural("Ingresar codigo de tarea a actualizar", 1, obligatorio:true);
                        if (tablero.ObtenerTareaPorCodigo(codigoTarea) == -1)
                        {
                            InputHelper.PedirContinuacion($"No se encontro una tarea con el codigo {codigoTarea}.");
                            break;
                        }

                        Console.WriteLine("Seleccionar nuevo estado:");
                        Console.WriteLine("1- Nueva");
                        Console.WriteLine("2- Activa");
                        Console.WriteLine("3- Finalizada");
                        Console.WriteLine("0- Cancelar");
                        int input = InputHelper.PedirNumeroNatural("", 0, 3, true);
                        if (input == 0)
                        {
                            InputHelper.PedirContinuacion();
                            break;
                        };

                        Estado estado = (Estado)(input - 1);
                        tablero.CambiarEstado(codigoTarea, estado);

                        InputHelper.PedirContinuacion($"Tarea #{codigoTarea} actualizada a {estado}.");
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
