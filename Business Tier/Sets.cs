using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Sets : Spel
    {
        public int SetsTotaal { get; set; }

        public Sets(Speler speler1, Speler speler2, int startScore, int botGmd, bool einde, int setsTotaal)
            : base(speler1, speler2, startScore, botGmd, einde)
        {
            this.SetsTotaal = setsTotaal;
        }
    }
}
