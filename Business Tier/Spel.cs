using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Spel
    {
        public Speler Speler1 { get; set; }
        public Speler Speler2 { get; set; }
        public int Startscore { get; set; }
        public int BotGmd { get; set; }
        public int LegCount { get; set; }
        public bool Einde { get; set; }

        public Spel()
        {

        }
        public Spel(Speler speler1, Speler speler2, int startscore, int botGmd, int legCount, bool einde)
        {
            this.Speler1 = speler1;
            this.Speler2 = speler2;
            this.Startscore = startscore;
            this.BotGmd = botGmd;
            this.LegCount = legCount;
            this.Einde = einde;
        }
    }
}
