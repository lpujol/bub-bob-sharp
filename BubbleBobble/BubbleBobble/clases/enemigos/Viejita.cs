using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Viejita:PersonajeTerrestre,IEnemigo
    {
        static Random r;
        public Viejita(Direccion direccion)
            : base(8, 8, direccion)
        {
            moviendose = true;
            atrapado = false;
            if(Viejita.r==null)
                Viejita.r = new Random(DateTime.Now.Millisecond);
            this.permitidoEntreDisparos = 500;
        }

        public Viejita(Point posicion, Direccion direccion)
            : base(8,8,posicion,direccion)
        {
            moviendose = true;
            atrapado = false;
            if (Viejita.r == null)
                Viejita.r = new Random(DateTime.Now.Millisecond);
        }

        public override void vivir()
        {
            int n = Viejita.r.Next(30);            
            if (this.estado == Estado.caminando)
            {
                if (!moviendose) moviendose = true;
                bool cambia = false;
                if (this.direccion == Direccion.derecha)
                {
                    if (!puedoAvanzarDesdeIzquierda())
                        cambia = true;
                }
                else
                {
                    if (!puedoAvanzarDesdeDerecha())
                        cambia = true;
                }
                if (!cambia)
                {
                    if (n % 10 == 0)
                    {
                        foreach (Jugador j in laberinto.Jugadores)
                        {
                            if (!j.Inmortal)
                            {
                                int posY = j.getPosicion().Y;
                                int alt = j.getAlto();
                                if (this.getPosicion().Y >= posY && this.getPosicion().Y <= (posY + alt))
                                {
                                    if (this.direccion == Direccion.derecha)
                                    {
                                        if (j.getPosicion().X > this.getPosicion().X)
                                            Disparar();
                                    }
                                    else
                                    {
                                        if (j.getPosicion().X < this.getPosicion().X)
                                            Disparar();
                                    }
                                }
                            }

                        }
                    }
                }
                if (!cambia && n == 5) cambia = true;
                if (cambia)
                    cambiarDireccion();
                else
                {
                    bool apuntodecaer = false;
                    if (this.direccion == Direccion.derecha && !(laberinto.bloqueEn(this.posicion.X, this.posicion.Y - 1) is Aire) && laberinto.bloqueEn(this.posicion.X + 1, this.posicion.Y - 1) is Aire)
                        apuntodecaer = true;
                    if (this.direccion == Direccion.izquierda && !(laberinto.bloqueEn(this.posicion.X + getAncho(), this.posicion.Y - 1) is Aire) && laberinto.bloqueEn(this.posicion.X + this.getAncho() - 2, this.posicion.Y - 1) is Aire)
                        apuntodecaer = true;
                    if (apuntodecaer)
                        if (n % 3 == 0)
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
            return new BolaDeFuego(this.posicion, this.direccion, this.laberinto);
        }
    }
}
