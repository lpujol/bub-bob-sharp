﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Jugador:PersonajeTerrestre
    {
        bool muerto;
        int transcurridoMuerto;
        int maximoMuerto;
        int transcurridoInmortal;
        int maximoInmortal;
        bool inmortal;
        int vidas;
        Point posicionInicial;
        int estadoCamina;
        bool cambiaDir;

        public Jugador(Direccion direccion)
            : base(4, 4, direccion)
        {
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;
            vidas = 3;
            estadoCamina = 0;
        }

        public Jugador(Point posicion, Direccion direccion)
            : base(4,4,posicion,direccion)
        {
            posicionInicial = posicion;
            maximoMuerto = 20;
            transcurridoMuerto = 0;
            maximoInmortal = 30;
            transcurridoInmortal = 0;            
            vidas = 3;
            estadoCamina = 0;
            cambiaDir = false;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return new BurbujaDisparada(new Point(getPosicion().X+(this.direccion==Direccion.derecha?2:-2), getPosicion().Y), this.direccion,this.laberinto);
        }

        internal void matar()
        {
            muerto = true;
        }

        public override void vivir()
        {
            if (muerto)
            {
                if (transcurridoMuerto > maximoMuerto)
                {
                    transcurridoMuerto = 0;
                    muerto = false;
                    laberinto.matar(this);
                    vidas--;
                }
                else
                {
                    transcurridoMuerto++;
                }
            }
            else
            {
                if (inmortal)
                {
                    transcurridoInmortal++;
                    if (transcurridoInmortal > maximoInmortal)
                        inmortal = false;
                }
                base.vivir();
            }
        }

        public void sumarVidas()
        {
            vidas++;
        }

        public int Vidas
        {
            get { return this.vidas; }
        }

        public bool Muerto
        {
            get { return this.muerto; }
        }

        public bool Inmortal
        {
            get { return this.inmortal; }
        }

        public int TranscurridoInmortal
        {
            get { return this.transcurridoInmortal; }
        }



        internal void reiniciar()
        {
            this.posicion = posicionInicial;
            this.estado = Estado.caminando;
            this.inmortal = true;
            transcurridoInmortal = 0;
        }

        public override void Disparar()
        {
            if(!muerto)
                base.Disparar();
        }

        public int EstadoCamina
        {
            get { return this.estadoCamina; }
            set {
                if (value > 6)
                    this.estadoCamina = 1;
                else
                    this.estadoCamina = value; 
            }
        }


        internal void cambiaDireccion()
        {
            cambiaDir = true;
        }

        public bool CambiaDir
        {
            get {

                if (!cambiaDir) return false;
                cambiaDir = false;
                return true;
                    
                }           
            
        }
    }
}