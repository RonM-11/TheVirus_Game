namespace MyGame_RonM
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.buttonPurple = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelVS = new System.Windows.Forms.Label();
            this.labelComputer = new System.Windows.Forms.Label();
            this.pictureBoxRedVirus = new System.Windows.Forms.PictureBox();
            this.pictureBoxGreenVirus = new System.Windows.Forms.PictureBox();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonNewGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirus)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPurple
            // 
            this.buttonPurple.BackColor = System.Drawing.Color.Transparent;
            this.buttonPurple.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPurple.BackgroundImage")));
            this.buttonPurple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPurple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurple.ForeColor = System.Drawing.Color.Black;
            this.buttonPurple.Location = new System.Drawing.Point(825, 166);
            this.buttonPurple.Name = "buttonPurple";
            this.buttonPurple.Size = new System.Drawing.Size(166, 166);
            this.buttonPurple.TabIndex = 0;
            this.buttonPurple.UseVisualStyleBackColor = false;
            this.buttonPurple.Visible = false;
            this.buttonPurple.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPurple_MouseClick);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Transparent;
            this.buttonBlue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBlue.BackgroundImage")));
            this.buttonBlue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBlue.ForeColor = System.Drawing.Color.Black;
            this.buttonBlue.Location = new System.Drawing.Point(825, 333);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(166, 166);
            this.buttonBlue.TabIndex = 1;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Visible = false;
            this.buttonBlue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonBlue_MouseClick);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Transparent;
            this.buttonGreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGreen.BackgroundImage")));
            this.buttonGreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGreen.ForeColor = System.Drawing.Color.Black;
            this.buttonGreen.Location = new System.Drawing.Point(825, 500);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(166, 166);
            this.buttonGreen.TabIndex = 2;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Visible = false;
            this.buttonGreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGreen_MouseClick);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Transparent;
            this.buttonRed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRed.BackgroundImage")));
            this.buttonRed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRed.ForeColor = System.Drawing.Color.Black;
            this.buttonRed.Location = new System.Drawing.Point(825, 666);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(166, 166);
            this.buttonRed.TabIndex = 3;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Visible = false;
            this.buttonRed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRed_MouseClick);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(520, 333);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(203, 46);
            this.labelPlayer.TabIndex = 4;
            this.labelPlayer.Text = "Player:0";
            // 
            // labelVS
            // 
            this.labelVS.AutoSize = true;
            this.labelVS.BackColor = System.Drawing.Color.Transparent;
            this.labelVS.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVS.Location = new System.Drawing.Point(593, 476);
            this.labelVS.Name = "labelVS";
            this.labelVS.Size = new System.Drawing.Size(77, 46);
            this.labelVS.TabIndex = 5;
            this.labelVS.Text = "VS.";
            // 
            // labelComputer
            // 
            this.labelComputer.AutoSize = true;
            this.labelComputer.BackColor = System.Drawing.Color.Transparent;
            this.labelComputer.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComputer.Location = new System.Drawing.Point(482, 606);
            this.labelComputer.Name = "labelComputer";
            this.labelComputer.Size = new System.Drawing.Size(264, 46);
            this.labelComputer.TabIndex = 6;
            this.labelComputer.Text = "Computer:0";
            // 
            // pictureBoxRedVirus
            // 
            this.pictureBoxRedVirus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRedVirus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRedVirus.BackgroundImage")));
            this.pictureBoxRedVirus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRedVirus.Location = new System.Drawing.Point(909, 832);
            this.pictureBoxRedVirus.Name = "pictureBoxRedVirus";
            this.pictureBoxRedVirus.Size = new System.Drawing.Size(128, 111);
            this.pictureBoxRedVirus.TabIndex = 7;
            this.pictureBoxRedVirus.TabStop = false;
            // 
            // pictureBoxGreenVirus
            // 
            this.pictureBoxGreenVirus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGreenVirus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGreenVirus.BackgroundImage")));
            this.pictureBoxGreenVirus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGreenVirus.Location = new System.Drawing.Point(804, 831);
            this.pictureBoxGreenVirus.Name = "pictureBoxGreenVirus";
            this.pictureBoxGreenVirus.Size = new System.Drawing.Size(108, 131);
            this.pictureBoxGreenVirus.TabIndex = 8;
            this.pictureBoxGreenVirus.TabStop = false;
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackColor = System.Drawing.Color.Transparent;
            this.buttonUndo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUndo.BackgroundImage")));
            this.buttonUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Location = new System.Drawing.Point(528, 12);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(70, 69);
            this.buttonUndo.TabIndex = 11;
            this.buttonUndo.UseVisualStyleBackColor = false;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click_1);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNewGame.BackgroundImage")));
            this.buttonNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNewGame.Location = new System.Drawing.Point(605, 16);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(65, 65);
            this.buttonNewGame.TabIndex = 12;
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1094, 882);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.pictureBoxGreenVirus);
            this.Controls.Add(this.pictureBoxRedVirus);
            this.Controls.Add(this.labelComputer);
            this.Controls.Add(this.labelVS);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonPurple);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MinimumSize = new System.Drawing.Size(1100, 858);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Shown += new System.EventHandler(this.FormGame_Shown);
            this.SizeChanged += new System.EventHandler(this.FormGame_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormGame_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonRed;
        protected System.Windows.Forms.Button buttonPurple;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelVS;
        private System.Windows.Forms.Label labelComputer;
        private System.Windows.Forms.PictureBox pictureBoxRedVirus;
        private System.Windows.Forms.PictureBox pictureBoxGreenVirus;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonNewGame;
    }
}