using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble
{
    public static class program
    {
        [STAThread]
        public static void Main()
        {
            Juego juego = new Juego();
            juego.Run();
        }
    }
}
