using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Sets : Spel
    {
        public int SetsStand { get; set; }
        public int SetsTotaal { get; set; }

        public Sets(Speler speler1, Speler speler2, int startScore, int botGmd, int legCount, bool einde, int setsStand, int setsTotaal)
            : base(speler1, speler2, startScore, botGmd, legCount, einde)
        {
            this.SetsStand = setsStand;
            this.SetsTotaal = setsTotaal;
        }
    }
}
