using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BubbleBobble.clases
{
    public class Robotito:PersonajeTerrestre,IEnemigo
    {
        int estadoAnimacion;
        static Random r;
        public Robotito(Direccion direccion)
            : base(4, 4, direccion)
        {
            moviendose = true;
            estadoAnimacion = 0;
            if(Robotito.r==null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public Robotito(Point posicion, Direccion direccion)
            : base(4,4,posicion,direccion)
        {
            moviendose = true;
            estadoAnimacion = 0;
            if (Robotito.r == null)
                Robotito.r = new Random(DateTime.Now.Millisecond);
        }

        public override void vivir()
        {
            int n = Robotito.r.Next(30);
            if (n == 15)
                saltar();
            if (n % 8 == 0)
            {
                cambiarDireccion();
            }
            base.vivir();
        }

        private void cambiarDireccion()
        {
            if (this.direccion == Direccion.derecha)
                this.direccion = Direccion.izquierda;
            else
                this.direccion = Direccion.derecha;
        }

        public override ObjetoDisparado getObjetoDisparado()
        {
            return null;
        }

        #region Miembros de IEnemigo


        public int Estado
        {
            get
            {
                return this.estadoAnimacion;
            }
            set
            {
                this.estadoAnimacion=value;
                if (estadoAnimacion > 3)
                    estadoAnimacion = 0;
            }
        }

        #endregion
    }
}
