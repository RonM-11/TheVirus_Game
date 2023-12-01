namespace MyGame_RonM
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonIntructions = new System.Windows.Forms.Button();
            this.pictureBoxTheVirusLogo = new System.Windows.Forms.PictureBox();
            this.buttonTableOfRecords = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheVirusLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.AutoSize = true;
            this.buttonNewGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNewGame.BackgroundImage")));
            this.buttonNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.ForeColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.Location = new System.Drawing.Point(67, 278);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(158, 160);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseClick);
            // 
            // buttonIntructions
            // 
            this.buttonIntructions.BackColor = System.Drawing.Color.Transparent;
            this.buttonIntructions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonIntructions.BackgroundImage")));
            this.buttonIntructions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonIntructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIntructions.ForeColor = System.Drawing.Color.Transparent;
            this.buttonIntructions.Location = new System.Drawing.Point(253, 278);
            this.buttonIntructions.Name = "buttonIntructions";
            this.buttonIntructions.Size = new System.Drawing.Size(175, 164);
            this.buttonIntructions.TabIndex = 1;
            this.buttonIntructions.UseVisualStyleBackColor = false;
            this.buttonIntructions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonIntructions_MouseClick);
            // 
            // pictureBoxTheVirusLogo
            // 
            this.pictureBoxTheVirusLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTheVirusLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheVirusLogo.BackgroundImage")));
            this.pictureBoxTheVirusLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTheVirusLogo.Location = new System.Drawing.Point(228, 46);
            this.pictureBoxTheVirusLogo.Name = "pictureBoxTheVirusLogo";
            this.pictureBoxTheVirusLogo.Size = new System.Drawing.Size(236, 206);
            this.pictureBoxTheVirusLogo.TabIndex = 2;
            this.pictureBoxTheVirusLogo.TabStop = false;
            // 
            // buttonTableOfRecords
            // 
            this.buttonTableOfRecords.BackColor = System.Drawing.Color.Transparent;
            this.buttonTableOfRecords.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTableOfRecords.BackgroundImage")));
            this.buttonTableOfRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTableOfRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTableOfRecords.ForeColor = System.Drawing.Color.Transparent;
            this.buttonTableOfRecords.Location = new System.Drawing.Point(452, 276);
            this.buttonTableOfRecords.Name = "buttonTableOfRecords";
            this.buttonTableOfRecords.Size = new System.Drawing.Size(175, 164);
            this.buttonTableOfRecords.TabIndex = 3;
            this.buttonTableOfRecords.UseVisualStyleBackColor = false;
            this.buttonTableOfRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonTableOfRecords_MouseClick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(734, 575);
            this.Controls.Add(this.buttonTableOfRecords);
            this.Controls.Add(this.pictureBoxTheVirusLogo);
            this.Controls.Add(this.buttonIntructions);
            this.Controls.Add(this.buttonNewGame);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.SizeChanged += new System.EventHandler(this.Game_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheVirusLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonIntructions;
        private System.Windows.Forms.PictureBox pictureBoxTheVirusLogo;
        private System.Windows.Forms.Button buttonTableOfRecords;
    }
}

