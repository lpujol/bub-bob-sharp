using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public enum Estado { salto1,salto2,salto3,ssalto1,ssalto2,ssalto3,cayendo,caminando}
    public enum EstadoDisparo { d1,d2,d3}
    public enum Direccion { izquierda, derecha}
    
    public abstract class PersonajeTerrestre:Personaje
    {
        protected Estado estado;
        protected bool moviendose;
        protected Direccion direccion;
        protected int velocidad;
        protected int tiempoDesdeElUltimoDisparo;
        protected int permitidoEntreDisparos;
        protected bool atrapado;
        protected bool cambiaDir;
        protected bool vivo;
        private int conteomuerto;

        public PersonajeTerrestre(int ancho, int alto, Point posicion,Direccion direccion)
            : base(ancho, alto, posicion)
        {
            estado = Estado.caminando;
            moviendose = false;
            this.direccion = direccion;
            velocidad = 1;
            permitidoEntreDisparos = 8;
            tiempoDesdeElUltimoDisparo = permitidoEntreDisparos;
            vivo = true;
            conteomuerto = 0;
        }

        public PersonajeTerrestre(int ancho, int alto,Direccion direccion)
            : base(ancho, alto)
        {
            estado = Estado.caminando;
            moviendose = false;
            this.direccion = direccion;
            velocidad = 1;
            vivo = true;
            conteomuerto = 0;
        }

        public bool Moviendose
        {
            set { this.moviendose = value; }
            get { return this.moviendose;}
        }

        public Direccion Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        public bool Vivo
        {
            get { return this.vivo; }
            set { this.vivo = value; }
        }

        
        public override void vivir()
        {
            if (vivo)
            {
                switch (this.estado)
                {
                    case Estado.cayendo:
                        if (getPosicion().Y < -getAlto())
                            setPosicion(new Point(getPosicion().X, laberinto.getAlto()));
                        for (int x = 0; x < 4; x++)
                        {
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n <= getAncho(); n++)
                            {
                                if (getPosicion().X % Laberinto.TBloque != 0)
                                    puntos.Add(new Point(this.getPosicion().X - 1 + n, getPosicion().Y - Laberinto.TBloque));
                                else
                                {
                                    if (n != getAncho())
                                        puntos.Add(new Point(this.getPosicion().X + n, getPosicion().Y - Laberinto.TBloque));
                                }
                            }
                            if (laberinto.esOcupableDesdeArriba(puntos))
                                bajarUno();
                            else
                            {
                                x = 5;
                                estado = Estado.caminando;
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
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n < getAlto(); n++)
                                puntos.Add(new Point(this.getPosicion().X + getAncho(), getPosicion().Y + n));
                            if (laberinto.esOcupableDesdeIzquierda(puntos))
                                derechaUno();
                        }
                    }
                    else
                    {
                        for (int x = 0; x < velocidad; x++)
                        {
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n < getAlto(); n++)
                                puntos.Add(new Point(this.getPosicion().X - Laberinto.TBloque, getPosicion().Y + n));
                            if (laberinto.esOcupableDesdeDerecha(puntos))
                                izquierdaUno();
                        }

                    }
                }
                if (estado == Estado.caminando)
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
                    if (laberinto.esOcupableDesdeArriba(puntos))
                        estado = Estado.cayendo;
                }
                if (tiempoDesdeElUltimoDisparo <= permitidoEntreDisparos)
                    tiempoDesdeElUltimoDisparo++;
            }
            else//si esta muerto... mas que nada para los enemigos...
            {
                conteomuerto++;
                if (conteomuerto == 50) estado = Estado.cayendo;
                if (posicion.Y > laberinto.getAlto() + 15) estado = Estado.salto2;
                if (estado == Estado.salto1)
                {
                    for (int x = 0; x < 4; x++)
                        subirUno();                    
                }
                if (estado == Estado.salto2)
                {
                    for (int x = 0; x < 4; x++)
                        bajarUno();
                }
                if (estado == Estado.cayendo)
                {
                    if (getPosicion().Y < -getAlto())
                        setPosicion(new Point(getPosicion().X, laberinto.getAlto()));
                    for (int x = 0; x < 4; x++)
                    {
                        List<Point> puntos = new List<Point>();
                        for (int n = 0; n <= getAncho(); n++)
                        {
                            if (getPosicion().X % Laberinto.TBloque != 0)
                                puntos.Add(new Point(this.getPosicion().X - 1 + n, getPosicion().Y - Laberinto.TBloque));
                            else
                            {
                                if (n != getAncho())
                                    puntos.Add(new Point(this.getPosicion().X + n, getPosicion().Y - Laberinto.TBloque));
                            }
                        }
                        if (laberinto.esOcupableDesdeArriba(puntos))
                            bajarUno();
                        else
                        {
                            x = 5;
                            laberinto.convertirEnObjetoConPuntos(this);
                        }
                    }
                }
                else
                {
                    
                    if (direccion == Direccion.derecha)
                    {
                        for(int x=0;x<4;x++)
                        {
                            if (posicion.X+getAncho() < laberinto.getAncho() - 2 * Laberinto.TBloque)
                                derechaUno();
                            else
                            {
                                x = 4;
                                direccion = Direccion.izquierda;
                            }
                        }
                    }
                    else
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            if (posicion.X > Laberinto.TBloque * 2)
                                izquierdaUno();
                            else
                            {
                                x = 4;
                                direccion = Direccion.derecha;
                            }
                        }
                    }
                }
            }
        }

        public void saltar()
        {
            if (estado != Estado.salto1 && estado != Estado.salto2 && estado != Estado.salto3 &&estado!=Estado.cayendo)
                if(estado!=Estado.ssalto1 && estado!=Estado.ssalto2 && estado!= Estado.ssalto3)
                    estado = Estado.salto1;
        }

        public abstract ObjetoDisparado getObjetoDisparado();

        
        public virtual void Disparar()
        {
            if (tiempoDesdeElUltimoDisparo > permitidoEntreDisparos)
            {
                laberinto.agregarDisparo(this.getObjetoDisparado());
                tiempoDesdeElUltimoDisparo = 0;
            }
        }

        public bool Atrapado
        {
            get { return this.atrapado; }
            set { this.atrapado = value; }
        }

        public void fueAtrapado()
        {
            atrapado = true;
        }

        public void fueLiberado()
        {
            atrapado = false;
        }

        public void cambiaDireccion()
        {
            cambiaDir = true;
        }

        public bool CambiaDir
        {
            get
            {

                if (!cambiaDir) return false;
                cambiaDir = false;
                return true;

            }

        }
        
        
    }
}
