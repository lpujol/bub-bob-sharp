using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Core;
using System.Drawing;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics;

namespace BubbleBobble.clases.menu
{
    public class OpcionSalir:Opcion
    {
        public OpcionSalir(Point p,Menu m):base(p,m)
        {
            this.imagen = new TextSprite("Salir", new SdlDotNet.Graphics.Font(Resource1.arial,50), Color.White, p);
            this.imagenSobre = new TextSprite("Salir", new SdlDotNet.Graphics.Font(Resource1.arial, 50), Color.Yellow, p);
        }

        public override void ejecutarComando()
        {
            Events.QuitApplication();
        }
    }
}
