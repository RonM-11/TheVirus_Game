using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGame_RonM
{
    public partial class FormTie : Form
    {
        static Game game; /*טופס התפריט הראשי של המשחק.*/

        public FormTie()
        {
            //פעולה בונה של טופס המציג מצב של תיקו בין השחקנים
            InitializeComponent();
            labelTie.Location = new Point((int)(this.Width - labelTie.Width) / 2, (int)(this.Height / 4));
            pictureBoxGreenVirusWin.Location = new Point((int)(this.Width - labelTie.Width) / 2, (int)(this.Height / 4 + labelTie.Height));
            pictureBoxRedVirusWin.Location = new Point((int)(this.Width - labelTie.Width) / 2+pictureBoxGreenVirusWin.Width+20, (int)(this.Height / 4 + labelTie.Height));
            buttonExit.Size = new Size((int)(this.Size.Width * 0.15), (int)(this.Size.Height * 0.15));
            buttonExit.Location = new Point((int)(this.Size.Width * 0.05), (int)(this.Size.Height * 0.05));
        }

        public static void SetMainPageForm(Game game0)
        { game = game0; }

        private void FormTie_FormClosing(object sender, FormClosingEventArgs e)
        {
            //פעולה שסוגרת לגמרי את המשחק
            Application.Exit();
        }

        private void FormTie_SizeChanged(object sender, EventArgs e)
        {
            //פעולה שמשנה את מיקום וגודל האלמנטים שנמצאים על גבי הטופס
            labelTie.Location = new Point((int)(this.Width - labelTie.Width) / 2, (int)(this.Height / 4));
            pictureBoxGreenVirusWin.Location = new Point((int)(this.Width - labelTie.Width) / 2, (int)(this.Height / 4 + labelTie.Height));
            pictureBoxRedVirusWin.Location = new Point((int)(this.Width - labelTie.Width) / 2 + pictureBoxGreenVirusWin.Width + 20, (int)(this.Height / 4 + labelTie.Height));
            buttonExit.Size = new Size((int)(this.Size.Width * 0.15), (int)(this.Size.Height * 0.15));
            buttonExit.Location = new Point((int)(this.Size.Width * 0.05), (int)(this.Size.Height * 0.05));
        }

        private void buttonExit_MouseClick(object sender, MouseEventArgs e)
        {
            //פעולה שסוגרת את הטופס ופותחת טופס ראשי חדש
            game.Show();
            this.Hide();
        }
    }
}
