using System;
using System.Collections.Generic;
using System.Text;
using BubbleBobble.clases;
using SdlDotNet.Graphics.Sprites;

namespace BubbleBobble.Vista
{
    public class VistaJugador : BubbleBobble.Vista.Ivista
    {
        Jugador jugador;
        Dictionary<string, Sprite> sprites;
        int estadoCamina;
        int estadoMuerto;
        public VistaJugador(Jugador jugador, Dictionary<string,Sprite> sprites)
        {
            this.jugador = jugador;
            this.sprites = sprites;
            estadoCamina = 1;
            estadoMuerto = 1;
        }

        public Sprite getSprite()
        {
            if (jugador.Inmortal && jugador.TranscurridoInmortal % 3 == 0) return null;
            if (jugador.Muerto)
            {
                if (estadoMuerto > 8) estadoMuerto = 1;
                int estadoM = (estadoMuerto + 1) / 2;
                estadoMuerto++;
                return sprites["muerto"+estadoM.ToString()];
            }
            if (jugador.CambiaDir)
            {
                return sprites["frente"];
            }
            if (estadoCamina > 6) estadoCamina = 1;
            if (!jugador.Moviendose) estadoCamina = 1;
            int estadoC = (estadoCamina + 1) / 2;
            estadoCamina++;
            switch (estadoC)
            {
                case 3:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        return sprites["derecha3"];
                    }
                    else
                    {
                        return sprites["izquierda3"];
                    }
                    break;
                case 2:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        return sprites["derecha2"];
                    }
                    else
                    {
                        return sprites["izquierda2"];
                    }
                    break;
                case 1:
                    if (jugador.Direccion == Direccion.derecha)
                    {
                        return sprites["derecha1"];
                    }
                    else
                    {
                        return sprites["izquierda1"];
                    }
                    break;
            }            
            return null;
        }

    }
}
