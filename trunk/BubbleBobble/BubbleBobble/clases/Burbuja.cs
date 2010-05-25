using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public enum EstadoBurbuja { Estable,Rev1,Rev2 }
    public class Burbuja:ObjetoVivo
    {
        private EstadoBurbuja estado;
        public Burbuja(Point posicion,Laberinto laberinto)
            : base(4, 4, posicion)
        {
            this.laberinto = laberinto;
            estado = EstadoBurbuja.Estable;
        }

        public EstadoBurbuja Estado
        {
            get { return this.estado; }
        }

        public override void vivir()
        {
            if (estado == EstadoBurbuja.Rev2)
            {
                laberinto.reventarBurbuja(this);
                return;
            }
            if (estado == EstadoBurbuja.Rev1)
            {
                estado = EstadoBurbuja.Rev2;
                return;
            }
            if (getPosicion().X < 4 || getPosicion().X>60)
            {
                estado = EstadoBurbuja.Rev1;
            }

        }
    }
}
