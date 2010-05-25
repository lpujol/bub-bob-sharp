using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Input;
using BubbleBobble.clases;

namespace BubbleBobble.Controlador
{
    public class Controlador
    {
        Key izquierda;
        Key arriba;
        Key derecha;
        Key fuego;

        bool presionadoDerecha;
        bool presionadoIzquierda;

        public Jugador jugador;

        public Controlador(Jugador jugador, Key izquierda, Key arriba, Key derecha, Key fuego)
        {
            this.jugador = jugador;
            this.izquierda = izquierda;
            this.arriba = arriba;
            this.derecha = derecha;
            this.fuego = fuego;
            this.presionadoDerecha = false;
            this.presionadoIzquierda = false;
        }

        public void keyDown(Key key)
        {
            if (key == izquierda)
            {
                presionadoIzquierda = true;
                jugador.Direccion = Direccion.izquierda;
            }
            if (key == derecha)
            {
                presionadoDerecha = true;
                jugador.Direccion = Direccion.derecha;
            }
            if (presionadoDerecha || presionadoIzquierda)
                jugador.Moviendose = true;
        }

        public void keyUp(Key key)
        {
            if (key == derecha)
            {
                presionadoDerecha = false;
                if (presionadoIzquierda)
                    jugador.Direccion = Direccion.izquierda;
            }
            if (key == izquierda)
            {
                presionadoIzquierda = false;
                if (presionadoDerecha)
                    jugador.Direccion = Direccion.derecha;
            }
            if (!presionadoIzquierda && !presionadoDerecha)
                jugador.Moviendose = false;
        }

        public void keyPress(Key key)
        {
            if (key == arriba)
                jugador.saltar();
            if (key == fuego)
                jugador.Disparar();
        }

        public Key Izquierda
        {
            get { return this.izquierda; }
        }

        public Key Derecha
        {
            get { return this.derecha; }
        }

        public Key Arriba
        {
            get { return this.arriba; }
        }

        public Key Fuego
        {
            get { return this.fuego; }
        }
    }
}
