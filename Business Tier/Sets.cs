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

        public Sets(Speler speler, int startScore, int botGmd, int setsStand, int setsTotaal)
            : base(speler, startScore, botGmd)
        {
            this.SetsStand = setsStand;
            this.SetsTotaal = setsTotaal;
        }
    }
}
