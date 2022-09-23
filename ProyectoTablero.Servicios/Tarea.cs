using System;

namespace ProyectoTablero.Servicios
{
    public class Tarea
    {
        // Constructor
        public Tarea(string descripcion, int orden, int codigo)
        {
            _descripcion = descripcion;
            _orden = orden;
            _codigo = codigo;
            _fechaAlta = DateTime.Now;
            _estado = Estado.Nueva;

        }

        // Atributos
        private readonly string _descripcion;
        private readonly int _orden;
        private readonly int _codigo;
        private readonly DateTime _fechaAlta;
        private DateTime _fechaRealizacion;
        private Estado _estado;

        // Propiedades
        internal int Codigo
        {
            get { return _codigo; }
        }

        internal DateTime FechaAlta
        {
            get { return _fechaAlta; }
        }

        internal DateTime FechaRealizacion
        {
            set { _fechaRealizacion = value; }
        }
        
        internal Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public bool IsFinalizada
        {
            get { return _estado == Estado.Finalizada; }
        }
    }
}
