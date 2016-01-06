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
    public partial class Login : Form
    {
        private Instellingen instellingen;
        public Login()
        {
            InitializeComponent();
            instellingen = new Instellingen();
        }

        private void btnGast_Click(object sender, EventArgs e)
        {
            instellingen.Show();
        }
    }
}
