using System.Drawing;

namespace BubbleBobble.clases
{
    public interface IDibujable
    {
        /// <summary>
        /// Devuelve el alto de el elemento en unidades del juego
        /// </summary>
        /// <returns></returns>
        int getAlto();
        /// <summary>
        /// Devuelve el ancho de el elemento en unidades del juego
        /// </summary>
        /// <returns></returns>
        int getAncho();
        /// <summary>
        /// Devuelve la poscicion del elemento en cordenadas del juego
        /// </summary>
        /// <returns></returns>
        Point getPosicion();
    }
}
