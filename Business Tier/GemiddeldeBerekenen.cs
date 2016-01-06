using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class GemiddeldeBerekenen
    {
        public void BerekenGemiddelde()
        {
            
        }


        public void BerekenGemiddelde(string naam, int score, List<Spel> pspellen)
        {
            foreach (Spel s in pspellen)
            {
                if (s.Speler.Naam == naam)
                {
                    if (s.Speler.Gemiddelde == 0)
                    {
                        s.Speler.Gemiddelde = score;
                    }
                    else
                    {
                        s.Speler.Gemiddelde = (s.Startscore - s.Speler.Score) / (s.Speler.Darts / 3);
                    }
                }

            }
        }
    }
}
