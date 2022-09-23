using System;
using System.Collections.Generic;

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
        private string _titulo;
        private string _descripcion;
        private List<Tarea> _tareas;
        private DateTime _fechaInicioProyecto;
    }
}
