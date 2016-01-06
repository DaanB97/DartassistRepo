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

        /// <summary>
        /// Het onderstaande stuk code berekent het gemiddelde tijdens een Leg zodat het realtime kan worden 
        /// bijgehouden en kan worden getoond.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        /// <param name="pspellen"></param>
        public void BerekenGemiddelde(string naam, int score, List<Spel> pspellen)
        {
            foreach (Spel s in pspellen)
            {
                if (s.Speler1.Naam == naam)
                {
                    if (s.Speler1.Gemiddelde == 0)
                    {
                        s.Speler1.Gemiddelde = score;
                    }
                    else
                    {
                        s.Speler1.Gemiddelde = (s.Startscore - s.Speler1.Score) / (s.Speler1.Darts / 3);
                    }
                }
                if (s.Speler2.Naam == naam)
                {
                    if (s.Speler2.Gemiddelde == 0)
                    {
                        s.Speler2.Gemiddelde = score;
                    }
                    else
                    {
                        s.Speler2.Gemiddelde = (s.Startscore - s.Speler2.Score) / (s.Speler2.Darts / 3);
                    }
                }

            }
        }
    }
}
