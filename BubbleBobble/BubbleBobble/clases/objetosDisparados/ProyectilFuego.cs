using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases.objetosDisparados
{
    public class ProyectilFuego:ObjetoDisparado
    {
        public ProyectilFuego(Point posicion, Direccion direccion, Laberinto laberinto)
            : base(posicion, direccion, laberinto, 5)
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
                    if(puedoAvanzarDesdeDerecha())
                        izquierdaUno();
                    else
                        laberinto.eliminarObjetoDisparado(this);
                }
                foreach (IEnemigo enemigo in laberinto.Enemigos)
                {
                    if (colisionaCon((Objeto)enemigo))
                    {
                        enemigo.Vivo = false;
                        if (enemigo is PersonajeTerrestre)
                        {
                            ((PersonajeTerrestre)enemigo).saltar();
                        }

                    }
                }                
            }
        }
    }
}
