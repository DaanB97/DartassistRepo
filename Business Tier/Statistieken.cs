using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tier
{
    public class Statistieken
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

        public void SaveGemiddelde(string naam, List<Spel> spellen, List<Statistieken> stats)
        {
            // Dit zou je als counter kunnen gebruiken maar zodra er met sets wordt gespeeld doet dit het niet meer
            //int counter = 0;
            //foreach (Legs l in legs)
            //{
            //    counter = counter + l.Stand;
            //}
            foreach (Spel s in spellen)
            {
                if (s.Speler1.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Gemiddelde == 0)
                        {
                            stat.Gemiddelde = s.Speler1.Gemiddelde;
                        }
                        else
                        {
                            stat.Gemiddelde = s.Speler1.Gemiddelde / s.LegCount;
                        }
                    }
                }
                else if (s.Speler2.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.Gemiddelde == 0)
                        {
                            stat.Gemiddelde = s.Speler2.Gemiddelde;
                        }
                        else
                        {
                            stat.Gemiddelde = s.Speler2.Gemiddelde / s.LegCount;
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
        public string SaveEindstand(int check, List<Spel> spellen, List<Sets> sets, List<Legs> legs)
        {
            int p1score = 0;
            int p2score = 0;

            if (check == 1)
            {
                int countsets = 0;
                foreach (Spel s in spellen)
                {
                    foreach (Sets set in sets)
                    {
                        if (s.Speler1.Naam == set.Speler1.Naam)
                        {
                            if (countsets == 0)
                            {
                                p1score = set.SetsStand;
                                countsets++;
                            }
                            else if (countsets == 1)
                            {
                                p2score = set.SetsStand;
                            }
                        }
                        else if (s.Speler2.Naam == set.Speler2.Naam)
                        {
                            if (countsets == 0)
                            {
                                p1score = set.SetsStand;
                                countsets++;
                            }
                            else if (countsets == 1)
                            {
                                p2score = set.SetsStand;
                            }
                        }
                    }
                }
                return p1score + " - " + p2score;
            }
            else if (check == 0)
            {
                int countlegs = 0;
                foreach (Spel s in spellen)
                {
                    foreach (Legs l in legs)
                    {
                        if (s.Speler1.Naam == l.Speler1.Naam)
                        {
                            if (countlegs == 0)
                            {
                                p1score = l.Stand;
                                countlegs++;
                            }
                            else if (countlegs == 1)
                            {
                                p2score = l.Stand;
                            }
                        }
                        else if (s.Speler2.Naam == l.Speler2.Naam)
                        {
                            if (countlegs == 0)
                            {
                                p1score = l.Stand;
                                countlegs++;
                            }
                            else if (countlegs == 1)
                            {
                                p2score = l.Stand;
                            }
                        }
                    }
                }
                return p1score + " - " + p2score;
            }
            return null;
        }

        /// <summary>
        /// Slaat het gemiddelde aantal gegooide Darts per leg op
        /// </summary>
        /// <param name="naam"></param>
        public void SaveDartsPerLeg(string naam, List<Spel> spellen, List<Statistieken> stats)
        {
            // Dit zou je als counter kunnen gebruiken maar zodra er met sets wordt gespeeld doet dit het niet meer
            //int counter = 0;
            //foreach (Legs l in legs)
            //{
            //    counter = counter + l.Stand;
            //}
            foreach (Spel s in spellen)
            {
                if (s.Speler1.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.DartsPerLeg == 0)
                        {
                            stat.DartsPerLeg = s.Speler1.Darts;
                        }
                        else
                        {
                            stat.DartsPerLeg = s.Speler1.Darts / s.LegCount;
                        }
                    }
                }
                else if (s.Speler2.Naam == naam)
                {
                    foreach (Statistieken stat in stats)
                    {
                        if (stat.DartsPerLeg == 0)
                        {
                            stat.DartsPerLeg = s.Speler2.Darts;
                        }
                        else
                        {
                            stat.DartsPerLeg = s.Speler2.Darts / s.LegCount;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
