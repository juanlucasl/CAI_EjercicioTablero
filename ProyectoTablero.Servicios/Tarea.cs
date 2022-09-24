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
        protected string Descripcion
        {
            get { return _descripcion; }
        }

        internal int Orden
        {
            get { return _orden; }
        }

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
            get { return _fechaRealizacion; }
            set { _fechaRealizacion = value; }
        }
        
        internal Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        protected bool IsFinalizada
        {
            get { return _estado == Estado.Finalizada; }
        }

        // Metodos
        public override string ToString()
        {
            string tareaString = $"=== Tarea #{_codigo}: {_descripcion} ===\n" +
                                 $"Orden: {_orden}\n" +
                                 $"Estado: {_estado}";
            if (IsFinalizada) tareaString += $"\nFecha de finalizacion: {_fechaRealizacion}";
            return tareaString;
        }
    }
}
