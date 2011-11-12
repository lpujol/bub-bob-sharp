using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class BurbujaDisparada:ObjetoDisparado
    {
        protected int distanciaMaxima;
        int distanciaRecorrida;

        bool inicia;
        public BurbujaDisparada(Point posicion, Direccion direccion,Laberinto laberinto,bool rapida)
            : base(posicion, direccion,laberinto,rapida?8:5)
        {
            distanciaRecorrida = 0;
            distanciaMaxima = 40;
            inicia = true;
        }        

        public override void vivir()
        {
            if (inicia)
            {
                inicia = false;
                return;
            }
            if (posicion.X < 0 || posicion.X > laberinto.getAncho())
                laberinto.pasarABurbujaRegular(this);
            if (this.Direccion == Direccion.derecha)
            {
                for (int x = 0; x < this.Velocidad; x++)
                    {

                        if (distanciaRecorrida < distanciaMaxima)
                        {
                            
                            if (puedoAvanzarDesdeIzquierda())
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
                                x = this.Velocidad;
                                distanciaRecorrida = distanciaMaxima;
                                laberinto.pasarABurbujaRegular(this);
                            }
                            distanciaRecorrida++;
                        }
                        else
                        {
                            x = this.Velocidad;
                            laberinto.pasarABurbujaRegular(this);
                        }
                            
                    }
            }
            else
            {
                for (int x = 0; x < this.Velocidad; x++)
                {
                    if (distanciaRecorrida < distanciaMaxima)
                    {
                       
                        if (puedoAvanzarDesdeDerecha())
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
                            x = this.Velocidad;
                            distanciaRecorrida = distanciaMaxima;
                            laberinto.pasarABurbujaRegular(this);
                        }
                        distanciaRecorrida++;
                    }
                    else
                    {
                        x = this.Velocidad;
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
