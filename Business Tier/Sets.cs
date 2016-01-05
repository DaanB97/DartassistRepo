using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class Sets : Spel
    {
        public int SetsStand1 { get; set; }
        public int SetsStand2 { get; set; }
        public int SetsTotaal { get; set; }

        public Sets(string speler1, string speler2, int scoreP1, int scoreP2, int gmd1, int gmd2, int startScore, int setsStand1, int setsStand2, int setsTotaal)
            : base(speler1, speler2, scoreP1, scoreP2, gmd1, gmd2, startScore)
        {
            this.SetsStand1 = setsStand1;
            this.SetsStand2 = setsStand2;
            this.SetsTotaal = setsTotaal;
        }
    }
}
