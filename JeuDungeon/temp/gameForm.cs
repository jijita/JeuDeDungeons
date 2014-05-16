using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_JeuDungeon.BL;

namespace TP_JeuDungeon.PL
{
    public partial class GameForm : Form
    {

        Jeu theGame;

        public GameForm()
        {
            InitializeComponent();

            theGame = new Jeu();

           theGame.init();
            pnlTerrainLimites.Controls.Add(theGame.jiface.thePictureBox);
            
            foreach (Ennemi item in theGame.lstEnnemi)
            {                
                pnlTerrainLimites.Controls.Add(item.thePictureBox);
                item.VieChangee += vieChangee;
            }
  
            foreach (Artefact item in theGame.lstArtefact)
            {               
                pnlTerrainLimites.Controls.Add(item.thePictureBox);
            }
            
           
            theGame.AF_versSac += theGame_AF_versSac;
            theGame.giveEnnemiActions();
            tmrEnnemiActions.Enabled = true;

        }

        void theGame_AF_versSac(Artefact af_pris)
        {
            PictureBox potion = af_pris.thePictureBox;

            flpnl_Sac.Controls.Add(potion);
            pnlTerrainLimites.Controls.Remove(potion);

        }
              
        private void vieChangee(object sender, int pointsDeVieActuels)
        {
            if (sender is Ennemi)
            {
                Ennemi evil = (Ennemi)sender;
                tboxResult.Text = String.Format("{0} a maintenant {1} points de vie", evil.nom, pointsDeVieActuels);
            }
        }

        private void moveToDirectionOnClick(object sender, EventArgs e)
        {
            string str = ((Panel)sender).Name;

            switch (str)
            {
                case "panelFlecheHaut":
                    theGame.jiface.deplacer(Direction.HAUT);
                    break;
                case "panelFlecheDroite":
                    theGame.jiface.deplacer(Direction.DROITE);
                    break;
                case "panelFlecheBas":
                    theGame.jiface.deplacer(Direction.BAS);
                    break;
                case "panelFlecheGauche":
                    theGame.jiface.deplacer(Direction.GAUCHE);
                    break;
            }
        }

        //  still testing
        private void attackOnClick(object sender, EventArgs e)
        {
            theGame.jiface.attaquer();
        }

        private void timeTick(object sender, EventArgs e)
        {
            foreach (var item in theGame.lstEnnemi)
            {

                if (item.nom.Equals("Ghoul"))
                    item.deplacerAI(theGame.jiface);
                else
                    item.deplacerRandomDir();
            }
        }

        private void btn_prendre_Click(object sender, EventArgs e)
        {
            theGame.jiface.prendreArtefact();
        }

        private void labelXquit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void gestion_deplacement(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                theGame.jiface.deplacer(Direction.HAUT);
            else if (e.KeyCode == Keys.Down)
                theGame.jiface.deplacer(Direction.BAS);
            else if (e.KeyCode== Keys.Right)
                theGame.jiface.deplacer(Direction.DROITE);
            else if (e.KeyCode == Keys.Left)
                theGame.jiface.deplacer(Direction.GAUCHE);

        }

        private void gestion_deplacement(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                theGame.jiface.deplacer(Direction.HAUT);
            else if (e.KeyCode == Keys.Down)
                theGame.jiface.deplacer(Direction.BAS);
            else if (e.KeyCode == Keys.Right)
                theGame.jiface.deplacer(Direction.DROITE);
            else if (e.KeyCode == Keys.Left)
                theGame.jiface.deplacer(Direction.GAUCHE);
        }
        #region TEMPORAIRE
        private void button1_Click(object sender, EventArgs e)
        {
            theGame.jiface.pointsDeVie += 10;
            theGame.jiface.force += 1;
            theGame.jiface.pointsEndurance += 10;
            theGame.jiface.agilite += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theGame.jiface.pointsDeVie -= 10;
            theGame.jiface.force -= 1;
            theGame.jiface.pointsEndurance -= 10;
            theGame.jiface.agilite -= 10;
        }
        #endregion
    }

 
    
}
