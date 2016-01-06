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
    public partial class DartAssist : Form
    {
        private SpelController spelController;
        private Eindstand es;
        public DartAssist(SpelController spelController)
        {
            InitializeComponent();
            es = new Eindstand(spelController);
            this.spelController = spelController;
        }

        public void SpelStart()
        {
            string naam = "";
            foreach (Spel s in spelController.Spellen)
            {
                naam = s.Speler.Naam;
            }

            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler.Naam != " ")
                {
                    if (s.Speler.Naam == naam)
                    {
                        lblNaamP2.Text = s.Speler.Naam.ToString();
                        lblScore2.Text = Convert.ToString(s.Speler.Score);
                    }
                    else if (s.Speler.Naam != naam)
                    {
                        lblNaamP1.Text = s.Speler.Naam.ToString();
                        lblScore1.Text = Convert.ToString(s.Speler.Score);
                    }
                }
            }
        }

        public void UpdateStand()
        {
            foreach (Legs s in spelController.Legs)
            {
                if (s.Speler.Naam == lblNaamP1.Text)
                {
                    lblLegs1.Text = Convert.ToString(s.Stand);
                }
                else if (s.Speler.Naam == lblNaamP2.Text)
                {
                    lblLegs2.Text = Convert.ToString(s.Stand);
                }
            }
            foreach (Sets s in spelController.Sets)
            {
                if (s.Speler.Naam == lblNaamP1.Text)
                {
                    lblSetsStand1.Text = Convert.ToString(s.SetsStand);
                }
                else if (s.Speler.Naam == lblNaamP2.Text)
                {
                    lblSetsStand2.Text = Convert.ToString(s.SetsStand);
                }
            }
        }

        private void btnInvoer1_Click(object sender, EventArgs e)
        {
            if (tbInvoer1.Text == "")
            {
                MessageBox.Show("Voer score in");
            }
            else
            {
                string naam1 = lblNaamP1.Text;
                int invoer1 = Convert.ToInt32(tbInvoer1.Text);
                spelController.ScoreInvoer(invoer1, naam1);
                FillLabels();
                tbInvoer1.Text = "";
            }

            UpdateStand();
            CheckEindeSpel();

            BotTurn();
        }

        private void btnInvoer2_Click(object sender, EventArgs e)
        {
            if (tbInvoer2.Text == "")
            {
                MessageBox.Show("Voer score in");
            }
            else
            {
                string naam2 = lblNaamP2.Text;
                int invoer2 = Convert.ToInt32(tbInvoer2.Text);
                spelController.ScoreInvoer(invoer2, naam2);
                FillLabels();
                tbInvoer2.Text = "";
            }
            UpdateStand();
            CheckEindeSpel();
        }

        private void FillLabels()
        {
            string naam1 = lblNaamP1.Text;
            string naam2 = lblNaamP2.Text;
            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler.Naam == naam1)
                {
                    lblLaatsteScore1.Text = Convert.ToString(Convert.ToInt32(lblScore1.Text) - s.Speler.Score);
                    lblScore1.Text = Convert.ToString(s.Speler.Score);
                    lblGemiddelde1.Text = Convert.ToString(s.Speler.Gemiddelde);
                    lblAantalDarts1.Text = Convert.ToString(s.Speler.Darts);
                }
                else if (s.Speler.Naam == naam2)
                {
                    lblLaatsteScore2.Text = Convert.ToString(Convert.ToInt32(lblScore2.Text) - s.Speler.Score);
                    lblScore2.Text = Convert.ToString(s.Speler.Score);
                    lblGemiddelde2.Text = Convert.ToString(s.Speler.Gemiddelde);
                    lblAantalDarts2.Text = Convert.ToString(s.Speler.Darts);
                }

            }
            lblUitworp1.Text = spelController.UitworpTonen(naam1);
            lblUitworp2.Text = spelController.UitworpTonen(naam2);
        }

        public void BotTurn()
        {
            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler.SpelerType == SpelerType.Bot)
                {
                    spelController.ScoreInvoer(0, lblNaamP2.Text);
                    FillLabels();
                    UpdateStand();
                    CheckEindeSpel();
                }
            }
        }

        public void CheckEindeSpel()
        {
            if (spelController.CheckEindeSpel() == true)
            {
                es.Show();
            }
        }
    }
}
