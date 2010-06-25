using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Robotito:PersonajeTerrestre,IEnemigo
    {
        static Random r;
        public Robotito(Direccion direccion)
            : base(8, 8, direccion)
        {
            moviendose = true;
            atrapado = false;            
            if(Robotito.r==null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public Robotito(Point posicion, Direccion direccion)
            : base(8,8,posicion,direccion)
        {
            moviendose = true;
            atrapado = false;
            if (Robotito.r == null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public override void vivir()
        {
            int n = Robotito.r.Next(30);
            /*if (n == 15)
                saltar();
            if (n % 8 == 0)
            {
                cambiarDireccion();
            }*/
            if(this.estado==Estado.caminando)
            {
                if (!moviendose) moviendose = true;
                bool cambia = false;
                if (this.direccion == Direccion.derecha)
                {
                     List<Point> puntos = new List<Point>();
                     for (int nn = 0; nn < getAlto(); nn++)
                         puntos.Add(new Point(this.getPosicion().X + getAncho(), getPosicion().Y +nn));
                     if (!laberinto.esOcupableDesdeIzquierda(puntos))
                         cambia = true;
                }
                else
                {
                    List<Point> puntos = new List<Point>();
                    for (int nn = 0; nn < getAlto(); nn++)
                        puntos.Add(new Point(this.getPosicion().X -Laberinto.TBloque, getPosicion().Y + nn));
                    if (!laberinto.esOcupableDesdeDerecha(puntos))
                        cambia = true;
                }
                if (!cambia && n == 5) cambia = true;
                if (cambia)
                    cambiarDireccion();
                else
                {
                    bool apuntodecaer = false;
                    if (this.direccion == Direccion.derecha && !(laberinto.bloqueEn(this.posicion.X,this.posicion.Y-1) is Aire)&& laberinto.bloqueEn(this.posicion.X + 1, this.posicion.Y - 1) is Aire)
                        apuntodecaer = true;
                    if (this.direccion == Direccion.izquierda && !(laberinto.bloqueEn(this.posicion.X+getAncho(),this.posicion.Y-1) is Aire) && laberinto.bloqueEn(this.posicion.X+this.getAncho()-2 , this.posicion.Y - 1) is Aire)
                        apuntodecaer = true;
                    if (apuntodecaer)
                        if (n %3==0)
                            cambiarDireccion();
                    if (n == 17) saltar();
                }
            }
            if (this.estado == Estado.cayendo)
            {
                if (moviendose)
                    if (n < 23)
                        moviendose = false;
            }
            base.vivir();
            if (vivo)
            {
                foreach (Jugador jugador in laberinto.Jugadores)
                {
                    if (!jugador.Inmortal)
                    {
                        if (colisionaCon(jugador))
                            jugador.matar();
                    }

                }
            }
        }

        private void cambiarDireccion()
        {
            cambiaDireccion();
            if (this.direccion == Direccion.derecha)
                this.direccion = Direccion.izquierda;
            else
                this.direccion = Direccion.derecha;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return null;
        }
    }
}
