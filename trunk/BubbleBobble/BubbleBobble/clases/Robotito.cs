using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Robotito:PersonajeTerrestre,IEnemigo
    {
        static Random r;
        public Robotito(Direccion direccion)
            : base(8, 8, direccion)
        {
            moviendose = true;
            atrapado = false;
            if(Robotito.r==null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public Robotito(Point posicion, Direccion direccion)
            : base(8,8,posicion,direccion)
        {
            moviendose = true;
            atrapado = false;
            if (Robotito.r == null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public override void vivir()
        {
            int n = Robotito.r.Next(30);
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
