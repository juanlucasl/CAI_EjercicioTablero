using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProyectoTablero.Servicios
{
    public class Tablero
    {
        // Constructor
        public Tablero(string titulo, string descripcion)
        {
            _titulo = titulo;
            _descripcion = descripcion;
            _fechaInicioProyecto = DateTime.Now;
        }

        // Atributos

        private static int _codigoContador = 0;
        private readonly string _titulo;
        private readonly string _descripcion;
        private readonly List<Tarea> _tareas;
        private readonly DateTime _fechaInicioProyecto;

        // Metodos

        /// <summary>Crea una nueva tarea y la agrega al tablero.</summary>
        /// <param name="descripcion">Descripcion de la tarea.</param>
        /// <param name="orden">Orden de la Tarea. Por defecto equivale a la cantidad de tareas en el tablero (incluyendo a la nueva)</param>
        public void AgregarTarea(string descripcion, int orden = -1)
        {
            int ordenTarea = orden < 0 ? _tareas.Count() + 1 : orden;
            _tareas.Add(new Tarea(descripcion, ordenTarea, Interlocked.Increment(ref _codigoContador)));
        }

        /// <summary>Cambia el estado de una tarea.</summary>
        /// <param name="codigo">Codigo de la tarea a modificar.</param>
        /// <param name="estado">Nuevo estado.</param>
        public void CambiarEstado(int codigo, Estado estado)
        {
            int indiceTarea = ObtenerTareaPorCodigo(codigo);
            _tareas[indiceTarea].Estado = estado;
            _tareas[indiceTarea].FechaRealizacion = DateTime.Now;
        }

        /// <summary>Devuelve todas las tareas con el estado dado. Si no se especifica un estado, devuelve todas las tareas.</summary>
        /// <param name="estado">Estado a buscar.</param>
        /// <returns>Lista de tareas.</returns>
        public IEnumerable<Tarea> TraerTareas(Estado? estado = null)
        {
            if (estado == null) return _tareas;
            return _tareas.FindAll((tarea) => (tarea.Estado == estado));
        }
        
        /// <summary>Devuelve la tarea mas antigua.</summary>
        /// <returns>Tarea mas antigua.</returns>
        public Tarea TraerTareaMasAntigua()
        {
            IOrderedEnumerable<Tarea> tareasOrdenadas = _tareas.OrderBy((tarea) => tarea.FechaAlta);
            return tareasOrdenadas.First();
        }

        /// <summary>Devuelve el indice de la tarea correspondiente a un codigo dado.</summary>
        /// <param name="codigo">Codigo de tarea.</param>
        /// <returns>Indice de la tarea encontrada o -1.</returns>
        private int ObtenerTareaPorCodigo(int codigo)
        {
            return _tareas.FindIndex((tarea) => (tarea.Codigo == codigo));
        }
    }
}
