using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyGame_RonM
{
    public partial class FormBackgrounds : Form
    {
        //משתנה מסוג enum
        //ששומר את צבע לוח המשחק
        public enum Status
        {
            Purple, Red, Green, Blue, Colorful
        };
        string restoreFile; /*שם הקובץ ששומר את המשחק האחרון ששוחק*/
        FormBackgrounds.Status lastBackground; /*נשמר צבע הרקע שנבחר*/

        public FormBackgrounds()
        {
            //פעולה בונה של טופס צבע רקע
            InitializeComponent();
            restoreFile = "Restore.txt";
            lastBackground = FormBackgrounds.Status.Colorful;
            //הגדרת המיקום והגודל של הכפתורים ושל הטקסט
            backgroundButtonPurple.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.1));
            backgroundButtonPurple.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            backgroundButtonGreen.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.1));
            backgroundButtonGreen.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            backgroundButtonColorful.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.1));
            backgroundButtonColorful.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            backgroundButtonRed.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.6));
            backgroundButtonRed.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            backgroundButtonBlue.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.6));
            backgroundButtonBlue.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            buttonRestore.Location = new Point((int)(this.Size.Width * 0.75), (int)(this.Size.Height * 0.65));
            buttonRestore.Size = new Size((int)(this.Size.Width * 0.22), (int)(this.Size.Width * 0.22));
            labelOr.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.55));
            labelTitle.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.45));
            textBoxName.BackColor = SystemColors.AppWorkspace;
            textBoxName.Text = "Type Here Your Name";
        }

        private void FormBackgrounds_SizeChanged(object sender, EventArgs e)
        {
            //פעולה שמגדירה את מיקום הלחצנים והטקסט בזמן שגודל הלוח משתנה
            backgroundButtonPurple.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.1));
            backgroundButtonGreen.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.1));
            backgroundButtonColorful.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.1));
            backgroundButtonRed.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.6));
            backgroundButtonBlue.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.6));
            buttonRestore.Location = new Point((int)(this.Size.Width * 0.75), (int)(this.Size.Height * 0.65));
            labelOr.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.55));
            labelTitle.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.45));
        }

        private FormBackgrounds.Status FromStringToEnum(string s)
        {
            //פעולה שממירה מ string 
            //ל enum
            if (s == "Red")
                return FormBackgrounds.Status.Red;
            else if (s == "Blue")
                return FormBackgrounds.Status.Blue;
            else if (s == "Purple")
                return FormBackgrounds.Status.Purple;
            else if (s == "Green")
                return FormBackgrounds.Status.Green;
            return FormBackgrounds.Status.Colorful;
        }

        private void FormBackgrounds_FormClosing(object sender, FormClosingEventArgs e)
        {
            //סגירה סופית של הפרוייקט
            Application.Exit();
        }

        //בזמן לחיצה על אחד מכפתורי הצבע ריקה- עידכון משתני ה enum
        //פתיחת טופס חדש מסוג לוח המשחק והצגתו, הסתרת הטופס הזה
        private void backgroundButtonPurple_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxName.Text != "Type Here Your Name" && textBoxName.Text != "")
            {
                lastBackground = FormBackgrounds.Status.Purple;
                FormGame formGame = new FormGame(Image.FromFile("backgroundPurple2.png"), restoreFile, lastBackground, textBoxName.Text);
                formGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name");
                textBoxName.Text = "Type Here Your Name";
                textBoxName.BackColor = Color.Red;
            }
        }

        private void backgroundButtonGreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxName.Text != "Type Here Your Name" && textBoxName.Text != "")
            {
                lastBackground = FormBackgrounds.Status.Green;
                FormGame formGame = new FormGame(Image.FromFile("backgroundGreen2.png"), restoreFile, lastBackground, textBoxName.Text);
                formGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name");
                textBoxName.Text = "Type Here Your Name";
                textBoxName.BackColor = Color.Red;
            }
        }

        private void backgroundButtonRed_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxName.Text != "Type Here Your Name" && textBoxName.Text != "")
            {
                lastBackground = FormBackgrounds.Status.Red;
                FormGame formGame = new FormGame(Image.FromFile("backgroundRed2.png"), restoreFile, lastBackground, textBoxName.Text);
                formGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name");
                textBoxName.Text = "Type Here Your Name";
                textBoxName.BackColor = Color.Red;
            }
        }

        private void backgroundButtonBlue_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxName.Text != "Type Here Your Name" && textBoxName.Text != "")
            {
                lastBackground = FormBackgrounds.Status.Blue;
                FormGame formGame = new FormGame(Image.FromFile("backgroundBlue2.png"), restoreFile, lastBackground, textBoxName.Text);
                formGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name");
                textBoxName.Text = "Type Here Your Name";
                textBoxName.BackColor = Color.Red;
            }
        }

        private void backgroundButtonColorful_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxName.Text != "Type Here Your Name" && textBoxName.Text != "")
            {
                lastBackground = FormBackgrounds.Status.Colorful;
                FormGame formGame = new FormGame(Image.FromFile("background4.png"), restoreFile, lastBackground, textBoxName.Text);
                formGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter your name");
                textBoxName.Text = "Type Here Your Name";
                textBoxName.BackColor = Color.Red;
            }
        }

        private Image FromEnumToImage(FormBackgrounds.Status backColor)
        {
            //פעולה שממירה מ enum 
            //לתמונה בצבע המתאים
            if (backColor == FormBackgrounds.Status.Blue)
                return Image.FromFile("backgroundBlue2.png");
            else if (backColor == FormBackgrounds.Status.Green)
                return Image.FromFile("backgroundGreen2.png");
            else if (backColor == FormBackgrounds.Status.Purple)
                return Image.FromFile("backgroundPurple2.png");
            else if (backColor == FormBackgrounds.Status.Red)
                return Image.FromFile("backgroundRed2.png");
            return Image.FromFile("background4.png");
        }

        private GameManager.Status FromStringToGameManagerStatus(string s)
        {
            //פעולה שממירה ממשתנה מסוג string 
            //למשתנה מתאים מסוג enum 
            if (s == "computer")
                return GameManager.Status.computer;
            else if (s == "player")
                return GameManager.Status.player;
            return GameManager.Status.empty;
        }

        private MyImage.Status FromStringtoMyImageStatus(string s)
        {
            //פעולה שממירה ממשתנה מסוג string 
            //למשתנה מסוג enum מתאים
            if ((s == "Red")||(s=="PlayerRed")||(s=="ComputerRed"))
                return MyImage.Status.Red;
            else if ((s == "Green") || (s == "PlayerGreen") || (s == "ComputerGreen"))
                return MyImage.Status.Green;
            else if ((s == "Blue") || (s == "PlayerBlue") || (s == "computerBlue"))
                return MyImage.Status.Blue;
            return MyImage.Status.Purple;
        }

        private void buttonRestore_MouseClick(object sender, MouseEventArgs e)
        {
            //שיחזור משחק אחרון ופתיחתו
            if (!File.Exists(restoreFile))
            {
                //מקרה ובו המשחק האחרון נגמר בהצלחה ולכן לא ניתן לשחזר אותו
                MessageBox.Show("Unable to restore last game, please start a new game");
            }

            else
            {
                string s = "";
                string alltext = "";
                //המרת הקובץ שבו נשמר המשחק האחרון למשתנה מסוג string
                using (StreamReader streamReader = File.OpenText(restoreFile))
                {
                    s = streamReader.ReadLine();
                    while (s != null)
                    {
                        alltext = alltext + s;
                        s = streamReader.ReadLine();
                    }
                }

                int index = 0;
                FormBackgrounds.Status latestBackground = FormBackgrounds.Status.Colorful;
                GameManager.Status turn = GameManager.Status.computer;
                int latestCompScore = 0, latestPlayerScore = 0;
                int columns = 0, lines = 0;
                string temps2 = "", lastPlayerName = "";
                //שחזור מידע כללי שקשור למשחק;צבע הריקע, התוצאה של השחקן והמחשבת מימדי הלוח, מי האחרון ששיחק
                while (alltext[index] != 'I')
                { index++; }

                if ((alltext[index] == 'I') && (alltext[index + 1] == 'n') && (alltext[index + 2] == 'f') && (alltext[index + 3] == 'o'))
                {
                    index = index + 5;
                    while (alltext[index] != ',')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    index++;
                    latestBackground = FromStringToEnum(temps2);
                    temps2 = "";
                    while (alltext[index] != ':')
                    {
                        index++;
                    }
                    index++;
                    while (alltext[index] != ',')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    latestPlayerScore = Int32.Parse(temps2);
                    temps2 = "";
                    index++;
                    while (alltext[index] != ':')
                    {
                        index++;
                    }
                    index++;
                    while (alltext[index] != 'i')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    latestCompScore = Int32.Parse(temps2);
                    index++;
                    temps2 = "";
                    while (alltext[index] != 'j')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    columns = Int32.Parse(temps2);
                    index++;
                    temps2 = "";
                    while (alltext[index] != ',')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    lines = Int32.Parse(temps2);
                    index++;
                    temps2 = "";
                    while (alltext[index] != ',')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    lastPlayerName = temps2;
                    index++;
                    temps2 = "";
                    while (alltext[index] != '.')
                    {
                        temps2 = temps2 + alltext[index];
                        index++;
                    }
                    turn = FromStringToGameManagerStatus(temps2);
                }

                MyImage.Status[,] latestColors = new MyImage.Status[columns, lines];
                GameManager.Status[,] latestStatuses = new GameManager.Status[columns, lines];

                int i = 0, j = 0;
                string tempS1 = "";
                //שחזור הלוח עצמו-צבעי המשבצות ומי בחר כל משבצת
                for (int m = 0; m < alltext.Length; m++)
                {
                    if (alltext[m] == '[')
                        m++;

                    while (alltext[m] != ',')
                    {
                        tempS1 = tempS1 + alltext[m];
                        m++;
                    }
                    i = int.Parse(tempS1);
                    tempS1 = "";
                    m++;
                    while (alltext[m] != ']')
                    {
                        tempS1 = tempS1 + alltext[m];
                        m++;
                    }
                    j = int.Parse(tempS1);
                    tempS1 = "";
                    m++;
                    while (alltext[m] != ' ')
                    {
                        tempS1 = tempS1 + alltext[m];
                        m++;
                    }
                    latestStatuses[i, j] = FromStringToGameManagerStatus(tempS1);
                    m++;
                    tempS1 = "";
                    while ((alltext[m] != '[') && (alltext[m] != '-'))
                    {
                        tempS1 = tempS1 + alltext[m];
                        m++;
                    }

                    if (alltext[m] == '-')
                        m = alltext.Length - 1;

                    latestColors[i, j] = FromStringtoMyImageStatus(tempS1);
                    tempS1 = "";

                }

                //בניית הטופס משחק עם המידע שהתקבל
                FormGame formGame = new FormGame(FromEnumToImage(latestBackground), restoreFile, latestBackground, latestColors, latestStatuses
                  , latestCompScore, latestPlayerScore, turn, lastPlayerName);

                //מעבר לטופס המשחק
                formGame.Show();
                this.Hide();
            }
        }

        private void textBoxName_Click(object sender, EventArgs e)
        {
            //מחיקת הטקסט בתיבת טקסט בשביל נוחות המשתמש
            textBoxName.Text = "";
        }

    }
}
