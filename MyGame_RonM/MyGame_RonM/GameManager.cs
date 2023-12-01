using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MyGame_RonM
{
    public class GameManager
    {
        public enum Status 
        {
            //מחלקה מסוג enum 
            //מייצגת את הבעלים של התא
            //שחקן, מחשב או תא ריק
            player, computer, empty
        };

        Images images; /*מכיל את כל התמונות של תאי המשחק*/
        Board board; /*עצם מסוג לוח המשחק*/
        Graphics g; /*עצם מסוג המחלקה Graphics*/
        FormGame formGame; /*טופס המשחק*/
        FormPlayerWin formPlayerWin; /*טופס ניצחון השחקן*/
        FormComputerWin formComputerWin; /* טופס ניצחון המחשב*/
        FormTie formTie; /*טופס תיקו*/
        Status turn = Status.computer; /*משתנה ששומר של מי התור הנוכחי, המחשב הוא מי שמתחיל את המשחק */
        bool turnIsDone; /*משתנה בוליאני ששומר האם תור הסתיים*/
        private bool purple, red, green, blue; /*משתנים בוליאנים ששומרים על איזה כפתור השחקן לחץ*/
        Button buttonRed, buttonPurple, buttonGreen, buttonBlue; /*הלחצנים שמקדמים את המשחק*/
        Button buttonUndo, buttonNewGame; /*כפתורי שיחזור ומשחק חדש*/
        Label labelComputer, labelPlayer, labelVS; /*התוויות שמציגות מידע על הניקוד של השחקן והמחשב*/
        PictureBox pictureBoxRedVirus, pictureBoxGreenVirus; /*תמונות של הווירוסים שמייצגות הפסד או ניצחון רגעי של השחקן או המחשב*/
        Image greenVirus, greenVirusWin, redVirus, redVirusWin; /*תמונות של השחקן והמחשב במצב הפסד וניצחון*/
        int isItChecked = 0; /*משתנה עזר לפעולה שבוחרת תאים*/
         TableOfRecords tableOfRecords;/*טבלת ההישגים*/
        MinMaxTree minMaxTree;/*עץ אפשרויות למחשב*/
        FormBackgrounds.Status backColorStatus; /*צבע הרקע של המשחק*/
        Stack<Board> undo; /*מחסנית שבאמצעותה אפשר לבטל מהלכים*/
        string playerName; /*שם השחקן*/
        bool gameFinished; /*משתנה עזר ששומר אם יש לשמור את המשחק האחרון ששוחק או לא*/

        public GameManager(Graphics g0, FormGame formGame0,
            Button buttonRed0, Button buttonPurple0, Button buttonGreen0, Button buttonBlue0,
            Label labelComputer0, Label labelPlayer0, Label lavelVS0,
            PictureBox pictureBoxRedVirus0, PictureBox pictureBoxGreenVirus0,
            FormPlayerWin formPlayerWin0, FormComputerWin formComputerWin0, FormTie formTie0, TableOfRecords tableOfRecords0, FormBackgrounds.Status backColorStatus0,
            Button buttonUndo0, Button buttonNewGame0, string playerName0)
        {
            //פעולה בונה של מנהל המשחק לפי הערכים שהפעולה מקבלת
            this.g = g0;
            this.formGame = formGame0;
            images = new Images();
            int boardWidth;
            if ((int)(formGame.Size.Height) <= formGame.Size.Width)//קטע שקובע מה יהיה גודל הלוח כך שהוא יראה טוב ויזואלית
                boardWidth = (int)(formGame.Size.Height);
            else
                boardWidth = ((int) formGame.Size.Width );
            board = new Board(40, (int)(formGame.Size.Height / 12), boardWidth, 15, 15, formGame, this, g);//בניית משתנה מסוג לוח המשחק
            buttonRed = buttonRed0;
            buttonPurple = buttonPurple0;
            buttonGreen = buttonGreen0;
            buttonBlue = buttonBlue0;
            labelComputer = labelComputer0;
            labelPlayer = labelPlayer0;
            labelVS = lavelVS0;
            pictureBoxRedVirus = pictureBoxRedVirus0;
            pictureBoxGreenVirus = pictureBoxGreenVirus0;
            formPlayerWin = formPlayerWin0;
            formComputerWin = formComputerWin0;
            formTie = formTie0;
            tableOfRecords = tableOfRecords0;
            InitialCondition();
            backColorStatus = backColorStatus0;
            buttonUndo = buttonUndo0;
            buttonNewGame = buttonNewGame0;
            playerName = playerName0;
            labelPlayer.Text = playerName + ":0";
            undo = new Stack<Board>();
            gameFinished = false;
        }

        public GameManager(Graphics g0, FormGame formGame0,
        Button buttonRed0, Button buttonPurple0, Button buttonGreen0, Button buttonBlue0,
        Label labelComputer0, Label labelPlayer0, Label lavelVS0,
        PictureBox pictureBoxRedVirus0, PictureBox pictureBoxGreenVirus0,
        FormPlayerWin formPlayerWin0, FormComputerWin formComputerWin0, FormTie formTie0, TableOfRecords tableOfRecords0, 
        MyImage.Status[,] lastColors, GameManager.Status[,] lastStatuses, int computerTS, int playerTS,
        FormBackgrounds.Status backColorStatus0, Status turn0, 
        Button buttonUndo0, Button buttonNewGame0, string playerName0)
        {
            //פעולה שבונה את מנהל המשחק למשחק שכבר היה קיים לפי הערכים שהפעולה מקבלת
            this.g = g0;
            this.formGame = formGame0;
            images = new Images();
            int boardWidth;
            if ((int)(formGame.Size.Height) <= formGame.Size.Width)//קטע שקובע מה יהיה גודל הלוח כך שהוא יראה טוב ויזואלית
                boardWidth = (int)(formGame.Size.Height);
            else
                boardWidth = ((int)formGame.Size.Width);
            board = new Board(40, (int)(formGame.Size.Height / 12), boardWidth, 15, 15, formGame, this, g, lastStatuses, lastColors);//בניית משתנה מסוג לוח המשחק
            buttonRed = buttonRed0;
            buttonPurple = buttonPurple0;
            buttonGreen = buttonGreen0;
            buttonBlue = buttonBlue0;
            labelComputer = labelComputer0;
            labelPlayer = labelPlayer0;
            labelVS = lavelVS0;
            pictureBoxRedVirus = pictureBoxRedVirus0;
            pictureBoxGreenVirus = pictureBoxGreenVirus0;        
            formPlayerWin = formPlayerWin0;
            formComputerWin = formComputerWin0;
            formTie = formTie0;
            tableOfRecords = tableOfRecords0;
            InitialCondition();
            board.ComputerTotalScore = computerTS;
            board.PlayerTotalScore = playerTS;
            playerName = playerName0;
            labelComputer.Text = "Computer:" + computerTS;
            labelPlayer.Text = playerName + ":" + playerTS;
            backColorStatus = backColorStatus0;
            turn = turn0;
            buttonUndo = buttonUndo0;
            buttonNewGame = buttonNewGame0;
            undo = new Stack<Board>();
            gameFinished = false;
        }

        public void InitialCondition()
        {
            //פעולה שמאתחלת את התמונות הוירוסים ואת גודל תמונות אלו
            pictureBoxRedVirus.Size = new Size(130, 110);
            pictureBoxGreenVirus.Size = new Size(110, 130);
            greenVirus = Image.FromFile("greenVirus.png");
            greenVirusWin = Image.FromFile("greenVirusWin2.png");
            redVirus = Image.FromFile("redVirus.png");
            redVirusWin = Image.FromFile("redVirusWin2.png");
        }

        //פעולות שדואגות לעידכון המשתנים שמייצגים איזה צבע נבחר
        //הם משנים את הצבע הנבחר לאמת ואת שאר הצבעים לשקר
        public bool Purple
        {
            get { return purple; }
            set
            {
                purple = value;
                red = false;
                green = false;
                blue = false;
                gameFinished = false;
            }
        }

        public bool Red
        {
            get { return red; }
            set
            {
                red = value;
                purple = false;
                green = false;
                blue = false;
                gameFinished = false;
            }
        }

        public bool Green
        {
            get { return green; }
            set
            {
                green = value;
                red = false;
                purple = false;
                blue = false;
                gameFinished = false;
            }
        }

        public bool Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                red = false;
                green = false;
                purple = false;
                gameFinished = false;
            }
        }

        public Board Board
        {
            //פעולה שמחזירה את לוח המשחק
            get { return board; }
        }

        public Status Turn
        {
            //פעולה שמחזירה של מי התור כרגע
            get { return turn; }
        }

        public void FormGameShow()
        {
            //מפעילה פעולות שנעשות ברגע שהמשחק מתחיל בפעם הראשונה
            labelPlayer.Location = new Point(700, 20);
            labelVS.Location = new Point(964, 20);
            labelComputer.Location = new Point(744, 80);
            labelPlayer.Size = new Size(260, 60);
            labelVS.Size = new Size(98, 60);
            labelComputer.Size = new Size(337, 60);
            buttonUndo.Location = new Point(labelComputer.Location.X, labelComputer.Location.Y + 70);
            buttonNewGame.Location = new Point(0, 0);
            board.Draw();
            CompMove();
            board.AllColorsThatPlayerBeChose(buttonRed, buttonPurple, buttonGreen, buttonBlue);
        }

        public void FormSizeChanged()
        {
            //משנה את מיקום האלמנטים שעל הטופס ברגע שגודל הטופס משתנה
            formGame.Refresh();
            //שינוי מיקום וגודל הכפתורים
            buttonPurple.Location = new Point((int)((formGame.Size.Width * 3) / 4), (int)(formGame.Size.Height * 1 / 6)-10);
            buttonBlue.Location = new Point((int)((formGame.Size.Width * 3) / 4), (int)(formGame.Size.Height * 2 / 6)-10);
            buttonGreen.Location = new Point((int)((formGame.Size.Width * 3) / 4), (int)(formGame.Size.Height * 3 / 6)-10);
            buttonRed.Location = new Point((int)((formGame.Size.Width * 3) / 4), (int)(formGame.Size.Height * 4 / 6)-10);
            buttonPurple.Size = new Size((int)(formGame.Size.Height * 1 / 6), (int)(formGame.Size.Height * 1 / 6));
            buttonBlue.Size = new Size((int)(formGame.Size.Height * 1 / 6), (int)(formGame.Size.Height * 1 / 6));
            buttonGreen.Size = new Size((int)(formGame.Size.Height * 1 / 6), (int)(formGame.Size.Height * 1 / 6));
            buttonRed.Size = new Size((int)(formGame.Size.Height * 1 / 6), (int)(formGame.Size.Height * 1 / 6));
            pictureBoxGreenVirus.SendToBack();
            int boardWidth;
            if ((int)(formGame.Size.Height ) <= (int)formGame.Size.Width)//קטע שקובע מה יהיה גודל הלוח כך שהוא יראה טוב ויזואלית
                boardWidth = (int)(formGame.Size.Height );
            else
                boardWidth = (int) formGame.Size.Width ;
            //שינוי מיקום התוויות וגודל ומיקום התמונות
            if ((int)((formGame.Size.Width*3)/4)-(int)((boardWidth*3)/4)>=340)
            {              
                labelPlayer.Location = new Point(((formGame.Size.Height * 3) / 4)+100, (int)(formGame.Size.Height * 2 / 6));
                labelVS.Location = new Point(((formGame.Size.Height * 3) / 4)+100, (int)(formGame.Size.Height * 3 / 6)-30);
                labelComputer.Location = new Point(((formGame.Size.Height * 3) / 4)+100, (int)(formGame.Size.Height * 4 / 6)-60);
                labelPlayer.Size = new Size(500, 500);
                labelVS.Size = new Size(98, 60);
                labelComputer.Size = new Size(337, 60);
                pictureBoxRedVirus.Location = new Point((int)((formGame.Size.Width * 3) / 4) - 250, (int)(formGame.Size.Height * 1 / 6) - 50);
                pictureBoxGreenVirus.Location = new Point(((formGame.Size.Height * 3) / 4) + 125, (int)(formGame.Size.Height * 4 / 6));
                pictureBoxRedVirus.Size = new Size(230, 190);
                pictureBoxGreenVirus.Size = new Size(190, 230);
                buttonUndo.Location = new Point(buttonPurple.Location.X + buttonPurple.Size.Width + 50, buttonPurple.Location.Y - 50);
                buttonNewGame.Location = new Point(buttonUndo.Location.X + buttonUndo.Size.Width + 10, buttonUndo.Location.Y);
                pictureBoxRedVirus.SendToBack();

            }
            else
            {
                labelPlayer.Location = new Point(700, 20);
                labelVS.Location = new Point(964, 20);
                labelComputer.Location = new Point(744, 80);
                pictureBoxRedVirus.Location = new Point((int)((formGame.Size.Width * 3) / 4)+70, (int)(formGame.Size.Height * 4 / 6)+(int)(formGame.Size.Height * 1 / 6));
                pictureBoxGreenVirus.Location = new Point((int)((formGame.Size.Width * 3) / 4)-50, (int)(formGame.Size.Height * 4 / 6)+(int)(formGame.Size.Height * 1 / 6));
                pictureBoxRedVirus.Size = new Size(130, 110);
                pictureBoxGreenVirus.Size = new Size(110, 130);
                buttonUndo.Location = new Point(labelComputer.Location.X, labelComputer.Location.Y + 70);
                buttonNewGame.Location = new Point(0, 0);
            }
            board.DrawAgain(40, (int)(formGame.Size.Height * 1 / 12), boardWidth);//ציור הלוח
        }

        public void MouseClick()
        {
            //פעולה שמקיימת את הפעולה שבה השחקן בחר ומיד אחריה פעולת נגד מצד המחשב
            //התור של השחקן            
            Board currentBoard = new Board(board);
            undo.Push(currentBoard);     
            turn = GameManager.Status.player;
            if (purple)
                    turnIsDone = board.MouseClick(turn, MyImage.Status.Purple, isItChecked++);
                else if (red)
                    turnIsDone = board.MouseClick(turn, MyImage.Status.Red, isItChecked++);
                else if (Green)
                    turnIsDone = board.MouseClick(turn, MyImage.Status.Green, isItChecked++);
                else if (Blue)
                    turnIsDone = board.MouseClick(turn, MyImage.Status.Blue, isItChecked++);
            board.AllColorsThatCanBeChose(GameManager.Status.player);
            if (board.IsGameOver(buttonRed, buttonPurple, buttonGreen, buttonBlue))//בודקת אם לאחר שהשחקן עשה תור אין לאן להמשיך והמשחק נגמר
                GameOver();
            //..........................................................................
            ChangeGraphics();//משנה את הניקוד ואת התמונות של הוירוסים
            //..........................................................................    
            CompMove();//מקיימת צעד של מחשב
            //בודקת אפשרויות לצעד של השחקן
            board.AllColorsThatPlayerBeChose(buttonRed, buttonPurple, buttonGreen, buttonBlue);
            if (board.IsGameOver(buttonRed, buttonPurple, buttonGreen, buttonBlue))//בודקת אם לאחר שהשחקן עשה תור אין לאן להמשיך והמשחק נגמר
                GameOver();
        }

        public void GameOver()
        {
            //פעולה שמסיימת את המשחק
            //........................................................................................
            tableOfRecords.SetTwoLastScores(new int[] { board.PlayerTotalScore, board.ComputerTotalScore }, new string[] { playerName, "Computer" }); //בודקת אפשרות להכניס את הניקוד לטבלת השיאים, אם הניקוד אכן מהווה שיא
            //..........................................................................................
            gameFinished = true;//משתנה עזר ששומר כי המשחק נגמר
            System.Threading.Thread.Sleep(1000);
            formGame.Hide();
            //בודקת מי ניצח או אם יש תיקו ולפי כך מציגה טופס אחר בהתאם
            if (board.ComputerTotalScore > board.PlayerTotalScore)
            { formComputerWin.Show(); }
            else if (board.ComputerTotalScore < board.PlayerTotalScore)
            { formPlayerWin.Show(); }
            else
            { formTie.Show(); }
            NewGame();//מתכנן את המשחק הבא
        }

        public void NewGame()
        {
            //מאתחלת משתנים ולוח לטובת המשחק הבא
            int boardWidth;
            if ((int)(formGame.Size.Height) <= formGame.Size.Width)
                boardWidth = (int)(formGame.Size.Height);
            else
                boardWidth = ((int)formGame.Size.Width);

            board = new Board(40, (int)(formGame.Size.Height / 12), boardWidth, 15, 15, formGame, this, g);
            board.Draw();
            board.ComputerTotalScore = 0;
            board.PlayerTotalScore = 0;
            labelComputer.Text = "Computer:" + "0";
            labelPlayer.Text = playerName + ":" + "0";
            pictureBoxGreenVirus.BackgroundImage = greenVirus;
            pictureBoxRedVirus.BackgroundImage = redVirus;
        }
        
        public void CompMove()
        {
            //מקיימת צעד של מחשב
            turn = GameManager.Status.computer;
            minMaxTree = new MinMaxTree(5, board, GameManager.Status.player);//בונה עץ אפשרויות
            if (minMaxTree.IsGameOver())//בודקת האם המשחק נגמר או שאפשר לקיים את המהלך
                GameOver();
            if (turn == Status.computer)
            {
                MyImage.Status compMove = minMaxTree.GetTheIdealColor();//מחפשת את הצעד האידיאלי
                turnIsDone = board.MouseClick(turn, compMove, isItChecked++);//עושה תור לטובת המחשב
            }
            //..........................................................................
            ChangeGraphics();//משנה את הניקוד ואת התמונות של הוירוסים
            //.......................................................................... 
        }

        public void ChangeGraphics()
        {
            //פעולה שבודקת אם אפשר לשנות את הניקוד של המשתמשים ואת הציורים ומגיבה בהתאמה
            if (turnIsDone)
            {
                //שינוי ניקוד
                if (turn == Status.computer)
                {
                    turn = Status.player;
                    labelComputer.Text = "Computer:" + board.ComputerTotalScore.ToString();
                }

                else
                {
                    turn = Status.computer;
                    labelPlayer.Text = playerName + ":" + board.PlayerTotalScore.ToString();
                }
                ChangeViruses();
            }
        }

        public bool IsGameOver()
        {
            //פעולה שבודקת אם המשחק נגמר
            return board.IsGameOver(buttonRed, buttonPurple, buttonGreen, buttonBlue) || minMaxTree.IsGameOver();
        }

        public void ChangeViruses()
        {
            //פעולה שמשנה את התמונות של הוירוסים בהתאמה לניקוד     
            if (board.ComputerTotalScore > board.PlayerTotalScore)
            {
                pictureBoxRedVirus.BackgroundImage = redVirus;
                pictureBoxGreenVirus.BackgroundImage = greenVirusWin;
            }
            else if (board.ComputerTotalScore < board.PlayerTotalScore)
            {
                pictureBoxRedVirus.BackgroundImage = redVirusWin;
                pictureBoxGreenVirus.BackgroundImage = greenVirus;
            }
            else
            {
                pictureBoxRedVirus.BackgroundImage = redVirus;
                pictureBoxGreenVirus.BackgroundImage = greenVirus;
            }
        }

        public void putBoardIntoFile(string fileName)
        {
            //פעולה שמעבירה את כל המידע בלוח למקובץ שאותו אפשר לשחזר אם רוצים לפתוח משחק שנסגר באמצע
            for (int i = 0; i < board.GetCellsBoard().GetLength(0); i++)
            {
                for (int j = 0; j < board.GetCellsBoard().GetLength(1); j++)
                {
                    File.AppendAllText(fileName, string.Format("[" + i + "," + j + "]" + board.GetCellsBoard()[i, j].CellStatus + " " + board.GetCellsBoard()[i, j].CellColor, Environment.NewLine));

                }
            }
            File.AppendAllText(fileName, "-" + "Info " + backColorStatus.ToString() + "," + labelPlayer.Text + "," + labelComputer.Text + "i" + board.GetCellsBoard().GetLength(0) + "j" + board.GetCellsBoard().GetLength(1) + "," + playerName + "," + turn + ".");
        }

        public void UndoButtonClicked()
        {
            //פעולה שמבצעת ביטול של המהלך האחרון של השחקן
            if (undo.Count == 0)
            {
                MessageBox.Show("Make a move.");
                return;
            }
            this.board = new Board(undo.Pop());
            labelComputer.Text = "Computer:" + board.ComputerTotalScore.ToString();
            labelPlayer.Text = playerName + ":" + board.PlayerTotalScore.ToString();
            ChangeViruses();
            formGame.Refresh();
            int currentWidth=0;
            if ((int)(formGame.Size.Height) <= (int)formGame.Size.Width)//קטע שקובע מה יהיה גודל הלוח כך שהוא יראה טוב ויזואלית
                currentWidth = (int)(formGame.Size.Height);
            else
                currentWidth = (int)formGame.Size.Width;
            board.DrawAgain(40, (int)(formGame.Size.Height * 1 / 12), currentWidth);
            board.AllColorsThatPlayerBeChose(buttonRed, buttonPurple, buttonGreen, buttonBlue);
        }

        public bool IsGameFinished()
        {
            //מחזירה את המשתנה עזר שאומר אם המשחק נגמר או שצריך לשמור את המצב הקיים
            return gameFinished;
        }

    }
}
