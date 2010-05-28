using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleBobble.clases
{
    public interface IEnemigo
    {
        int Estado
        {
            get;
            set;
        }

        void vivir();

        void fueAtrapado();

        void fueLiberado();
    }
}
