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
        public BurbujaDisparada(Point posicion, Direccion direccion,Laberinto laberinto)
            : base(posicion, direccion,laberinto)
        {
            velocidad = 3;
            distanciaRecorrida = 0;
            distanciaMaxima = 20;
        }

        public override void vivir()
        {
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
                                derechaUno();
                            else
                            {
                                x = velocidad;
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
                            izquierdaUno();
                        else
                        {
                            x = velocidad;
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

    }
}
