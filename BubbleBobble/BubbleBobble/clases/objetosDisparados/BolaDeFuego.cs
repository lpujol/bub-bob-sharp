using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    class BolaDeFuego:ObjetoDisparado
    {
        
        public BolaDeFuego(Point posicion, Direccion direccion,Laberinto laberinto):base(posicion,direccion,laberinto,3)
        {
            
        }
        public override void vivir()
        {
            for (int x = 0; x < this.Velocidad; x++)
            {
                if (this.Direccion == Direccion.derecha)
                {
                    if (puedoAvanzarDesdeIzquierda())
                        derechaUno();
                    else
                        laberinto.eliminarObjetoDisparado(this);
                }
                else
                {
                    if (puedoAvanzarDesdeDerecha())
                        izquierdaUno();
                    else
                        laberinto.eliminarObjetoDisparado(this);
                }
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
    }
}
