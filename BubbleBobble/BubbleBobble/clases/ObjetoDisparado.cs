using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public abstract class ObjetoDisparado:ObjetoVivo
    {
        private Direccion direccion;
        private int velocidad;
        public ObjetoDisparado(System.Drawing.Point posicion, Direccion direccion,Laberinto contenedor,int velocidad)
            : base(8, 8, posicion)
        {
            this.direccion = direccion;
            this.laberinto = contenedor;
            this.velocidad = velocidad;
        }

        public Direccion Direccion
        {
            get { return this.direccion; }            
        }

        public int Velocidad
        {
            get { return this.velocidad; }
        }


        public abstract override void vivir();
        
        
    }
}
