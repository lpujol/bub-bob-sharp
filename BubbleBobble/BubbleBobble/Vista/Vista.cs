﻿using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;
using BubbleBobble.clases;
using System.Drawing;
using SdlDotNet.Particles;
using SdlDotNet.Particles.Emitters;
using SdlDotNet.Particles.Manipulators;


namespace BubbleBobble.Vista
{
    public class Vista
    {
        int alto;
        int ancho;
        int unidad;
        bool fullscreen;
        int margenDerecho;
        int margenIzquierdo;
        SdlDotNet.Graphics.Font fuente;
        Menu menu;

        Surface screen;
        Dictionary<string,Sprite> pared;
        //Sprite bubc1, bubc2, bubc3;
        //Sprite bubc1i, bubc2i, bubc3i;
        Sprite bvd1, bvd2, bvd3, bvd4;
        Sprite bv, bvr1, bvr2;
        Sprite sprcereza;
        Sprite vidaBub,vidaBob;

        //Sprite bvm;
        Dictionary<string, Sprite> bub;
        Dictionary<string, Sprite> bob;
        Dictionary<string, Sprite> robotito;
        Dictionary<string, Sprite> viejita;

        Sprite fireball;

        ParticleSystem particles;
        public Vista(int ancho, int alto)
        {
            pared = new Dictionary<string, Sprite>();
            pared.Add("pared01",new Sprite(new Surface(Resource1.pared01)));
            pared.Add("pared2", new Sprite(new Surface(Resource1.pared2)));
            pared.Add("pared3", new Sprite(new Surface(Resource1.pared3)));
            pared.Add("pared4", new Sprite(new Surface(Resource1.pared4)));
            pared.Add("pared5", new Sprite(new Surface(Resource1.pared5)));

            #region spritesBub
            bub = new Dictionary<string, Sprite>();
            Sprite bubc1 = new Sprite(new Surface(Resource1.bubc1));
            Sprite bubc2 = new Sprite(new Surface(Resource1.bubc2));
            Sprite bubc3 = new Sprite(new Surface(Resource1.bubc3));
            Sprite bubc1i = new Sprite(new Surface(Resource1.bubc1i));
            Sprite bubc2i = new Sprite(new Surface(Resource1.bubc2i));
            Sprite bubc3i = new Sprite(new Surface(Resource1.bubc3i));
            Sprite bubm1 = new Sprite(new Surface(Resource1.bubm1));
            Sprite bubm2 = new Sprite(new Surface(Resource1.bubm2));
            Sprite bubm3 = new Sprite(new Surface(Resource1.bubm3));
            Sprite bubm4 = new Sprite(new Surface(Resource1.bubm4));
            Sprite frente = new Sprite(new Surface(Resource1.bubfte));           
           
            bub.Add("derecha1", bubc1);
            bub.Add("derecha2", bubc2);
            bub.Add("derecha3", bubc3);
            bub.Add("izquierda1", bubc1i);
            bub.Add("izquierda2", bubc2i);
            bub.Add("izquierda3", bubc3i);
            bub.Add("muerto1", bubm1);
            bub.Add("muerto2", bubm2);
            bub.Add("muerto3", bubm3);
            bub.Add("muerto4", bubm4);
            bub.Add("frente", frente);

            foreach (KeyValuePair<string, Sprite> par in bub)
            {
                par.Value.Transparent = true;
                par.Value.TransparentColor = Color.Magenta;
            }

            #endregion spritesBub

            #region spritesBob
            bob = new Dictionary<string, Sprite>();

            bubc1 = new Sprite(new Surface(Resource1.bobc1));
            bubc2 = new Sprite(new Surface(Resource1.bobc2));
            bubc3 = new Sprite(new Surface(Resource1.bobc3));
            bubc1i = new Sprite(new Surface(Resource1.bobc1i));
            bubc2i = new Sprite(new Surface(Resource1.bobc2i));
            bubc3i = new Sprite(new Surface(Resource1.bobc3i));
            bubm1 = new Sprite(new Surface(Resource1.bobm1));
            bubm2 = new Sprite(new Surface(Resource1.bobm2));
            bubm3 = new Sprite(new Surface(Resource1.bobm3));
            bubm4 = new Sprite(new Surface(Resource1.bobm4));
            frente = new Sprite(new Surface(Resource1.bobfte));
            
            bob.Add("derecha1", bubc1);
            bob.Add("derecha2", bubc2);
            bob.Add("derecha3", bubc3);
            bob.Add("izquierda1", bubc1i);
            bob.Add("izquierda2", bubc2i);
            bob.Add("izquierda3", bubc3i);
            bob.Add("muerto1", bubm1);
            bob.Add("muerto2", bubm2);
            bob.Add("muerto3", bubm3);
            bob.Add("muerto4", bubm4);
            bob.Add("frente", frente);

            foreach (KeyValuePair<string, Sprite> par in bob)
            {
                par.Value.Transparent = true;
                par.Value.TransparentColor = Color.Magenta;
            }

            #endregion spritesBob

            #region burbujaVerde
            bvd1 = new Sprite(new Surface(Resource1.bvd1));
            bvd2 = new Sprite(new Surface(Resource1.bvd2));
            bvd3 = new Sprite(new Surface(Resource1.bvd3));
            bvd4 = new Sprite(new Surface(Resource1.bvd4));
            bv = new Sprite(new Surface(Resource1.bv));
            bvr1 = new Sprite(new Surface(Resource1.bvr1));
            bvr2 = new Sprite(new Surface(Resource1.bvr2));

            bvd1.Transparent = true; 
            bvd1.TransparentColor = Color.Magenta;
            bvd2.Transparent = true;
            bvd2.TransparentColor = Color.Magenta;
            bvd3.Transparent = true;           
            bvd3.TransparentColor = Color.Magenta;                        
            bvd4.Transparent = true;
            bvd4.TransparentColor = Color.Magenta;
            bv.Transparent = true;
            bv.TransparentColor = Color.Magenta;
            bvr1.Transparent = true;
            bvr1.TransparentColor = Color.Magenta;
            bvr2.Transparent = true;
            bvr2.TransparentColor = Color.Magenta;
            #endregion burbujaVerde

            #region spriteRobotito
            Sprite rob0 = new Sprite(new Surface(Resource1.rt0));
            Sprite rob0i = new Sprite(new Surface(Resource1.rt0i));
            Sprite rob1 = new Sprite(new Surface(Resource1.rt1));
            Sprite rob1i = new Sprite(new Surface(Resource1.rt1i));
            Sprite rob2 = new Sprite(new Surface(Resource1.rt2));
            Sprite rob2i = new Sprite(new Surface(Resource1.rt2i));
            Sprite rob3 = new Sprite(new Surface(Resource1.rt3));
            Sprite rob3i = new Sprite(new Surface(Resource1.rt3i));            
            Sprite renc = new Sprite(new Surface(Resource1.renc));
            Sprite renc1 = new Sprite(new Surface(Resource1.renc1));
            Sprite renc2 = new Sprite(new Surface(Resource1.renc2));
            Sprite rfrente = new Sprite(new Surface(Resource1.rtf));
            

            robotito = new Dictionary<string, Sprite>();
            robotito.Add("derecha0", rob0);
            robotito.Add("derecha1", rob1);
            robotito.Add("derecha2", rob2);
            robotito.Add("derecha3", rob3);
            robotito.Add("izquierda0", rob0i);
            robotito.Add("izquierda1", rob1i);
            robotito.Add("izquierda2", rob2i);
            robotito.Add("izquierda3", rob3i);
            robotito.Add("encerradomedio", renc);
            robotito.Add("encerrado1", renc1);
            robotito.Add("encerrado2", renc2);
            robotito.Add("frente", rfrente);
            foreach (KeyValuePair<string, Sprite> par in robotito)
            {
                par.Value.Transparent = true;
                par.Value.TransparentColor = Color.Magenta;
            }
            #endregion spriteRobotito

            #region spriteViejita
            Sprite viej0=new Sprite(new Surface(Resource1.vi1));
            Sprite viej1 = new Sprite(new Surface(Resource1.vi2));
            Sprite viej2 = new Sprite(new Surface(Resource1.vi3));
            Sprite viej3 = new Sprite(new Surface(Resource1.vi4));
            Sprite viej0i = new Sprite(new Surface(Resource1.vii1));
            Sprite viej1i = new Sprite(new Surface(Resource1.vii2));
            Sprite viej2i = new Sprite(new Surface(Resource1.vii3));
            Sprite viej3i = new Sprite(new Surface(Resource1.vii4));
            Sprite vieje = new Sprite(new Surface(Resource1.vienc));
            Sprite vieje1 = new Sprite(new Surface(Resource1.vienc1));
            Sprite vieje2 = new Sprite(new Surface(Resource1.vienc2));
            Sprite vif = new Sprite(new Surface(Resource1.vif));

            viejita = new Dictionary<string, Sprite>();
            viejita.Add("derecha0", viej0);
            viejita.Add("derecha1", viej1);
            viejita.Add("derecha2", viej2);
            viejita.Add("derecha3", viej3);
            viejita.Add("izquierda0", viej0i);
            viejita.Add("izquierda1", viej1i);
            viejita.Add("izquierda2", viej2i);
            viejita.Add("izquierda3", viej3i);
            viejita.Add("encerradomedio", vieje);
            viejita.Add("encerrado1", vieje1);
            viejita.Add("encerrado2", vieje2);
            viejita.Add("frente", vif);

            fireball = new Sprite(new Surface(Resource1.fireball));

            foreach(KeyValuePair<string,Sprite> par in viejita)
            {
                par.Value.Transparent = true;
                par.Value.TransparentColor = Color.Magenta;
            }
            #endregion spriteViejita

            particles = new ParticleSystem();

            #region frutas
            sprcereza = new Sprite(new Surface(Resource1.fruta001));
            sprcereza.TransparentColor = Color.Magenta;
            sprcereza.Transparent = true;
            #endregion frutas

            vidaBub = new Sprite(new Surface(Resource1.vidaBub));
            vidaBub.TransparentColor = Color.Magenta;
            vidaBub.Transparent = true;

            vidaBob = new Sprite(new Surface(Resource1.vidaBob));
            vidaBob.TransparentColor = Color.Magenta;
            vidaBob.Transparent = true;

            this.alto = alto;
            this.ancho = ancho;
            this.unidad = 5;
            fullscreen = false;

            screen=Video.SetVideoMode(ancho, alto, false, false, fullscreen);
            Video.WindowCaption = "Re-Bubble Bobble";
            Video.WindowIcon(Resource1.icono);

            fuente = new SdlDotNet.Graphics.Font(Resource1.arial, 20);
            
        }

        public void Dibujar(IDibujable dibujable)
        {
            Point posicion = APosicionVisual(new Point(dibujable.getPosicion().X, dibujable.getPosicion().Y + dibujable.getAlto()));
            Size tam=new Size(dibujable.getAncho() * unidad, dibujable.getAlto() * unidad);
            screen.Fill(new Rectangle(APosicionVisual(new Point(dibujable.getPosicion().X , dibujable.getPosicion().Y+dibujable.getAlto())), new Size(dibujable.getAncho() * unidad, dibujable.getAlto() * unidad)), Color.Red);
        }

        public void Dibujar(Personaje personaje)
        {
            Point posicion = APosicionVisual(new Point(personaje.getPosicion().X, personaje.getPosicion().Y + personaje.getAlto()));
            Size tam = new Size(personaje.getAncho() * unidad, personaje.getAlto() * unidad);
            screen.Fill(new Rectangle(APosicionVisual(new Point(personaje.getPosicion().X, personaje.getPosicion().Y + personaje.getAlto())), new Size(personaje.getAncho() * unidad, personaje.getAlto() * unidad)), Color.Blue);
        }

        public void Dibujar(Jugador jugador)
        {
            Point posicion = APosicionVisual(new Point(jugador.getPosicion().X, jugador.getPosicion().Y + jugador.getAlto()));
            Sprite dibujar = jugador.Vista.getSprite();
            if (dibujar != null)
            {
                dibujar.Position = posicion;
                screen.Blit(dibujar);
            }
            //puntajes, ver esto!
            if (jugador is Bub)
            {
                screen.Blit(new TextSprite(jugador.Puntaje.ToString(),fuente,Color.White,new Point(0,0)));
                dibujarVidasBub(jugador.Vidas);
            }
            if (jugador is Bob)
            {
                screen.Blit(new TextSprite(jugador.Puntaje.ToString(), fuente, Color.White, new Point(ancho-(jugador.Puntaje.ToString().Length)*10-5, 0)));
                dibujarVidasBob(jugador.Vidas);
            }
        }

        private void dibujarVidasBub(int vidas)
        {
            if(vidas>=1)
            {
                vidaBub.Position = new Point(4 * unidad + unidad*4, alto - unidad*4);
                screen.Blit(vidaBub);
            }
            if (vidas >= 2)
            {
                vidaBub.Position = new Point(4 * unidad + unidad*8, alto - unidad*4);
                screen.Blit(vidaBub);
            }
            if (vidas >= 3)
            {
                vidaBub.Position = new Point(4 * unidad + unidad * 12, alto - unidad*4);
                screen.Blit(vidaBub);
            }
            if (vidas >= 4)
            {
                vidaBub.Position = new Point(4 * unidad + unidad * 16, alto - unidad*4);
                screen.Blit(vidaBub);
            }
            if (vidas >= 5)
            {
                vidaBub.Position = new Point(4 * unidad + unidad * 24, alto - unidad*4);
                screen.Blit(vidaBub);
            }
        }

        private void dibujarVidasBob(int vidas)
        {
            if (vidas >= 1)
            {
                vidaBob.Position = new Point(ancho -(unidad*24+ unidad * 4), alto - unidad * 4);
                screen.Blit(vidaBob);
            }
            if (vidas >= 2)
            {
                vidaBob.Position = new Point(ancho  -(unidad*24+ unidad * 8), alto - unidad * 4);
                screen.Blit(vidaBob);
            }
            if (vidas >= 3)
            {
                vidaBob.Position = new Point(ancho  - (unidad*24+ unidad * 12), alto - unidad * 4);
                screen.Blit(vidaBob);
            }
            if (vidas >= 4)
            {
                vidaBob.Position = new Point(ancho  - (unidad*24+ unidad * 16), alto - unidad * 4);
                screen.Blit(vidaBob);
            }
            if (vidas >= 5)
            {
                vidaBob.Position = new Point(ancho  - (unidad*24+ unidad * 24), alto - unidad * 4);
                screen.Blit(vidaBob);
            }
        }

        public void Dibujar(Robotito robotito)
        {
            Point posicion = APosicionVisual(new Point(robotito.getPosicion().X, robotito.getPosicion().Y + robotito.getAlto()));
            Sprite paradibujar = robotito.Vista.getSprite();            
            if(paradibujar!=null)
            {
                paradibujar.Position=posicion;
                screen.Blit(paradibujar);
            }
        }

        public void Dibujar(PersonajeTerrestre personaje)
        {
            Point posicion = APosicionVisual(new Point(personaje.getPosicion().X, personaje.getPosicion().Y + personaje.getAlto()));
            if (personaje.Vista == null)
            {
                if (personaje is Robotito)
                    setRobotito((Robotito)personaje);
                if (personaje is Viejita)
                    setViejita((Viejita)personaje);

            }
            Sprite paradibujar = personaje.Vista.getSprite();
            if (paradibujar != null)
            {
                paradibujar.Position = posicion;
                screen.Blit(paradibujar);
            }
        }

        public void Dibujar(Pared dibujable,string cual)
        {
            Point posicion = APosicionVisual(new Point(dibujable.getPosicion().X, dibujable.getPosicion().Y + dibujable.getAlto()));
            pared[cual].Position = posicion;
            screen.Blit(pared[cual]);
        }

        public void Dibujar(Burbuja burbuja)
        {
            Point posicion = APosicionVisual(new Point(burbuja.getPosicion().X, burbuja.getPosicion().Y + burbuja.getAlto()));
            if (burbuja.Estado == EstadoBurbuja.Estable)
            {
                if (burbuja is BurbujaConEnemigo)
                {
                    IEnemigo enemigo = ((BurbujaConEnemigo)burbuja).Enemigo;
                    if (enemigo is PersonajeTerrestre)
                    {
                        PersonajeTerrestre r = (PersonajeTerrestre)enemigo;
                        r.setPosicion(burbuja.getPosicion());
                        Dibujar(r);
                    }
                }
                bv.Position = posicion;
                screen.Blit(bv);
            }
            else
            {
                if (burbuja.Estado == EstadoBurbuja.Rev1)
                {
                    bvr1.Position = posicion;
                    screen.Blit(bvr1);
                    ParticleCircleEmitter explosion = new ParticleCircleEmitter(particles, Color.Green, Color.YellowGreen, 1, 2);
                    explosion.X = posicion.X+burbuja.getAncho()/2; // donde explotará
                    explosion.Y = posicion.Y+burbuja.getAlto()/2;
                    explosion.Life = 5;
                    explosion.Frequency = 10000;
                    explosion.LifeMin = 3;
                    explosion.LifeMax = 7;
                    explosion.LifeFullMin = 5;
                    explosion.LifeFullMax = 5;
                    explosion.SpeedMin = 8;
                    explosion.SpeedMax = 20;
                }
                else
                {
                    bvr2.Position = posicion;
                    screen.Blit(bvr2);
                }
            }
        }

        public void Dibujar(BurbujaDisparada bdisp)
        {
            Point posicion=APosicionVisual(new Point(bdisp.getPosicion().X,bdisp.getPosicion().Y+bdisp.getAlto()));
            if (bdisp.DistanciaRecorrida <= 2)
            {
                bvd1.Position = posicion;
                screen.Blit(bvd1);
            }
            else
            {
                if (bdisp.DistanciaRecorrida <= 6)
                {
                    bvd2.Position = posicion;
                    screen.Blit(bvd2);
                }
                else
                {
                    if (bdisp.DistanciaRecorrida <=10)
                    {
                        bvd3.Position = posicion;
                        screen.Blit(bvd3);
                    }
                    else
                    {
                        bvd4.Position = posicion;
                        screen.Blit(bvd4);
                    }
                }
            }
        }



        public void Dibujar(Laberinto laberinto,bool pausa)
        {
            Video.Screen.Fill(Color.Black);
            for (int x = 0; x < laberinto.getAncho(); x+=Laberinto.TBloque)
                for (int y = 0; y < laberinto.getAlto(); y+=Laberinto.TBloque)
                {
                    if(laberinto.bloqueEn(x,y) is Pared)
                        Dibujar((Pared)laberinto.bloqueEn(x, y),laberinto.Pared);
                }
            if(!laberinto.enTransicion())
                screen.Blit(new TextSprite("Nivel "+laberinto.NumeroNivel.ToString(), fuente, Color.White, new Point(ancho / 2 - 50, alto - (laberinto.getAlto()+5) * unidad)));
            foreach (IEnemigo enemigo in laberinto.Enemigos)
            {
                if (enemigo is PersonajeTerrestre)
                    Dibujar((PersonajeTerrestre)enemigo);
            }
            foreach (Jugador jugador in laberinto.Jugadores)
            {
                if(jugador.Vidas>=0)
                    Dibujar(jugador);
            }
            foreach (ObjetoDisparado ob in laberinto.ObjetosDisparados)
            {
                Dibujar(ob);                
            }
            foreach (Burbuja b in laberinto.Burbujas)
            {
                Dibujar(b);
            }
            foreach (Fruta fruta in laberinto.Frutas)
            {
                if (fruta is Cereza)
                    Dibujar((Cereza)fruta);
                else
                    Dibujar(fruta);
            }
            if (pausa)
            {
                Rectangle rect = new Rectangle(0, 0, screen.Width, screen.Height);
                Surface srf = new Surface(rect);
                srf.Fill(Color.Black);
                srf.Alpha = 128;
                srf.AlphaBlending = true;
                screen.Blit(srf);
                Dibujar(menu);
            }
            particles.Update();
            particles.Render(Video.Screen);
            Video.Update();
        }

        private void Dibujar(ObjetoDisparado objeto)
        {
            if (objeto is BurbujaDisparada)
            {
                Dibujar((BurbujaDisparada)objeto);
                return;
            }
            if (objeto is BolaDeFuego)
            {
                Dibujar((BolaDeFuego)objeto);
                return;
            }
            else
                Dibujar(objeto);
        }

        private void Dibujar(BolaDeFuego dibujable)
        {
            Point posicion = APosicionVisual(new Point(dibujable.getPosicion().X, dibujable.getPosicion().Y + dibujable.getAlto()));
            fireball.Position = posicion;
            screen.Blit(fireball);
        }

        public Point APosicionVisual(Point p)
        {
            return new Point(8*unidad+p.X * unidad, alto - p.Y * unidad);
        }


        internal void setBub(Jugador jugador)
        {
            jugador.Vista = new VistaJugador(jugador, bub);
        }

        internal void setBob(Jugador jugador)
        {
            jugador.Vista = new VistaJugador(jugador, bob);
        }

        public void setRobotito(Robotito robotito)
        {
            robotito.Vista = new VistaEnemigoTerrestre(robotito, this.robotito);
        }

        public void setViejita(Viejita viejita)
        {
            viejita.Vista = new VistaEnemigoTerrestre(viejita, this.viejita);
        }

        public void Dibujar(Cereza dibujable)
        {
            Point posicion = APosicionVisual(new Point(dibujable.getPosicion().X, dibujable.getPosicion().Y + dibujable.getAlto()));
            sprcereza.Position = posicion;
            screen.Blit(sprcereza);
        }

        internal void dibujarMenu()
        {
            
            Video.Update();
        }

        internal void Dibujar(Menu menu)
        {
            foreach (Opcion opc in menu.Opciones)
            {
                if (opc == menu.Seleccionada)
                    screen.Blit(opc.ImagenSobre);
                else
                    screen.Blit(opc.Imagen);
            }
            Video.Update();
        }

        internal void setMenu(Menu menu)
        {
            this.menu = menu;
        }
    }
}
