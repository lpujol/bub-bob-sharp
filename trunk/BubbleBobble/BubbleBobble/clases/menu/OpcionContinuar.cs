using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics.Sprites;

namespace BubbleBobble.clases.menu
{
    public class OpcionContinuar:Opcion
    {
        public OpcionContinuar(Point posicion,Menu contenedor):base(posicion,contenedor)
        {
            this.imagen = new TextSprite("Continuar", new SdlDotNet.Graphics.Font(Resource1.arial, 50), Color.White, posicion);
            this.imagenSobre = new TextSprite("Continuar", new SdlDotNet.Graphics.Font(Resource1.arial, 50), Color.Yellow, posicion);
        }

        public override void ejecutarComando()
        {
            this.contenedor.Juego.pausarJuego();
        }
    }
}
