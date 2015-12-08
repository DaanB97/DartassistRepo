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

        public Instellingen()
        {
            InitializeComponent();
            dartAssist = new DartAssist();
        }

        int score1;
        int score2;

        public int StartOpties()
        {
            string speler1 = tbSpeler1.Text;
            string speler2 = tbSpeler2.Text;
            int i = CheckScores();

            dartAssist.NieuwSpel(speler1,speler2,score1,score2);
            return i;
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
            if(rb301P1.Checked)
            {
                score1 = 301;
                score2 = 301;
                return 1;
            }
            else if(rb501P1.Checked)
            {
                score1 = 501;
                score2 = 501;
                return 1;
            }
            else if(rb501P1.Checked)
            {
                score1 = 701;
                score2 = 701;
                return 1;
            }
            else
            {
                MessageBox.Show("Kies spelsoort");
                return 0;
            }
        }

    }
}
