using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Viejita:PersonajeTerrestre,IEnemigo
    {
        static Random r;
        public Viejita(Direccion direccion)
            : base(8, 8, direccion)
        {
            moviendose = true;
            atrapado = false;
            if(Viejita.r==null)
                Viejita.r = new Random(DateTime.Now.Millisecond);
        }

        public Viejita(Point posicion, Direccion direccion)
            : base(8,8,posicion,direccion)
        {
            moviendose = true;
            atrapado = false;
            if (Viejita.r == null)
                Viejita.r = new Random(DateTime.Now.Millisecond);
        }

        public override void vivir()
        {
            int n = Viejita.r.Next(30);
            if (n == 15)
                saltar();
            if (n % 8 == 0)
            {
                cambiarDireccion();
            }
            base.vivir();
            foreach (Jugador jugador in laberinto.Jugadores)
            {
                if (!jugador.Inmortal)
                {
                    if (colisionaCon(jugador))
                        jugador.matar();
                }
                    
            }
        }

        private void cambiarDireccion()
        {
            cambiaDireccion();
            if (this.direccion == Direccion.derecha)
                this.direccion = Direccion.izquierda;
            else
                this.direccion = Direccion.derecha;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return null;
        }
    }
}
