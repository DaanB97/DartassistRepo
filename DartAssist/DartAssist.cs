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
            btnInvoer2.Enabled = false;
            lblTurn2.Visible = false;
        }

        #region Spel initialiseren
        public void SpelStart()
        {
            string naam1 = "";
            string naam2 = "";
            foreach (Spel s in spelController.Spellen)
            {
                naam1 = s.Speler1.Naam;
                naam2 = s.Speler2.Naam;
            }

            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler1.Naam != " ")
                {
                    lblNaamP2.Text = s.Speler2.Naam.ToString();
                    lblScore2.Text = Convert.ToString(s.Speler2.Score);
                    lblNaamP1.Text = s.Speler1.Naam.ToString();
                    lblScore1.Text = Convert.ToString(s.Speler1.Score);
                }
            }
        }
        #endregion

        #region score invoer

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

                try
                {
                    spelController.ScoreInvoer(invoer1, naam1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    SwitchTurn();
                }
                FillLabels();
                tbInvoer1.Text = "";
            }
            UpdateStand();
            SwitchTurn();
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
                try
                {
                    spelController.ScoreInvoer(invoer2, naam2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    SwitchTurn();
                }
                FillLabels();
                tbInvoer2.Text = "";
            }
            UpdateStand();
            SwitchTurn();
            CheckEindeSpel();
        }

        #endregion

        #region Bot
        public void BotTurn()
        {
            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler2.SpelerType == SpelerType.Bot)
                {
                    try
                    {
                        spelController.ScoreInvoer(0, lblNaamP2.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        SwitchTurn();
                    }

                    FillLabels();
                    UpdateStand();
                    SwitchTurn();
                    CheckEindeSpel();
                }
            }
        }
        #endregion

        #region Updates

        /// <summary>
        /// Controleerd of het spel is afgelopen of niet.
        /// </summary>
        public void CheckEindeSpel()
        {
            if (spelController.CheckEindeSpel() == true)
            {
                es.FillLabels();
                es.Show();
            }
        }

        /// <summary>
        /// Zorgt ervoor dat iemand niet 2 keer achter elkaar een score kan invullen.
        /// </summary>
        public void SwitchTurn()
        {
            if (btnInvoer1.Enabled == true)
            {
                btnInvoer1.Enabled = false;
                btnInvoer2.Enabled = true;
                lblTurn1.Visible = false;
                lblTurn2.Visible = true;
            }
            else if (btnInvoer2.Enabled == true)
            {
                btnInvoer1.Enabled = true;
                btnInvoer2.Enabled = false;
                lblTurn1.Visible = true;
                lblTurn2.Visible = false;
            }
        }

        /// <summary>
        /// Zorgt ervoor dat de stand in real- time getoond wordt.
        /// </summary>
        public void UpdateStand()
        {
            foreach (Legs s in spelController.Legs)
            {
                if (s.Speler1.Naam == lblNaamP1.Text)
                {
                    lblLegs1.Text = Convert.ToString(s.Stand);
                }
                else if (s.Speler2.Naam == lblNaamP2.Text)
                {
                    lblLegs2.Text = Convert.ToString(s.Stand);
                }
            }
            foreach (Sets s in spelController.Sets)
            {
                if (s.Speler1.Naam == lblNaamP1.Text)
                {
                    lblSetsStand1.Text = Convert.ToString(s.SetsStand);
                }
                else if (s.Speler2.Naam == lblNaamP2.Text)
                {
                    lblSetsStand2.Text = Convert.ToString(s.SetsStand);
                }
            }
        }

        /// <summary>
        /// Vult alle labels met de nodige informatie.
        /// </summary>
        private void FillLabels()
        {
            string naam1 = lblNaamP1.Text;
            string naam2 = lblNaamP2.Text;
            foreach (Spel s in spelController.Spellen)
            {
                if (s.Speler1.Naam == naam1)
                {
                    lblScore1.Text = Convert.ToString(s.Speler1.Score);
                    lblGemiddelde1.Text = Convert.ToString(s.Speler1.Gemiddelde);
                    lblAantalDarts1.Text = Convert.ToString(s.Speler1.Darts);
                }
                if (s.Speler2.Naam == naam2)
                {
                    lblScore2.Text = Convert.ToString(s.Speler2.Score);
                    lblGemiddelde2.Text = Convert.ToString(s.Speler2.Gemiddelde);
                    lblAantalDarts2.Text = Convert.ToString(s.Speler2.Darts);
                }

            }
            lblUitworp1.Text = spelController.UitworpTonen(naam1);
            lblUitworp2.Text = spelController.UitworpTonen(naam2);
        }
        #endregion
    }
}
