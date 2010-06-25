using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Fruta:ObjetoVivo
    {
        private int puntos;
        public Fruta(Point posicion)
            : base(8, 8, posicion)
        {
            puntos = 1000;
        }

        public int Puntaje
        {
            get { return this.puntos; }
        }

        public override void vivir()
        {            
        }

    }
}
