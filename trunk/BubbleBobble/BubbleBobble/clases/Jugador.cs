using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Jugador:PersonajeTerrestre
    {
        public Jugador(Direccion direccion)
            : base(4, 4, direccion)
        {
        }

        public Jugador(Point posicion, Direccion direccion)
            : base(4,4,posicion,direccion)
        {
        } 
    }
}
