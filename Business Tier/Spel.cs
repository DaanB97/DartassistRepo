using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Spel
    {
        public Speler Speler { get; set; }
        public int Startscore { get; set; }
        public int BotGmd { get; set; }


        public Spel()
        {

        }
        public Spel(Speler speler, int startscore, int botGmd)
        {
            this.Speler = speler;
            this.Startscore = startscore;
            this.BotGmd = botGmd;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
