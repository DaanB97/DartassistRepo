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
        private int score2;
        private int counter1 = 2;
        private int counter2 = 2;
        public void BerekenGemiddelde()
        {
            
        }


        public void fghjk(string naam, int score, List<Spel> pspellen)
        {
            foreach (Spel s in pspellen)
            {

                if (s.Speler1 == naam)
                {
                    if (s.Gmd1 == 0)
                    {
                        s.Gmd1 = score;
                        score1 = score;
                    }
                    else
                    {
                        score1 = score1 + score;
                        s.Gmd1 = score1 / counter1;
                        counter1++;
                    }
                }
                else if (s.Speler2 == naam)
                {
                    if (s.Gmd2 == 0)
                    {
                        s.Gmd2 = score;
                        score2 = score;
                    }
                    else
                    {
                        score2 = score2 + score;
                        s.Gmd2 = score2 / counter2;
                        counter2++;
                    }
                }
            }
        }
    }
}
