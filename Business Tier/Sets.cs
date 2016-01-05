using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class Sets : Spel
    {
        public int Setstand { get; set; }
        public int Legstand { get; set; }

        public Sets(string speler1, string speler2, int scoreP1, int scoreP2, int gmd1, int gmd2, int startScore, int setStand, int legStand)
            : base(speler1, speler2, scoreP1, scoreP2, gmd1, gmd2, startScore)
        {
            this.Legstand = legStand;
            this.Setstand = setStand;
        }
    }
}
