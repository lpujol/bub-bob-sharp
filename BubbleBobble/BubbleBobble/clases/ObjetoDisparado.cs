using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public abstract class ObjetoDisparado:ObjetoVivo
    {
        private Direccion direccion;
        public ObjetoDisparado(System.Drawing.Point posicion, Direccion direccion,Laberinto contenedor)
            : base(4, 4, posicion)
        {
            this.direccion = direccion;
            this.laberinto = contenedor;
        }

        public Direccion Direccion
        {
            get { return this.direccion; }            
        }

        public abstract override void vivir();
        
        
    }
}
