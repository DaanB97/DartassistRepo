using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class Speler
    {
        public SpelerType SpelerType { get; set; }
        public string Naam { get; set; }
        public int Score { get; set; }
        public int Gemiddelde { get; set; }
        public int Darts { get; set; }


        public Speler(SpelerType spelerType, string naam, int score, int gemiddelde, int darts)
	    {
            this.SpelerType = spelerType;
            this.Naam = naam;
            this.Score = score;
            this.Gemiddelde = gemiddelde;
            this.Darts = darts;
	    }

    }
}
