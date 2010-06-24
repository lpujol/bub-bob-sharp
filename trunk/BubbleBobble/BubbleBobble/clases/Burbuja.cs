using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public enum EstadoBurbuja { Estable,Rev1,Rev2 }
    public class Burbuja:ObjetoVivo
    {
        private EstadoBurbuja estado;
        public Burbuja(Point posicion,Laberinto laberinto)
            : base(8, 8, posicion)
        {
            this.laberinto = laberinto;
            estado = EstadoBurbuja.Estable;
        }

        public EstadoBurbuja Estado
        {
            get { return this.estado; }
        }

        public void pinchar()
        {
            this.estado = EstadoBurbuja.Rev1;
        }

        int delay = 2;
        int count = 0;
        public override void vivir()
        {
            if (estado == EstadoBurbuja.Rev2)
            {
                laberinto.reventarBurbuja(this);
                return;
            }
            if (estado == EstadoBurbuja.Rev1)
            {
                estado = EstadoBurbuja.Rev2;
                return;
            }
            if (getPosicion().X < Laberinto.TBloque || getPosicion().X>laberinto.getAncho()-Laberinto.TBloque)
            {
                estado = EstadoBurbuja.Rev1;
                return;
            }
            foreach (Jugador jugador in laberinto.Jugadores)
            {
                if (!jugador.Muerto)
                {
                    if (colisionaCon(jugador))
                    {
                        if (jugador.getPosicion().Y == getPosicion().Y + getAlto())
                        {
                        }
                        else
                        {
                            if (jugador.Direccion == Direccion.derecha)
                            {
                                if (getPosicion().X >= jugador.getPosicion().X + getAncho() - 1)
                                {
                                }
                                else
                                {
                                    estado = EstadoBurbuja.Rev1;
                                    return;
                                }
                            }
                            else
                            {
                                if ((getPosicion().X + getAncho() - 1) <= jugador.getPosicion().X)
                                {
                                }
                                else
                                {
                                    estado = EstadoBurbuja.Rev1;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            //count++;
            //if (count < delay) return;
            //count = 0;

            /*int x=(getPosicion().X/2)*2;
            int y=(getPosicion().Y/2)*2;
            Bloque b1 = laberinto.bloqueEn(x, y);
            Bloque b2 = laberinto.bloqueEn(x + 2, y);
            Bloque b3 = laberinto.bloqueEn(x, y + 2);
            Bloque b4 = laberinto.bloqueEn(x + 2, y + 2);*/
            //if (b1 is Pared || b2 is Pared || b3 is Pared || b4 is Pared)
            /*{
                estado = EstadoBurbuja.Rev1;
                return;
            }*/
            int arriba = 0;
            int abajo = 0;
            int izquierda = 0;
            int derecha = 0;

            /*if (b1 is Aire)
            {
                switch (((Aire)b1).DireccionCorriente)
                {
                    case DireccionCorriente.Arriba:
                        arriba++;
                        break;
                    case DireccionCorriente.Abajo:
                        abajo++;
                        break;
                    case DireccionCorriente.Derecha:
                        derecha++;
                        break;
                    case DireccionCorriente.Izquierda:
                        izquierda++;
                        break;
                }
            }
            if (b2 is Aire)
            {
                switch (((Aire)b2).DireccionCorriente)
                {
                    case DireccionCorriente.Arriba:
                        arriba++;
                        break;
                    case DireccionCorriente.Abajo:
                        abajo++;
                        break;
                    case DireccionCorriente.Derecha:
                        derecha++;
                        break;
                    case DireccionCorriente.Izquierda:
                        izquierda++;
                        break;
                }
            }
            if (b3 is Aire)
            {
                switch (((Aire)b3).DireccionCorriente)
                {
                    case DireccionCorriente.Arriba:
                        arriba++;
                        break;
                    case DireccionCorriente.Abajo:
                        abajo++;
                        break;
                    case DireccionCorriente.Derecha:
                        derecha++;
                        break;
                    case DireccionCorriente.Izquierda:
                        izquierda++;
                        break;
                }
            }
            if (b4 is Aire)
            {
                switch (((Aire)b4).DireccionCorriente)
                {
                    case DireccionCorriente.Arriba:
                        arriba++;
                        break;
                    case DireccionCorriente.Abajo:
                        abajo++;
                        break;
                    case DireccionCorriente.Derecha:
                        derecha++;
                        break;
                    case DireccionCorriente.Izquierda:
                        izquierda++;
                        break;
                }
            }*/
            for (int x = 0; x < getAncho(); x++)
            {
                for (int y = 0; y < getAlto(); y++)
                {
                    Bloque b = laberinto.bloqueEn(getPosicion().X + x, getPosicion().Y + y);
                    if (b is Aire)
                    {
                        switch (((Aire)b).DireccionCorriente)
                        {
                            case DireccionCorriente.Arriba:
                                arriba++;
                                break;
                            case DireccionCorriente.Abajo:
                                abajo++;
                                break;
                            case DireccionCorriente.Derecha:
                                derecha++;
                                break;
                            case DireccionCorriente.Izquierda:
                                izquierda++;
                                break;
                        }
                    }
                }
            }
            int m = mayor(arriba, abajo, izquierda, derecha);
            switch(m)
            {
                case 1:
                    subirUno();
                    break;
                case 2:
                    bajarUno();
                    break;
                case 3:
                    izquierdaUno();
                    break;
                case 4:
                    derechaUno();
                    break;
            }


        }

        int mayor(int a, int b, int c, int d)
        {
            if (a > b)
            {
                if (a > c)
                {
                    if (a > d)
                        return 1;
                    else
                        return 4;
                }
                else
                {
                    if (c > d)
                        return 3;
                    else
                        return 4;
                }
            }
            else
            {
                if (b > c)
                {
                    if (b > d)
                        return 2;
                    else
                        return 4;
                }
                else
                {
                    if (c > d)
                        return 3;
                    else
                        return 4;
                }
            }
        }
    }
}
