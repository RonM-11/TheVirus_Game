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
    public partial class IntructionsForm : Form
    {
        static Game game; /*טופס התפריט ראשי של המשחק*/
        static FormGame formGame; /*טופס המשחק עצמו*/
        static FormBackgrounds formBackgrounds; /*טופס בחירת צבע רקע*/
        Image[] intructionsImages; /*מערך תמונות ששומר את כל התמונות שבהם יש את הוראות המשחק*/
        int index = 0; /*משתנה ששומר את ציון המקום של התמונה שמוצאת באותה רגע מתוך מערך התמונות*/

        public IntructionsForm()
        {
            //פעולה בונה של טופס ההוראות של המשחק
            InitializeComponent();
            intructionsImages = new Image[3];
            //הגדרת המיקום והגודל ההתחלתי של הכפתורים והתמונות
            ChangeSizes();
            intructionsImages[0] = Image.FromFile("InstructionsPage1.png");
            intructionsImages[1] = Image.FromFile("InstructionsPage2.png");
            intructionsImages[2] = Image.FromFile("InstructionsPage3.png");

        }

        public static void SetMainPageForm(Game game0)
        { game = game0; }

        public static void SetGameForm(FormGame formGame0)
        { formGame = formGame0; }

        public static void SetFormBackgrounds(FormBackgrounds formBackgrounds0)
        { formBackgrounds = formBackgrounds0; }

        private void IntructionsForm_SizeChanged(object sender, EventArgs e)
        {
            //פעולה שמשנה את גודל ומיקום הכפתורים והתמונות בטופס בהתאם לגודל החדש שאליו שונה הטופס
            ChangeSizes();
        }

        private void buttonNewGame_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור משחק חדש ומעבר לטופס המשחק עצמו
            formBackgrounds.Show();
            this.Hide();
        }

        private void buttonExit_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור יציאה ומעבר למסך הראשי
            game.Show();
            this.Hide();
        }

        private void IntructionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //פעולה שסוגרת לגמרי את המשחק
            Application.Exit();
        }

        private void buttonArrowRight_Click(object sender, EventArgs e)
        {
            //בעת לחיצה על הכפתור הימני תמונת ההוראות מתחלפת לתמונה הבאה של ההוראות, אם מדובר בעמוד ההוראות האחרון מוצגת הודעה מתאימה
            if (index < intructionsImages.Length - 1)
            {
                index++;
                pictureBoxFullInstructions.BackgroundImage = intructionsImages[index];
            }
            else
                MessageBox.Show("You've reached the last instruction page.");
        }

        private void buttonArrowLeft_Click(object sender, EventArgs e)
        {
            //בעת לחיצה על הכפתור השמאלי תמונת ההוראות מתחלפת לתמונה הקודמה של ההוראות, אם מדובר בעמוד הראשון מוצגת הודעה מתאימה
            if (index > 0)
            {
                index--;
                pictureBoxFullInstructions.BackgroundImage = intructionsImages[index];
            }
            else
                MessageBox.Show("You've reached the first instruction page.");
        }

        public void ChangeSizes()
        {
            //פעולה שמשנה את המיקום והגודל של אלמנטים שונים על גבי הטופס בהתאם לגודלו של הטופס
            if ((int)(this.Size.Width * 0.8) < (int)(this.Size.Height * 0.8))
                pictureBoxFullInstructions.Size = new Size((int)(this.Size.Width * 0.8), (int)(this.Size.Width * 0.8));
            else
                pictureBoxFullInstructions.Size = new Size((int)(this.Size.Height * 0.8), (int)(this.Size.Height * 0.8));
            pictureBoxFullInstructions.Location = new Point((int)((this.Width - pictureBoxFullInstructions.Size.Width) / 2),
                -30 + (int)((this.Height - pictureBoxFullInstructions.Size.Height) / 2));
            pictureBoxGreenVirus.Size = new Size((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.3));
            pictureBoxRedVirus.Size = new Size((int)(this.Size.Width * 0.15), (int)(this.Size.Height * 0.25));
            buttonNewGame.Size = new Size((int)(this.Size.Width * 0.15), (int)(this.Size.Width * 0.15));
            buttonExit.Size = new Size((int)(this.Size.Width * 0.15), (int)(this.Size.Width * 0.15));
            pictureBoxGreenVirus.Location = new Point((int)(this.Size.Width * 0.05), -30 + (int)(this.Size.Height * 0.6));
            pictureBoxRedVirus.Location = new Point((int)(this.Size.Width * 0.8), -20 + (int)(this.Size.Height * 0.05));
            buttonNewGame.Location = new Point((int)(this.Size.Width * 0.05), (int)(this.Size.Height * 0.05));
            buttonExit.Location = new Point((int)(this.Size.Width * 0.8), -50 + (int)(this.Size.Height * 0.75));
            buttonArrowLeft.Location = new Point(pictureBoxFullInstructions.Location.X,
                pictureBoxFullInstructions.Size.Height + pictureBoxFullInstructions.Location.Y);
            buttonArrowRight.Location = new Point(pictureBoxFullInstructions.Location.X + pictureBoxFullInstructions.Size.Width
                - buttonArrowRight.Size.Width, pictureBoxFullInstructions.Size.Height + pictureBoxFullInstructions.Location.Y);
            pictureBoxGreenVirus.BringToFront();
            pictureBoxRedVirus.BringToFront();
            buttonExit.BringToFront();
            buttonNewGame.BringToFront();
            buttonArrowRight.BringToFront();
            buttonArrowLeft.BringToFront();
        }

    }
}


