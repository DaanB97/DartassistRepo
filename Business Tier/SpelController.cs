﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Tier
{
    public class SpelController
    {
        private GemiddeldeBerekenen gb = new GemiddeldeBerekenen();
        private Statistieken st = new Statistieken();
        private List<Spel> spellen = new List<Spel>();
        private List<Legs> legs = new List<Legs>();
        private List<Sets> sets = new List<Sets>();
        private List<Statistieken> statistieken = new List<Statistieken>();

        public List<Spel> Spellen { get { return spellen; } set { spellen = value; } }
        public List<Legs> Legs { get { return legs; } set { legs = value; } }
        public List<Sets> Sets { get { return sets; } set { sets = value; } }
        public List<Statistieken> Statistieken { get { return statistieken; } set { statistieken = value; } }


        #region Nieuw spel aanmaken

        /// <summary>
        /// Systeem maakt nieuw spel aan aan de hand van de gegevens die de gebruiker heeft meegegeven.
        /// Indien er een bot is ingesteld wordt het spelerstype hieraan aangepast.
        /// </summary>
        /// <param name="speler1"></param>
        /// <param name="speler2"></param>
        /// <param name="score"></param>
        /// <param name="legsTotaal"></param>
        /// <param name="setsTotaal"></param>
        /// <param name="botGmd"></param>
        /// <returns></returns>
        public bool NieuwSpel(string speler1, string speler2, int score, int legsTotaal, int setsTotaal, int botGmd)
        {
            Speler sp1 = new Speler(SpelerType.Gebruiker, speler1, score, 0, 0, 0,0,0);

            SpelerType st;
            if (speler2 == "Bot")
            {
                st = SpelerType.Bot;
            }
            else
            {
                st = SpelerType.Gebruiker;
            }
            Speler sp2 = new Speler(st, speler2, score, 0, 0, 0,0,0);

            Spel spel = new Spel(sp1, sp2, score, botGmd, false);
            Legs leg = new Legs(sp1, sp2, score, botGmd, false, legsTotaal);
            Sets set = new Sets(sp1, sp2, score, botGmd, false, setsTotaal);
            Statistieken stat1 = new Statistieken(speler1, "", 0, 0, 0, 0, 0, 0, 0, 0);
            Statistieken stat2 = new Statistieken(speler2, "", 0, 0, 0, 0, 0, 0, 0, 0);

            statistieken.Add(stat1);
            statistieken.Add(stat2);
            spellen.Add(spel);
            legs.Add(leg);
            sets.Add(set);
            return true;
        }
        #endregion

        #region Einde spel
        /// <summary>
        /// Is voor vieuwer om na iedere beurt te checken of het spel is afgelopen.
        /// </summary>
        /// <returns></returns>
        public bool CheckEindeSpel()
        {
            bool check = false;
            foreach (Spel s in spellen)
            {
                if (s.Einde == true)
                {
                    check = true;
                    return check;
                }
            }
            return check;
        }

        /// <summary>
        /// Slaat de eindstand op en slaat op wie de winnaar is van het spel
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="i"></param>
        public void EindeSpel(int i)
        {
            // Geeft einstand aan statistieken voor je ze laat zien.
            string eindstand = SaveEindstand(i);
            foreach (Statistieken stat in statistieken)
            {
                stat.Eindstand = eindstand;
            }

            foreach (Spel s in spellen)
            {
                s.Einde = true;
            }
        }
        #endregion

        #region Opslaan statistieken

        /// <summary>
        /// scores checken kijken of ze moeten worden opgeslagen voor statistieken.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void SaveScore(string naam, int score)
        {
            st.SaveScore(naam, score, statistieken);
        }

        /// <summary>
        /// checked wat de hoogste score is en slaat dit op in de lijst.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void SaveUitworp(string naam, int score)
        {
            st.SaveUitworp(naam, score, statistieken);
        }

        /// <summary>
        /// Gemiddelde opslaan bij de juiste speler.
        /// </summary>
        /// <param name="naam"></param>
        public void SaveGemiddelde(string naam)
        {
            st.SaveGemiddelde(naam, spellen, statistieken);
        }

        /// <summary>
        /// Geeft de eindstand terug.
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public string SaveEindstand(int check)
        {
            return st.SaveEindstand(check, spellen);
        }

        /// <summary>
        /// Slaat het gemiddelde aantal gegooide Darts per leg op
        /// </summary>
        /// <param name="naam"></param>
        public void SaveDartsPerLeg(string naam)
        {
            st.SaveDartsPerLeg(naam, spellen, statistieken);
        }
        #endregion

        #region AVG
        /// <summary>
        /// gemiddelde per leg wordt berekend aan de hand van de naam van de speler en de score van de speler.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void GemiddeldePerLeg(string naam, int score)
        {
            gb.BerekenGemiddelde(naam, score, spellen);
        }
        #endregion

        #region Algoritme voor spel
        /// <summary>
        /// Invoer van score en main algoritme van het programma
        /// </summary>
        /// <param name="score"></param>
        /// <param name="naam"></param>
        public void ScoreInvoer(int score, string naam)
        {
            foreach (Spel s in spellen)
            {
                if (naam == s.Speler1.Naam)
                {
                    if (s.Speler1.SpelerType == SpelerType.Bot)
                    {
                        score = BotScore(naam);
                        if (s.Speler1.Score <= s.BotGmd)
                        {
                            score = s.Speler1.Score;
                        }
                    }

                    if (score <= 180)
                    {
                        if (s.Speler1.Score > score)
                        {
                            s.Speler1.Score = s.Speler1.Score - score;
                            s.Speler1.Darts = s.Speler1.Darts + 3;
                            s.Speler1.TurnCount++; // Speler heeft een beurt gehad dus teller telt op voor het berekenen van statistieken.
                            GemiddeldePerLeg(naam, score);
                            SaveGemiddelde(naam); // saved het gemiddelde.
                            SaveDartsPerLeg(naam); // saved het aantal darts dat per leg wordt gebruikt
                            SaveScore(naam, score); // saved scores
                        }
                        else if (s.Speler1.Score == score)
                        {
                            s.Speler1.Darts = s.Speler1.Darts + 3; //pop-up geven waar gebruiker aantal darts in moet geven.
                            s.Speler1.TurnCount++; // Speler heeft een beurt gehad dus teller telt op voor het berekenen van statistieken.
                            GemiddeldePerLeg(naam, score);
                            SaveUitworp(naam, score); // checken of het de hoogste uitworp tot nu toe is.
                            SaveGemiddelde(naam); // saved het gemiddelde.
                            SaveDartsPerLeg(naam); // saved het aantal darts dat per leg wordt gebruikt
                            SaveScore(naam, score); // saved scores

                            foreach (Legs l in legs)
                            {
                                if (l.Speler1.Naam == naam)
                                {
                                    s.Speler1.Legs = s.Speler1.Legs + 1; // Leg is gewonnen wanneer score gelijk is aan worp.
                                    if (s.Speler1.Legs == l.LegsTotaal)
                                    {
                                        Reset(); //Alle spelgegevens terug zetten naar orrigineel.

                                        foreach (Sets set in sets)
                                        {
                                            if (set.SetsTotaal != 0)
                                            {
                                                s.Speler1.Sets = s.Speler1.Sets + 1; // Set is gewonnen

                                                if (s.Speler1.Sets == set.SetsTotaal)
                                                {
                                                    EindeSpel(1); // Einde spel.
                                                }
                                            }
                                            else
                                            {
                                                EindeSpel(0); // Einde spel.
                                            }
                                        }
                                    }
                                    Reset(); //Alle spelgegevens terug zetten naar orrigineel.
                                }
                            }
                        }
                        else
                        {
                            //melding geven, kapot gegooid.
                            throw new CostumException("Kapot gegooid!");
                        }
                    }
                    else
                    {
                        //melding geven 180 is max
                        throw new CostumException("180 is de maximale score!");
                    }
                }
                else if (naam == s.Speler2.Naam)
                {
                    if (s.Speler2.SpelerType == SpelerType.Bot)
                    {
                        score = BotScore(naam);
                        if (s.Speler2.Score <= s.BotGmd)
                        {
                            score = s.Speler2.Score;
                        }
                    }

                    if (score <= 180)
                    {
                        if (s.Speler2.Score > score)
                        {
                            s.Speler2.Score = s.Speler2.Score - score;
                            s.Speler2.Darts = s.Speler2.Darts + 3;
                            s.Speler2.TurnCount++; // Speler heeft een beurt gehad dus teller telt op voor het berekenen van statistieken.
                            GemiddeldePerLeg(naam, score);
                            SaveGemiddelde(naam); // saved het gemiddelde.
                            SaveDartsPerLeg(naam); // saved het aantal darts dat per leg wordt gebruikt
                            SaveScore(naam, score); // saved scores
                        }
                        else if (s.Speler2.Score == score)
                        {
                            s.Speler2.Darts = s.Speler2.Darts + 3; //pop-up geven waar gebruiker aantal darts in moet geven.
                            s.Speler2.TurnCount++; // Speler heeft een beurt gehad dus teller telt op voor het berekenen van statistieken.
                            GemiddeldePerLeg(naam, score);
                            SaveUitworp(naam, score); // checken of het de hoogste uitworp tot nu toe is.
                            SaveGemiddelde(naam); // saved het gemiddelde.
                            SaveDartsPerLeg(naam); // saved het aantal darts dat per leg wordt gebruikt
                            SaveScore(naam, score); // saved scores
                            

                            foreach (Legs l in legs)
                            {
                                if (l.Speler2.Naam == naam)
                                {
                                    s.Speler2.Legs = s.Speler2.Legs + 1; // Leg is gewonnen wanneer score gelijk is aan worp.
                                    if (s.Speler2.Legs == l.LegsTotaal)
                                    {
                                        Reset(); //Alle spelgegevens terug zetten naar orrigineel.

                                        foreach (Sets set in sets)
                                        {
                                            if (set.SetsTotaal != 0)
                                            {
                                                s.Speler2.Sets = s.Speler2.Sets + 1; // Set is gewonnen

                                                if (s.Speler2.Sets == set.SetsTotaal)
                                                {
                                                    EindeSpel(1); // Einde spel.
                                                }
                                            }
                                            else
                                            {
                                                EindeSpel(0); // Einde spel.
                                            }
                                        }
                                    }
                                    Reset(); //Alle spelgegevens terug zetten naar orrigineel.
                                }
                            }
                        }
                        else
                        {
                            //melding geven, kapot gegooid.
                            throw new CostumException("Kapot gegooid!");
                        }
                    }
                    else
                    {
                        //melding geven 180 is max
                        throw new CostumException("180 is de maximale score!");
                    }
                }

            }
        }

        #region Uitworp terug geven

        /// <summary>
        /// Uitworp berekenen
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public string UitworpTonen(string naam)
        {
            int score = 170;
            string uitworp = "";

            foreach (Spel s in spellen)
            {
                if (naam == s.Speler1.Naam)
                {
                    foreach (Spel sp in spellen)
                    {
                        if (sp.Speler1.Naam == s.Speler1.Naam)
                        {
                            if (sp.Speler1.Score <= 170)
                            {
                                score = sp.Speler1.Score;
                                #region uitworpswitch
                                switch (score)
                                {
                                    case 170:
                                        uitworp = "T20 T20 BULL";
                                        break;
                                    case 169:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 168:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 167:
                                        uitworp = "T20 T19 BULL";
                                        break;
                                    case 166:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 165:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 164:
                                        uitworp = "T19 T19 BULL";
                                        break;
                                    case 163:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 162:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 161:
                                        uitworp = "T20 T17 BULL";
                                        break;
                                    case 160:
                                        uitworp = "T20 T20 D20";
                                        break;
                                    case 159:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 158:
                                        uitworp = "T20 T20 D19";
                                        break;
                                    case 157:
                                        uitworp = "T20 T19 D20";
                                        break;
                                    case 156:
                                        uitworp = "T20 T20 D18";
                                        break;
                                    case 155:
                                        uitworp = "T20 T19 D19";
                                        break;
                                    case 154:
                                        uitworp = "T20 T18 D20";
                                        break;
                                    case 153:
                                        uitworp = "T20 T19 D18";
                                        break;
                                    case 152:
                                        uitworp = "T20 T20 D16";
                                        break;
                                    case 151:
                                        uitworp = "T20 T17 D20";
                                        break;
                                    case 150:
                                        uitworp = "T20 T18 D18";
                                        break;
                                    case 149:
                                        uitworp = "T20 T19 D16";
                                        break;
                                    case 148:
                                        uitworp = "T20 T20 D14";
                                        break;
                                    case 147:
                                        uitworp = "T20 T17 D18";
                                        break;
                                    case 146:
                                        uitworp = "T20 T20 D13";
                                        break;
                                    case 145:
                                        uitworp = "T20 T15 D20";
                                        break;
                                    case 144:
                                        uitworp = "T20 T20 D12";
                                        break;
                                    case 143:
                                        uitworp = "T20 T17 D16";
                                        break;
                                    case 142:
                                        uitworp = "T20 T14 D20";
                                        break;
                                    case 141:
                                        uitworp = "T20 T19 D12";
                                        break;
                                    case 140:
                                        uitworp = "T20 T20 D10";
                                        break;
                                    case 139:
                                        uitworp = "T20 T13 D20";
                                        break;
                                    case 138:
                                        uitworp = "T20 T14 D18";
                                        break;
                                    case 137:
                                        uitworp = "T20 T15 D18";
                                        break;
                                    case 136:
                                        uitworp = "T20 T20 D8";
                                        break;
                                    case 135:
                                        uitworp = "T20 T13 D18";
                                        break;
                                    case 134:
                                        uitworp = "T20 T14 D16";
                                        break;
                                    case 133:
                                        uitworp = "T20 T19 D8";
                                        break;
                                    case 132:
                                        uitworp = "T20 T10 D16";
                                        break;
                                    case 131:
                                        uitworp = "T20 T13 D16";
                                        break;
                                    case 130:
                                        uitworp = "T20 T18 D8";
                                        break;
                                    case 129:
                                        uitworp = "T19 T16 D12";
                                        break;
                                    case 128:
                                        uitworp = "T20 T20 D4";
                                        break;
                                    case 127:
                                        uitworp = "T20 T17 D8";
                                        break;
                                    case 126:
                                        uitworp = "T19 T19 D6";
                                        break;
                                    case 125:
                                        uitworp = "25 T20 D20";
                                        break;
                                    case 124:
                                        uitworp = "T14 BULL D16";
                                        break;
                                    case 123:
                                        uitworp = "T19 T10 D18";
                                        break;
                                    case 122:
                                        uitworp = "T18  18 BULL";
                                        break;
                                    case 121:
                                        uitworp = "25 T20 D18";
                                        break;
                                    case 120:
                                        uitworp = "T20 20 D20";
                                        break;
                                    case 119:
                                        uitworp = "19 T20 D20";
                                        break;
                                    case 118:
                                        uitworp = "T20 18 D20";
                                        break;
                                    case 117:
                                        uitworp = "T20 17 D20";
                                        break;
                                    case 116:
                                        uitworp = "T20 16 D20";
                                        break;
                                    case 115:
                                        uitworp = "T20 19 D18";
                                        break;
                                    case 114:
                                        uitworp = "T20 14 D20";
                                        break;
                                    case 113:
                                        uitworp = "T20 13 D20";
                                        break;
                                    case 112:
                                        uitworp = "T20 20 D16";
                                        break;
                                    case 111:
                                        uitworp = "T20 19 D26";
                                        break;
                                    case 110:
                                        uitworp = "T20 18 D26";
                                        break;
                                    case 109:
                                        uitworp = "T20 17 D16";
                                        break;
                                    case 108:
                                        uitworp = "T20 16 D16";
                                        break;
                                    case 107:
                                        uitworp = "T19 18 D16";
                                        break;
                                    case 106:
                                        uitworp = "T20 10 D18";
                                        break;
                                    case 105:
                                        uitworp = "T20 13 D16";
                                        break;
                                    case 104:
                                        uitworp = "T18 18 D16";
                                        break;
                                    case 103:
                                        uitworp = "T19 10 D18";
                                        break;
                                    case 102:
                                        uitworp = "T14 20 D20";
                                        break;
                                    case 101:
                                        uitworp = "T17 18 D16";
                                        break;
                                    case 100:
                                        uitworp = "T20 D20";
                                        break;
                                    case 99:
                                        uitworp = "T19 10 D16";
                                        break;
                                    case 98:
                                        uitworp = "T20 D19";
                                        break;
                                    case 97:
                                        uitworp = "T19 D20";
                                        break;
                                    case 96:
                                        uitworp = "T20 10 D18";
                                        break;
                                    case 95:
                                        uitworp = "T15 BULL";
                                        break;
                                    case 94:
                                        uitworp = "T18 D20";
                                        break;
                                    case 93:
                                        uitworp = "T19 D18";
                                        break;
                                    case 92:
                                        uitworp = "T20 D16";
                                        break;
                                    case 91:
                                        uitworp = "T17 D20";
                                        break;
                                    case 90:
                                        uitworp = "T18 D18";
                                        break;
                                    case 89:
                                        uitworp = "T19 D16";
                                        break;
                                    case 88:
                                        uitworp = "T16 D20";
                                        break;
                                    case 87:
                                        uitworp = "T17 D18";
                                        break;
                                    case 86:
                                        uitworp = "BULL D18";
                                        break;
                                    case 85:
                                        uitworp = "T15 D20";
                                        break;
                                    case 84:
                                        uitworp = "T20 D12";
                                        break;
                                    case 83:
                                        uitworp = "T17 D16";
                                        break;
                                    case 82:
                                        uitworp = "BULL D16";
                                        break;
                                    case 81:
                                        uitworp = "T17 D15";
                                        break;
                                    case 80:
                                        uitworp = "T20 D10";
                                        break;
                                    case 79:
                                        uitworp = "T17 D14";
                                        break;
                                    case 78:
                                        uitworp = "T14 D18";
                                        break;
                                    case 76:
                                        uitworp = "T20 D8";
                                        break;
                                    case 75:
                                        uitworp = "T17 D12";
                                        break;
                                    case 74:
                                        uitworp = "T18 D10";
                                        break;
                                    case 73:
                                        uitworp = "T19 D8";
                                        break;
                                    case 72:
                                        uitworp = "T12 D18";
                                        break;
                                    case 71:
                                        uitworp = "T17 D10";
                                        break;
                                    case 70:
                                        uitworp = "T18 D8";
                                        break;
                                    case 69:
                                        uitworp = "T19 D6";
                                        break;
                                    case 68:
                                        uitworp = "T20 D4";
                                        break;
                                    case 67:
                                        uitworp = "T17 D8";
                                        break;
                                    case 66:
                                        uitworp = "T10 D18";
                                        break;
                                    case 65:
                                        uitworp = "T15 D10";
                                        break;
                                    case 64:
                                        uitworp = "T16 D8";
                                        break;
                                    case 63:
                                        uitworp = "T13 D12";
                                        break;
                                    case 62:
                                        uitworp = "T10 D16";
                                        break;
                                    case 61:
                                        uitworp = "25 D18";
                                        break;
                                    case 60:
                                        uitworp = "20 D20";
                                        break;
                                    case 59:
                                        uitworp = "19 D20";
                                        break;
                                    case 58:
                                        uitworp = "18 D20";
                                        break;
                                    case 57:
                                        uitworp = "17 D20";
                                        break;
                                    case 56:
                                        uitworp = "20 D18";
                                        break;
                                    case 55:
                                        uitworp = "19 D18";
                                        break;
                                    case 54:
                                        uitworp = "18 D18";
                                        break;
                                    case 53:
                                        uitworp = "19 D18";
                                        break;
                                    case 52:
                                        uitworp = "20 D16";
                                        break;
                                    case 51:
                                        uitworp = "19 D16";
                                        break;
                                    case 50:
                                        uitworp = "18 D16";
                                        break;
                                    case 49:
                                        uitworp = "17 D16";
                                        break;
                                    case 48:
                                        uitworp = "16 D16";
                                        break;
                                    case 47:
                                        uitworp = "15 D16";
                                        break;
                                    case 46:
                                        uitworp = "10 D18";
                                        break;
                                    case 45:
                                        uitworp = "13 D16";
                                        break;
                                    case 44:
                                        uitworp = "12 D16";
                                        break;
                                    case 43:
                                        uitworp = "11 D16";
                                        break;
                                    case 42:
                                        uitworp = "10 D16";
                                        break;
                                    case 41:
                                        uitworp = "9 D16";
                                        break;
                                    case 40:
                                        uitworp = "D20";
                                        break;
                                    case 39:
                                        uitworp = "7 D16";
                                        break;
                                    case 38:
                                        uitworp = "D19";
                                        break;
                                    case 37:
                                        uitworp = "5 D16";
                                        break;
                                    case 36:
                                        uitworp = "D18";
                                        break;
                                    case 35:
                                        uitworp = "3 D16";
                                        break;
                                    case 34:
                                        uitworp = "D17";
                                        break;
                                    case 33:
                                        uitworp = "1 D16";
                                        break;
                                    case 32:
                                        uitworp = "D16";
                                        break;
                                    case 31:
                                        uitworp = "7 D12";
                                        break;
                                    case 30:
                                        uitworp = "D15";
                                        break;
                                    case 29:
                                        uitworp = "5 D12";
                                        break;
                                    case 28:
                                        uitworp = "D14";
                                        break;
                                    case 27:
                                        uitworp = "3 D12";
                                        break;
                                    case 26:
                                        uitworp = "D13";
                                        break;
                                    case 25:
                                        uitworp = "1 D12";
                                        break;
                                    case 24:
                                        uitworp = "D12";
                                        break;
                                    case 23:
                                        uitworp = "7 D8";
                                        break;
                                    case 22:
                                        uitworp = "D11";
                                        break;
                                    case 21:
                                        uitworp = "1 D10";
                                        break;
                                    case 20:
                                        uitworp = "D10";
                                        break;
                                    case 19:
                                        uitworp = "3 D8";
                                        break;
                                    case 18:
                                        uitworp = "D9";
                                        break;
                                    case 17:
                                        uitworp = "1 D8";
                                        break;
                                    case 16:
                                        uitworp = "D8";
                                        break;
                                    case 15:
                                        uitworp = "3 D6";
                                        break;
                                    case 14:
                                        uitworp = "D7";
                                        break;
                                    case 13:
                                        uitworp = "1 D6";
                                        break;
                                    case 12:
                                        uitworp = "D6";
                                        break;
                                    case 11:
                                        uitworp = "3 D4";
                                        break;
                                    case 10:
                                        uitworp = "D5";
                                        break;
                                    case 9:
                                        uitworp = "1 D4";
                                        break;
                                    case 8:
                                        uitworp = "D4";
                                        break;
                                    case 7:
                                        uitworp = "3 D2";
                                        break;
                                    case 6:
                                        uitworp = "D3";
                                        break;
                                    case 5:
                                        uitworp = "1 D2";
                                        break;
                                    case 4:
                                        uitworp = "D2";
                                        break;
                                    case 3:
                                        uitworp = "1 D1";
                                        break;
                                    case 2:
                                        uitworp = "D1";
                                        break;
                                    case 1:
                                        uitworp = "Dit mag je nooit te zien krijgen";
                                        break;
                                }
                                #endregion

                            }
                        }
                    }
                }
                else if (naam == s.Speler2.Naam)
                {
                    foreach (Spel sp in spellen)
                    {
                        if (sp.Speler2.Naam == s.Speler2.Naam)
                        {
                            if (sp.Speler2.Score <= 170)
                            {
                                score = sp.Speler2.Score;
                                #region uitworpswitch
                                switch (score)
                                {
                                    case 170:
                                        uitworp = "T20 T20 BULL";
                                        break;
                                    case 169:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 168:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 167:
                                        uitworp = "T20 T19 BULL";
                                        break;
                                    case 166:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 165:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 164:
                                        uitworp = "T19 T19 BULL";
                                        break;
                                    case 163:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 162:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 161:
                                        uitworp = "T20 T17 BULL";
                                        break;
                                    case 160:
                                        uitworp = "T20 T20 D20";
                                        break;
                                    case 159:
                                        uitworp = "Geen uitworp mogelijk";
                                        break;
                                    case 158:
                                        uitworp = "T20 T20 D19";
                                        break;
                                    case 157:
                                        uitworp = "T20 T19 D20";
                                        break;
                                    case 156:
                                        uitworp = "T20 T20 D18";
                                        break;
                                    case 155:
                                        uitworp = "T20 T19 D19";
                                        break;
                                    case 154:
                                        uitworp = "T20 T18 D20";
                                        break;
                                    case 153:
                                        uitworp = "T20 T19 D18";
                                        break;
                                    case 152:
                                        uitworp = "T20 T20 D16";
                                        break;
                                    case 151:
                                        uitworp = "T20 T17 D20";
                                        break;
                                    case 150:
                                        uitworp = "T20 T18 D18";
                                        break;
                                    case 149:
                                        uitworp = "T20 T19 D16";
                                        break;
                                    case 148:
                                        uitworp = "T20 T20 D14";
                                        break;
                                    case 147:
                                        uitworp = "T20 T17 D18";
                                        break;
                                    case 146:
                                        uitworp = "T20 T20 D13";
                                        break;
                                    case 145:
                                        uitworp = "T20 T15 D20";
                                        break;
                                    case 144:
                                        uitworp = "T20 T20 D12";
                                        break;
                                    case 143:
                                        uitworp = "T20 T17 D16";
                                        break;
                                    case 142:
                                        uitworp = "T20 T14 D20";
                                        break;
                                    case 141:
                                        uitworp = "T20 T19 D12";
                                        break;
                                    case 140:
                                        uitworp = "T20 T20 D10";
                                        break;
                                    case 139:
                                        uitworp = "T20 T13 D20";
                                        break;
                                    case 138:
                                        uitworp = "T20 T14 D18";
                                        break;
                                    case 137:
                                        uitworp = "T20 T15 D18";
                                        break;
                                    case 136:
                                        uitworp = "T20 T20 D8";
                                        break;
                                    case 135:
                                        uitworp = "T20 T13 D18";
                                        break;
                                    case 134:
                                        uitworp = "T20 T14 D16";
                                        break;
                                    case 133:
                                        uitworp = "T20 T19 D8";
                                        break;
                                    case 132:
                                        uitworp = "T20 T10 D16";
                                        break;
                                    case 131:
                                        uitworp = "T20 T13 D16";
                                        break;
                                    case 130:
                                        uitworp = "T20 T18 D8";
                                        break;
                                    case 129:
                                        uitworp = "T19 T16 D12";
                                        break;
                                    case 128:
                                        uitworp = "T20 T20 D4";
                                        break;
                                    case 127:
                                        uitworp = "T20 T17 D8";
                                        break;
                                    case 126:
                                        uitworp = "T19 T19 D6";
                                        break;
                                    case 125:
                                        uitworp = "25 T20 D20";
                                        break;
                                    case 124:
                                        uitworp = "T14 BULL D16";
                                        break;
                                    case 123:
                                        uitworp = "T19 T10 D18";
                                        break;
                                    case 122:
                                        uitworp = "T18  18 BULL";
                                        break;
                                    case 121:
                                        uitworp = "25 T20 D18";
                                        break;
                                    case 120:
                                        uitworp = "T20 20 D20";
                                        break;
                                    case 119:
                                        uitworp = "19 T20 D20";
                                        break;
                                    case 118:
                                        uitworp = "T20 18 D20";
                                        break;
                                    case 117:
                                        uitworp = "T20 17 D20";
                                        break;
                                    case 116:
                                        uitworp = "T20 16 D20";
                                        break;
                                    case 115:
                                        uitworp = "T20 19 D18";
                                        break;
                                    case 114:
                                        uitworp = "T20 14 D20";
                                        break;
                                    case 113:
                                        uitworp = "T20 13 D20";
                                        break;
                                    case 112:
                                        uitworp = "T20 20 D16";
                                        break;
                                    case 111:
                                        uitworp = "T20 19 D26";
                                        break;
                                    case 110:
                                        uitworp = "T20 18 D26";
                                        break;
                                    case 109:
                                        uitworp = "T20 17 D16";
                                        break;
                                    case 108:
                                        uitworp = "T20 16 D16";
                                        break;
                                    case 107:
                                        uitworp = "T19 18 D16";
                                        break;
                                    case 106:
                                        uitworp = "T20 10 D18";
                                        break;
                                    case 105:
                                        uitworp = "T20 13 D16";
                                        break;
                                    case 104:
                                        uitworp = "T18 18 D16";
                                        break;
                                    case 103:
                                        uitworp = "T19 10 D18";
                                        break;
                                    case 102:
                                        uitworp = "T14 20 D20";
                                        break;
                                    case 101:
                                        uitworp = "T17 18 D16";
                                        break;
                                    case 100:
                                        uitworp = "T20 D20";
                                        break;
                                    case 99:
                                        uitworp = "T19 10 D16";
                                        break;
                                    case 98:
                                        uitworp = "T20 D19";
                                        break;
                                    case 97:
                                        uitworp = "T19 D20";
                                        break;
                                    case 96:
                                        uitworp = "T20 10 D18";
                                        break;
                                    case 95:
                                        uitworp = "T15 BULL";
                                        break;
                                    case 94:
                                        uitworp = "T18 D20";
                                        break;
                                    case 93:
                                        uitworp = "T19 D18";
                                        break;
                                    case 92:
                                        uitworp = "T20 D16";
                                        break;
                                    case 91:
                                        uitworp = "T17 D20";
                                        break;
                                    case 90:
                                        uitworp = "T18 D18";
                                        break;
                                    case 89:
                                        uitworp = "T19 D16";
                                        break;
                                    case 88:
                                        uitworp = "T16 D20";
                                        break;
                                    case 87:
                                        uitworp = "T17 D18";
                                        break;
                                    case 86:
                                        uitworp = "BULL D18";
                                        break;
                                    case 85:
                                        uitworp = "T15 D20";
                                        break;
                                    case 84:
                                        uitworp = "T20 D12";
                                        break;
                                    case 83:
                                        uitworp = "T17 D16";
                                        break;
                                    case 82:
                                        uitworp = "BULL D16";
                                        break;
                                    case 81:
                                        uitworp = "T17 D15";
                                        break;
                                    case 80:
                                        uitworp = "T20 D10";
                                        break;
                                    case 79:
                                        uitworp = "T17 D14";
                                        break;
                                    case 78:
                                        uitworp = "T14 D18";
                                        break;
                                    case 76:
                                        uitworp = "T20 D8";
                                        break;
                                    case 75:
                                        uitworp = "T17 D12";
                                        break;
                                    case 74:
                                        uitworp = "T18 D10";
                                        break;
                                    case 73:
                                        uitworp = "T19 D8";
                                        break;
                                    case 72:
                                        uitworp = "T12 D18";
                                        break;
                                    case 71:
                                        uitworp = "T17 D10";
                                        break;
                                    case 70:
                                        uitworp = "T18 D8";
                                        break;
                                    case 69:
                                        uitworp = "T19 D6";
                                        break;
                                    case 68:
                                        uitworp = "T20 D4";
                                        break;
                                    case 67:
                                        uitworp = "T17 D8";
                                        break;
                                    case 66:
                                        uitworp = "T10 D18";
                                        break;
                                    case 65:
                                        uitworp = "T15 D10";
                                        break;
                                    case 64:
                                        uitworp = "T16 D8";
                                        break;
                                    case 63:
                                        uitworp = "T13 D12";
                                        break;
                                    case 62:
                                        uitworp = "T10 D16";
                                        break;
                                    case 61:
                                        uitworp = "25 D18";
                                        break;
                                    case 60:
                                        uitworp = "20 D20";
                                        break;
                                    case 59:
                                        uitworp = "19 D20";
                                        break;
                                    case 58:
                                        uitworp = "18 D20";
                                        break;
                                    case 57:
                                        uitworp = "17 D20";
                                        break;
                                    case 56:
                                        uitworp = "20 D18";
                                        break;
                                    case 55:
                                        uitworp = "19 D18";
                                        break;
                                    case 54:
                                        uitworp = "18 D18";
                                        break;
                                    case 53:
                                        uitworp = "19 D18";
                                        break;
                                    case 52:
                                        uitworp = "20 D16";
                                        break;
                                    case 51:
                                        uitworp = "19 D16";
                                        break;
                                    case 50:
                                        uitworp = "18 D16";
                                        break;
                                    case 49:
                                        uitworp = "17 D16";
                                        break;
                                    case 48:
                                        uitworp = "16 D16";
                                        break;
                                    case 47:
                                        uitworp = "15 D16";
                                        break;
                                    case 46:
                                        uitworp = "10 D18";
                                        break;
                                    case 45:
                                        uitworp = "13 D16";
                                        break;
                                    case 44:
                                        uitworp = "12 D16";
                                        break;
                                    case 43:
                                        uitworp = "11 D16";
                                        break;
                                    case 42:
                                        uitworp = "10 D16";
                                        break;
                                    case 41:
                                        uitworp = "9 D16";
                                        break;
                                    case 40:
                                        uitworp = "D20";
                                        break;
                                    case 39:
                                        uitworp = "7 D16";
                                        break;
                                    case 38:
                                        uitworp = "D19";
                                        break;
                                    case 37:
                                        uitworp = "5 D16";
                                        break;
                                    case 36:
                                        uitworp = "D18";
                                        break;
                                    case 35:
                                        uitworp = "3 D16";
                                        break;
                                    case 34:
                                        uitworp = "D17";
                                        break;
                                    case 33:
                                        uitworp = "1 D16";
                                        break;
                                    case 32:
                                        uitworp = "D16";
                                        break;
                                    case 31:
                                        uitworp = "7 D12";
                                        break;
                                    case 30:
                                        uitworp = "D15";
                                        break;
                                    case 29:
                                        uitworp = "5 D12";
                                        break;
                                    case 28:
                                        uitworp = "D14";
                                        break;
                                    case 27:
                                        uitworp = "3 D12";
                                        break;
                                    case 26:
                                        uitworp = "D13";
                                        break;
                                    case 25:
                                        uitworp = "1 D12";
                                        break;
                                    case 24:
                                        uitworp = "D12";
                                        break;
                                    case 23:
                                        uitworp = "7 D8";
                                        break;
                                    case 22:
                                        uitworp = "D11";
                                        break;
                                    case 21:
                                        uitworp = "1 D10";
                                        break;
                                    case 20:
                                        uitworp = "D10";
                                        break;
                                    case 19:
                                        uitworp = "3 D8";
                                        break;
                                    case 18:
                                        uitworp = "D9";
                                        break;
                                    case 17:
                                        uitworp = "1 D8";
                                        break;
                                    case 16:
                                        uitworp = "D8";
                                        break;
                                    case 15:
                                        uitworp = "3 D6";
                                        break;
                                    case 14:
                                        uitworp = "D7";
                                        break;
                                    case 13:
                                        uitworp = "1 D6";
                                        break;
                                    case 12:
                                        uitworp = "D6";
                                        break;
                                    case 11:
                                        uitworp = "3 D4";
                                        break;
                                    case 10:
                                        uitworp = "D5";
                                        break;
                                    case 9:
                                        uitworp = "1 D4";
                                        break;
                                    case 8:
                                        uitworp = "D4";
                                        break;
                                    case 7:
                                        uitworp = "3 D2";
                                        break;
                                    case 6:
                                        uitworp = "D3";
                                        break;
                                    case 5:
                                        uitworp = "1 D2";
                                        break;
                                    case 4:
                                        uitworp = "D2";
                                        break;
                                    case 3:
                                        uitworp = "1 D1";
                                        break;
                                    case 2:
                                        uitworp = "D1";
                                        break;
                                    case 1:
                                        uitworp = "Dit mag je nooit te zien krijgen";
                                        break;
                                }
                                #endregion

                            }
                        }
                    }
                }
            }
            return uitworp;
        }

        #endregion


        /// <summary>
        /// Resetten van belangrijke waarden. (wordt gebruikt aan het einde van een leg)
        /// </summary>
        public void Reset()
        {
            foreach (Spel s in spellen)
            {
                s.Speler1.Score = s.Startscore;
                s.Speler1.Gemiddelde = 0;
                s.Speler1.Darts = 0;
                s.Speler1.Legs = 0;

                s.Speler2.Score = s.Startscore;
                s.Speler2.Gemiddelde = 0;
                s.Speler2.Darts = 0;
                s.Speler2.Legs = 0;
            }
        }
        #endregion

        #region Bot score
        /// <summary>
        /// Berekend een score die de bot gooit aan de hand van het gemiddelde dat is gekozen door de gebruiker.
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public int BotScore(string naam)
        {
            int score = 0;
            foreach (Spel s in spellen)
            {
                if (s.Speler2.Naam == naam)
                {
                    Random rnd = new Random();
                    score = rnd.Next(s.BotGmd - 15, s.BotGmd + 15);
                    return score;
                }
            }
            return score;
        }

        #endregion
    }

}
