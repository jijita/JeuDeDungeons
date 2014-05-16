using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_JeuDungeon
{
    public partial class FenetreNiveau : Form
    {
        public int niveau = 0;

        public FenetreNiveau()
        {
            InitializeComponent();
        }

        private void niveau1_Click(object sender, EventArgs e)
        {
            niveau = 1;
            this.Close();
        }
        
        private void Niveau2_Click(object sender, EventArgs e)
        {
            niveau = 2;
            this.Close();
        }

        private void niveau3_Click(object sender, EventArgs e)
        {
            niveau = 3;
            this.Close();
        }
    }
}
