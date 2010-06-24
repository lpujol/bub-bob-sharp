using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public class Laberinto
    {
        Bloque[,] bloques;
        private List<Jugador> jugadores;
        private List<IEnemigo> enemigos;
        private List<ObjetoDisparado> objetosDisparados;
        private List<Burbuja> burbujas;
        private static int alto=104;
        private static int ancho=128;
        public static int TBloque = 4;
        private string pared;

        private static Bloque[,] armarBloques(out string pared)
        {
            Bloque[,] b = new Bloque[Laberinto.ancho, Laberinto.alto];
            string cadena = Resource1.n0063;
            int posicion = 0;
            for (int y = Laberinto.alto-Laberinto.TBloque; y >= 0; y -= Laberinto.TBloque)
            {
                for (int x = 0; x < Laberinto.ancho; x += Laberinto.TBloque)
                {
                    while (cadena[posicion] == '\n' || cadena[posicion] == '\r')
                        posicion++;
                    b[x, y] = getBloqueSegunchar(cadena[posicion], new System.Drawing.Point(x, y));
                    if (b[x, y] is Aire)
                    {
                        for (int nnx = 0; nnx < Laberinto.TBloque; nnx++)
                        {
                            for (int nny = 0; nny < Laberinto.TBloque; nny++)
                            {
                                if (nnx == 0 && nny == 0) { }
                                else
                                {
                                    b[x + nnx, y + nny] = b[x, y];
                                }
                            }
                        }
                        //b[x, y + 1] = b[x, y];
                        //b[x + 1, y] = b[x, y];
                        //b[x + 1, y + 1] = b[x, y];
                    }
                    posicion++;                    
                }
            }
            string resto = cadena.Substring(posicion+2);
            pared = resto;
            return b;
        }

        private static Bloque getBloqueSegunchar(char c,System.Drawing.Point posicion)
        {
            switch (c)
            {
                case 'x':
                    return new Pared(posicion);
                case '>':
                    return new Aire(posicion, DireccionCorriente.Derecha);
                case '<':
                    return new Aire(posicion, DireccionCorriente.Izquierda);
                case '^':
                    return new Aire(posicion, DireccionCorriente.Arriba);
                case 'v':
                    return new Aire(posicion, DireccionCorriente.Abajo);
            }
            return new Aire(posicion, DireccionCorriente.Abajo);
        }

        public Laberinto()
        {

            bloques = Laberinto.armarBloques(out this.pared);

            jugadores = new List<Jugador>();
            Jugador jugador = new Bub();
            jugador.Laberinto = this;
            jugadores.Add(jugador);
            jugador = new Bob();
            jugador.Laberinto = this;
            jugadores.Add(jugador);

            enemigos = new List<IEnemigo>();            
            Robotito robotito = new Robotito(new System.Drawing.Point(48, 64), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);
            robotito = new Robotito(new System.Drawing.Point(48, 76), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);
            Viejita viej = new Viejita(new System.Drawing.Point(48, 84), Direccion.derecha);
            viej.Laberinto = this;
            enemigos.Add(viej);

            objetosDisparados = new List<ObjetoDisparado>();
            burbujas = new List<Burbuja>();            
        }

        public string Pared
        {
            get { return this.pared; }
        }

        public List<IEnemigo> Enemigos
        {
            get { return this.enemigos; }
        }

        public Bloque bloqueEn(int x, int y)
        {
            if (y >= 0 && y < Laberinto.alto)
                return bloques[x, y];
            else
                return null;
                //return new Aire(new System.Drawing.Point(x, y), DireccionCorriente.Abajo);
        }

        public Bloque bloqueEnP(int x, int y)
        {
            if (y >= 0 && y < Laberinto.alto - Laberinto.TBloque)
                return bloques[x, y];
            else
                //return null;
                return new Aire(new System.Drawing.Point(x, y), DireccionCorriente.Abajo);
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
                if ((punto.X % Laberinto.TBloque) != 0) return true;
                Bloque b1 = bloqueEn(punto.X, punto.Y);
                Bloque b2 = bloqueEn(punto.X + Laberinto.TBloque, punto.Y);
                if (b1 == null || b2 == null)
                    return true;
                if (b1.GetType() != b2.GetType())
                    return false;
                return true;
            }
            catch (Exception) { return true; }
        }

        private bool esOcupableDesdeIzquierda(System.Drawing.Point punto)
        {
            try
            {
                if ((punto.X % Laberinto.TBloque) != 0) return true;
                Bloque b1 = bloqueEn(punto.X, punto.Y);
                Bloque b2 = bloqueEn(punto.X - Laberinto.TBloque, punto.Y);
                if (b1 == null || b2 == null)
                    return true;
                if (b1.GetType() != b2.GetType())
                    return false;
                return true;
            }
            catch (Exception) { return true; }
        }

        private bool esOcupableDesdeArriba(System.Drawing.Point punto)
        {
            try
            {
                if ((punto.Y % Laberinto.TBloque) != 0) return true;
                if (bloqueEnP(punto.X, punto.Y) is Aire) return true;
                Bloque b1=bloqueEn(punto.X, punto.Y);
                Bloque b2=bloqueEn(punto.X, punto.Y + Laberinto.TBloque);
                if (b1 == null || b2 == null) return true;
                if (b1.GetType() != b2.GetType())
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

        public void pasarABurbujaRegular(BurbujaDisparada burbujaDisparada)
        {
            objetosDisparados.Remove(burbujaDisparada);
            Burbuja burbuja = new Burbuja(burbujaDisparada.getPosicion(), this);
            burbujas.Add(burbuja);            
        }



        public void reventarBurbuja(Burbuja burbuja)
        {
            burbujas.Remove(burbuja);
            foreach (Burbuja b in burbujas)
                if (b.colisionaCon(burbuja))
                    b.Estado = EstadoBurbuja.Rev1;
        }

        internal void burbujaAtrapaEnemigo(BurbujaDisparada burbujaDisparada, IEnemigo enemigo)
        {
            objetosDisparados.Remove(burbujaDisparada);
            enemigo.fueAtrapado();
            Burbuja nueva = new BurbujaConEnemigo(burbujaDisparada.getPosicion(),this, enemigo);
            enemigos.Remove(enemigo);
            burbujas.Add(nueva);
        }

        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }
        }

        internal void matar(Jugador jugador)
        {
            jugador.reiniciar();// setPosicion(new System.Drawing.Point(6, 2));
        }

        internal void liberarEnemigo(BurbujaConEnemigo burbujaConEnemigo)
        {
            IEnemigo enemigo = burbujaConEnemigo.liberarEnemigo();
            enemigo.fueLiberado();
            enemigos.Add(enemigo);
            burbujaConEnemigo.pinchar();
        }

        public int getAlto()
        {
            return Laberinto.alto;
        }

        public int getAncho()
        {
            return Laberinto.ancho;
        }


        public bool hayBurbujaEnPosiciones(List<System.Drawing.Point> puntos)
        {
            foreach (Burbuja burbuja in this.burbujas)
            {
                foreach (System.Drawing.Point p in puntos)
                {
                    if (p.Y == (burbuja.getPosicion().Y + burbuja.getAlto()))
                    {
                        for(int x=0;x<burbuja.getAncho();x++)
                            if(burbuja.getPosicion().X+x==p.X)
                                return true;
                    }
                }
            }
            return false;
        }
    }
}
