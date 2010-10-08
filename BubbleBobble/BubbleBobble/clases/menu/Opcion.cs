using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics.Sprites;

namespace BubbleBobble.clases
{
    public abstract class Opcion
    {
        private Point posicion;
        protected Menu contenedor;
        protected Sprite imagen;
        protected Sprite imagenSobre;
        public Opcion(Point posicion,Menu contenedor)
        {
            this.posicion = posicion;
            this.contenedor=contenedor;
        }

        public abstract void ejecutarComando();

        public Sprite Imagen
        {
            get { return this.imagen; }
        }

        public Sprite ImagenSobre
        {
            get { return this.imagenSobre; }
        }


    }
}
