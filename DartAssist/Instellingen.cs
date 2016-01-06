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
    public partial class Instellingen : Form
    {
        private DartAssist dartAssist;
        private SpelController spelController;

        public Instellingen()
        {
            InitializeComponent();
            spelController = new SpelController();
            dartAssist = new DartAssist(spelController);

        }

        public int StartOpties()
        {
            string speler1 = tbSpeler1.Text;
            string speler2 = tbSpeler2.Text;
            int botGmd = 0;

            if (checkBox1.Checked)
            {
                speler2 = "Bot";
                botGmd = Convert.ToInt32(nudBot.Value);
            }

            int legsTotaal = Convert.ToInt32(nudLegs.Value);
            int setsTotaal = Convert.ToInt32(nudSets.Value);
            int i = CheckScores();

            spelController.NieuwSpel(speler1, speler2, i, legsTotaal, setsTotaal, botGmd);

            if (i == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void btnBeginSpel_Click(object sender, EventArgs e)
        {
            if (StartOpties() == 1)
            {
                dartAssist.SpelStart();
                dartAssist.Show();
            }
        }

        public int CheckScores()
        {
            int score;
            if (rb301P1.Checked)
            {
                score = 301;
                return score;
            }
            else if (rb501P1.Checked)
            {
                score = 501;
                return score;
            }
            else if (rb501P1.Checked)
            {
                score = 701;
                return score;
            }
            else if (rbCostum.Checked)
            {
                score = Convert.ToInt32(tbCostum.Text);
                return score;
            }
            else
            {
                MessageBox.Show("Kies spelsoort");
                return 0;
            }
        }

    }
}
