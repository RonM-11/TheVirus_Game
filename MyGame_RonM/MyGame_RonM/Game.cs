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
    public partial class Game : Form
    {
        Graphics g; /*עצם מסוג המחלקה Graphics*/
        IntructionsForm intructionsForm; /*טופס הוראות*/
        FormGame formGame; /*טופס משחק*/
        FormPlayerWin formPlayerWin; /*טופס ניצחון של שחקן*/
        FormComputerWin formComputerWin; /*טופס ניצחון של מחשב*/
        FormTie formTie; /*טופס תיקו*/
        string tableOfRecordsFile; /*שם קובץ ששומר את הנתונים של טבלאת השיאים*/
        TableOfRecords tableOfRecords; /*טופס טבלאת שיאים*/
        FormBackgrounds formBackgrounds; /*טופס בחירת צבע רקע*/

        public Game()
        {
            //פעולה בונה של טופס מסך ראשי של משחק
            InitializeComponent();
            g = CreateGraphics();
            intructionsForm = new IntructionsForm();
            formPlayerWin = new FormPlayerWin();
            formComputerWin = new FormComputerWin();
            formTie = new FormTie();
            tableOfRecords = new TableOfRecords();
            formBackgrounds = new FormBackgrounds();
            IntructionsForm.SetGameForm(formGame);
            IntructionsForm.SetFormBackgrounds(formBackgrounds);
            FormGame.SetIntructionsForm(intructionsForm);
            FormGame.SetPlayerWinForm(formPlayerWin);
            FormGame.SetComputerWinForm(formComputerWin);
            FormGame.SetTieForm(formTie);
            FormGame.SetTableOfRecordsForm(tableOfRecords);
            TableOfRecords.SetGameForm(formGame);
            TableOfRecords.SetFormBackgrounds(formBackgrounds);
            tableOfRecordsFile = "SaveHighScore.txt";
            TableOfRecords.SetFileName(tableOfRecordsFile);
            ////////File.Delete(tableOfRecordsFile); /*משתמש לאתחול טבלאת השיאים*/
        }

        private void Game_Shown(object sender, EventArgs e)
        {
            //כל הפעולות שקורות ברגע שפותחים את המסך הראשי של המשחק
            g = CreateGraphics();
            pictureBoxTheVirusLogo.Location=new Point((int)(this.Size.Width / 2) - (int)(this.Size.Width * 0.15), (int)(this.Size.Height * 0.1));
            pictureBoxTheVirusLogo.Size=new Size((int)(this.Size.Width * 0.3), (int)(this.Size.Width * 0.3));
            buttonNewGame.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonNewGame.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));
            buttonIntructions.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonIntructions.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));
            buttonTableOfRecords.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonTableOfRecords.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));
            FormGame.SetMainPageForm(this);
            TableOfRecords.SetMainPageForm(this);
            IntructionsForm.SetMainPageForm(this);
            FormPlayerWin.SetMainPageForm(this);
            FormComputerWin.SetMainPageForm(this);
            FormTie.SetMainPageForm(this);
            FormGame.SetTableOfRecordsFileName(tableOfRecordsFile);
           

        }

        private void Game_SizeChanged(object sender, EventArgs e)
        {
            //הפעולות שקורות ברגע שלוח המשחק משתנה-שינוי הגודל והמיקום של האלמנטים שנמצאים על פניו
            g = CreateGraphics();
            this.Refresh();
            pictureBoxTheVirusLogo.Location = new Point((int)(this.Size.Width / 2) - (int)(this.Size.Width * 0.15), (int)(this.Size.Height * 0.1));
            pictureBoxTheVirusLogo.Size = new Size((int)(this.Size.Width * 0.3), (int)(this.Size.Width * 0.3));
            buttonNewGame.Location = new Point((int)(this.Size.Width * 0.1), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonNewGame.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));
            buttonIntructions.Location = new Point((int)(this.Size.Width * 0.4), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonIntructions.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));
            buttonTableOfRecords.Location = new Point((int)(this.Size.Width * 0.7), (int)(this.Size.Height * 0.1) + (int)(this.Size.Width * 0.3) + 20);
            buttonTableOfRecords.Size = new Size((int)(this.Size.Width * 0.2), (int)(this.Size.Width * 0.2));

        }


        private void buttonNewGame_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור משחק חדש ומעבר לטופס המשחק עצמו
            formBackgrounds.Show();
            this.Hide();
        }

        private void buttonIntructions_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור הוראות ומעבר לטופס הוראות
            intructionsForm.Show();
            this.Hide();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            //לחיצה על כפתור הוראות וסגירת המשחק
            Application.Exit();
        }

        private void buttonTableOfRecords_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור הוראות ומעבר לטבלת השיאים
            tableOfRecords.Show();
            this.Hide();
        }
    }
}
