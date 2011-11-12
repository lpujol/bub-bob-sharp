using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public class Laberinto
    {
        Bloque[,] bloques;
        Bloque[,] bloques2;
        private List<Jugador> jugadores;
        private List<IEnemigo> enemigos;
        private List<ObjetoDisparado> objetosDisparados;
        private List<Burbuja> burbujas;
        private List<Fruta> frutas;
        private List<string> niveles;
        private List<string> eniveles;
        private static int alto=104;
        private static int ancho=128;
        public static int TBloque = 4;
        private string pared;
        int transcurridoFinal;
        int indiceNivel;
        bool transicion;
        int indiceTransicion;

        private static Bloque[,] armarBloques(string nivel,out string pared)
        {
            Bloque[,] b = new Bloque[Laberinto.ancho, Laberinto.alto];
            string cadena = nivel;
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

        private static List<IEnemigo> armarEnemigos(string txt)
        {
            List<IEnemigo> enemigos=new List<IEnemigo>();
            int n=txt.IndexOf((char)13);
            while(n>0)
            {
                string leido=txt.Substring(0,n);
                string[] l=leido.Split(new char[]{','});
                string tipo=l[0];
                string dir=l[1];
                int x=int.Parse(l[2]);
                int y=int.Parse(l[3]);
                if (tipo == "Robotito")
                    enemigos.Add(new Robotito(new System.Drawing.Point(x, y), dir == "Izquierda" ? Direccion.izquierda : Direccion.derecha));
                if(tipo=="Viejita")
                    enemigos.Add(new Viejita(new System.Drawing.Point(x,y),dir=="Izquierda"?Direccion.izquierda:Direccion.derecha));
                txt=txt.Substring(n + 2);
                n = txt.IndexOf((char)13);
            }
            
            return enemigos;
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

        public Laberinto(List<string> niveles,List<string> eniveles)
        {
            this.niveles = niveles;
            this.eniveles = eniveles;
            indiceNivel = 0;
            bloques = Laberinto.armarBloques(niveles[indiceNivel++],out this.pared);

            jugadores = new List<Jugador>();
            Jugador jugador = new Bub();
            jugador.Laberinto = this;
            jugadores.Add(jugador);
            jugador = new Bob();
            jugador.Laberinto = this;
            jugadores.Add(jugador);

            /*enemigos = new List<IEnemigo>();            
            Robotito robotito = new Robotito(new System.Drawing.Point(48, 64), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);
            robotito = new Robotito(new System.Drawing.Point(48, 76), Direccion.derecha);
            robotito.Laberinto = this;
            enemigos.Add(robotito);
            Viejita viej = new Viejita(new System.Drawing.Point(48, 84), Direccion.derecha);
            viej.Laberinto = this;
            enemigos.Add(viej);*/
            enemigos = Laberinto.armarEnemigos(eniveles[0]);
            foreach (IEnemigo e in enemigos)
                ((ObjetoVivo)e).Laberinto = this;

            objetosDisparados = new List<ObjetoDisparado>();
            burbujas = new List<Burbuja>();
            frutas = new List<Fruta>();
            transcurridoFinal = 0;
            transicion = false;
            indiceTransicion = 0;
        }

        public string Pared
        {
            get { return this.pared; }
        }

        public List<IEnemigo> Enemigos
        {
            get { return this.enemigos; }
        }

        public List<Fruta> Frutas
        {
            get { return this.frutas; }
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
                    b.pinchar();
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

        public void liberarEnemigo(BurbujaConEnemigo burbujaConEnemigo)
        {
            IEnemigo enemigo = burbujaConEnemigo.liberarEnemigo();
            enemigo.fueLiberado();
            enemigos.Add(enemigo);
            burbujaConEnemigo.pinchar();
        }

        public void reingresarEnemigo(IEnemigo ene)
        {
            ene.fueLiberado();
            enemigos.Add(ene);
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

        internal void convertirEnObjetoConPuntos(PersonajeTerrestre personajeTerrestre)
        {
            enemigos.Remove((IEnemigo)personajeTerrestre);
            frutas.Add(new Cereza(personajeTerrestre.getPosicion()));
        }

        internal void comeFruta(Fruta f)
        {
            frutas.Remove(f);
        }

        public void vivir()
        {
            if (enemigos.Count == 0 && !transicion)
            {
                bool continuar = false;
                foreach (Burbuja b in burbujas)
                    if (b is BurbujaConEnemigo && ((BurbujaConEnemigo)b).Enemigo!=null)
                        continuar = true;
                if (!continuar)
                {
                    transcurridoFinal++;
                    if (transcurridoFinal == 75)
                    {
                        pasarNivel();
                        transcurridoFinal = 0;
                    }
                }
            }
            if (transicion)
            {

                if (indiceTransicion >= getAlto())
                {
                    bloques = Laberinto.armarBloques(niveles[indiceNivel - 1], out pared);
                    transicion = false;
                    foreach (Jugador j in jugadores)
                        j.inicial();
                    if (indiceNivel-1 < eniveles.Count)
                        enemigos = Laberinto.armarEnemigos(eniveles[indiceNivel - 1]);
                    else
                        enemigos = Laberinto.armarEnemigos(eniveles[0]);
                    foreach (IEnemigo e in enemigos)
                        ((ObjetoVivo)e).Laberinto = this;                    

                }
                else
                {
                    foreach (Jugador j in jugadores)
                        j.acercarInicial();
                    for (int nn = 0; nn < 4; nn++)
                    {
                        if (indiceTransicion < getAlto())
                        {
                            for (int y = Laberinto.alto - 1; y > 0; y--)
                            {
                                for (int x = 0; x < getAncho(); x++)
                                {
                                    bloques[x, y] = bloques[x, y - 1];
                                    if (bloques[x, y] != null)
                                        bloques[x, y].setPosicion(new System.Drawing.Point(x, y - 1));
                                }
                            }
                            for (int x = 0; x < getAncho(); x++)
                            {
                                bloques[x, 0] = bloques2[x, Laberinto.alto - indiceTransicion - 1];
                                if (bloques[x, 0] != null) bloques[x, 0].setPosicion(new System.Drawing.Point(x, 0));
                            }
                            indiceTransicion++;
                        }
                    }
                }
            }
        }

        private void pasarNivel()
        {
            if (indiceNivel < niveles.Count)
            {
                transicion = true;
                indiceTransicion = 0;
                frutas = new List<Fruta>();
                burbujas = new List<Burbuja>();
                string n;
                bloques2 = Laberinto.armarBloques(niveles[indiceNivel++], out n);                
            }
        }

        public bool enTransicion()
        {
            return this.transicion;
        }

        public int NumeroNivel
        {
            get { return this.indiceNivel; }
        }

        public Bloque Bloque
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal void eliminarObjetoDisparado(ObjetoDisparado objeto)
        {
            this.objetosDisparados.Remove(objeto);
        }
    }
}
