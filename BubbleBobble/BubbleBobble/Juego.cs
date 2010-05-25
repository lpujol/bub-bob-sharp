using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Core;
using BubbleBobble.clases;
using BubbleBobble.Vista;
using SdlDotNet.Input;

namespace BubbleBobble
{

    public class Juego
    {
        Laberinto lab;
        Vista.Vista vista;
        List<Controlador.Controlador> controladores;

        public Juego()
        {
            vista = new Vista.Vista(800, 600);
            lab = new Laberinto();
            controladores = new List<BubbleBobble.Controlador.Controlador>();
            controladores.Add(new BubbleBobble.Controlador.Controlador(lab.jugador, Key.LeftArrow, Key.UpArrow, Key.RightArrow, Key.Space));
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
            foreach (Controlador.Controlador c in controladores)
                c.keyUp(e.Key);
        }

        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.Escape)
                Events.QuitApplication();
            foreach (Controlador.Controlador c in controladores)
            {
                c.keyDown(e.Key);
                c.keyPress(e.Key);
            }
            
        }

        public void Run()
        {
            Events.Run();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            lab.jugador.vivir();
            for (int x = 0; x < lab.ObjetosDisparados.Count; x++)
            {
                ObjetoDisparado disparado = lab.ObjetosDisparados[x];
                try
                {
                    disparado.vivir();
                }
                catch (Exception ex) {  }
            }
            foreach (IEnemigo enemigo in lab.Enemigos)
                enemigo.vivir();
            vista.Dibujar(lab);
        }
        
    }
}
