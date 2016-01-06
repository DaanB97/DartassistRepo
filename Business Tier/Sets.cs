using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Sets : Spel
    {
        public int SetsStand1 { get; set; }
        public int SetsStand2 { get; set; }
        public int SetsTotaal { get; set; }

        public Sets(Speler speler, int startScore, int botGmd, int setsStand1, int setsStand2, int setsTotaal)
            : base(speler, startScore, botGmd)
        {
            this.SetsStand1 = setsStand1;
            this.SetsStand2 = setsStand2;
            this.SetsTotaal = setsTotaal;
        }
    }
}
