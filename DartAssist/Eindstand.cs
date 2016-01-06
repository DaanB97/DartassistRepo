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

        public void FillLabels()
        {
            string speler1 = "";
            string speler2 = "";
            int count = 0;
            foreach (Spel s in spelController.Spellen)
            {
                if (count == 0)
                {
                    speler1 = s.Speler.Naam;
                    count++;
                }
                else if (count == 1)
                {
                    speler2 = s.Speler.Naam;
                    count++;
                }
            }
            foreach (Statistieken stat in spelController.Statistieken)
            {
                lblEindstand.Text = stat.Eindstand;
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
            foreach (Spel s in spelController.Spellen)
            {
                if(s.Speler.Naam == speler1)
                {
                    gbSpeler1.Text = s.Speler.Naam;
                }
                if (s.Speler.Naam == speler2)
                {
                    gbSpeler2.Text = s.Speler.Naam;
                }
            }
        }
    }
}
