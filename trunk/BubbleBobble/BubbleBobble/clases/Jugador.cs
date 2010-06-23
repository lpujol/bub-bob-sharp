using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Jugador:PersonajeTerrestre
    {
        bool muerto;
        int transcurridoMuerto;
        int maximoMuerto;
        int transcurridoInmortal;
        int maximoInmortal;
        bool inmortal;
        int vidas;
        Point posicionInicial;
        bool _saltoLatente;

        public Jugador(Direccion direccion)
            : base(4, 4, direccion)
        {
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;
            vidas = 3;
            _saltoLatente = false;
        }

        public Jugador(Point posicion, Direccion direccion)
            : base(4,4,posicion,direccion)
        {
            posicionInicial = posicion;
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;            
            vidas = 3;           
            cambiaDir = false;
            _saltoLatente = false;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return new BurbujaDisparada(new Point(getPosicion().X+(this.direccion==Direccion.derecha?2:-2), getPosicion().Y), this.direccion,this.laberinto);
        }

        internal void matar()
        {
            muerto = true;
            estado = Estado.cayendo;
        }

        public override void vivir()
        {
            if (muerto)
            {
                if (transcurridoMuerto > maximoMuerto)
                {
                    transcurridoMuerto = 0;
                    muerto = false;
                    laberinto.matar(this);
                    vidas--;
                }
                else
                {
                    transcurridoMuerto++;
                }
                if (this.estado == Estado.cayendo)
                {
                        if (getPosicion().Y < -getAlto())
                            setPosicion(new Point(getPosicion().X, laberinto.getAlto()));
                        for (int x = 0; x < 2; x++)
                        {
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n <= getAncho(); n++)
                            {
                                if (getPosicion().X % 2 != 0)
                                    puntos.Add(new Point(this.getPosicion().X - 1 + n, getPosicion().Y - 2));
                                else
                                {
                                    if (n != getAncho())
                                        puntos.Add(new Point(this.getPosicion().X + n, getPosicion().Y - 2));
                                }
                            }
                            if (laberinto.esOcupableDesdeArriba(puntos))
                                bajarUno();
                            else
                            {
                                x = 3;
                                estado = Estado.caminando;
                            }
                        }
                    
                }
            }
            else
            {
                if (inmortal)
                {
                    transcurridoInmortal++;
                    if (transcurridoInmortal > maximoInmortal)
                        inmortal = false;
                }
                if (this.estado == Estado.cayendo)
                {
                    if (_saltoLatente)
                    {
                        List<Point> puntos = new List<Point>();
                        for (int n = 0; n <= getAncho(); n++)
                            puntos.Add(new Point(this.getPosicion().X + n, this.getPosicion().Y));
                        if (laberinto.hayBurbujaEnPosiciones(puntos))
                        {
                            this.estado = Estado.salto1;                           
                        }
                    }
                }
                base.vivir();
            }
        }

        public void sumarVidas()
        {
            vidas++;
        }

        public int Vidas
        {
            get { return this.vidas; }
        }

        public bool Muerto
        {
            get { return this.muerto; }
        }

        public bool Inmortal
        {
            get { return this.inmortal; }
        }

        public int TranscurridoInmortal
        {
            get { return this.transcurridoInmortal; }
        }



        internal void reiniciar()
        {
            this.posicion = posicionInicial;
            this.estado = Estado.caminando;
            this.inmortal = true;
            transcurridoInmortal = 0;
        }

        public override void Disparar()
        {
            if(!muerto)
                base.Disparar();
        }

        
        public void saltoLatente()
        {
            _saltoLatente = true;
        }



        internal void liberaSaltoLatente()
        {
            _saltoLatente = false;
        }
    }
}
