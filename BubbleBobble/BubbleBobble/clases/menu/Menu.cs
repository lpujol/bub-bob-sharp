using System;
using System.Collections.Generic;
using System.Text;
using BubbleBobble.clases.menu;

namespace BubbleBobble.clases
{
    public class Menu
    {
        List<Opcion> opciones;
        Opcion seleccionada;
        Juego juego;
        public Menu(Juego juego)
        {
            this.juego = juego;
            opciones = new List<Opcion>();
            opciones.Add(new OpcionContinuar(new System.Drawing.Point(50, 50), this));
            opciones.Add(new OpcionSalir(new System.Drawing.Point(50, 120), this));

        }

        public List<Opcion> Opciones
        {
            get { return this.opciones; }
        }

        public Opcion Seleccionada
        {
            get { return this.seleccionada; }
        }

        public void baja()
        {
            if (seleccionada == null)
            {
                seleccionada = opciones[0];
            }
            else
            {
                int n = opciones.IndexOf(seleccionada);
                if (n < opciones.Count - 1)
                    seleccionada = opciones[n + 1];
                else
                    seleccionada = opciones[0];
            }
        }

        public void sube()
        {
            if (seleccionada == null)
            {
                seleccionada = opciones[opciones.Count - 1];
            }
            else
            {
                int n = opciones.IndexOf(seleccionada);
                if (n > 0)
                    seleccionada = opciones[n - 1];
                else
                    seleccionada = opciones[opciones.Count - 1];
            }
        }

        public Juego Juego{
            get { return this.juego; }
        }


    }
}
