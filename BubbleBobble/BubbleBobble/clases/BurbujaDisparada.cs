﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class BurbujaDisparada:ObjetoDisparado
    {
        int velocidad;
        int distanciaMaxima;
        int distanciaRecorrida;

        bool inicia;
        public BurbujaDisparada(Point posicion, Direccion direccion,Laberinto laberinto)
            : base(posicion, direccion,laberinto)
        {
            velocidad = 3;
            distanciaRecorrida = 0;
            distanciaMaxima = 20;
            inicia = true;
        }

        public override void vivir()
        {
            if (inicia)
            {
                inicia = false;
                return;
            }
            if (this.Direccion == Direccion.derecha)
            {
                for (int x = 0; x < velocidad; x++)
                    {

                        if (distanciaRecorrida < distanciaMaxima)
                        {
                            List<Point> puntos = new List<Point>();
                            for (int n = 0; n < getAlto(); n++)
                                puntos.Add(new Point(this.getPosicion().X + getAncho(), getPosicion().Y + n));
                            if (laberinto.esOcupableDesdeIzquierda(puntos))
                            {
                                derechaUno();
                                foreach (IEnemigo enemigo in laberinto.Enemigos)
                                {
                                    if (this.intersecta((Objeto)enemigo))
                                    {
                                        laberinto.burbujaAtrapaEnemigo(this, enemigo);
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                x = velocidad;
                                distanciaRecorrida = distanciaMaxima;
                                laberinto.pasarABurbujaRegular(this);
                            }
                            distanciaRecorrida++;
                        }
                        else
                        {
                            x = velocidad;
                            laberinto.pasarABurbujaRegular(this);
                        }
                            
                    }
            }
            else
            {
                for (int x = 0; x < velocidad; x++)
                {
                    if (distanciaRecorrida < distanciaMaxima)
                    {
                        List<Point> puntos = new List<Point>();
                        for (int n = 0; n < getAlto(); n++)
                            puntos.Add(new Point(this.getPosicion().X - 2, getPosicion().Y + n));
                        if (laberinto.esOcupableDesdeDerecha(puntos))
                        {
                            izquierdaUno();
                            foreach (IEnemigo enemigo in laberinto.Enemigos)
                            {
                                if (this.intersecta((Objeto)enemigo))
                                {
                                    laberinto.burbujaAtrapaEnemigo(this, enemigo);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            x = velocidad;
                            distanciaRecorrida = distanciaMaxima;
                            laberinto.pasarABurbujaRegular(this);
                        }
                        distanciaRecorrida++;
                    }
                    else
                    {
                        x = velocidad;
                        laberinto.pasarABurbujaRegular(this);                        
                    }
                }
            }
        }

        public int DistanciaRecorrida
        {
            get { return this.distanciaRecorrida; }
        }

        public int DistanciaMaxima
        {
            get { return this.distanciaMaxima; }
        }

    }
}