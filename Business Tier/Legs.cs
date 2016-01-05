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

        public Legs(string speler1, string speler2, int scoreP1, int scoreP2, int gmd1, int gmd2, int count1, int count2, int startScore, int stand1, int stand2, int legsTotaal)
            : base (speler1, speler2, scoreP1, scoreP2, gmd1, gmd2, count1, count2, startScore)
        {
            this.Stand1 = stand1;
            this.Stand2 = stand2;
            this.LegsTotaal = legsTotaal;
        }
    }
}
