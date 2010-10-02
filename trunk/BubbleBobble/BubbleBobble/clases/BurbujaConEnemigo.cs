using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class BurbujaConEnemigo:Burbuja
    {
        IEnemigo enemigo;
        int tiempoTranscurrido;
        int tiempoMaximo;
        public BurbujaConEnemigo(Point posicion, Laberinto laberinto, IEnemigo enemigo)
            : base(posicion, laberinto)
        {
            this.enemigo = enemigo;
            tiempoTranscurrido = 0;
            tiempoMaximo = 300;
            this.puntos = 1000;
        }

        public IEnemigo Enemigo {
            get { return this.enemigo; }
        }

        public IEnemigo liberarEnemigo()
        {
            IEnemigo ene = this.enemigo;
            this.enemigo = null;
            return ene;
        }

        public override void vivir()
        {
            tiempoTranscurrido++;
            if (tiempoTranscurrido > tiempoMaximo)
            {
                laberinto.liberarEnemigo(this);
                tiempoTranscurrido = 0;
            }
            base.vivir();
        }

        public override void pinchar()
        {
            enemigo.Vivo = false;
            if (enemigo is PersonajeTerrestre)
            {
                ((PersonajeTerrestre)enemigo).saltar();
            }

            laberinto.reingresarEnemigo(this.enemigo);
            base.pinchar();
        }

    }
}
