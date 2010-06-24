using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public enum DireccionCorriente { Izquierda, Derecha, Arriba, Abajo };

    public class Aire:Bloque
    {
        private DireccionCorriente direccion;

        public Aire(Point posicion,DireccionCorriente direccion):base(4,4,posicion)
        {
            this.direccion = direccion;
        }

        public DireccionCorriente DireccionCorriente
        {
            get { return this.direccion; }
        }
    }
}
