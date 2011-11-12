using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using BubbleBobble.clases.objetosDisparados;

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
        int puntaje;
        bool disparaRapido;
        bool disparaFuego;
        bool disparaLejos;
        bool caminaRapido;
        bool burbujaRapida;

        public bool BurbujaRapida
        {
            get { return burbujaRapida; }
            set { burbujaRapida = value; }
        }

        public bool CaminaRapido
        {
            get { return caminaRapido; }
            set { caminaRapido = value; }
        }

        public bool DisparaLejos
        {
            get { return disparaLejos; }
            set { disparaLejos = value; }
        }

        public bool DisparaRapido
        {
            get { return disparaRapido; }
            set { disparaRapido = value; }
        }

        public bool DisparaFuego
        {
            get { return disparaFuego; }
            set { disparaFuego = value; }
        }
        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        public Jugador(Direccion direccion)
            : base(8, 8, direccion)
        {
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;
            vidas = 3;
            _saltoLatente = false;
            puntaje = 0;
        }

        public Jugador(Point posicion, Direccion direccion)
            : base(8,8,posicion,direccion)
        {
            posicionInicial = posicion;
            DisparaFuego = false;
            DisparaLejos = false;
            DisparaRapido = false;
            CaminaRapido = false;
            BurbujaRapida = false;
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;            
            vidas = 3;           
            cambiaDir = false;
            _saltoLatente = false;
            velocidad = 2;
            puntaje = 0;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            if(DisparaLejos)
                return new BurbujaDisparadaLejos(new Point(getPosicion().X + (this.direccion == Direccion.derecha ? 2 : -2), getPosicion().Y), this.direccion, this.laberinto,this.burbujaRapida);
            if (DisparaFuego)
                return new ProyectilFuego(new Point(getPosicion().X + (this.direccion == Direccion.derecha ? 2 : -2), getPosicion().Y), this.direccion, this.laberinto);
            return new BurbujaDisparada(new Point(getPosicion().X+(this.direccion==Direccion.derecha?2:-2), getPosicion().Y), this.direccion,this.laberinto,this.burbujaRapida);
        }

        internal void matar()
        {
            muerto = true;
            DisparaFuego = false;
            DisparaLejos = false;
            DisparaRapido = false;
            CaminaRapido = false;
            BurbujaRapida = false;
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
                            if(puedoAvanzarDesdeArriba())
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
                /*if (this.estado == Estado.cayendo)
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
                }*/
                vivirJugador();
            }
        }

        private void vivirJugador()
        {
            for (int x = 0; x < laberinto.Frutas.Count; x++)
            {
                Fruta f = laberinto.Frutas[x];
                try
                {
                    if (colisionaCon(f))
                    {
                        puntaje += f.Puntaje;
                        laberinto.comeFruta(f);
                    }
                }
                catch(Exception){}
            }
            switch (this.estado)
            {
                case Estado.cayendo:
                    if (getPosicion().Y < -getAlto())
                        setPosicion(new Point(getPosicion().X, laberinto.getAlto()));
                    for (int x = 0; x < 4; x++)
                    {
                        bool continuar = true;
                        if (_saltoLatente)
                        {
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n <= getAncho(); n++)
                                puntos.Add(new Point(this.getPosicion().X + n, this.getPosicion().Y));
                            if (laberinto.hayBurbujaEnPosiciones(puntos))
                            {
                                this.estado = Estado.salto1;
                                continuar = false;
                            }
                        }
                        if (continuar)
                        {
                            if (puedoAvanzarDesdeArriba())
                                bajarUno();
                            else
                            {
                                x = 5;
                                estado = Estado.caminando;
                            }
                        }
                    }
                    break;
                case Estado.salto3:
                    for (int x = 0; x < 4; x++)
                        subirUno();
                    estado = Estado.cayendo;
                    break;
                case Estado.salto2:
                    for (int x = 0; x < 8; x++)
                        subirUno();
                    estado = Estado.salto3;
                    break;
                case Estado.salto1:
                    for (int x = 0; x < 12; x++)
                        subirUno();
                    estado = Estado.salto2;
                    break;

            }
            if (moviendose)
            {
                if (direccion == Direccion.derecha)
                {
                    for (int x = 0; x < velocidad; x++)
                    {
                        if (puedoAvanzarDesdeIzquierda())
                        {
                            if (CaminaRapido) derechaUno();
                            derechaUno();
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < velocidad; x++)
                    {
                        if (puedoAvanzarDesdeDerecha())
                        {
                            if (caminaRapido) izquierdaUno();
                            izquierdaUno();
                        }
                    }

                }
            }
            if (estado == Estado.caminando)
            {
                
                if (puedoAvanzarDesdeArriba())
                    estado = Estado.cayendo;
            }
            if (tiempoDesdeElUltimoDisparo <= permitidoEntreDisparos)
            {
                if (DisparaRapido) tiempoDesdeElUltimoDisparo++;
                tiempoDesdeElUltimoDisparo++;
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

        public void inicial()
        {
            this.posicion = posicionInicial;
            this.estado = Estado.caminando;
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

        internal void acercarInicial()
        {
            int newx, newy;
            if (this.posicion.X > this.posicionInicial.X)
                newx = this.posicion.X - (this.posicion.X-this.posicionInicial.X>3?3:1);
            else
            {
                if (this.posicion.X < this.posicionInicial.X)
                    newx = this.posicion.X + (this.posicion.X - this.posicionInicial.X > 3 ? 3 : 1);
                else
                    newx = this.posicion.X;
            }
            if (this.posicion.Y > this.posicionInicial.Y)
                newy = this.posicion.Y - (this.posicion.Y - this.posicionInicial.Y > 3 ? 3 : 1);
            else
            {
                if (this.posicion.Y < this.posicionInicial.Y)
                    newy = this.posicion.Y + (this.posicion.Y - this.posicionInicial.Y > 3 ? 3 : 1);
                else
                    newy = this.posicion.Y;
            }
            this.posicion = new Point(newx, newy);
        }

        internal void sumarPuntos(int puntos)
        {
            this.puntaje += puntos;
        }
    }
}
