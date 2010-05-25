using System.Drawing;
using System.Collections.Generic;

namespace BubbleBobble.clases
{
    public class Objeto:IDibujable
    {
        private int ancho;
        private int alto;
        protected Point posicion;

        public Objeto(int ancho, int alto, Point posicion)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.posicion = posicion;
        }

        public Objeto(int ancho, int alto)
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
            return this.ancho;
        }

        public Point getPosicion()
        {
            return this.posicion;
        }

        public void setPosicion(Point punto)
        {
            this.posicion = punto;
        }

        #endregion

        /// <summary>
        /// Indica si hay colision entre los rectangulos pertenecientes a lso objetos
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Devuelve true, si ambos objetos estan ocupando el mismo espacio fisico</returns>
        public bool colisionaCon(Objeto o)
        {
            List<Point> puntos = new List<Point>();
            puntos.Add(o.getPosicion());
            puntos.Add(new Point(o.getPosicion().X, o.getPosicion().Y));
            puntos.Add(new Point(o.getPosicion().X, o.getPosicion().Y+o.getAlto()));
            puntos.Add(new Point(o.getPosicion().X+o.getAncho(), o.getPosicion().Y));
            puntos.Add(new Point(o.getPosicion().X+o.getAncho(), o.getPosicion().Y+o.getAlto()));
            foreach (Point p in puntos)
            {
                if (p.X >= this.posicion.X && p.X <= (this.posicion.X + ancho))
                {
                    if (p.Y >= this.posicion.Y && p.Y <= (this.posicion.Y + alto))
                        return true;
                }
            }
            return false;
        }

        public bool intersecta(Objeto o)
        {
            List<Point> puntos = new List<Point>();
            puntos.Add(o.getPosicion());
            puntos.Add(new Point(o.getPosicion().X, o.getPosicion().Y));
            puntos.Add(new Point(o.getPosicion().X, o.getPosicion().Y + 1));
            puntos.Add(new Point(o.getPosicion().X-1, o.getPosicion().Y + 1));
            puntos.Add(new Point(o.getPosicion().X+1, o.getPosicion().Y + 1));
            puntos.Add(new Point(o.getPosicion().X-1, o.getPosicion().Y));
            puntos.Add(new Point(o.getPosicion().X+1, o.getPosicion().Y));
            puntos.Add(new Point(o.getPosicion().X-1, o.getPosicion().Y - 1));
            puntos.Add(new Point(o.getPosicion().X, o.getPosicion().Y - 1));
            puntos.Add(new Point(o.getPosicion().X + 1, o.getPosicion().Y - 1));

            foreach (Point p in puntos)
            {
                if (p.X == posicion.X && p.Y == posicion.Y)
                    return true;
            }
            return false;
        }
    }
}
