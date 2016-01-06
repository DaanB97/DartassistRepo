using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class GemiddeldeBerekenen
    {
        private int score1;
        private int counter1 = 2;
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
                        score1 = score;
                    }
                    else
                    {
                        score1 = score1 + score;
                        s.Speler.Gemiddelde = score1 / counter1;
                        counter1++;
                    }
                }

            }
        }
    }
}
