using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Legs : Spel
    {
        public int Stand { get; set; }
        public int LegsTotaal { get; set; }

        public Legs(Speler speler1, Speler speler2, int startScore, int botGmd, int legCount, bool einde, int stand, int legsTotaal)
            : base (speler1, speler2, startScore, botGmd, legCount, einde)
        {
            this.Stand = stand;
            this.LegsTotaal = legsTotaal;
        }
    }
}
