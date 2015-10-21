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

        public Speler(SpelerType spelerType, string naam)
	    {
            this.SpelerType = spelerType;
            this.Naam = naam;
	    }

    }
}
