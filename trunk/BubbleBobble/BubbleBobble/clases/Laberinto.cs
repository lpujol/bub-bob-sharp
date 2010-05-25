using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public class Laberinto
    {
        Bloque[,] bloques;
        public Jugador jugador;
        private List<IEnemigo> enemigos;
        private List<ObjetoDisparado> objetosDisparados;
        private List<Burbuja> burbujas;

        public Laberinto()
        {
            bloques = new Bloque[64, 52];
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 52; y++)
                {
                    if(x==0 ||x==2||x==60|| x==62||y==0 || y==50)
                        bloques[x,y]=new Pared(new System.Drawing.Point(x,y));
                    else
                        bloques[x, y] = new Aire(new System.Drawing.Point(x, y),DireccionCorriente.Arriba);
                }
            }
            bloques[4,10]=new Pared(new System.Drawing.Point(4,10));
            bloques[6,10]=new Pared(new System.Drawing.Point(6,10));
            bloques[4, 20] = new Pared(new System.Drawing.Point(4, 20));
            bloques[6, 20] = new Pared(new System.Drawing.Point(6, 20));
            bloques[4, 30] = new Pared(new System.Drawing.Point(4, 30));
            bloques[6, 30] = new Pared(new System.Drawing.Point(6, 30));

            bloques[56, 10] = new Pared(new System.Drawing.Point(56, 10));
            bloques[58, 10] = new Pared(new System.Drawing.Point(58, 10));
            bloques[56, 20] = new Pared(new System.Drawing.Point(56, 20));
            bloques[58, 20] = new Pared(new System.Drawing.Point(58, 20));
            bloques[56, 30] = new Pared(new System.Drawing.Point(56, 30));
            bloques[58, 30] = new Pared(new System.Drawing.Point(58, 30));

            for (int x = 0; x < 36; x++)
            {
                bloques[x + 14, 10] = new Pared(new System.Drawing.Point(x + 14, 10));
                bloques[x + 14, 20] = new Pared(new System.Drawing.Point(x + 14, 20));
                bloques[x + 14, 30] = new Pared(new System.Drawing.Point(x + 14, 30));
            }
            jugador = new Jugador(new System.Drawing.Point(6, 2),Direccion.derecha);
            Robotito robotito = new Robotito(new System.Drawing.Point(24, 32), Direccion.derecha);
            jugador.Laberinto = this;
            robotito.Laberinto = this;

            enemigos = new List<IEnemigo>();
            enemigos.Add(robotito);
            robotito = new Robotito(new System.Drawing.Point(24, 38), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);

            robotito = new Robotito(new System.Drawing.Point(24, 42), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);

            objetosDisparados = new List<ObjetoDisparado>();
            burbujas = new List<Burbuja>();
        }

        public List<IEnemigo> Enemigos
        {
            get { return this.enemigos; }
        }

        public Bloque bloqueEn(int x, int y)
        {
            return bloques[x, y];
        }

        public bool esOcupableDesdeDerecha(List<System.Drawing.Point> puntos)
        {
            for (int x = 0; x < puntos.Count; x++)
                if (!esOcupableDesdeDerecha(puntos[x])) return false;
            return true;
        }

        private bool esOcupableDesdeDerecha(System.Drawing.Point punto)
        {
            try
            {
                if ((punto.X % 2) != 0) return true;
                if (bloques[punto.X, punto.Y].GetType() != bloques[punto.X + 2, punto.Y].GetType())
                    return false;
                return true;
            }
            catch (Exception) { return false; }
        }

        private bool esOcupableDesdeIzquierda(System.Drawing.Point punto)
        {
            try
            {
                if ((punto.X % 2) != 0) return true;
                if (bloques[punto.X, punto.Y].GetType() != bloques[punto.X - 1, punto.Y].GetType())
                    return false;
                return true;
            }
            catch (Exception) { return false; }
        }

        private bool esOcupableDesdeArriba(System.Drawing.Point punto)
        {
            try
            {
                if ((punto.Y % 2) != 0) return true;
                if (bloques[punto.X, punto.Y] is Aire) return true;
                if (bloques[punto.X, punto.Y].GetType() != bloques[punto.X, punto.Y + 2].GetType())
                    return false;
                return true;
            }
            catch (Exception) { return false; }
        }
        private bool esOcupableDesdeAbajo(System.Drawing.Point punto,Personaje personaje)
        {
            if (personaje is PersonajeTerrestre) return true;
            return false;
        }

        public bool esOcupableDesdeIzquierda(List<System.Drawing.Point> puntos)
        {
            for (int x = 0; x < puntos.Count; x++)
                if (!esOcupableDesdeIzquierda(puntos[x]))
                    return false;
            return true;
        }

        public bool esOcupableDesdeAbajo(List<System.Drawing.Point> puntos)
        {
            return true;
        }

        public bool esOcupableDesdeArriba(List<System.Drawing.Point> puntos)
        {
            for (int x = 0; x < puntos.Count; x++)
                if (!esOcupableDesdeArriba(puntos[x]))
                    return false;
            return true;
        }

        internal void agregarDisparo(ObjetoDisparado objetoDisparado)
        {
            objetosDisparados.Add(objetoDisparado);
        }

        public List<ObjetoDisparado> ObjetosDisparados
        {
            get { return this.objetosDisparados; }
        }

        public List<Burbuja> Burbujas
        {
            get { return this.burbujas; }
        }

        internal void pasarABurbujaRegular(BurbujaDisparada burbujaDisparada)
        {
            objetosDisparados.Remove(burbujaDisparada);
            burbujas.Add(new Burbuja(burbujaDisparada.getPosicion(),this));
        }

        internal void reventarBurbuja(Burbuja burbuja)
        {
            burbujas.Remove(burbuja);
        }
    }
}
