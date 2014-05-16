using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Speech;
using System.Speech.Synthesis;

namespace TP_JeuDungeon.BL
{
    public enum Direction { HAUT, DROITE, BAS, GAUCHE }

    #region Les EventArgs

    public class DeplacementEventArgs : EventArgs
    {
        public Direction dir { get; set; }
    }

    public class ArtefactPrisEventArgs : EventArgs
    {
        public Artefact af { get; set; }
    }

    public class AttqueEventArgs : EventArgs
    {
        public int damage { get; set; }
    }

    public class EnnemiMeurt : EventArgs
    {
        public Ennemi lui { get; set; }
    }

    #endregion

    public static class SpecsDuJeu
    {
        #region Sounds
        public static SoundPlayer applause = new SoundPlayer("applause_converted.wav");
        public static SoundPlayer better = new SoundPlayer("better_converted.wav");
        public static SoundPlayer cheering = new SoundPlayer("cheering_converted.wav");
        public static SoundPlayer creakDoor = new SoundPlayer("creakDoor_converted.wav");
        public static SoundPlayer drumRoll = new SoundPlayer("drum_roll_rimshot_converted.wav");
        public static SoundPlayer getStufffloop = new SoundPlayer("floopArtifact_converted.wav");
        public static SoundPlayer flush = new SoundPlayer("flush_y_converted.wav");

        public static void say(string text)
        {
            SpeechSynthesizer talker = new SpeechSynthesizer();
            talker.SpeakAsync(text);
        }
        #endregion
        public static int nv = 1;
        #region Points de vie de base

        public static readonly int pVieBaseJoueur = 100;
        public static readonly int pVieBaseGhoul = 70;
        public static readonly int pVieBaseFantome = 25;
        public static readonly int pVieBaseChauvesouris = 10;

        #endregion

        #region Forces de base

        public static readonly int forceBaseJoueur = 5;
        public static readonly int forceBaseGhoul = 15;
        public static readonly int forceBaseFantome = 10;
        public static readonly int forceBaseChauvesouris = 2;

        public static readonly int forceEpee = 20;
        public static readonly int forceHache = 25;

        #endregion

        public static readonly string[] tabNomElements = { "Ghoul", "Fantome", "Chauve-Souris", "Potion Rouge", "Potion Bleue", "Epee", "Hache" };

        public static readonly int distanceDeDeplacement = 14;

        #region Scores gagnes

        public static readonly int scoreGhoul = 50;
        public static readonly int scoreFantome = 30;
        public static readonly int scoreChauvesouris = 10;
        public static readonly int scoreArtefact = 35;

        #endregion        

        #region Sizes

        public static readonly Size sizePersonnage = new Size(50, 50);
        public static readonly Size sizeArtefact = new Size(35, 35);

        #endregion

        #region Starting positions

        public static readonly Point startLocalJoueur = new Point(680, 160);

        public static readonly List<Point> listStartLocalGhouls = new List<Point> { new Point(0, 25), new Point(0, 150), new Point(0, 275) };

        public static readonly List<Point> listStartLocalBat = new List<Point> { new Point(70, 25), new Point(200, 70), new Point(400, 275), new Point(0, 350) };

        public static readonly List<Point> listStartLocalBluePot = new List<Point> { new Point(100, 325), new Point(450, 150) };

        public static readonly List<Point> listStartLocalRedPot = new List<Point> { new Point(300, 225) };


        #endregion

        #region Autres statistiques du Joueur

        public static readonly int throwingDistance = 100;
        public static readonly int agilite = 100;
        public static readonly int endurance = 100;

        #endregion

        #region Points attribues par les artefacts

        public static readonly int redPotPointsVie = 25;
        public static readonly int bluePotPointsEndurance = 25;
		 
	    #endregion
    }

    public abstract class ElementDuJeu
    {
        #region Les proprietes d'un ElementDuJeu

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private PictureBox _laPicBox;
        public PictureBox laPicBox
        {
            get { return _laPicBox; }
            set
            {
                _laPicBox = value;
                position = laPicBox.Bounds;
            }
        }

        private Rectangle _position;
        public Rectangle position
        {
            get { return _position; }
            set
            {
                _position = value;
                _laPicBox.Bounds = _position;
            }
        }

        #endregion

        #region Les methodes d'un ElementDuJeu

        public bool voisinage(ElementDuJeu cible, Size distanceDeVoisinage)
        {
            Rectangle range = position;

            range.Inflate(distanceDeVoisinage);

            return range.IntersectsWith(cible.position);
        }

        #endregion
    }

    #region Les personnages du jeu

    public abstract class Personnage : ElementDuJeu
    {
        #region Les proprietes d'un Personnage

        private int _pointsDeVie;
        public virtual int pointsDeVie
        {
            get { return _pointsDeVie; }
            set { _pointsDeVie = value; }
        }

        private int _force;
        public virtual int force
        {
            get { return _force; }
            set { _force = value; }
        }

        #endregion

        #region Les methodes d'un Personnage

        public virtual void deplacer(Direction direction)
        {

        }

        public virtual void attaquer()
        {
            
        }

        #endregion
    }

    public class Joueur : Personnage
    {
        #region Les proprietes d'un Joueur

        public override int force
        {
            get { return base.force; }
            set { base.force = value; }
        }

        public override int pointsDeVie
        {
            get { return base.pointsDeVie; }
            set 
            {
                if (value < 0)
                    value = 0;

                base.pointsDeVie = value; 
            }
        }

        private int _agilite;
        public int agilite
        {
            get { return _agilite; }
            set 
            {
                if (value > 100)
                    value = 100;

                _agilite = value;
            }
        }

        private int _pointsEndurance;
        public int pointsEndurance
        {
            get { return _pointsEndurance; }
            set { _pointsEndurance = value; }
        }

        private Artefact _AFSelectionne;
        public Artefact AFSelectionne
        {
            get { return _AFSelectionne; }
            set
            {
                _AFSelectionne = value;
            }
        }

        public int throwingRange { get; set; }

        public List<Artefact> sac { get; set; }

        #endregion

        #region Constructeur(s) d'un Joueur

        public Joueur()
        {
            sac = new List<Artefact>();
        }

        #endregion

        #region Les methodes d'un Joueur

        public override void deplacer(Direction direction)
        {
            deplace(this, new DeplacementEventArgs { dir = direction });
        }

        public override void attaquer()
        {
            attaque(this, new AttqueEventArgs { damage = force });
        }

        public void prendreArtefact()
        {
            prendreArtefactEvent(this, new EventArgs());          
        }

        //changement
        public void selectionnerArtefact(Artefact AF)
        {
            if (_AFSelectionne != null)
                AFSelectionne.estSelectionee = false;

            AFSelectionne = AF;

            if (AFSelectionne.nom.Equals(SpecsDuJeu.tabNomElements[4]))
                agilite += AFSelectionne.pointsAttribues;       // om ajoute les propriete


            if (AFSelectionne.nom.Equals(SpecsDuJeu.tabNomElements[3]))            
                force = AFSelectionne.pointsAttribues;
            
            AFSelectionne.estSelectionee = true;

            //selectionneUnArtefact(this, new ArtefactPrisEventArgs { af = AFSelectionne });
        }

        #endregion

        #region Les event d'un Joueur

        public event EventHandler<DeplacementEventArgs> deplace;
        public event EventHandler<AttqueEventArgs> attaque;
        public event EventHandler prendreArtefactEvent;

        #endregion
     }

    public class Ennemi : Personnage
    {
        #region Les proprietes d'un Ennemi

        public override int pointsDeVie
        {
            get { return base.pointsDeVie; }
            set
            {
                if (value < 0)
                    value = 0;

                base.pointsDeVie = value;
            }
        }

        public int scoreGagne { get; set; }
        public int enduranceGagnee { get; set; }

        #endregion

        #region Les methodes d'un Ennemi

        public override void deplacer(Direction direction)
        {
            deplace(this, new DeplacementEventArgs { dir = direction });
        }

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

        public override void attaquer()
        {
            attaque(this, new AttqueEventArgs { damage = force });
        }

        #endregion

        #region Les events d'un Ennemi
        
        public event EventHandler<DeplacementEventArgs> deplace;
        //public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<AttqueEventArgs> attaque;
        
        #endregion

    }

    #endregion

    #region Les artefacts (potions et armes) du jeu

    public class Artefact : ElementDuJeu
    {
        #region Les proprietes d'un Artefact

        private bool _estSelectionnee;
        public bool estSelectionee
        {
            get { return _estSelectionnee; }
            set { _estSelectionnee = value; }
        }

        public int pointsAttribues { get; set; }
        public int scoreGagne { get; set; }

        #endregion
    }

    #endregion

    public class Jeu
    {
        #region Les proprietes d'un Jeu

        public Rectangle terrain { get; set; }
        public List<Ennemi> lstEnnemi { get; set; }
        public List<Artefact> lstArtefact { get; set; }
        public Joueur jiface { get; set; }

        public List<Ennemi> lstEnnemiMort { get; set; }

        #endregion

        #region Constructeur(s) d'un Jeu

        public Jeu()
        {
            lstEnnemi = new List<Ennemi>();
            lstArtefact = new List<Artefact>();
            lstEnnemiMort = new List<Ennemi>();

            initJeu();
        }

        #endregion

        #region Tests de collisions entre Personnages pour chaque directions

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

        #region Test pour superposition entre Joueur et Artefacts

        public Artefact joueurSurArtefact()
        {
            var artefactFiltre = from art in lstArtefact
                                 where jiface.position.Contains(art.position)
                                 select art;

            return artefactFiltre.Count() > 0 ? artefactFiltre.First() : null;
        }

        #endregion

        #region Les methodes d'un Jeu

        public void jouerLesGhouls()
        {
            foreach (var item in lstEnnemi)
            {
                if (item.nom.Equals(SpecsDuJeu.tabNomElements[0]))
                    item.deplacerAI(jiface);
                else if (item.nom.Equals(SpecsDuJeu.tabNomElements[2]))
                    item.deplacerRandomDir();
            }
        }

        private void initJoueur()
        {
            jiface = new Joueur
            {
                sac = new List<Artefact>(),
                throwingRange = SpecsDuJeu.throwingDistance,
                agilite = SpecsDuJeu.agilite - SpecsDuJeu.agilite,
                force = SpecsDuJeu.forceBaseJoueur,
                pointsDeVie = SpecsDuJeu.pVieBaseJoueur,
                pointsEndurance = SpecsDuJeu.endurance,
                laPicBox = new PictureBox
                {
                    Location = SpecsDuJeu.startLocalJoueur,
                    Size = SpecsDuJeu.sizePersonnage,
                    Image = global::TP_JeuDungeon.Properties.Resources.player
                }
            };

            jiface.laPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

            jiface.deplace += persoDeplacement;
            jiface.prendreArtefactEvent += joueurEssaieDePrendreArtefact;
            jiface.attaque += persoAttaque;
        }        

        private void initPotions()
        {
            for (int i = 0; i < SpecsDuJeu.listStartLocalBluePot.Count; i++)
            {
                lstArtefact.Add(new Artefact
                {
                    estSelectionee = false,
                    nom = SpecsDuJeu.tabNomElements[4],
                    scoreGagne = SpecsDuJeu.scoreArtefact,
                    pointsAttribues = SpecsDuJeu.bluePotPointsEndurance,
                    laPicBox = new PictureBox
                    {
                        Location = SpecsDuJeu.listStartLocalBluePot[i],
                        Size = SpecsDuJeu.sizeArtefact,
                        Image = global::TP_JeuDungeon.Properties.Resources.potion_blue
                    }
                });
            }

            for (int i = 0; i < SpecsDuJeu.listStartLocalRedPot.Count; i++)
            {
                lstArtefact.Add(new Artefact
                {
                    estSelectionee = false,
                    nom = SpecsDuJeu.tabNomElements[3],
                    scoreGagne = SpecsDuJeu.scoreArtefact,
                    pointsAttribues = SpecsDuJeu.redPotPointsVie,
                    laPicBox = new PictureBox
                    {
                        Location = SpecsDuJeu.listStartLocalRedPot[i],
                        Size = SpecsDuJeu.sizeArtefact,
                        Image = global::TP_JeuDungeon.Properties.Resources.potion_red
                    }
                });
            }



            foreach (var item in lstArtefact)
            {
                item.laPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void initGhouls(int nb)
        {
            if (nb < 0)
                nb = 0;
            else if (nb > 3)
                nb = 3;

            for (int i = 0; i < nb; i++)
            {
                lstEnnemi.Add(new Ennemi
                {
                    force = SpecsDuJeu.forceBaseGhoul * SpecsDuJeu.nv,
                    nom = SpecsDuJeu.tabNomElements[0],
                    pointsDeVie = SpecsDuJeu.pVieBaseGhoul * SpecsDuJeu.nv,
                    scoreGagne = SpecsDuJeu.scoreGhoul,
                    laPicBox = new PictureBox
                    {
                        Location = SpecsDuJeu.listStartLocalGhouls[i],
                        Size = SpecsDuJeu.sizePersonnage,
                        Image = global::TP_JeuDungeon.Properties.Resources.ghoul
                    }
                });
            }

            foreach (var item in lstEnnemi)
            {
                item.laPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                item.deplace += persoDeplacement;
                item.attaque += persoAttaque;
            }
            
        }

        private void initBats(int nb)
        {
            if (nb < 0)
                nb = 0;
            else if (nb > 3)
                nb = 4;

            for (int i = 0; i < nb; i++)
            {
                lstEnnemi.Add(new Ennemi
                {
                    force = SpecsDuJeu.forceBaseChauvesouris * SpecsDuJeu.nv,
                    nom = SpecsDuJeu.tabNomElements[2],
                    pointsDeVie = SpecsDuJeu.pVieBaseChauvesouris * SpecsDuJeu.nv,
                    scoreGagne = SpecsDuJeu.scoreChauvesouris,
                    laPicBox = new PictureBox
                    {
                        Location = SpecsDuJeu.listStartLocalBat[i],
                        Size = SpecsDuJeu.sizePersonnage,
                        Image = global::TP_JeuDungeon.Properties.Resources.bat
                    }
                });
            }

            foreach (var item in lstEnnemi)
            {
                item.laPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                item.deplace += persoDeplacement;
                item.attaque += persoAttaque;
            }

        }

        public void initJeu()
        {
            initJoueur();

            initGhouls(2);

            initBats(2);

            initPotions();
        }

        #endregion

        #region Reactions aux events

        public void persoDeplacement(object sender, DeplacementEventArgs e)
        {
            int deplacement = SpecsDuJeu.distanceDeDeplacement;

            Direction dir = e.dir;

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

            if (sender is Joueur)
            {
                ((Joueur)sender).prendreArtefact();

                //Random rand = new Random();
                //int att = rand.Next(5);

                //if (att==0)
                ((Joueur)sender).attaquer();
            }
            else if (sender is Ennemi)
                ((Ennemi)sender).attaquer();
        }

        private void joueurEssaieDePrendreArtefact(object sender, EventArgs e)
        {
            Artefact aPrendre = joueurSurArtefact();
            if (aPrendre != null)
            {
                AF_versSac(this, new ArtefactPrisEventArgs { af = aPrendre });

                jiface.sac.Add(aPrendre);
                lstArtefact.Remove(aPrendre);
            }
        }

        private void persoAttaque(object sender, AttqueEventArgs e)
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

            var adversaires = from dude in lst
                              where perso.voisinage(dude, new Size(10,10))
                              select dude;

            foreach (Personnage item in adversaires)
            {
                item.pointsDeVie -= perso.force;

                //essai

                if (item.pointsDeVie == 0)
                {
                    if (item is Ennemi)
                    {
                        killEnnemi(this, new EnnemiMeurt { lui = (Ennemi)item });
                        lstEnnemiMort.Add((Ennemi)item);
                        lstEnnemi.Remove((Ennemi)item);
                    }
                    else
                        killJoueur(this, new EventArgs());
                }
            }
        }

        #endregion

        #region Events du Jeu

        public event EventHandler<ArtefactPrisEventArgs> AF_versSac;
        public event EventHandler<EnnemiMeurt> killEnnemi;
        public event EventHandler killJoueur;

        #endregion
    }

}