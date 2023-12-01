namespace MyGame_RonM
{
    partial class IntructionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntructionsForm));
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.pictureBoxFullInstructions = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBoxRedVirus = new System.Windows.Forms.PictureBox();
            this.pictureBoxGreenVirus = new System.Windows.Forms.PictureBox();
            this.buttonArrowRight = new System.Windows.Forms.Button();
            this.buttonArrowLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFullInstructions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirus)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNewGame.BackgroundImage")));
            this.buttonNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.ForeColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.Location = new System.Drawing.Point(3, 3);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(100, 108);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNewGame_MouseClick);
            // 
            // pictureBoxFullInstructions
            // 
            this.pictureBoxFullInstructions.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFullInstructions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFullInstructions.BackgroundImage")));
            this.pictureBoxFullInstructions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxFullInstructions.Location = new System.Drawing.Point(194, 143);
            this.pictureBoxFullInstructions.Name = "pictureBoxFullInstructions";
            this.pictureBoxFullInstructions.Size = new System.Drawing.Size(330, 316);
            this.pictureBoxFullInstructions.TabIndex = 1;
            this.pictureBoxFullInstructions.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(572, 492);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(102, 101);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseClick);
            // 
            // pictureBoxRedVirus
            // 
            this.pictureBoxRedVirus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRedVirus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRedVirus.BackgroundImage")));
            this.pictureBoxRedVirus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRedVirus.Location = new System.Drawing.Point(519, 28);
            this.pictureBoxRedVirus.Name = "pictureBoxRedVirus";
            this.pictureBoxRedVirus.Size = new System.Drawing.Size(103, 83);
            this.pictureBoxRedVirus.TabIndex = 3;
            this.pictureBoxRedVirus.TabStop = false;
            // 
            // pictureBoxGreenVirus
            // 
            this.pictureBoxGreenVirus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGreenVirus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGreenVirus.BackgroundImage")));
            this.pictureBoxGreenVirus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGreenVirus.Location = new System.Drawing.Point(12, 483);
            this.pictureBoxGreenVirus.Name = "pictureBoxGreenVirus";
            this.pictureBoxGreenVirus.Size = new System.Drawing.Size(78, 85);
            this.pictureBoxGreenVirus.TabIndex = 4;
            this.pictureBoxGreenVirus.TabStop = false;
            // 
            // buttonArrowRight
            // 
            this.buttonArrowRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonArrowRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArrowRight.BackgroundImage")));
            this.buttonArrowRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonArrowRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArrowRight.Location = new System.Drawing.Point(424, 465);
            this.buttonArrowRight.Name = "buttonArrowRight";
            this.buttonArrowRight.Size = new System.Drawing.Size(100, 70);
            this.buttonArrowRight.TabIndex = 5;
            this.buttonArrowRight.UseVisualStyleBackColor = false;
            this.buttonArrowRight.Click += new System.EventHandler(this.buttonArrowRight_Click);
            // 
            // buttonArrowLeft
            // 
            this.buttonArrowLeft.BackColor = System.Drawing.Color.Transparent;
            this.buttonArrowLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArrowLeft.BackgroundImage")));
            this.buttonArrowLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonArrowLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArrowLeft.Location = new System.Drawing.Point(194, 465);
            this.buttonArrowLeft.Name = "buttonArrowLeft";
            this.buttonArrowLeft.Size = new System.Drawing.Size(100, 70);
            this.buttonArrowLeft.TabIndex = 6;
            this.buttonArrowLeft.UseVisualStyleBackColor = false;
            this.buttonArrowLeft.Click += new System.EventHandler(this.buttonArrowLeft_Click);
            // 
            // IntructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.buttonArrowLeft);
            this.Controls.Add(this.buttonArrowRight);
            this.Controls.Add(this.pictureBoxGreenVirus);
            this.Controls.Add(this.pictureBoxRedVirus);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxFullInstructions);
            this.Controls.Add(this.buttonNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "IntructionsForm";
            this.Text = "IntructionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntructionsForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.IntructionsForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFullInstructions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.PictureBox pictureBoxFullInstructions;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBoxRedVirus;
        private System.Windows.Forms.PictureBox pictureBoxGreenVirus;
        private System.Windows.Forms.Button buttonArrowRight;
        private System.Windows.Forms.Button buttonArrowLeft;
    }
}