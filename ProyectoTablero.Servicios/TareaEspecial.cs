using System;

namespace ProyectoTablero.Servicios
{
    public class TareaEspecial : Tarea
    {
        // Constructor
        public TareaEspecial(string descripcion, int orden, int codigo) : base(descripcion, orden, codigo)
        {
            Random random = new Random();
            _color = random.Next(1, 16);
        }

        // Atributos
        private int _color;

        // Propiedades
        public int Color
        {
            get { return _color; }
        }

        // Metodos
        public override string ToString()
        {
            string tareaString = $"*** Tarea #{Codigo}: {Descripcion} ***\n" +
                                 $"Orden: {Orden}\n" +
                                 $"Estado: {Estado}";
            if (IsFinalizada) tareaString += $"\nFecha de finalizacion: {FechaRealizacion}";
            return tareaString;
        }
    }
}
