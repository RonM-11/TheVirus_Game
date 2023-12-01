namespace MyGame_RonM
{
    partial class FormPlayerWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayerWin));
            this.labelWin = new System.Windows.Forms.Label();
            this.pictureBoxRedVirusWin = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirusWin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.BackColor = System.Drawing.Color.Transparent;
            this.labelWin.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWin.Location = new System.Drawing.Point(64, 93);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(361, 60);
            this.labelWin.TabIndex = 0;
            this.labelWin.Text = "Player Won!";
            // 
            // pictureBoxRedVirusWin
            // 
            this.pictureBoxRedVirusWin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRedVirusWin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRedVirusWin.BackgroundImage")));
            this.pictureBoxRedVirusWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRedVirusWin.Location = new System.Drawing.Point(133, 146);
            this.pictureBoxRedVirusWin.Name = "pictureBoxRedVirusWin";
            this.pictureBoxRedVirusWin.Size = new System.Drawing.Size(244, 214);
            this.pictureBoxRedVirusWin.TabIndex = 1;
            this.pictureBoxRedVirusWin.TabStop = false;
            this.pictureBoxRedVirusWin.SizeChanged += new System.EventHandler(this.pictureBoxRedVirusWin_SizeChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(3, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(77, 78);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonExit_MouseClick);
            // 
            // FormPlayerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxRedVirusWin);
            this.Controls.Add(this.labelWin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormPlayerWin";
            this.Text = "FormPlayerWin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlayerWin_FormClosing_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRedVirusWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.PictureBox pictureBoxRedVirusWin;
        private System.Windows.Forms.Button buttonExit;
    }
}