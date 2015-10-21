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

        public void NieuwSpel(string speler1, string speler2, int score1, int score2)
        {
            spelController.NieuwSpel( speler1,  speler2, score1, score2);
        }

        private void btnInvoer1_Click(object sender, EventArgs e)
        {
            int invoer1 = Convert.ToInt32(tbInvoer1.Text);
            string naam1 = lblNaamP1.Text;
            spelController.ScoreInvoer(invoer1, naam1);
            int nieuwscore;

            foreach(Spel s in spelController.spellen)
            {
                if (naam1 == s.Speler1)
                {
                    nieuwscore = s.Scorep1;
                    lblScore1.Text = Convert.ToString(nieuwscore);
                }
            }
            tbInvoer1.Text = "";
            lblUitworp1.Text = spelController.UitworpTonen(naam1);
        }

        private void btnInvoer2_Click(object sender, EventArgs e)
        {
            int invoer2 = Convert.ToInt32(tbInvoer2.Text);
            string naam2 = lblNaamP2.Text;
            spelController.ScoreInvoer(invoer2, naam2);
            int nieuwscore;

            foreach(Spel s in spelController.spellen)
            {
                if(naam2 == s.Speler2)
                {
                    nieuwscore = s.Scorep2;
                    lblScore2.Text = Convert.ToString(nieuwscore);
                }
            }
            tbInvoer2.Text = "";
            lblUitworp2.Text = spelController.UitworpTonen(naam2);
        }
    }
}
