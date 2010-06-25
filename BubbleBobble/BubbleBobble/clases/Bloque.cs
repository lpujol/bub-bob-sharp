using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Bloque:IDibujable
    {
        int ancho;
        int alto;
        Point posicion;

        public Bloque(int ancho, int alto, Point posicion)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.posicion = posicion;
        }

        public Bloque(int ancho, int alto)
            : this(ancho, alto, new Point(0, 0))
        {
        }

        #region Miembros de IDibujable

        public int getAlto()
        {
            return this.alto;
        }

        public int getAncho()
        {
            return this.alto;
        }

        public System.Drawing.Point getPosicion()
        {
            return this.posicion;
        }

        #endregion

        public bool esOcupable(Bloque proveniente)
        {
            if (proveniente.GetType() == this.GetType())
                return true;
            if (this is Aire) return true;
            return false;
        }

        internal void setPosicion(Point point)
        {
            this.posicion = point;
        }
    }
}
