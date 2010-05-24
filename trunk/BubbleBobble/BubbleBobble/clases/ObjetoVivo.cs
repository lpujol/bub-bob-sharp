using System.Drawing;

namespace BubbleBobble.clases
{
    public abstract class ObjetoVivo:Objeto,Ivivo
    {
        protected Laberinto laberinto;

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

        public abstract void vivir();
    }
}
