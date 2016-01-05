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
        public DartAssist()
        {
            InitializeComponent();
            spelController = new SpelController();
        }

        public void SpelStart()
        {

            foreach (Spel s in spelController.spellen)
            {
                if (s.Speler1 != " ")
                {
                    lblNaamP1.Text = s.Speler1.ToString();
                    lblNaamP2.Text = s.Speler2.ToString();
                    lblScore1.Text = Convert.ToString(s.Scorep1);
                    lblScore2.Text = Convert.ToString(s.Scorep2);

                }
            }
        }

        public void UpdateStand()
        {
            foreach (Legs s in spelController.legs)
            {
                if (s.Speler1 == lblNaamP1.Text)
                {
                    lblLegs1.Text = Convert.ToString(s.Stand1);
                    lblLegs2.Text = Convert.ToString(s.Stand2);
                }
            }
        }

        public void NieuwSpel(string speler1, string speler2, int score1, int score2, int startScore)
        {
            spelController.NieuwSpel(speler1, speler2, score1, score2, startScore);
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
                lblLaatsteScore1.Text = Convert.ToString(invoer1);
            }
            UpdateStand();
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
                lblLaatsteScore2.Text = Convert.ToString(invoer2);
            }
            UpdateStand();
        }

        private void FillLabels()
        {
            string naam1 = lblNaamP1.Text;
            string naam2 = lblNaamP2.Text;
            foreach (Spel s in spelController.spellen)
            {
                lblScore1.Text = Convert.ToString(s.Scorep1);
                lblScore2.Text = Convert.ToString(s.Scorep2);
                lblGemiddelde1.Text = Convert.ToString(s.Gmd1);
                lblGemiddelde2.Text = Convert.ToString(s.Gmd2);
            }
            lblUitworp1.Text = spelController.UitworpTonen(naam1);
            lblUitworp2.Text = spelController.UitworpTonen(naam2);
        }
    }
}
