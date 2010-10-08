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
        private bool pausa,gameOver;
        Menu menu;

        public Juego()
        {
            vista = new Vista.Vista(800, 600);
            List<string> niveles = new List<string>();
            List<string> eniveles = new List<string>();
            niveles.Add(Resource1.n0001);
            eniveles.Add(Resource1.e0001);
            niveles.Add(Resource1.n0002);
            eniveles.Add(Resource1.e0002);
            niveles.Add(Resource1.n0003);
            niveles.Add(Resource1.n0063);


            lab = new Laberinto(niveles,eniveles);
            controladores = new List<BubbleBobble.Controlador.Controlador>();
            controladores.Add(new BubbleBobble.Controlador.Controlador(lab.Jugadores[0], Key.LeftArrow, Key.UpArrow, Key.RightArrow, Key.Space));
            controladores.Add(new BubbleBobble.Controlador.Controlador(lab.Jugadores[1], Key.A, Key.W, Key.D, Key.LeftShift));
            vista.setBub(lab.Jugadores[0]);
            vista.setBob(lab.Jugadores[1]);
            /*foreach(IEnemigo enemigo in lab.Enemigos)
            {
                if (enemigo is Robotito)
                    vista.setRobotito((Robotito)enemigo);
                if(enemigo is Viejita)
                    vista.setViejita((Viejita)enemigo);
            }*/
            //inicializar eventos
            pausa = true;
            menu = new Menu(this);
            vista.setMenu(menu);

            Events.Fps = 15;
            System.Console.WriteLine(Events.Fps.ToString());
            Events.Tick+=new EventHandler<TickEventArgs>(Events_Tick);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(Events_KeyboardDown);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(Events_KeyboardUp);             
            Events.Quit += new EventHandler<QuitEventArgs>(Events_Quit);
        }

        /// <summary>
        /// Para cuando se cierra la ventana con la X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
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
                pausarJuego();
            if (!pausa)
            {
                foreach (Controlador.Controlador c in controladores)
                {
                    c.keyDown(e.Key);
                    c.keyPress(e.Key);
                }
            }
            else
            {
                if (e.Key == Key.DownArrow)
                    menu.baja();
                if (e.Key == Key.UpArrow)
                    menu.sube();
                if(e.KeyboardCharacter.ToString()=="return")
                    menu.Seleccionada.ejecutarComando();
            }
            
        }

        public void pausarJuego()
        {
            if (pausa)
                pausa = false;
            else
                pausa = true;
        }

        public void Run()
        {
            Events.Run();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            //System.Console.WriteLine(Events.Fps.ToString());
            if (!pausa)
            {
                if (!lab.enTransicion())
                {
                    int sumaVidas = 0;
                    for (int x = 0; x < lab.Jugadores.Count; x++)
                    {
                        sumaVidas += lab.Jugadores[x].Vidas;
                        if(lab.Jugadores[x].Vidas>=0)
                            lab.Jugadores[x].vivir();
                        if (sumaVidas < 0)
                            gameOver = true;
                    }
                }
                for (int x = 0; x < lab.ObjetosDisparados.Count; x++)
                {
                    ObjetoDisparado disparado = lab.ObjetosDisparados[x];
                    try
                    {
                        disparado.vivir();
                    }
                    catch (Exception) { }
                }
                for (int x = 0; x < lab.Burbujas.Count; x++)
                {
                    Burbuja burbuja = lab.Burbujas[x];
                    try
                    {
                        burbuja.vivir();
                    }
                    catch (Exception) { }
                }
                for (int x = 0; x < lab.Enemigos.Count; x++)
                {
                    IEnemigo enemigo = lab.Enemigos[x];
                    try
                    {
                        enemigo.vivir();
                    }
                    catch (Exception) { }
                }
                lab.vivir();
            }   
            vista.Dibujar(lab,pausa);
            //if (pausa)
            //    vista.Dibujar(menu);
            
        }
        
    }
}
