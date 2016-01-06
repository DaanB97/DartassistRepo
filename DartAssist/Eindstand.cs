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
        private SpelController sc;
        public Eindstand(SpelController meegegeven )
        {
            sc = meegegeven;
            InitializeComponent();
        }
    }
}
