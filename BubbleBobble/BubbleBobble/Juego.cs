using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Core;
using BubbleBobble.clases;
using BubbleBobble.Vista;

namespace BubbleBobble
{

    public class Juego
    {
        Laberinto lab;
        Vista.Vista vista;

        public Juego()
        {
            vista = new Vista.Vista(800, 600);
            lab = new Laberinto();
            Events.Fps = 15;
            Events.Tick+=new EventHandler<TickEventArgs>(Events_Tick);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(Events_KeyboardDown);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(Events_KeyboardUp);
            Events.Quit += new EventHandler<QuitEventArgs>(Events_Quit);
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                lab.jugador.Moviendose = false;
            }
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                lab.jugador.Moviendose = false;
            }
        }

        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.Escape)
                Events.QuitApplication();
            if (e.Key == SdlDotNet.Input.Key.UpArrow)
                lab.jugador.saltar();
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                lab.jugador.Direccion = Direccion.derecha;
                lab.jugador.Moviendose = true;
            }
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                lab.jugador.Direccion = Direccion.izquierda;
                lab.jugador.Moviendose = true;
            }
        }

        public void Run()
        {
            Events.Run();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            lab.jugador.vivir();
            foreach (IEnemigo enemigo in lab.Enemigos)
                enemigo.vivir();
            vista.Dibujar(lab);
        }
        
    }
}
