using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Tier;

namespace DartAssist
{
    public partial class Eindstand : Form
    {
        private SpelController spelController;
        public Eindstand(SpelController spelController)
        {
            InitializeComponent();
            this.spelController = spelController;
        }

        #region Labels vullen
        public void FillLabels()
        {
            string speler1 = "";
            string speler2 = "";
            foreach (Spel s in spelController.Spellen)
            {
                speler1 = s.Speler1.Naam;
                speler2 = s.Speler2.Naam;
                gbSpeler1.Text = speler1;
                gbSpeler2.Text = speler2;
            }
            foreach (Statistieken stat in spelController.Statistieken)
            {
                foreach (Spel s in spelController.Spellen)
                {
                    if (s.Speler1.Naam == stat.Speler)
                    {
                        if (s.Einde == true)
                        {
                            lblEindstand.Text = stat.Eindstand.ToString();
                        }
                    }
                    else if (s.Speler2.Naam == stat.Speler)
                    {
                        if (s.Einde == true)
                        {
                            lblEindstand.Text = stat.Eindstand.ToString();
                        }

                    }

                }

                if (stat.Speler == speler1)
                {
                    lblGmdP1.Text = Convert.ToString(stat.Gemiddelde);
                    lblHsP1.Text = Convert.ToString(stat.HoogsteScore);
                    lblHfP1.Text = Convert.ToString(stat.HoogsteFinish);
                    lbl60P1.Text = Convert.ToString(stat.Aantal60);
                    lbl100P1.Text = Convert.ToString(stat.Aantal100);
                    lbl140P1.Text = Convert.ToString(stat.Aantal140);
                    lbl180P1.Text = Convert.ToString(stat.Aantal180);
                    lblDpLP1.Text = Convert.ToString(stat.DartsPerLeg);
                }
                else if (stat.Speler == speler2)
                {
                    lblGmdP2.Text = Convert.ToString(stat.Gemiddelde);
                    lblHsP2.Text = Convert.ToString(stat.HoogsteScore);
                    lblHfP2.Text = Convert.ToString(stat.HoogsteFinish);
                    lbl60P2.Text = Convert.ToString(stat.Aantal60);
                    lbl100P2.Text = Convert.ToString(stat.Aantal100);
                    lbl140P2.Text = Convert.ToString(stat.Aantal140);
                    lbl180P2.Text = Convert.ToString(stat.Aantal180);
                    lblDpLP2.Text = Convert.ToString(stat.DartsPerLeg);
                }
            }
        }
        #endregion
    }
}
