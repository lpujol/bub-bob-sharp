using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class BurbujaConEnemigo:Burbuja
    {
        IEnemigo enemigo;
        public BurbujaConEnemigo(Point posicion, Laberinto laberinto, IEnemigo enemigo)
            : base(posicion, laberinto)
        {
            this.enemigo = enemigo;
        }

        public IEnemigo Enemigo {
            get { return this.enemigo; }
        }
    }
}
