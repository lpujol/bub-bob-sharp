using System;
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
        Dictionary<string,Sprite> pared;
        //Sprite bubc1, bubc2, bubc3;
        //Sprite bubc1i, bubc2i, bubc3i;
        Sprite rob0, rob1, rob2, rob3;
        Sprite rob0i, rob1i, rob2i, rob3i;
        Sprite bvd1, bvd2, bvd3, bvd4;
        Sprite renc;
        Sprite bv, bvr1, bvr2;

        //Sprite bvm;
        Dictionary<string, Sprite> bub;
        Dictionary<string, Sprite> bob;
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

            Sprite frente = new Sprite(new Surface(Resource1.bubfte));
            frente.Transparent = true;
            frente.TransparentColor = Color.Magenta;

            bubm1.Transparent = true;
            bubm1.TransparentColor = Color.Magenta;
            bubm2.Transparent = true;
            bubm2.TransparentColor = Color.Magenta;
            bubm3.Transparent = true;
            bubm3.TransparentColor = Color.Magenta;
            bubm4.Transparent = true;
            bubm4.TransparentColor = Color.Magenta;


            /*Sprite bvm = new Sprite(new Surface(Resource1.bubcm));
            bvm.Transparent = true;
            bvm.TransparentColor = Color.Magenta;*/

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

            frente = new Sprite(new Surface(Resource1.bobfte));
            frente.Transparent = true;
            frente.TransparentColor = Color.Magenta;

            bubm1.Transparent = true;
            bubm1.TransparentColor = Color.Magenta;
            bubm2.Transparent = true;
            bubm2.TransparentColor = Color.Magenta;
            bubm3.Transparent = true;
            bubm3.TransparentColor = Color.Magenta;
            bubm4.Transparent = true;
            bubm4.TransparentColor = Color.Magenta;

            /*bvm = new Sprite(new Surface(Resource1.bubcm));
            bvm.Transparent = true;
            bvm.TransparentColor = Color.Magenta;*/

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

            //Resource1.bobc1.
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

            renc = new Sprite(new Surface(Resource1.renc));
            renc.Transparent = true;
            renc.TransparentColor = Color.Magenta;
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
            Sprite dibujar = jugador.Vista.getSprite();
            if (dibujar != null)
            {
                dibujar.Position = posicion;
                screen.Blit(dibujar);
            }
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
                if (robotito.Atrapado)
                    paradibujar = renc;
                paradibujar.Position=posicion;
                screen.Blit(paradibujar);
            }
            robotito.Estado++;
            
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
                    if (enemigo is Robotito)
                    {
                        Robotito r = (Robotito)enemigo;
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
            if (bdisp.DistanciaRecorrida <= 1)
            {
                bvd1.Position = posicion;
                screen.Blit(bvd1);
            }
            else
            {
                if (bdisp.DistanciaRecorrida <= 3)
                {
                    bvd2.Position = posicion;
                    screen.Blit(bvd2);
                }
                else
                {
                    if (bdisp.DistanciaRecorrida <=5)
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



        public void Dibujar(Laberinto laberinto)
        {
            Video.Screen.Fill(Color.Black);
            for (int x = 0; x < 64; x+=2)
                for (int y = 0; y < 52; y+=2)
                {
                    if(laberinto.bloqueEn(x,y) is Pared)
                        Dibujar((Pared)laberinto.bloqueEn(x, y),laberinto.Pared);
                }
            foreach (IEnemigo enemigo in laberinto.Enemigos)
            {
                if (enemigo is Robotito)
                    Dibujar((Robotito)enemigo);
            }
            foreach(Jugador jugador in laberinto.Jugadores)
                Dibujar(jugador);
            foreach (ObjetoDisparado ob in laberinto.ObjetosDisparados)
            {
                if(ob is BurbujaDisparada)
                    Dibujar((BurbujaDisparada)ob);
            }
            foreach (Burbuja b in laberinto.Burbujas)
            {
                Dibujar(b);
            }
            Video.Update();
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
    }
}
