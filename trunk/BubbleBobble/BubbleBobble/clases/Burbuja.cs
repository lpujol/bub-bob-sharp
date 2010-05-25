﻿using System;
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
            : base(4, 4, posicion)
        {
            this.laberinto = laberinto;
            estado = EstadoBurbuja.Estable;
        }

        public EstadoBurbuja Estado
        {
            get { return this.estado; }
        }

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
            if (getPosicion().X < 4 || getPosicion().X>60)
            {
                estado = EstadoBurbuja.Rev1;
                return;
            }
            int x=(getPosicion().X/2)*2;
            int y=(getPosicion().Y/2)*2;
            Bloque b1 = laberinto.bloqueEn(x, y);
            Bloque b2 = laberinto.bloqueEn(x + 2, y);
            Bloque b3 = laberinto.bloqueEn(x, y + 2);
            Bloque b4 = laberinto.bloqueEn(x + 2, y + 2);
            //if (b1 is Pared || b2 is Pared || b3 is Pared || b4 is Pared)
            /*{
                estado = EstadoBurbuja.Rev1;
                return;
            }*/
            int arriba = 0;
            int abajo = 0;
            int izquierda = 0;
            int derecha = 0;

            if (b1 is Aire)
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
