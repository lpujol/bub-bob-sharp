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
        bool presionadoArriba;

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
            this.presionadoArriba = false;
        }

        public void keyDown(Key key)
        {
            if (key == izquierda)
            {
                presionadoIzquierda = true;
                if (jugador.Direccion == Direccion.derecha)
                    jugador.cambiaDireccion();
                jugador.Direccion = Direccion.izquierda;
            }
            if (key == derecha)
            {
                presionadoDerecha = true;
                if (jugador.Direccion == Direccion.izquierda)
                    jugador.cambiaDireccion();
                jugador.Direccion = Direccion.derecha;
            }
            if (key == arriba)
            {
                jugador.saltoLatente();
                presionadoArriba = true;
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
            if (key == arriba)
            {
                jugador.liberaSaltoLatente();
                presionadoArriba = false;
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
