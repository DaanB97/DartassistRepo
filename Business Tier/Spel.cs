using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Spel
    {
        public string Speler1 { get; set; }
        public string Speler2 { get; set; }
        public int Scorep1 { get; set; }
        public int Scorep2 { get; set; }
        public int Gmd1 { get; set; }
        public int Gmd2 { get; set; }

        public Spel()
        {

        }
        public Spel(string speler1, string speler2, int scoreP1, int scoreP2, int gmd1, int gmd2)
        {
            this.Speler1 = speler1;
            this.Speler2 = speler2;
            this.Scorep1 = scoreP1;
            this.Scorep2 = scoreP2;
            this.Gmd1 = gmd1;
            this.Gmd2 = gmd2;
        }

        public override string ToString()
        {
            return Speler1 + Speler2 + Scorep1 + Scorep2;
        }
    }
}
