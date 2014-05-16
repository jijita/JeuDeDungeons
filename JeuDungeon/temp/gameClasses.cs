using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP_JeuDungeon.BL
{
    public enum Direction { HAUT, DROITE, BAS, GAUCHE }

    public delegate void PersoDeplaceHandler(object sender, Direction dir);
    public delegate void PersoAttaqueHandler(object sender, int force);
    public delegate void PersoHealthChangeHandler(object sender, int pointsDeVieActuels);
    public delegate void JoueurPrendArtefactHandler(Artefact af_pris);

    public class Jeu
    {
        public Rectangle terrain { get; set; }
        public List<Ennemi> lstEnnemi { get; set; }
        public List<Artefact> lstArtefact { get; set; }



        public Joueur jiface { get; set; }
        

        public event JoueurPrendArtefactHandler AF_versSac;

        // donner l evenemnt pour bouger chaque element ennemi , et calculer les points de vie 

        public void giveEnnemiActions()
        {
            foreach (var item in lstEnnemi)
            {
                item.Deplacement += persoDeplacement;
                item.VieChangee += persoHealthChange;
            }
        }

        #region Init Jeu

        //public Jeu()
        //{
        //    init();
        //}

        public void init()
        {
            jiface = new Joueur
            {
                sac = new List<Artefact>(),
                throwingDistance = 100,
                agilite = 100,
                force = 1,
                AFSelectionne = null,
                pointsDeVie = 100,
                pointsEndurance = 100,
                thePictureBox = new PictureBox
                {
                    Location = new Point(540, 120),
                    Size = new Size(50, 50),
                    Image = global::TP_JeuDungeon.Properties.Resources.player
                }
            };

            jiface.Deplacement += persoDeplacement;
            jiface.Attaque += persoAttaque;
            jiface.VieChangee += persoHealthChange;
            jiface.actionPrendreAF += jiface_actionPrendreAF;

            lstEnnemi = new List<Ennemi>();           
            
            lstEnnemi.Add(new Ennemi
            {
                force = 5,
                nom = "Ghoul",
                pointsDeVie = 50,
                scoreEnnemi = 50,
                thePictureBox = new PictureBox
                {
                    Location = new Point(53, 150),
                    Size = new Size(50, 50),
                    Image = global::TP_JeuDungeon.Properties.Resources.ghoul
                }
            });

            lstArtefact = new List<Artefact>();

            lstArtefact.Add(new Artefact
            {
                scoreArtefact = 20,
                pointsAttribues = 50,
                thePictureBox = new PictureBox
                {
                    Location = new Point(450, 180),
                    Size = new Size(25, 25),
                    Image = global::TP_JeuDungeon.Properties.Resources.potion_blue
                }
            });
        }

        #endregion

        #region Reactions aux evennements
        public void persoDeplacement(object sender, Direction dir)
        {
            int deplacement = 14;

            Personnage lePerso = (Personnage)sender;
            Rectangle newPosition = lePerso.position;

            switch (dir)
            {
                case Direction.HAUT:
                    newPosition.Offset(0, -deplacement);
                    lePerso.position = newPosition.Top >= 0 ? (collisionPersoEnHaut(lePerso, newPosition) ? lePerso.position : newPosition) : lePerso.position;
                    break;
                case Direction.DROITE:
                    newPosition.Offset(deplacement, 0);
                    lePerso.position = newPosition.Right <= terrain.Width ? (collisionPersoADroite(lePerso, newPosition) ? lePerso.position : newPosition) : lePerso.position;
                    break;
                case Direction.BAS:
                    newPosition.Offset(0, deplacement);
                    lePerso.position = newPosition.Bottom <= terrain.Height ? (collisionPersoEnBas(lePerso, newPosition) ? lePerso.position : newPosition) : lePerso.position;
                    break;
                case Direction.GAUCHE:
                    newPosition.Offset(-deplacement, 0);
                    lePerso.position = newPosition.Left >= 0 ? (collisionPersoAGauche(lePerso, newPosition) ? lePerso.position : newPosition) : lePerso.position;
                    break;
            }
        }

        private void persoAttaque(object sender, int force)
        {
            Personnage perso = (Personnage)sender;

            List<Personnage> lst;

            if (perso is Ennemi)
            {
                lst = new List<Personnage>();
                lst.Add(jiface);
            }
            else
                lst = lstEnnemi.ToList<Personnage>();

            var adversaires = from dude in lstEnnemi
                              where perso.voisinage(dude)
                              select dude;

            foreach (Personnage item in adversaires)
            {
                item.pointsDeVie -= perso.force;
            }
        }

        private void persoHealthChange(object sender, int pointsDeVieActuels)
        {
            /// kill it if health reaches 0
            //if (sender is Ennemi)
            //{
            //    lstEnnemi.Remove((Ennemi)sender);
            //}
            //else 
            //{
            //    //demander au joueur s il veut recommencer
            //}
        }

        void jiface_actionPrendreAF()
        {
            Artefact aPrendre = joueurSurArtefact(jiface);
            if (aPrendre != null)
            {
                AF_versSac(aPrendre);

                jiface.sac.Add(aPrendre);
                lstArtefact.Remove(aPrendre);
            }
        }
        #endregion

        #region	Collisions entre perso par direction
        public bool collisionPersoEnHaut(Personnage testeur, Rectangle newPosition)
        {
            List<Personnage> listPerso = new List<Personnage>();
            listPerso.AddRange(lstEnnemi);
            listPerso.Add(jiface);

            listPerso.Remove(testeur);

            var lesAutres = from dude in listPerso
                            where dude.position.Top <= newPosition.Top
                            select dude;

            var quiFaitCollision = from dudette in lesAutres
                                   where dudette.position.IntersectsWith(newPosition)
                                   select dudette;

            return quiFaitCollision.Count() > 0;
        }

        public bool collisionPersoEnBas(Personnage testeur, Rectangle newPosition)
        {
            List<Personnage> listPerso = new List<Personnage>();
            listPerso.AddRange(lstEnnemi);
            listPerso.Add(jiface);

            listPerso.Remove(testeur);

            var lesAutres = from dude in listPerso
                            where dude.position.Bottom >= newPosition.Bottom
                            select dude;

            var quiFaitCollision = from dudette in lesAutres
                                   where dudette.position.IntersectsWith(newPosition)
                                   select dudette;

            return quiFaitCollision.Count() > 0;
        }

        public bool collisionPersoAGauche(Personnage testeur, Rectangle newPosition)
        {
            List<Personnage> listPerso = new List<Personnage>();
            listPerso.AddRange(lstEnnemi);
            listPerso.Add(jiface);

            listPerso.Remove(testeur);

            var lesAutres = from dude in listPerso
                            where dude.position.Left <= newPosition.Left
                            select dude;

            var quiFaitCollision = from dudette in lesAutres
                                   where dudette.position.IntersectsWith(newPosition)
                                   select dudette;

            return quiFaitCollision.Count() > 0;
        }

        public bool collisionPersoADroite(Personnage testeur, Rectangle newPosition)
        {
            List<Personnage> listPerso = new List<Personnage>();
            listPerso.AddRange(lstEnnemi);
            listPerso.Add(jiface);

            listPerso.Remove(testeur);

            var lesAutres = from dude in listPerso
                            where dude.position.Right >= newPosition.Right
                            select dude;

            var quiFaitCollision = from dudette in lesAutres
                                   where dudette.position.IntersectsWith(newPosition)
                                   select dudette;

            return quiFaitCollision.Count() > 0;
        }
        #endregion

        #region	Joueur superpose sur un artefact
        public Artefact joueurSurArtefact(Joueur player)
        {
            Artefact artefactPris = null;

            if (lstArtefact.Count() > 0)
            {
                var unArtefact = from art in lstArtefact
                                 where player.position.Contains(art.position)
                                 select art;
               
                if(unArtefact.Count()>0)
                    artefactPris = unArtefact.ToList()[0];
            }

            return artefactPris;
        }
        #endregion        
    }

    public abstract class ElementDuJeu //: INotifyPropertyChanged
    {
        #region	Propriete(s) complete(s)
        private Rectangle _position;

        public Rectangle position
        {
            get { return _position; }
            set
            {
                _position = value;
                thePictureBox.Bounds = position;
            }
        }

        private PictureBox _thePictureBox;

        public PictureBox thePictureBox
        {
            get { return _thePictureBox; }
            set 
            { 
                _thePictureBox = value;
                position = _thePictureBox.Bounds;
            }
        }
        #endregion

        public bool voisinage(ElementDuJeu cible)
        {
            Rectangle range = position;

            range.Inflate(position.Size);

            return range.IntersectsWith(cible.position);
        }
    }

    public abstract class Personnage : ElementDuJeu
    {
        #region	Propriete(s) complete(s)
        private int _pointsDeVie=-1;

        public int pointsDeVie
        {
            get { return _pointsDeVie; }
            set 
            {

                int ancienneVal = _pointsDeVie;

                    if (value <= 0)
                        value = 0;
                    
                
                    _pointsDeVie = value;
                    if (ancienneVal != -1)
                    {
                        VieChangee(this, _pointsDeVie);
                    }
                               
                       
                    
               


            }
        }

        private int _force;

        public int force
        {
            get { return _force; }
            set { _force = value; }
        }
        #endregion       

        #region	Evennements
        public event PersoDeplaceHandler Deplacement;
        public event PersoAttaqueHandler Attaque;
        public event PersoHealthChangeHandler VieChangee;

        #endregion

        public void deplacer(Direction dir)
        {
            Deplacement(this, dir);
        }

        public void attaquer()
        {
            Attaque(this, force);
        }
    }

    public class Joueur : Personnage
    {
        public List<Artefact> sac { get; set; }
        public int throwingDistance { get; set; }

        public event Action actionPrendreAF;

        #region	Propriete(s) complete(s)
        private Artefact _AFSelectionne;    // il faut que je rend les images de la liste puisse etre selectionne 

        public Artefact AFSelectionne
        {
            get { return _AFSelectionne; }
            set { _AFSelectionne = value;}
        }

        private int _agilite;

        public int agilite
        {
            get { return _agilite; }
            set { _agilite = value; }
        }

        private int _pointsEndurance;

        public int pointsEndurance
        {
            get { return _pointsEndurance; }
            set { _pointsEndurance = value; }
        #endregion
        }

        public void prendreArtefact()
        {
            actionPrendreAF();
        }
    }

    public class Ennemi : Personnage
    {
        public string nom { get; set; }
        public int scoreEnnemi { get; set; }

        public void deplacerAI(Joueur leJoueur)
        {
            int distance = 200; //Distance de voisinage verifie pour prendre la decision du mouvement
            Thread.Sleep(1);
            Random rand = new Random();
            int dir;

            List<int> values = new List<int>() { 0, 0, 0, 0 };
            Point centerEnnemi = new Point((this.position.X) + 28, (this.position.Y) + 33);
            Point centerJoueur = new Point((leJoueur.position.X) + 28, (leJoueur.position.Y) + 33);

            values[0] = +centerEnnemi.Y - centerJoueur.Y;
            values[1] = -centerEnnemi.X + centerJoueur.X;
            values[2] = -centerEnnemi.Y + centerJoueur.Y;
            values[3] = +centerEnnemi.X - centerJoueur.X;
            int dirInt = values.IndexOf(values.Max());

            if (values.Max() <= distance)
                dir = dirInt;
            else
                dir = rand.Next(4);

            switch (dir)
            {
                case 0:
                    deplacer(Direction.HAUT);
                    break;
                case 1:
                    deplacer(Direction.DROITE);
                    break;
                case 2:
                    deplacer(Direction.BAS);
                    break;
                case 3:
                    deplacer(Direction.GAUCHE);
                    break;
            }
        }
        public void deplacerRandomDir()
        {
            Thread.Sleep(1);
            Random rand = new Random();

            int dir = rand.Next(4);

            switch (dir)
            {
                case 0:
                    deplacer(Direction.HAUT);
                    break;
                case 1:
                    deplacer(Direction.DROITE);
                    break;
                case 2:
                    deplacer(Direction.BAS);
                    break;
                case 3:
                    deplacer(Direction.GAUCHE);
                    break;
            }
        }
    }

    public class Artefact : ElementDuJeu
    {
        public int pointsAttribues { get; set; }
        public int scoreArtefact { get; set; }
    }
}