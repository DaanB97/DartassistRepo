using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class Legs : Spel
    {
        public int Stand { get; set; }

        public Legs(string speler1, string speler2, int scoreP1, int scoreP2, int stand)
            : base (speler1, speler2, scoreP1, scoreP2)
        {
            this.Stand = stand;
        }
    }
}
