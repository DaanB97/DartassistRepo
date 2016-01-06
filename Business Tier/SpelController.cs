﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Tier
{
    public class SpelController
    {
        private int counter1 = 2;
        private int counter2 = 2;
        private int avgcounter1 = 2;
        private int avgcounter2 = 2;
        private int score1;
        private int score2;

        public List<Spel> spellen = new List<Spel>();
        public List<Legs> legs = new List<Legs>();
        public List<Sets> sets = new List<Sets>();
        public List<Statistieken> statistieken = new List<Statistieken>();
        public bool NieuwSpel(string speler1, string speler2, int score1, int score2, int startScore, int legsTotaal, int setsTotaal)
        {
            Spel s = new Spel(speler1, speler2, score1, score2, 0, 0, 0, 0, startScore);
            Legs l = new Legs(speler1, speler2, score1, score2, 0, 0, 0, 0, startScore, 0, 0, legsTotaal);
            Sets set = new Sets(speler1, speler2, score1, score2, 0, 0, 0, 0, startScore, 0, 0, setsTotaal);
            Statistieken stat1 = new Statistieken(speler1, "", 0, 0, 0, 0, 0, 0, 0, 0);
            Statistieken stat2 = new Statistieken(speler2, "", 0, 0, 0, 0, 0, 0, 0, 0);

            statistieken.Add(stat1);
            statistieken.Add(stat2);
            spellen.Add(s);
            legs.Add(l);
            sets.Add(set);
            return true;
        }

        public void EindeSpel(string naam)
        {
            // Tonen dat speler "naam" heeft gewonnen
            // Eindoverzicht geven
        }
        public void GeefEindOverzicht()
        {

        }

        #region Opslaan statistieken

        /// <summary>
        /// scores checken kijken of ze moeten worden opgeslagen voor statistieken.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void SaveScore(string naam, int score)
        {
            foreach (Statistieken s in statistieken)
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
        public void SaveUitworp(string naam, int score)
        {
            foreach(Statistieken s in statistieken)
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
        /// Gemiddelde opslaan bij de juiste speler.
        /// </summary>
        /// <param name="naam"></param>
        public void SaveGemiddelde(string naam)
        {
            foreach (Spel s in spellen)
            {
                if (s.Speler1 == naam)
                {
                    foreach (Statistieken stat in statistieken)
                    {
                        if (stat.Gemiddelde == 0)
                        {
                            stat.Gemiddelde = s.Gmd1;
                            avgcounter1++;
                        }
                        else
                        {
                            stat.Gemiddelde = s.Gmd1 / avgcounter1;
                        }
                    }
                }
                else if(s.Speler2 == naam)
                {
                    foreach (Statistieken stat in statistieken)
                    {
                        if (stat.Gemiddelde == 0)
                        {
                            stat.Gemiddelde = s.Gmd2;
                            avgcounter2++;
                        }
                        else
                        {
                            stat.Gemiddelde = s.Gmd2 / avgcounter2;
                        }
                    }
                }
            }
        }

        public void SaveEindstand()
        {

        }

        #endregion
        public void StatistiekenTonen()
        {

        }

        #region AVG
        /// <summary>
        /// gemiddelde per leg wordt berekend aan de hand van de naam van de speler en de score van de speler.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="score"></param>
        public void GemiddeldePerLeg(string naam, int score)
        {
            foreach (Spel s in spellen)
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

        #endregion


        /// <summary>
        /// Invoer van score en main algoritme van het programma
        /// </summary>
        /// <param name="score"></param>
        /// <param name="naam"></param>
        public void ScoreInvoer(int score, string naam)
        {
            foreach (Spel s in spellen)
            {
                if (naam == s.Speler1)
                {
                    if (score <= 180)
                    {
                        if (s.Scorep1 > score)
                        {
                            s.Scorep1 = s.Scorep1 - score;
                            GemiddeldePerLeg(naam, score);
                            SaveScore(naam, score);

                            s.Count1 = s.Count1 + 3;

                        }
                        else if (s.Scorep1 == score)
                        {
                            s.Count1 = s.Count1 + 0; //pop-up geven waar gebruiker aantal darts in moet geven.
                            SaveUitworp(naam, score); // checken of het de hoogste uitworp tot nu toe is.
                            SaveGemiddelde(naam); // saved het gemiddelde.

                            foreach (Legs l in legs)
                            {
                                if (l.Speler1 == naam)
                                {
                                    l.Stand1 = l.Stand1 + 1; // Leg is gewonnen wanneer score gelijk is aan worp.
                                    if (l.Stand1 == l.LegsTotaal)
                                    {
                                        Reset(); //Alle spelgegevens terug zetten naar orrigineel.

                                        foreach (Sets set in sets)
                                        {
                                            if (set.SetsTotaal != 0)
                                            {
                                                set.SetsStand1 = set.SetsStand1 + 1; // Set is gewonnen

                                                if (set.SetsStand1 == set.SetsTotaal)
                                                {
                                                    SaveEindstand();
                                                    EindeSpel(naam); // Einde spel.
                                                }
                                            }
                                            else
                                            {
                                                SaveEindstand();
                                                EindeSpel(naam); // Einde spel.
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
                        }
                    }
                    else
                    {
                        //melding geven 180 is max
                    }

                }
                else if (naam == s.Speler2)
                {
                    if (score <= 180)
                    {
                        if (s.Scorep2 > score)
                        {
                            s.Scorep2 = s.Scorep2 - score;
                            GemiddeldePerLeg(naam, score);
                            s.Count2 = s.Count2 + 3;
                            SaveScore(naam, score);
                        }
                        else if (s.Scorep2 == score)
                        {
                            s.Count2 = s.Count2 + 0; //pop-up geven waar gebruiker aantal darts in moet geven.
                            SaveUitworp(naam, score); // checken of het de hoogste uitworp tot nu toe is.
                            SaveGemiddelde(naam); // saved het gemiddelde.

                            foreach (Legs l in legs)
                            {
                                if (l.Speler2 == naam)
                                {
                                    l.Stand2 = l.Stand2 + 1; // Legs is gewonnen wanneer score gelijk is aan worp.
                                    if (l.Stand1 == l.LegsTotaal)
                                    {
                                        Reset(); //Alle spelgegevens terug zetten naar orrigineel.

                                        foreach (Sets set in sets)
                                        {
                                            if (set.SetsTotaal != 0)
                                            {
                                                set.SetsStand1 = set.SetsStand1 + 1; // Set is 

                                                if (set.SetsStand1 == set.SetsTotaal)
                                                {
                                                    SaveEindstand();
                                                    EindeSpel(naam);// Einde spel.
                                                }
                                            }
                                            else
                                            {
                                                SaveEindstand();
                                                EindeSpel(naam); // Einde spel.
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
                        }
                    }
                    else
                    {
                        //melding geven dat 180 max is.
                    }
                }
            }
        }

        public string UitworpTonen(string naam)
        {
            int score = 170;
            string uitworp = "";

            foreach (Spel s in spellen)
            {
                if (naam == s.Speler1)
                {
                    foreach (Spel sp in spellen)
                    {
                        if (sp.Scorep1 <= 170)
                        {
                            score = sp.Scorep1;
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
                if (naam == s.Speler2)
                {
                    foreach (Spel sp in spellen)
                    {
                        if (sp.Scorep2 <= 170)
                        {
                            score = sp.Scorep2;
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



            return uitworp;
        }

        public void Reset()
        {
            foreach (Spel s in spellen)
            {
                s.Scorep1 = s.Startscore;
                s.Scorep2 = s.Startscore;
                s.Gmd1 = 0;
                s.Gmd2 = 0;
                s.Count1 = 0;
                s.Count2 = 0;
                counter1 = 2;
                counter2 = 2;
                score1 = 0;
                score2 = 0;
            }
        }

        public void BotniveauInstellen()
        {

        }

        public void BotScore()
        {

        }
    }

}
