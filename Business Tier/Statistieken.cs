using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Statistieken
    {
        private int oudescorep1 = 0;
        private int oudescorep2 = 0;

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

        public Statistieken()
        {

        }

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

        #region Statistieken opslaan
        /// <summary>
        /// scores checken kijken of ze moeten worden opgeslagen voor statistieken.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void SaveScore(string naam, int score, List<Statistieken> stats)
        {
            foreach (Statistieken s in stats)
            {
                if (s.Speler == naam)
                {
                    // checken op hoogste score
                    if (s.HoogsteScore < score)
                    {
                        s.HoogsteScore = score;
                    }

                    // checken op wat voor scores het zijn
                    if (score == 180)
                    {
                        s.Aantal180++;
                    }
                    else if (score >= 140)
                    {
                        s.Aantal140++;
                    }
                    else if (score >= 100)
                    {
                        s.Aantal100++;
                    }
                    else if (score >= 60)
                    {
                        s.Aantal60++;
                    }
                }
            }
        }

        /// <summary>
        /// checked wat de hoogste score is en slaat dit op in de lijst.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void SaveUitworp(string naam, int score, List<Statistieken> stats)
        {
            foreach (Statistieken s in stats)
            {
                if (s.Speler == naam)
                {
                    if (s.HoogsteFinish < score)
                    {
                        s.HoogsteFinish = score;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="spellen"></param>
        /// <param name="stats"></param>
        /// <param name="legs"></param>
        /// <param name="sets"></param>
        public void SaveGemiddelde(string naam, List<Spel> spellen, List<Statistieken> stats, List<Legs> legs, List<Sets> sets)
        {
            foreach (Spel s in spellen)
            {
                if (s.Speler1.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Speler == s.Speler1.Naam)
                        {
                            if (stat.Gemiddelde == 0)
                            {
                                stat.Gemiddelde = s.Speler1.Gemiddelde;
                            }
                            else 
                            {
                                stat.Gemiddelde = (stat.Gemiddelde + (oudescorep1 - s.Speler1.Score)) / s.Speler1.TurnCount;
                                oudescorep1 = s.Speler1.Score;
                            }
                        }
                    }
                }
                else if (s.Speler2.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Speler == s.Speler2.Naam)
                        {
                            if (stat.Gemiddelde == 0)
                            {
                                stat.Gemiddelde = s.Speler2.Gemiddelde;
                            }
                            else
                            {
                                stat.Gemiddelde = (stat.Gemiddelde + (oudescorep2 - s.Speler2.Score)) / s.Speler2.TurnCount;
                                oudescorep2 = s.Speler2.Score;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Geeft de eindstand terug.
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public string SaveEindstand(int check, List<Spel> spellen)
        {
                foreach (Spel s in spellen)
                {
                    if (check == 1)
                    {
                        return s.Speler1.Sets + " - " +  s.Speler2.Sets;
                    }
                    if (check == 0)
                    {
                        return s.Speler1.Legs + " - " + s.Speler2.Legs;
                    }
                }
                return null;
        }

        /// <summary>
        /// Slaat het gemiddelde aantal gegooide Darts per leg op
        /// </summary>
        /// <param name="naam"></param>
        public void SaveDartsPerLeg(string naam, List<Spel> spellen, List<Statistieken> stats)
        {
            foreach (Spel s in spellen)
            {
                if (s.Speler1.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Speler == s.Speler1.Naam)
                        {
                            if (stat.DartsPerLeg == 0)
                            {
                                stat.DartsPerLeg = s.Speler1.Darts;
                            }
                            else
                            {
                                stat.DartsPerLeg = (stat.DartsPerLeg + s.Speler1.Darts) / s.Speler1.TurnCount;
                            }
                        }
                    }
                }
                else if (s.Speler2.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Speler == s.Speler2.Naam)
                        {
                            if (stat.DartsPerLeg == 0)
                            {
                                stat.DartsPerLeg = s.Speler2.Darts;
                            }
                            else
                            {
                                stat.DartsPerLeg = (stat.DartsPerLeg + s.Speler2.Darts) / s.Speler2.TurnCount;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
