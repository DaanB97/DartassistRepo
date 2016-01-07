using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Legs : Spel
    {
        public int LegsTotaal { get; set; }

        public Legs(Speler speler1, Speler speler2, int startScore, int botGmd, bool einde, int legsTotaal)
            : base (speler1, speler2, startScore, botGmd, einde)
        {
            this.LegsTotaal = legsTotaal;
        }
    }
}
