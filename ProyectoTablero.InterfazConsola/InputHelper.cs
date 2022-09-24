using System;

namespace ProyectoTablero.InterfazConsola
{
    /// <summary>
    /// Clase helper para pedido de inputs.
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Solicita al usuario que ingrese un numero natural. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario, un numero minimo y un numero maximo.
        /// </summary>
        /// <param name="mensaje" type="string">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero natural")
        /// </param>
        /// <param name="min" type="int">
        /// Valor minimo para el numero que el usuario puede ingresar (default 0)
        /// </param>
        /// <param name="max" type="int">
        /// Valor maximo para el numero que el usuario puede ingresar (default 2147483647)
        /// </param>
        /// <returns type="int">El número que ingresó el usuario, o -1 si el usuario no ingreso datos.</returns>
        public static int PedirNumeroNatural(
            string mensaje = "Ingresar un numero natural",
            int min = 0,
            int max = Int32.MaxValue
        )
        {
            int numeroNatural;
            string input;

            Console.WriteLine(mensaje);

            while (!int.TryParse(input = Console.ReadLine(), out numeroNatural) || numeroNatural < min || numeroNatural > max)
            {
                if (string.IsNullOrWhiteSpace(input)) return -1;
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return numeroNatural;
        }

        /// <summary>
        /// Solicita al usuario que ingrese texto.
        /// </summary>
        /// <param name="mensaje" type="string">
        /// Mensaje para mostrarle al usuario antes de que ingrese el text (default "Ingresar texto")
        /// </param>
        /// <param name="obligatorio" type="boolean">
        /// Flag que indica si se debe rechazar al texto ingresado si esta vacio.
        /// </param>
        /// <returns type="string">El texto que ingreso el usuario</returns>
        public static string PedirString(string mensaje = "Ingresar texto", bool obligatorio = false)
        {
            Console.WriteLine(mensaje);
            string inputString = Console.ReadLine();

            while (obligatorio && String.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("El texto ingresado no puede estar vacio. Ingrese un texto distinto.");
                inputString = Console.ReadLine();
            }
            
            return inputString;
        }

        /// <summary>Pide que presione una tecla para continuar.</summary>
        /// <param name="mensaje" type="string">Mensaje para mostrar al usuario.</param>
        public static void PedirContinuacion(string mensaje = "")
        {
            if (!string.IsNullOrWhiteSpace(mensaje)) Console.WriteLine(mensaje);
            Console.WriteLine("Presionar una tecla para continuar");
            Console.ReadKey();
        }
    }
}
