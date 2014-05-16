namespace TP_JeuDungeon.PL
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelXquit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTerrainBackground = new System.Windows.Forms.Panel();
            this.pnlTerrainLimites = new System.Windows.Forms.Panel();
            this.pnlParchemJoueur = new System.Windows.Forms.Panel();
            this.pnlDonneesJoueur = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.labelNBscore = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelNBniveau = new System.Windows.Forms.Label();
            this.labelNiveau = new System.Windows.Forms.Label();
            this.progBarAgilite = new System.Windows.Forms.ProgressBar();
            this.progBarForce = new System.Windows.Forms.ProgressBar();
            this.progBarEndurance = new System.Windows.Forms.ProgressBar();
            this.progBarVie = new System.Windows.Forms.ProgressBar();
            this.labelEndurance = new System.Windows.Forms.Label();
            this.labelAgilite = new System.Windows.Forms.Label();
            this.labelForce = new System.Windows.Forms.Label();
            this.labelVie = new System.Windows.Forms.Label();
            this.flpnl_Sac = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDirections = new System.Windows.Forms.Panel();
            this.panelFlecheGauche = new System.Windows.Forms.Panel();
            this.panelFlecheDroite = new System.Windows.Forms.Panel();
            this.panelFlecheBas = new System.Windows.Forms.Panel();
            this.panelFlecheHaut = new System.Windows.Forms.Panel();
            this.tm_affich = new System.Windows.Forms.Timer(this.components);
            this.imageAvoir = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlTerrainBackground.SuspendLayout();
            this.pnlParchemJoueur.SuspendLayout();
            this.pnlDonneesJoueur.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panelDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAvoir)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 800;
            this.timer.Tick += new System.EventHandler(this.timedActions);
            // 
            // labelXquit
            // 
            this.labelXquit.AutoSize = true;
            this.labelXquit.BackColor = System.Drawing.Color.Transparent;
            this.labelXquit.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXquit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(1)))), ((int)(((byte)(0)))));
            this.labelXquit.Location = new System.Drawing.Point(21, 15);
            this.labelXquit.Name = "labelXquit";
            this.labelXquit.Size = new System.Drawing.Size(58, 62);
            this.labelXquit.TabIndex = 1;
            this.labelXquit.Text = "X";
            this.labelXquit.Click += new System.EventHandler(this.labelXquit_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::TP_JeuDungeon.Properties.Resources.boutonOr2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelXquit);
            this.panel1.Location = new System.Drawing.Point(25, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 93);
            this.panel1.TabIndex = 9;
            // 
            // pnlTerrainBackground
            // 
            this.pnlTerrainBackground.BackColor = System.Drawing.Color.Transparent;
            this.pnlTerrainBackground.BackgroundImage = global::TP_JeuDungeon.Properties.Resources.terrain11;
            this.pnlTerrainBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTerrainBackground.Controls.Add(this.pnlTerrainLimites);
            this.pnlTerrainBackground.Location = new System.Drawing.Point(119, 16);
            this.pnlTerrainBackground.Name = "pnlTerrainBackground";
            this.pnlTerrainBackground.Size = new System.Drawing.Size(960, 540);
            this.pnlTerrainBackground.TabIndex = 10;
            // 
            // pnlTerrainLimites
            // 
            this.pnlTerrainLimites.BackColor = System.Drawing.Color.Transparent;
            this.pnlTerrainLimites.Location = new System.Drawing.Point(110, 98);
            this.pnlTerrainLimites.Name = "pnlTerrainLimites";
            this.pnlTerrainLimites.Size = new System.Drawing.Size(730, 390);
            this.pnlTerrainLimites.TabIndex = 2;
            // 
            // pnlParchemJoueur
            // 
            this.pnlParchemJoueur.BackColor = System.Drawing.Color.Transparent;
            this.pnlParchemJoueur.BackgroundImage = global::TP_JeuDungeon.Properties.Resources.parchemin3;
            this.pnlParchemJoueur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlParchemJoueur.Controls.Add(this.pnlDonneesJoueur);
            this.pnlParchemJoueur.Location = new System.Drawing.Point(119, 534);
            this.pnlParchemJoueur.Name = "pnlParchemJoueur";
            this.pnlParchemJoueur.Size = new System.Drawing.Size(785, 186);
            this.pnlParchemJoueur.TabIndex = 11;
            // 
            // pnlDonneesJoueur
            // 
            this.pnlDonneesJoueur.BackColor = System.Drawing.Color.Transparent;
            this.pnlDonneesJoueur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDonneesJoueur.Controls.Add(this.panel22);
            this.pnlDonneesJoueur.Controls.Add(this.flpnl_Sac);
            this.pnlDonneesJoueur.Location = new System.Drawing.Point(4, 3);
            this.pnlDonneesJoueur.Name = "pnlDonneesJoueur";
            this.pnlDonneesJoueur.Size = new System.Drawing.Size(740, 183);
            this.pnlDonneesJoueur.TabIndex = 2;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.labelNBscore);
            this.panel22.Controls.Add(this.labelScore);
            this.panel22.Controls.Add(this.labelNBniveau);
            this.panel22.Controls.Add(this.labelNiveau);
            this.panel22.Controls.Add(this.progBarAgilite);
            this.panel22.Controls.Add(this.progBarForce);
            this.panel22.Controls.Add(this.progBarEndurance);
            this.panel22.Controls.Add(this.progBarVie);
            this.panel22.Controls.Add(this.labelEndurance);
            this.panel22.Controls.Add(this.labelAgilite);
            this.panel22.Controls.Add(this.labelForce);
            this.panel22.Controls.Add(this.labelVie);
            this.panel22.Location = new System.Drawing.Point(453, 24);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(281, 140);
            this.panel22.TabIndex = 16;
            // 
            // labelNBscore
            // 
            this.labelNBscore.AutoSize = true;
            this.labelNBscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNBscore.ForeColor = System.Drawing.Color.Maroon;
            this.labelNBscore.Location = new System.Drawing.Point(191, 6);
            this.labelNBscore.Name = "labelNBscore";
            this.labelNBscore.Size = new System.Drawing.Size(0, 31);
            this.labelNBscore.TabIndex = 11;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.Maroon;
            this.labelScore.Location = new System.Drawing.Point(143, 15);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(44, 16);
            this.labelScore.TabIndex = 10;
            this.labelScore.Text = "Score";
            // 
            // labelNBniveau
            // 
            this.labelNBniveau.AutoSize = true;
            this.labelNBniveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNBniveau.ForeColor = System.Drawing.Color.Maroon;
            this.labelNBniveau.Location = new System.Drawing.Point(72, 11);
            this.labelNBniveau.Name = "labelNBniveau";
            this.labelNBniveau.Size = new System.Drawing.Size(20, 24);
            this.labelNBniveau.TabIndex = 9;
            this.labelNBniveau.Text = "3";
            // 
            // labelNiveau
            // 
            this.labelNiveau.AutoSize = true;
            this.labelNiveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNiveau.ForeColor = System.Drawing.Color.Maroon;
            this.labelNiveau.Location = new System.Drawing.Point(18, 15);
            this.labelNiveau.Name = "labelNiveau";
            this.labelNiveau.Size = new System.Drawing.Size(51, 16);
            this.labelNiveau.TabIndex = 8;
            this.labelNiveau.Text = "Niveau";
            // 
            // progBarAgilite
            // 
            this.progBarAgilite.BackColor = System.Drawing.Color.Sienna;
            this.progBarAgilite.Location = new System.Drawing.Point(80, 105);
            this.progBarAgilite.Name = "progBarAgilite";
            this.progBarAgilite.Size = new System.Drawing.Size(197, 15);
            this.progBarAgilite.TabIndex = 7;
            this.progBarAgilite.Value = 50;
            // 
            // progBarForce
            // 
            this.progBarForce.BackColor = System.Drawing.Color.Sienna;
            this.progBarForce.Location = new System.Drawing.Point(80, 84);
            this.progBarForce.Name = "progBarForce";
            this.progBarForce.Size = new System.Drawing.Size(197, 15);
            this.progBarForce.TabIndex = 6;
            this.progBarForce.Value = 50;
            // 
            // progBarEndurance
            // 
            this.progBarEndurance.BackColor = System.Drawing.Color.Sienna;
            this.progBarEndurance.Location = new System.Drawing.Point(80, 63);
            this.progBarEndurance.Name = "progBarEndurance";
            this.progBarEndurance.Size = new System.Drawing.Size(197, 15);
            this.progBarEndurance.TabIndex = 5;
            this.progBarEndurance.Value = 100;
            // 
            // progBarVie
            // 
            this.progBarVie.BackColor = System.Drawing.Color.Sienna;
            this.progBarVie.ForeColor = System.Drawing.Color.Maroon;
            this.progBarVie.Location = new System.Drawing.Point(80, 42);
            this.progBarVie.Name = "progBarVie";
            this.progBarVie.Size = new System.Drawing.Size(197, 15);
            this.progBarVie.TabIndex = 4;
            this.progBarVie.Value = 50;
            // 
            // labelEndurance
            // 
            this.labelEndurance.AutoSize = true;
            this.labelEndurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndurance.ForeColor = System.Drawing.Color.Maroon;
            this.labelEndurance.Location = new System.Drawing.Point(1, 63);
            this.labelEndurance.Name = "labelEndurance";
            this.labelEndurance.Size = new System.Drawing.Size(73, 16);
            this.labelEndurance.TabIndex = 3;
            this.labelEndurance.Text = "Endurance";
            // 
            // labelAgilite
            // 
            this.labelAgilite.AutoSize = true;
            this.labelAgilite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgilite.ForeColor = System.Drawing.Color.Maroon;
            this.labelAgilite.Location = new System.Drawing.Point(24, 104);
            this.labelAgilite.Name = "labelAgilite";
            this.labelAgilite.Size = new System.Drawing.Size(45, 16);
            this.labelAgilite.TabIndex = 2;
            this.labelAgilite.Text = "Agilité";
            // 
            // labelForce
            // 
            this.labelForce.AutoSize = true;
            this.labelForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForce.ForeColor = System.Drawing.Color.Maroon;
            this.labelForce.Location = new System.Drawing.Point(26, 83);
            this.labelForce.Name = "labelForce";
            this.labelForce.Size = new System.Drawing.Size(43, 16);
            this.labelForce.TabIndex = 1;
            this.labelForce.Text = "Force";
            // 
            // labelVie
            // 
            this.labelVie.AutoSize = true;
            this.labelVie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVie.ForeColor = System.Drawing.Color.Maroon;
            this.labelVie.Location = new System.Drawing.Point(41, 41);
            this.labelVie.Name = "labelVie";
            this.labelVie.Size = new System.Drawing.Size(28, 16);
            this.labelVie.TabIndex = 0;
            this.labelVie.Text = "Vie";
            // 
            // flpnl_Sac
            // 
            this.flpnl_Sac.Location = new System.Drawing.Point(58, 24);
            this.flpnl_Sac.Name = "flpnl_Sac";
            this.flpnl_Sac.Size = new System.Drawing.Size(379, 140);
            this.flpnl_Sac.TabIndex = 15;
            // 
            // panelDirections
            // 
            this.panelDirections.BackColor = System.Drawing.Color.Transparent;
            this.panelDirections.BackgroundImage = global::TP_JeuDungeon.Properties.Resources.deplacement;
            this.panelDirections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDirections.Controls.Add(this.panelFlecheGauche);
            this.panelDirections.Controls.Add(this.panelFlecheDroite);
            this.panelDirections.Controls.Add(this.panelFlecheBas);
            this.panelDirections.Controls.Add(this.panelFlecheHaut);
            this.panelDirections.Location = new System.Drawing.Point(910, 568);
            this.panelDirections.Name = "panelDirections";
            this.panelDirections.Size = new System.Drawing.Size(169, 151);
            this.panelDirections.TabIndex = 12;
            // 
            // panelFlecheGauche
            // 
            this.panelFlecheGauche.Location = new System.Drawing.Point(0, 47);
            this.panelFlecheGauche.Name = "panelFlecheGauche";
            this.panelFlecheGauche.Size = new System.Drawing.Size(55, 40);
            this.panelFlecheGauche.TabIndex = 3;
            this.panelFlecheGauche.Click += new System.EventHandler(this.clickGauche);
            // 
            // panelFlecheDroite
            // 
            this.panelFlecheDroite.Location = new System.Drawing.Point(105, 47);
            this.panelFlecheDroite.Name = "panelFlecheDroite";
            this.panelFlecheDroite.Size = new System.Drawing.Size(55, 40);
            this.panelFlecheDroite.TabIndex = 2;
            this.panelFlecheDroite.Click += new System.EventHandler(this.clickDroite);
            // 
            // panelFlecheBas
            // 
            this.panelFlecheBas.Location = new System.Drawing.Point(59, 82);
            this.panelFlecheBas.Name = "panelFlecheBas";
            this.panelFlecheBas.Size = new System.Drawing.Size(40, 55);
            this.panelFlecheBas.TabIndex = 1;
            this.panelFlecheBas.Click += new System.EventHandler(this.clickBas);
            // 
            // panelFlecheHaut
            // 
            this.panelFlecheHaut.Location = new System.Drawing.Point(59, 0);
            this.panelFlecheHaut.Name = "panelFlecheHaut";
            this.panelFlecheHaut.Size = new System.Drawing.Size(40, 55);
            this.panelFlecheHaut.TabIndex = 0;
            this.panelFlecheHaut.Click += new System.EventHandler(this.clickHaut);
            // 
            // tm_affich
            // 
            this.tm_affich.Enabled = true;
            this.tm_affich.Tick += new System.EventHandler(this.tm_affich_Tick);
            // 
            // imageAvoir
            // 
            this.imageAvoir.BackColor = System.Drawing.Color.Transparent;
            this.imageAvoir.Location = new System.Drawing.Point(25, 181);
            this.imageAvoir.Name = "imageAvoir";
            this.imageAvoir.Size = new System.Drawing.Size(33, 26);
            this.imageAvoir.TabIndex = 14;
            this.imageAvoir.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_JeuDungeon.Properties.Resources.Parchemin2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1196, 725);
            this.ControlBox = false;
            this.Controls.Add(this.imageAvoir);
            this.Controls.Add(this.panelDirections);
            this.Controls.Add(this.pnlParchemJoueur);
            this.Controls.Add(this.pnlTerrainBackground);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.Load += new System.EventHandler(this.onLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTerrainBackground.ResumeLayout(false);
            this.pnlParchemJoueur.ResumeLayout(false);
            this.pnlDonneesJoueur.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panelDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageAvoir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelXquit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTerrainBackground;
        private System.Windows.Forms.Panel pnlTerrainLimites;
        private System.Windows.Forms.Panel pnlParchemJoueur;
        private System.Windows.Forms.Panel pnlDonneesJoueur;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label labelNBscore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelNBniveau;
        private System.Windows.Forms.Label labelNiveau;
        private System.Windows.Forms.Label labelEndurance;
        private System.Windows.Forms.Label labelAgilite;
        private System.Windows.Forms.Label labelForce;
        private System.Windows.Forms.Label labelVie;
        private System.Windows.Forms.FlowLayoutPanel flpnl_Sac;
        private System.Windows.Forms.Panel panelDirections;
        private System.Windows.Forms.Panel panelFlecheGauche;
        private System.Windows.Forms.Panel panelFlecheDroite;
        private System.Windows.Forms.Panel panelFlecheBas;
        private System.Windows.Forms.Panel panelFlecheHaut;
        public System.Windows.Forms.ProgressBar progBarAgilite;
        public System.Windows.Forms.ProgressBar progBarForce;
        public System.Windows.Forms.ProgressBar progBarEndurance;
        public System.Windows.Forms.ProgressBar progBarVie;
        private System.Windows.Forms.Timer tm_affich;
        private System.Windows.Forms.PictureBox imageAvoir;
    }
}

