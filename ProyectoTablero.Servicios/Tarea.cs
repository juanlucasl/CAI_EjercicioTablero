using System;

namespace ProyectoTablero.Servicios
{
    public class Tarea
    {
        // Constructor
        public Tarea(string descripcion, int orden)
        {
            _descripcion = descripcion;
            _orden = orden;
            _estado = Estado.Nueva;
            _fechaAlta = DateTime.Now;
        }

        // Atributos
        private int _codigo;
        private string _descripcion;
        private int _orden;
        private Estado _estado;
        private DateTime _fechaAlta;
        private DateTime _fechaRealizacion;

        // Propiedades
        public bool IsFinalizada
        {
            get { return _estado == Estado.Finalizada; }
        }
    }
}
