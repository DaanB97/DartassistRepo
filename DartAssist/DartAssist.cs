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
            foreach(Legs s in spelController.legs)
            {
                if (s.Speler1 == lblNaamP1.Text)
                {
                    lblLegs1.Text = Convert.ToString(s.Stand1);
                    lblLegs2.Text = Convert.ToString(s.Stand2);
                }
            }
        }

        public void NieuwSpel(string speler1, string speler2, int score1, int score2)
        {
            spelController.NieuwSpel( speler1,  speler2, score1, score2);
        }

        private void btnInvoer1_Click(object sender, EventArgs e)
        {
            if (tbInvoer1.Text == "")
            {
                MessageBox.Show("Voer score in");
            }
            else
            {
                int invoer1 = Convert.ToInt32(tbInvoer1.Text);
                lblLaatsteScore1.Text = Convert.ToString(invoer1);
                string naam1 = lblNaamP1.Text;
                string naam2 = lblNaamP2.Text;
                spelController.ScoreInvoer(invoer1, naam1);

                foreach (Spel s in spelController.spellen)
                {
                    if (naam1 == s.Speler1)
                    {
                        lblScore1.Text = Convert.ToString(s.Scorep1);
                        lblScore2.Text = Convert.ToString(s.Scorep2);
                        lblGemiddelde1.Text = Convert.ToString(s.Gmd1);
                    }
                }
                tbInvoer1.Text = "";
                lblUitworp1.Text = spelController.UitworpTonen(naam1);
                lblUitworp2.Text = spelController.UitworpTonen(naam2);
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
                int invoer2 = Convert.ToInt32(tbInvoer2.Text);
                lblLaatsteScore2.Text = Convert.ToString(invoer2);
                string naam1 = lblNaamP1.Text;
                string naam2 = lblNaamP2.Text;
                spelController.ScoreInvoer(invoer2, naam2);

                foreach (Spel s in spelController.spellen)
                {
                    if (naam2 == s.Speler2)
                    {
                        lblScore1.Text = Convert.ToString(s.Scorep1);
                        lblScore2.Text = Convert.ToString(s.Scorep2);
                        lblGemiddelde2.Text = Convert.ToString(s.Gmd2);
                    }
                }
                tbInvoer2.Text = "";
                lblUitworp1.Text = spelController.UitworpTonen(naam1);
                lblUitworp2.Text = spelController.UitworpTonen(naam2);
            }
            UpdateStand();
        }
    }
}
