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
        int vidas;

        public Jugador(Direccion direccion)
            : base(4, 4, direccion)
        {
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            vidas = 3;
        }

        public Jugador(Point posicion, Direccion direccion)
            : base(4,4,posicion,direccion)
        {
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            vidas = 3;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return new BurbujaDisparada(new Point(getPosicion().X+(this.direccion==Direccion.derecha?2:-2), getPosicion().Y), this.direccion,this.laberinto);
        }

        internal void matar()
        {
            muerto = true;
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
            }
            else            
                base.vivir();
        }

        public void sumarVidas()
        {
            vidas++;
        }

        public int Vidas
        {
            get { return this.vidas; }
        }


    }
}
