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
    public partial class FormGame : Form
    {
        static Game game; /*טופס תפריט ראשי של המשחק.*/
        static IntructionsForm intructionsForm; /*טופס הוראות.*/
        static FormPlayerWin formPlayerWin; /*טופס ניצחון של שחקן.*/
        static FormComputerWin formComputerWin; /*טופס ניצחון של מחשב.*/
        static FormTie formTie; /*טופס תיקו.*/
        static TableOfRecords tableOfRecords; /*טופס טבלאת שיאים.*/
         Graphics g; /*עצם מסוג המחלקה Graphics.*/
         GameManager gameManager; /*משתנה מסוג מנהל המשחק.*/
        static string tableOfRecordsFileName; /*שם טופס טבלאת השיאים*/
        string restoreFile; /*שם טופס השחזור*/
         FormBackgrounds.Status nameOfBackgroundImage; /*Statusשמייצג את צבע הלוח הנבחר.*/
        FormBackgrounds formBackgrounds; /*טופס בחירת רקעים.*/
        string playerName; /*שם השחקן.*/

        public FormGame(Image backgroundImage, String restoreFile0, FormBackgrounds.Status nameOfBackgroundImage0, string playerName0)
        {
            //פעולה בונה לטופס
            this.Location = new Point(0, 0);
            InitializeComponent();
            g = CreateGraphics();
            pictureBoxRedVirus.Size = new Size(130, 110);
            pictureBoxGreenVirus.Size = new Size(110, 130);
            pictureBoxRedVirus.Location = new Point((int)((this.Size.Width * 3) / 4) + 70, (int)(this.Size.Height * 4 / 6) + (int)(this.Size.Height * 1 / 6));
            pictureBoxGreenVirus.Location = new Point((int)((this.Size.Width * 3) / 4) - 50, (int)(this.Size.Height * 4 / 6) + (int)(this.Size.Height * 1 / 6)-20);
            pictureBoxGreenVirus.SendToBack();
            buttonPurple.Location= new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 1 / 6)-10);
            buttonBlue.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 2 / 6)-10);
            buttonGreen.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 3 / 6)-10);
            buttonRed.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 4 / 6)-10);
            buttonPurple.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonBlue.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonGreen.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonRed.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonUndo.Size = new Size(65, 65);
            buttonNewGame.Size = new Size(65, 65);
            buttonUndo.BringToFront();
            BackgroundImage = backgroundImage;
            restoreFile = restoreFile0;
            nameOfBackgroundImage = nameOfBackgroundImage0;
            g = CreateGraphics();
            playerName = playerName0;
            gameManager = new GameManager(g, this, buttonRed, buttonPurple, buttonGreen, buttonBlue, labelComputer, labelPlayer, labelVS,
                pictureBoxRedVirus, pictureBoxGreenVirus, formPlayerWin, formComputerWin, formTie, tableOfRecords, nameOfBackgroundImage, buttonUndo, buttonNewGame, playerName);  
        }

        public FormGame(Image backgroundImage, String restoreFile0, FormBackgrounds.Status nameOfBackgroundImage0, MyImage.Status[,] latestColors, GameManager.Status[,] latestStatus, int compS, int playerS, GameManager.Status turn, string playerName0)
        {
            //פעולה בונה לטופס שמשחזרת טופס שכבר קיים
            InitializeComponent();
            g = CreateGraphics();
            pictureBoxRedVirus.Size = new Size(130, 110);
            pictureBoxGreenVirus.Size = new Size(110, 130);
            pictureBoxRedVirus.Location = new Point((int)((this.Size.Width * 3) / 4) + 70, (int)(this.Size.Height * 4 / 6) + (int)(this.Size.Height * 1 / 6));
            pictureBoxGreenVirus.Location = new Point((int)((this.Size.Width * 3) / 4) - 50, (int)(this.Size.Height * 4 / 6) + (int)(this.Size.Height * 1 / 6) - 20);
            pictureBoxGreenVirus.SendToBack();
            buttonPurple.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 1 / 6) - 10);
            buttonBlue.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 2 / 6) - 10);
            buttonGreen.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 3 / 6) - 10);
            buttonRed.Location = new Point((int)((this.Size.Width * 3) / 4), (int)(this.Size.Height * 4 / 6) - 10);
            buttonPurple.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonBlue.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonGreen.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonRed.Size = new Size((int)(this.Size.Height * 1 / 6), (int)(this.Size.Height * 1 / 6));
            buttonUndo.Location = new Point(0, 0);
            buttonUndo.Size = new Size(65, 65);
            BackgroundImage = backgroundImage;
            restoreFile = restoreFile0;
            nameOfBackgroundImage = nameOfBackgroundImage0;
            g = CreateGraphics();
            playerName = playerName0;
            gameManager = new GameManager(g, this, buttonRed, buttonPurple, buttonGreen, buttonBlue, labelComputer, labelPlayer, labelVS,
                pictureBoxRedVirus, pictureBoxGreenVirus, formPlayerWin, formComputerWin, formTie, tableOfRecords, latestColors, latestStatus
                , compS, playerS, nameOfBackgroundImage, turn, buttonUndo, buttonNewGame, playerName);  
        }

        public static void SetMainPageForm(Game game0)
        { game = game0; }

        public static void SetTableOfRecordsFileName(String tableOfRecordsFileName0)
        { tableOfRecordsFileName = tableOfRecordsFileName0; }

        public static void SetIntructionsForm(IntructionsForm intructionsForm0)
        { intructionsForm = intructionsForm0; }

        public static void SetPlayerWinForm(FormPlayerWin formPlayerWin0)
        { formPlayerWin = formPlayerWin0; }

        public static void SetComputerWinForm(FormComputerWin formComputerWin0)
        { formComputerWin = formComputerWin0; }

        public static void SetTieForm(FormTie formTie0)
        { formTie = formTie0; }

        public static void SetTableOfRecordsForm(TableOfRecords tableOfRecords0)
        { tableOfRecords = tableOfRecords0; }

        private void FormGame_Shown(object sender, EventArgs e)
        {
            //כל הפעולות שקורות ברגע שהטופס מוצג
            File.Delete(restoreFile);//ברקע שרואים את הטופס נוצר משחק חדש ולכן המידע על המשחק האחרון נמחק
            gameManager.FormGameShow();
            gameManager.Board.Draw();
            gameManager.ChangeViruses();
        }

        public void DeleteRestoreFile() //פעולה שמוחקת את קובץ השיחזור משחק 
        { File.Delete(restoreFile); } 

        private void FormGame_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        //הכפתורים בצדדים מנהלים את מהלך המשחק- ברגע שהם נלחצים הפעולה של השחקן מתבצעת ולאחריה מתבצעת פעולת המחשב
        private void buttonBlue_MouseClick(object sender, MouseEventArgs e)
        {
            gameManager.Blue = true;
            gameManager.MouseClick();
        }

        private void buttonPurple_MouseClick(object sender, MouseEventArgs e)
        {
            gameManager.Purple = true;
            gameManager.MouseClick();
        }

        private void buttonGreen_MouseClick(object sender, MouseEventArgs e)
        {
            gameManager.Green = true;
            gameManager.MouseClick();
        }

        private void buttonRed_MouseClick(object sender, MouseEventArgs e)
        {
            gameManager.Red = true;
            gameManager.MouseClick();
        }

        private void FormGame_SizeChanged(object sender, EventArgs e)
        {
            //פעולה המשנה את גודל לוח המשחק ואת האלמטים האחרים בטופס
            gameManager.FormSizeChanged();
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {   
            //ברגע שהטופס נסגר- אם המשחק נסגר באמצע נשמרים הנתונים אליו, אם המשחק כבר נגמר לא נשמרים הנתונים והקובץ שבו הנתונים היו אמורים להשמר נמחק
            //לאחר מכן המשחק נסגר לגמרי  
            if (gameManager.IsGameFinished())
            {
                File.Delete(restoreFile);
            }
            else 
            {
                if (!File.Exists(restoreFile))
                    gameManager.putBoardIntoFile(restoreFile);
                
            }
            Application.Exit();
        }

        private void buttonUndo_Click_1(object sender, EventArgs e)
        {
            //המהלכים שקורים ברגע שלוחצים על כפתור הביטול
            gameManager.UndoButtonClicked();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            //לחיצה על כפתור משחק חדש, פתיחת משחק חדש וסגירת הטופס הנוכחי
            if (gameManager.IsGameOver())
            {
                File.Delete(restoreFile);
            }
            else
            {
                if (!File.Exists(restoreFile))
                    gameManager.putBoardIntoFile(restoreFile);

            }
            formBackgrounds = new FormBackgrounds();
            formBackgrounds.Show();
            this.Hide();
        }
    }
}
