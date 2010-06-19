using System;
using System.Collections.Generic;
using System.Text;
using BubbleBobble.clases;
using SdlDotNet.Graphics.Sprites;

namespace BubbleBobble.Vista
{
    public class VistaEnemigoTerrestre:Ivista
    {
        PersonajeTerrestre personaje;
        Dictionary<string, Sprite> sprites;
        int estadoCamina;
        int estadoAtrapado;

        public VistaEnemigoTerrestre(PersonajeTerrestre personaje, Dictionary<string, Sprite> sprites)
        {
            this.personaje = personaje;
            this.sprites = sprites;
            estadoCamina = 1;
            estadoAtrapado = 1;
        }

        public SdlDotNet.Graphics.Sprites.Sprite getSprite()
        {
            if (personaje.Atrapado)
            {
                if (estadoAtrapado > 8) estadoAtrapado = 0;
                int estadoA = (estadoAtrapado + 1) / 2;
                estadoAtrapado++;
                switch (estadoA)
                {
                    case 1:
                        return sprites["encerradomedio"];
                    case 2:
                        return sprites["encerrado1"];
                    case 3:
                        return sprites["encerradomedio"];
                    case 4:
                        return sprites["encerrado2"];
                }
            }
            if (personaje.CambiaDir)
                return sprites["frente"];
            if (estadoCamina > 8) estadoCamina = 1;
            int estadoC = ((estadoCamina + 1) / 2)-1;
            estadoCamina++;
            switch (estadoC)
            {
                case 0:
                    if (personaje.Direccion == Direccion.derecha)
                        return sprites["derecha0"];
                    else
                        return sprites["izquierda0"];
                case 1:
                    if (personaje.Direccion == Direccion.derecha)
                        return sprites["derecha1"];
                    else
                        return sprites["izquierda1"];
                case 2:
                    if (personaje.Direccion == Direccion.derecha)
                        return sprites["derecha2"];
                    else
                        return sprites["izquierda2"];
                case 3:
                    if (personaje.Direccion == Direccion.derecha)
                        return sprites["derecha3"];
                    else
                        return sprites["izquierda3"];
            }
            return null;
        }

    }
}
