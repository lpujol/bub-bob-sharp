﻿using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;
using BubbleBobble.clases;
using System.Drawing;

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

        Surface screen;
        Sprite pared;
        Sprite bubc1, bubc2, bubc3;
        Sprite bubc1i, bubc2i, bubc3i;
        Sprite rob0, rob1, rob2, rob3;
        Sprite rob0i, rob1i, rob2i, rob3i;
        int estadoCamina;
        public Vista(int ancho, int alto)
        {
            pared=new Sprite(new Surface(Resource1.pared01));

            #region spritesBub
            estadoCamina = 1;
            bubc1 = new Sprite(new Surface(Resource1.bubc1));
            bubc2 = new Sprite(new Surface(Resource1.bubc2));
            bubc3 = new Sprite(new Surface(Resource1.bubc3));
            bubc1i = new Sprite(new Surface(Resource1.bubc1i));
            bubc2i = new Sprite(new Surface(Resource1.bubc2i));
            bubc3i = new Sprite(new Surface(Resource1.bubc3i));

            bubc1.Transparent = true;
            bubc1.TransparentColor = Color.Magenta;
            bubc2.Transparent = true;
            bubc2.TransparentColor = Color.Magenta;
            bubc3.Transparent = true;
            bubc3.TransparentColor = Color.Magenta;

            bubc1i.Transparent = true;
            bubc1i.TransparentColor = Color.Magenta;
            bubc2i.Transparent = true;
            bubc2i.TransparentColor = Color.Magenta;
            bubc3i.Transparent = true;
            bubc3i.TransparentColor = Color.Magenta;
            #endregion spritesBub

            #region spriteRobotito
            rob0 = new Sprite(new Surface(Resource1.rt0));
            rob0i = new Sprite(new Surface(Resource1.rt0i));
            rob0.Transparent = true;
            rob0.TransparentColor = Color.Magenta;
            rob0i.Transparent = true;
            rob0i.TransparentColor = Color.Magenta;
            rob1 = new Sprite(new Surface(Resource1.rt1));
            rob1i = new Sprite(new Surface(Resource1.rt1i));
            rob1.Transparent = true;
            rob1.TransparentColor = Color.Magenta;
            rob1i.Transparent = true;
            rob1i.TransparentColor = Color.Magenta;
            rob2 = new Sprite(new Surface(Resource1.rt2));
            rob2i = new Sprite(new Surface(Resource1.rt2i));
            rob2.Transparent = true;
            rob2.TransparentColor = Color.Magenta;
            rob2i.Transparent = true;
            rob2i.TransparentColor = Color.Magenta;
            rob3 = new Sprite(new Surface(Resource1.rt3));
            rob3i = new Sprite(new Surface(Resource1.rt3i));
            rob3.Transparent = true;
            rob3.TransparentColor = Color.Magenta;
            rob3i.Transparent = true;
            rob3i.TransparentColor = Color.Magenta;
            #endregion spriteRobotito


            this.alto = alto;
            this.ancho = ancho;
            this.unidad = 10;
            fullscreen = false;
            screen=Video.SetVideoMode(ancho, alto, false, false, fullscreen);
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
            if (estadoCamina > 6) estadoCamina = 1;
            if(!jugador.Moviendose) estadoCamina=1;
            int estadoC = (estadoCamina+1) / 2;
            switch (estadoC)
            {
                case 3:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        bubc3.Position = posicion;
                        screen.Blit(bubc3);
                    }
                    else
                    {
                        bubc3i.Position = posicion;
                        screen.Blit(bubc3i);
                    }
                    break;
                case 2:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        bubc2.Position = posicion;
                        screen.Blit(bubc2);
                    }
                    else
                    {
                        bubc2i.Position = posicion;
                        screen.Blit(bubc2i);
                    }
                    break;
                case 1:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        bubc1.Position = posicion;
                        screen.Blit(bubc1);
                    }
                    else
                    {
                        bubc1i.Position = posicion;
                        screen.Blit(bubc1i);
                    }
                    break;
            }
            estadoCamina++;
        }

        public void Dibujar(Robotito robotito)
        {
            Point posicion = APosicionVisual(new Point(robotito.getPosicion().X, robotito.getPosicion().Y + robotito.getAlto()));
            Sprite paradibujar=null;
            switch (robotito.Estado)
            {
                case 0:
                    if (robotito.Direccion == Direccion.derecha)
                        paradibujar = rob0;
                    else
                        paradibujar = rob0i;
                    break;
                case 1:
                    if (robotito.Direccion == Direccion.derecha)
                        paradibujar = rob1;
                    else
                        paradibujar = rob1i;
                    break;
                case 2:
                    if (robotito.Direccion == Direccion.derecha)
                        paradibujar = rob2;
                    else
                        paradibujar = rob2i;
                    break;
                case 3:
                    if (robotito.Direccion == Direccion.derecha)
                        paradibujar = rob3;
                    else
                        paradibujar = rob3i;
                    break;
            }
            if(paradibujar!=null)
            {
                paradibujar.Position=posicion;
                screen.Blit(paradibujar);
            }
            robotito.Estado++;
            
        }

        public void Dibujar(Pared dibujable)
        {
            Point posicion = APosicionVisual(new Point(dibujable.getPosicion().X, dibujable.getPosicion().Y + dibujable.getAlto()));
            pared.Position = posicion;
            screen.Blit(pared);
        }



        public void Dibujar(Laberinto laberinto)
        {
            Video.Screen.Fill(Color.Black);
            for (int x = 0; x < 64; x+=2)
                for (int y = 0; y < 52; y+=2)
                {
                    if(laberinto.bloqueEn(x,y) is Pared)
                        Dibujar((Pared)laberinto.bloqueEn(x, y));
                }
            foreach (IEnemigo enemigo in laberinto.Enemigos)
            {
                if (enemigo is Robotito)
                    Dibujar((Robotito)enemigo);
            }
            Dibujar(laberinto.jugador);
            Video.Update();
        }

        public Point APosicionVisual(Point p)
        {
            return new Point(8*unidad+p.X * unidad, alto - p.Y * unidad);
        }

    }
}