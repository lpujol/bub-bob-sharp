namespace BubbleBobble.clases
{
    public interface Ivivo
    {
        /// <summary>
        /// Metodo llamado en cada Tick del programa
        /// </summary>
        void vivir();
        Vista.Ivista Vista
        {
            get;
            set;
        }
    }
}
