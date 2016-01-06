using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Legs : Spel
    {
        public int Stand1 { get; set; }
        public int Stand2 { get; set; }
        public int LegsTotaal { get; set; }

        public Legs(Speler speler, int startScore, int botGmd, int stand1, int stand2, int legsTotaal)
            : base (speler, startScore, botGmd)
        {
            this.Stand1 = stand1;
            this.Stand2 = stand2;
            this.LegsTotaal = legsTotaal;
        }
    }
}
