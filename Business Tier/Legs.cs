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

        public Legs(Speler speler, int startScore, int botGmd, int stand, int legsTotaal)
            : base (speler, startScore, botGmd)
        {
            this.Stand = stand;
            this.LegsTotaal = legsTotaal;
        }
    }
}
