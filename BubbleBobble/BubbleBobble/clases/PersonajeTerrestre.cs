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

        public PersonajeTerrestre(int ancho, int alto, Point posicion,Direccion direccion)
            : base(ancho, alto, posicion)
        {
            estado = Estado.caminando;
            moviendose = false;
            this.direccion = direccion;
            velocidad = 1;
            permitidoEntreDisparos = 8;
            tiempoDesdeElUltimoDisparo = permitidoEntreDisparos;
        }

        public PersonajeTerrestre(int ancho, int alto,Direccion direccion)
            : base(ancho, alto)
        {
            estado = Estado.caminando;
            moviendose = false;
            this.direccion = direccion;
            velocidad = 1;
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

        public override void vivir()
        {
            switch (this.estado)
            {
                case Estado.cayendo:
                    for (int x = 0; x < 2; x++)
                    {
                        List<Point> puntos=new List<Point>();
                        for (int n = 0; n <= getAncho(); n++)
                        {
                            if (getPosicion().X % 2 != 0)
                                puntos.Add(new Point(this.getPosicion().X - 1 + n, getPosicion().Y - 2));
                            else
                            {
                                if(n!=getAncho())
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
                    break;
                case Estado.salto3:
                    for (int x = 0; x < 2; x++)
                        subirUno();
                    estado = Estado.cayendo;
                    break;
                case Estado.salto2:
                    for (int x = 0; x < 4; x++)
                        subirUno();
                    estado = Estado.salto3;
                    break;
                case Estado.salto1:
                    for (int x = 0; x < 6; x++)
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
                            puntos.Add(new Point(this.getPosicion().X + getAncho(), getPosicion().Y +n));
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
                            puntos.Add(new Point(this.getPosicion().X -2, getPosicion().Y + n));
                        if (laberinto.esOcupableDesdeDerecha(puntos))
                            izquierdaUno();
                    }

                }
            }
            if (estado == Estado.caminando)
            {
                List<Point> puntos=new List<Point>();
                for (int n = 0; n <= getAncho(); n++)
                {
                    if (getPosicion().X % 2 != 0)
                        puntos.Add(new Point(this.getPosicion().X-1 + n, getPosicion().Y - 2));
                    else
                        if(n!=getAncho())
                            puntos.Add(new Point(this.getPosicion().X + n, getPosicion().Y - 2));
                }
                if (laberinto.esOcupableDesdeArriba(puntos))
                    estado = Estado.cayendo;
            }
            if(tiempoDesdeElUltimoDisparo<=permitidoEntreDisparos)
                tiempoDesdeElUltimoDisparo++;
        }

        public void saltar()
        {
            if (estado != Estado.salto1 && estado != Estado.salto2 && estado != Estado.salto3 &&estado!=Estado.cayendo)
                if(estado!=Estado.ssalto1 && estado!=Estado.ssalto2 && estado!= Estado.ssalto3)
                    estado = Estado.salto1;
        }

        public abstract ObjetoDisparado getObjetoDisparado();

        
        public void Disparar()
        {
            if (tiempoDesdeElUltimoDisparo > permitidoEntreDisparos)
            {
                laberinto.agregarDisparo(this.getObjetoDisparado());
                tiempoDesdeElUltimoDisparo = 0;
            }
        }
        
        
    }
}
