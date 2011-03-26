using System.Drawing;
using System.Collections.Generic;

namespace BubbleBobble.clases
{
    public abstract class ObjetoVivo:Objeto,Ivivo
    {
        protected Laberinto laberinto;
        protected Vista.Ivista vista;

        public ObjetoVivo(int ancho, int alto, Point posicion) :
            base(ancho, alto, posicion)
        {
        }

        public ObjetoVivo(int ancho, int alto) :
            base(ancho, alto)
        {
        }

        public void subirUno()
        {
            this.posicion = new Point(posicion.X, posicion.Y + 1);
        }

        public void bajarUno()
        {
            this.posicion = new Point(posicion.X, posicion.Y - 1);
        }

        public void izquierdaUno()
        {
            this.posicion = new Point(posicion.X-1, posicion.Y);
        }

        public void derechaUno()
        {
            this.posicion = new Point(posicion.X+1, posicion.Y);
        }

        public Laberinto Laberinto
        {
            set { this.laberinto = value; }
        }

        public bool puedoAvanzarDesdeIzquierda()
        {
            List<Point> puntos = new List<Point>();
            for (int n = 0; n < getAlto(); n++)
                puntos.Add(new Point(this.getPosicion().X + getAncho(), getPosicion().Y + n));
            return (laberinto.esOcupableDesdeIzquierda(puntos));
        }

        public bool puedoAvanzarDesdeDerecha()
        {
            List<Point> puntos = new List<Point>();
            for (int n = 0; n < getAlto(); n++)
                puntos.Add(new Point(this.getPosicion().X - Laberinto.TBloque, getPosicion().Y + n));
            return (laberinto.esOcupableDesdeDerecha(puntos));
        }

        public bool puedoAvanzarDesdeArriba()
        {
            List<Point> puntos = new List<Point>();
            for (int n = 0; n <= getAncho(); n++)
            {
                if (getPosicion().X % Laberinto.TBloque != 0)
                    puntos.Add(new Point(this.getPosicion().X - 1 + n, getPosicion().Y - Laberinto.TBloque));
                else
                    if (n != getAncho())
                        puntos.Add(new Point(this.getPosicion().X + n, getPosicion().Y - Laberinto.TBloque));
            }
            return laberinto.esOcupableDesdeArriba(puntos);
        }

        public abstract void vivir();
        public Vista.Ivista Vista
        {
            get { return this.vista; }
            set { this.vista = value; }
        }
    }
}
