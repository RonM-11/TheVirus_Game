namespace MyGame_RonM
{
    partial class FormTie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTie));
            this.labelTie = new System.Windows.Forms.Label();
            this.pictureBoxRedVirusWin = new System.Windows.Forms.PictureBox();
            this.pictureBoxGreenVirusWin = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirusWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirusWin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTie
            // 
            this.labelTie.AutoSize = true;
            this.labelTie.BackColor = System.Drawing.Color.Transparent;
            this.labelTie.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTie.Location = new System.Drawing.Point(78, 104);
            this.labelTie.Name = "labelTie";
            this.labelTie.Size = new System.Drawing.Size(320, 79);
            this.labelTie.TabIndex = 1;
            this.labelTie.Text = "It\'s A Tie";
            // 
            // pictureBoxRedVirusWin
            // 
            this.pictureBoxRedVirusWin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRedVirusWin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRedVirusWin.BackgroundImage")));
            this.pictureBoxRedVirusWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRedVirusWin.Location = new System.Drawing.Point(243, 186);
            this.pictureBoxRedVirusWin.Name = "pictureBoxRedVirusWin";
            this.pictureBoxRedVirusWin.Size = new System.Drawing.Size(187, 171);
            this.pictureBoxRedVirusWin.TabIndex = 2;
            this.pictureBoxRedVirusWin.TabStop = false;
            // 
            // pictureBoxGreenVirusWin
            // 
            this.pictureBoxGreenVirusWin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGreenVirusWin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGreenVirusWin.BackgroundImage")));
            this.pictureBoxGreenVirusWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGreenVirusWin.Location = new System.Drawing.Point(77, 186);
            this.pictureBoxGreenVirusWin.Name = "pictureBoxGreenVirusWin";
            this.pictureBoxGreenVirusWin.Size = new System.Drawing.Size(160, 171);
            this.pictureBoxGreenVirusWin.TabIndex = 3;
            this.pictureBoxGreenVirusWin.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(77, 78);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseClick);
            // 
            // FormTie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxGreenVirusWin);
            this.Controls.Add(this.pictureBoxRedVirusWin);
            this.Controls.Add(this.labelTie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormTie";
            this.Text = "Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTie_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FormTie_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirusWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirusWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTie;
        private System.Windows.Forms.PictureBox pictureBoxRedVirusWin;
        private System.Windows.Forms.PictureBox pictureBoxGreenVirusWin;
        private System.Windows.Forms.Button buttonExit;
    }
}