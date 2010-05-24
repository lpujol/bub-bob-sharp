using System.Collections.Generic;
using System.Drawing;

namespace BubbleBobble.clases
{
    public abstract class Personaje:ObjetoVivo
    {
        public Personaje(int ancho, int alto, Point posicion)
            : base(ancho, alto, posicion)
        {
        }

        public Personaje(int ancho, int alto)
            : base(ancho, alto)
        {
        }

        protected void avanzarIzquierda()
        {            
            List<Point> puntos = new List<Point>();
            for(int x=0;x<this.getAlto();x++)
                puntos.Add(new Point(this.getPosicion().X-1,this.getPosicion().Y+x));
            if (laberinto.esOcupableDesdeDerecha(puntos))
                izquierdaUno();
        }

        protected void avanzarderecha()
        {
            List<Point> puntos = new List<Point>();
            for (int x = 0; x < this.getAlto(); x++)
                puntos.Add(new Point(this.getPosicion().X +this.getAncho(), this.getPosicion().Y + x));
            if (laberinto.esOcupableDesdeIzquierda(puntos))
                izquierdaUno();
        }

        public override abstract void vivir();
        
    }
}
