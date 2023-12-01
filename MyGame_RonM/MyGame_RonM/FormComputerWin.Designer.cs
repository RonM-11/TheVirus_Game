namespace MyGame_RonM
{
    partial class FormComputerWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComputerWin));
            this.labelTie = new System.Windows.Forms.Label();
            this.pictureBoxGreenVirusWin = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirusWin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTie
            // 
            this.labelTie.AutoSize = true;
            this.labelTie.BackColor = System.Drawing.Color.Transparent;
            this.labelTie.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTie.Location = new System.Drawing.Point(21, 93);
            this.labelTie.Name = "labelTie";
            this.labelTie.Size = new System.Drawing.Size(439, 60);
            this.labelTie.TabIndex = 0;
            this.labelTie.Text = "Computer Won!";
            // 
            // pictureBoxGreenVirusWin
            // 
            this.pictureBoxGreenVirusWin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGreenVirusWin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGreenVirusWin.BackgroundImage")));
            this.pictureBoxGreenVirusWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGreenVirusWin.Location = new System.Drawing.Point(159, 156);
            this.pictureBoxGreenVirusWin.Name = "pictureBoxGreenVirusWin";
            this.pictureBoxGreenVirusWin.Size = new System.Drawing.Size(183, 193);
            this.pictureBoxGreenVirusWin.TabIndex = 1;
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
            // FormComputerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxGreenVirusWin);
            this.Controls.Add(this.labelTie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormComputerWin";
            this.Text = "FormComputerWin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComputerWin_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FormComputerWin_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreenVirusWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTie;
        private System.Windows.Forms.PictureBox pictureBoxGreenVirusWin;
        private System.Windows.Forms.Button buttonExit;
    }
}