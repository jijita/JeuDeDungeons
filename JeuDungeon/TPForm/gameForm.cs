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
        public Jeu leJeu;
        public GameForm()

        {
            InitializeComponent();

            #region Selection du niveau
            FenetreNiveau niveau = new FenetreNiveau();
            niveau.ShowDialog();
            int i = niveau.niveau;
            SpecsDuJeu.nv = i;
            labelNBniveau.Text =""+ i;
            #endregion

            Point position1 = pnlTerrainLimites.Location;
            position1.X += pnlTerrainBackground.Location.X;
            position1.Y += pnlTerrainBackground.Location.Y;

            imageAvoir.Location = position1;
            imageAvoir.Size = pnlTerrainLimites.Size;
        }

        private void labelXquit_Click(object sender, EventArgs e)
        {
            SpecsDuJeu.flush.Play();
            Thread.Sleep(2500);
            Dispose();
        }

        private void onLoad(object sender, EventArgs e)
        {
            SpecsDuJeu.say("Game start");
            leJeu = new Jeu { terrain = pnlTerrainLimites.Bounds };
            pnlTerrainLimites.Controls.Add(leJeu.jiface.laPicBox);

            foreach (var item in leJeu.lstEnnemi)
            {
                pnlTerrainLimites.Controls.Add(item.laPicBox);
            }

            foreach (var item in leJeu.lstArtefact)
            {
                pnlTerrainLimites.Controls.Add(item.laPicBox);
            }

            leJeu.AF_versSac += artefactVaDansLeSac;
            leJeu.killEnnemi += leJeu_killEnnemi;
            leJeu.killJoueur += leJeu_killJoueur;
            KeyDown += GameForml_KeyDown;
            timer.Enabled = true;
        }

        void leJeu_killJoueur(object sender, EventArgs e)
        {
            timer.Enabled = false;
            pnlTerrainLimites.Controls.Remove(leJeu.jiface.laPicBox);
            SpecsDuJeu.say("Game Over");
        }

        void leJeu_killEnnemi(object sender, EnnemiMeurt e)
        {
            pnlTerrainLimites.Controls.Remove(e.lui.laPicBox);
            SpecsDuJeu.cheering.Play();
        }

        private void handler(object sender, EventArgs e)
        {
            string str = "";

            if (str.Equals("pointsDeVie"))
                progBarVie.Value = leJeu.jiface.pointsDeVie;
            else if (str.Equals("pointsEndurance"))
                progBarEndurance.Value = leJeu.jiface.pointsEndurance;
            else if (str.Equals("agilite"))
                progBarAgilite.Value = leJeu.jiface.agilite;
            else if (str.Equals("force"))
                progBarForce.Value = leJeu.jiface.force;
        }

        #region Deplacements du joueur

        private void clickHaut(object sender, EventArgs e)
        {
            leJeu.jiface.deplacer(Direction.HAUT);
        }

        private void clickDroite(object sender, EventArgs e)
        {
            leJeu.jiface.deplacer(Direction.DROITE);
        }

        private void clickBas(object sender, EventArgs e)
        {
            leJeu.jiface.deplacer(Direction.BAS);
        }

        private void clickGauche(object sender, EventArgs e)
        {
            leJeu.jiface.deplacer(Direction.GAUCHE);
        }

        private void GameForml_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        clickHaut(this, new EventArgs());
                    }
                    break;
                case Keys.Down:
                    {
                        clickBas(this, new EventArgs());
                    }
                    break;
                case Keys.Left:
                    {
                        clickGauche(this, new EventArgs());
                    }
                    break;
                case Keys.Right:
                    {
                        clickDroite(this, new EventArgs());
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion

        private void timedActions(object sender, EventArgs e)
        {
            leJeu.jouerLesGhouls();
            repaintProgBars();
        }        

        private void repaintProgBars()
        {
            progBarVie.Value = leJeu.jiface.pointsDeVie;
            progBarEndurance.Value = leJeu.jiface.pointsEndurance;
            progBarForce.Value = leJeu.jiface.force;
            progBarAgilite.Value = leJeu.jiface.agilite;
        }

        private void modificationStatsJoueur(object sender, PropertyChangedEventArgs e)
        {
            string str = e.PropertyName;

            if (str.Equals("pointsDeVie"))
                progBarVie.Value = leJeu.jiface.pointsDeVie;
            else if (str.Equals("pointsEndurance"))
                progBarEndurance.Value = leJeu.jiface.pointsEndurance;
            else if (str.Equals("agilite"))
                progBarAgilite.Value = leJeu.jiface.agilite;
            else if (str.Equals("force"))
                progBarForce.Value = leJeu.jiface.force;


        }

        //changement
        private void artefactVaDansLeSac(object sender, ArtefactPrisEventArgs e)
        {
            PictureBox potion = e.af.laPicBox;
            potion.Name = "pictureBox1";
            potion.Click += new System.EventHandler(this.potion_Click);
            flpnl_Sac.Controls.Add(potion);
            pnlTerrainLimites.Controls.Remove(potion);
            SpecsDuJeu.getStufffloop.Play();
        }

        //changement
        private void potion_Click(object sender, EventArgs e)
        {
            SpecsDuJeu.better.Play();
             var potionSelectionne = (from p in leJeu.jiface.sac
                                     where p.laPicBox == (PictureBox)sender
                                     select p).ToList();

            leJeu.jiface.selectionnerArtefact(potionSelectionne[0]);

            flpnl_Sac.Controls.Remove(potionSelectionne[0].laPicBox);

            var potionsPasSelectionner = from p in leJeu.jiface.sac
                                         where p.estSelectionee == false
                                         select p;

            foreach (var item in potionsPasSelectionner)
            {
                item.laPicBox.BorderStyle = BorderStyle.None;
            }

            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;

        }

        private void tm_affich_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pnlTerrainLimites.Width, pnlTerrainLimites.Height);
            pnlTerrainLimites.DrawToBitmap(bmp, new Rectangle(0, 0, pnlTerrainLimites.Width, pnlTerrainLimites.Height));

            imageAvoir.BackgroundImage = bmp;
        }
    }
}    

