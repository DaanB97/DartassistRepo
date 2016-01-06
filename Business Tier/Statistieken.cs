using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    class Statistieken
    {
        public string Speler { get; set; }
        public string Eindstand { get; set; }
        public int HoogsteScore { get; set; }
        public int Gemiddelde { get; set; }
        public int DartsPerLeg { get; set; }
        public int Aantal60 { get; set; }
        public int Aantal100 { get; set; }
        public int Aantal140 { get; set; }
        public int Aantal180 { get; set; }
        public int HoogsteFinish { get; set; }

        public Statistieken(string speler, string eindStand, int hoogsteScore, int gemiddelde, int dartsPerLeg, int aantal60, int aantal100, int aantal140, int aantal180, int hoogsteFinish)
        {
            this.Speler = speler;
            this.Eindstand = eindStand;
            this.HoogsteScore = hoogsteScore;
            this.Gemiddelde = gemiddelde;
            this.DartsPerLeg = dartsPerLeg;
            this.Aantal60 = aantal60;
            this.Aantal100 = aantal100;
            this.Aantal140 = aantal140;
            this.Aantal180 = aantal180;
            this.HoogsteFinish = hoogsteFinish;
        }
    }
}
