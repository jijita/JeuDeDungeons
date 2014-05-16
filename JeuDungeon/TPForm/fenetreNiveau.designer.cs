namespace TP_JeuDungeon
{
    partial class FenetreNiveau
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
            this.label1 = new System.Windows.Forms.Label();
            this.niveau2 = new System.Windows.Forms.Button();
            this.niveau1 = new System.Windows.Forms.Button();
            this.niveau3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(25, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selectionez le niveau du jeu:";
            // 
            // niveau2
            // 
            this.niveau2.Location = new System.Drawing.Point(153, 126);
            this.niveau2.Name = "niveau2";
            this.niveau2.Size = new System.Drawing.Size(58, 59);
            this.niveau2.TabIndex = 1;
            this.niveau2.Text = "2";
            this.niveau2.UseVisualStyleBackColor = true;
            this.niveau2.Click += new System.EventHandler(this.Niveau2_Click);
            // 
            // niveau1
            // 
            this.niveau1.Location = new System.Drawing.Point(69, 126);
            this.niveau1.Name = "niveau1";
            this.niveau1.Size = new System.Drawing.Size(58, 59);
            this.niveau1.TabIndex = 2;
            this.niveau1.Text = "1";
            this.niveau1.UseVisualStyleBackColor = true;
            this.niveau1.Click += new System.EventHandler(this.niveau1_Click);
            // 
            // niveau3
            // 
            this.niveau3.Location = new System.Drawing.Point(236, 126);
            this.niveau3.Name = "niveau3";
            this.niveau3.Size = new System.Drawing.Size(58, 59);
            this.niveau3.TabIndex = 3;
            this.niveau3.Text = "3";
            this.niveau3.UseVisualStyleBackColor = true;
            this.niveau3.Click += new System.EventHandler(this.niveau3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Old English Text MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 57);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dungeon Quest";
            // 
            // FenetreNiveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(368, 197);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.niveau3);
            this.Controls.Add(this.niveau1);
            this.Controls.Add(this.niveau2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FenetreNiveau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button niveau2;
        private System.Windows.Forms.Button niveau1;
        private System.Windows.Forms.Button niveau3;
        private System.Windows.Forms.Label label2;
    }
}