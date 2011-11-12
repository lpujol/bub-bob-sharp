using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class BurbujaDisparadaLejos:BurbujaDisparada
    {
        public BurbujaDisparadaLejos(Point posicion, Direccion direccion, Laberinto laberinto,bool rapida)
            : base(posicion, direccion, laberinto,rapida)
        {
            distanciaMaxima = 70;
        }

    }
}
