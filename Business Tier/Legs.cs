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

        public Legs(string speler1, string speler2, int scoreP1, int scoreP2, int stand1, int stand2)
            : base (speler1, speler2, scoreP1, scoreP2)
        {
            this.Stand1 = stand1;
            this.Stand2 = stand2;
        }
    }
}
