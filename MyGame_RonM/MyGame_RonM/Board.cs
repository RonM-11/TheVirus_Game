using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame_RonM
{
    public class Board
    {
        Graphics g; /*עצם מסוג המחלקה Graphics*/
        GraphicsCell[,] board; /*מערך דו מימדי מסוג GraphicsCell 
                                שמייצג את הלוח משחק*/
        int x, y; /* ערך האיקס והווי של מיקום הלוח משחק על גבי הטופס*/
        int width; /*ערך הרוחב של הלוח משחק, על ידיו נקבע גם האורך*/
        int numOfColumns, numOfLines; /* ערך מספר העמודות והשורות של לוח המשחק*/
        FormGame formGame; /*טופס המשחק*/
        Images images; /*עצם ששומר את כל התמונות האפשריות לתא*/
        GameManager gameManager; /*מנהל המשחק*/
        int playerTotalScore = 0; /*עצם ששומר את הניקוד הכולל של השחקן*/
        int computerTotalScore = 0; /*עצם ששומר את הניקוד הכולל של המחשב*/
        bool green, red, purple, blue; /*משתנים בולניארים ששומרים אלו מבין הצבעים הנ"ל יכולים להיבחר*/

        public Board(int x, int y, int width, int numOfLines, int numOfColumns, FormGame formGame, GameManager gameManager0, Graphics g0)
        {
            //פעולה בונה של לוח המשחק
            this.x = x;//מיקום הלוח 
            this.y = y;//מיקום הלוח
            this.width = width;
            this.numOfColumns = numOfColumns;
            this.numOfLines = numOfLines;
            this.formGame = formGame;
            this.g = g0;
            images = new Images();
            board = new GraphicsCell[numOfLines, numOfColumns]; //הגדרת לוח המשחק
            gameManager = gameManager0;
            //................................................................................
            Random randnum = new Random();
            Image randImage;
            int randNumber = randnum.Next(0, 4); //בהנחה שארבעת התמונות הראשונות במערך הן תמונות ריקות, זאת אומרת תמונות ללא סמל של המחשב או של השחקן
            //................................................................................
            int widthCell = width / numOfLines; //קביעת מימדי תא בודד
            int moveX = (int)((3 * widthCell) / 4), moveY = (int)(Math.Sqrt(3) * (widthCell / 2));//קביעת מיקום התאים
            int xCell = this.x, yCell = this.y;//מיקום של התא הראשון
            bool last = true; //שומר מידע אודות הערך האחרון של ycell
            //true אם הוא למעלה
            // false אם הוא למטה
            //................................................................................
            //פעולה שבונה כל תא ותא בלוח
            //כך שהתאים הראשון והאחרון מקבלים את הערך של השחקן והמחשב בהתאמה
            for (int i = 0; i < numOfColumns; i++)
            {
                if (i % 2 != 0)
                    yCell = yCell - (int)(moveY / 2);
                for (int j = 0; j < numOfLines; j++)
                {

                    if (i == 0 && j == 0)//התא הראשון הוא תא של השחקן
                    {
                        randNumber = randNumber + 8;
                        randImage = images.GetImageByItSerialNumber(randNumber);
                        board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, randImage, images, randNumber - 8,
                            new Point(i, j));
                        board[i, j].CellStatus = GameManager.Status.player;
                    }

                    else if (i == numOfColumns - 1 && j == numOfLines - 1)//התא האחרון הוא תא של המחשב
                    {
                        randNumber = randNumber + 4;
                        randImage = images.GetImageByItSerialNumber(randNumber);
                        board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, randImage, images, randNumber - 4,
                            new Point(i, j));
                        board[i, j].CellStatus = GameManager.Status.computer;
                    }
                    else//כל תא אחר הוא תא פנוי
                    {
                        randImage = images.GetImageByItSerialNumber(randNumber);
                        board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, randImage, images, randNumber,
                            new Point(i, j));
                        board[i, j].CellStatus = GameManager.Status.empty;
                    }
                    yCell = yCell + moveY;
                    randNumber = randnum.Next(0, 4);

                }
                xCell = xCell + moveX;
                yCell = this.y;
            }

            //שומר את כל התאים שנמצאים בשכנות לתא
            for (int m = 0; m < numOfColumns; m++)
            {
                for (int n = 0; n < numOfLines; n++)
                {
                    if (n > 0)
                    { board[m, n].AddNeighbor(board[m, n - 1]); }
                    if (n < numOfLines - 1)
                    { board[m, n].AddNeighbor(board[m, n + 1]); }
                    if (m > 0)
                    { board[m, n].AddNeighbor(board[m - 1, n]); }
                    if (m < numOfColumns - 1)
                    { board[m, n].AddNeighbor(board[m + 1, n]); }
                    if (m % 2 == 0)
                    {
                        if (m > 0 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m - 1, n + 1]); }
                        if (m < numOfColumns - 1 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m + 1, n + 1]); }
                    }
                    else
                    {
                        if (m < numOfColumns - 1 && n > 0) { board[m, n].AddNeighbor(board[m + 1, n - 1]); }
                        if (m > 0 && n > 0) { board[m, n].AddNeighbor(board[m - 1, n - 1]); }
                    }
                }
            }
        }

        public Board(int x, int y, int width, int numOfLines, int numOfColumns, FormGame formGame, GameManager gameManager0, Graphics g0
            , GameManager.Status[,] status, MyImage.Status[,] color)
        {
            //פעולה בונה של לוח המשחק למשחק שכבר היה קיים
            this.x = x;
            this.y = y;
            this.width = width;
            this.numOfColumns = numOfColumns;
            this.numOfLines = numOfLines;
            this.formGame = formGame;
            this.g = g0;
            images = new Images();
            board = new GraphicsCell[numOfLines, numOfColumns];//הגדרת לוח המשחק
            gameManager = gameManager0;
            //................................................................................
            int widthCell = width / numOfLines;//מימדי כל תא
            int moveX = (int)((3 * widthCell) / 4), moveY = (int)(Math.Sqrt(3) * (widthCell / 2));//קביעת מיקום התאים
            int xCell = this.x, yCell = this.y;//מיקום התא הראשון
            bool last = true; //שומר מידע אודות הערך האחרון של ycell
                              //true אם הוא למעלה
                              // false אם הוא למטה
                              //................................................................................
                              //פעולה שבונה כל תא ותא בלוח
                              //על פי הערכים שכבר נקבעו במשחק האחרון
            for (int i = 0; i < numOfColumns; i++)
            {
                if (i % 2 != 0)
                    yCell = yCell - (int)(moveY / 2);
                for (int j = 0; j < numOfLines; j++)
                {
                    if (i == 0 && j == 0)//התא הראשון של השחקן
                    {
                        board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, images.GetImageByItSerialNumber(images.GetSerialNumberByItName(color[i, j]) + 8)
                            , images, images.GetSerialNumberByItName(color[i, j]) + 8, new Point(i, j));
                        board[i, j].CellStatus = GameManager.Status.player;
                    }

                    else if (i == numOfColumns - 1 && j == numOfLines - 1)//התא האחרון של המחשב
                    {

                        board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, images.GetImageByItSerialNumber(images.GetSerialNumberByItName(color[i, j]) + 4)
                           , images, images.GetSerialNumberByItName(color[i, j]) + 4, new Point(i, j));
                        board[i, j].CellStatus = GameManager.Status.computer;
                    }
                    else
                    {
                        if (status[i, j] == GameManager.Status.computer)//במידה והתא נבחר על ידי המחשב
                        {
                            board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, images.GetImageByItSerialNumber(images.GetSerialNumberByItName(color[i, j]) + 4)
                               , images, images.GetSerialNumberByItName(color[i, j]) + 4, new Point(i, j));
                        }
                        else if (status[i, j] == GameManager.Status.player)//במידה והתא נבחר על ידי השחקן
                        {
                            board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, images.GetImageByItSerialNumber(images.GetSerialNumberByItName(color[i, j]) + 8)
                               , images, images.GetSerialNumberByItName(color[i, j]) + 8, new Point(i, j));
                        }
                        else//במידה והתא עדיין פנוי
                        {
                            board[i, j] = new GraphicsCell(formGame, gameManager, xCell, yCell, widthCell, g, images.GetImageByItSerialNumber(images.GetSerialNumberByItName(color[i, j]))
                               , images, images.GetSerialNumberByItName(color[i, j]), new Point(i, j));
                        }
                        board[i, j].CellStatus = status[i, j];
                    }
                    yCell = yCell + moveY;
                }
                xCell = xCell + moveX;
                yCell = this.y;

                //מאתחל את כל האפשרות בחירה ללחצנים כשקר
                green = false;
                red = false;
                blue = false;
                purple = false;
            }

            //שומר את כל התאים שנמצאים בשכנות לתא
            for (int m = 0; m < numOfColumns; m++)
            {
                for (int n = 0; n < numOfLines; n++)
                {
                    if (n > 0)
                    { board[m, n].AddNeighbor(board[m, n - 1]); }
                    if (n < numOfLines - 1)
                    { board[m, n].AddNeighbor(board[m, n + 1]); }
                    if (m > 0)
                    { board[m, n].AddNeighbor(board[m - 1, n]); }
                    if (m < numOfColumns - 1)
                    { board[m, n].AddNeighbor(board[m + 1, n]); }
                    if (m % 2 == 0)
                    {
                        if (m > 0 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m - 1, n + 1]); }
                        if (m < numOfColumns - 1 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m + 1, n + 1]); }
                    }
                    else
                    {
                        if (m < numOfColumns - 1 && n > 0) { board[m, n].AddNeighbor(board[m + 1, n - 1]); }
                        if (m > 0 && n > 0) { board[m, n].AddNeighbor(board[m - 1, n - 1]); }
                    }
                }
            }
        }

        public Board(Board b)
        {
            //פעולה בונה מעתיקה
            this.x = b.GetLocationPoint().X;
            this.y = b.GetLocationPoint().Y;
            this.g = b.GetG();
            this.width = b.GetWidth();
            this.numOfColumns = b.GetNumOfColumns();
            this.numOfLines = b.GetNumOfLines();
            this.formGame = b.GetFormGame();
            this.images = new Images();
            this.gameManager = b.GetGameManager();
            this.board = new GraphicsCell[b.GetCellsBoard().GetLength(0), b.GetCellsBoard().GetLength(1)];

            for (int i = 0; i < b.GetCellsBoard().GetLength(0); i++)
            {
                for (int j = 0; j < b.GetCellsBoard().GetLength(1); j++)
                {
                    this.board[i, j] = new GraphicsCell(b.GetCellsBoard()[i, j]);
                }
            }

            this.red = b.Red;
            this.green = b.Green;
            this.blue = b.Blue;
            this.purple = b.Purple;
            this.playerTotalScore = b.PlayerTotalScore;
            this.computerTotalScore = b.ComputerTotalScore;

            //שומר את כל התאים שנמצאים בשכנות לתא
            for (int m = 0; m < numOfColumns; m++)
            {
                for (int n = 0; n < numOfLines; n++)
                {
                    if (n > 0)
                    { board[m, n].AddNeighbor(board[m, n - 1]); }
                    if (n < numOfLines - 1)
                    { board[m, n].AddNeighbor(board[m, n + 1]); }
                    if (m > 0)
                    { board[m, n].AddNeighbor(board[m - 1, n]); }
                    if (m < numOfColumns - 1)
                    { board[m, n].AddNeighbor(board[m + 1, n]); }
                    if (m % 2 == 0)
                    {
                        if (m > 0 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m - 1, n + 1]); }
                        if (m < numOfColumns - 1 && n < numOfLines - 1) { board[m, n].AddNeighbor(board[m + 1, n + 1]); }
                    }
                    else
                    {
                        if (m < numOfColumns - 1 && n > 0) { board[m, n].AddNeighbor(board[m + 1, n - 1]); }
                        if (m > 0 && n > 0) { board[m, n].AddNeighbor(board[m - 1, n - 1]); }
                    }
                }
            }
        }

        //פעולות שמחזירות את הערך של המשתנים שבודקים האם אפשר לבחור את הצבע
        public bool Red
        {
            get { return red; }
        }

        public bool Green
        {
            get { return green; }
        }

        public bool Blue
        {
            get { return blue; }
        }

        public bool Purple
        {
            get { return purple; }
        }

        public GraphicsCell[,] GetCellsBoard() //פעולה שמחזירה את המערך תא מימדי של התאים שמייצגים את הלוח
        { return board; }

        public Point GetLocationPoint() //פעולה שמחזירה את מיקום הלוח
        { return new Point(this.x, this.y); }

        public int GetWidth() //פעולה שמחזירה את אורך הלוח
        { return this.width; }

        public int GetNumOfLines() //פעולה שמחזירה מספר השורות
        { return this.numOfLines; }

        public int GetNumOfColumns() //פעולה שמחזירה את מספר העמודות
        { return this.numOfColumns; }

        public FormGame GetFormGame() //פעולה שמחזירה את לוח המשחק
        { return this.formGame; }

        public GameManager GetGameManager() //פעולה שמחזירה משתנה שמייצג את המנהל משחק
        { return this.gameManager; }

        public Graphics GetG() //פעולה שמחזירה את משתנה הגרפיקה
        { return this.g; }

        public int PlayerTotalScore
        {
            //מחזיר את הניקוד הכללי של השחקן
            get { return playerTotalScore; }
            //מעדכן את הניקוד הכללי של השחקן
            set { playerTotalScore = playerTotalScore + value; }
        }

        public int ComputerTotalScore
        {
            //מחזיר את הניקוד הכללי של המחשב
            get { return computerTotalScore; }
            //מעדכן את הניקוד הכללי של המחשב
            set { computerTotalScore = computerTotalScore + value; }
        }

        public void DrawAgain(int startX, int startY, int newWidth)
        {
            //פעולה שמעדכנת את הגודל של לוח המשחק לאחר שינוי גודל המסך הכללי ומציגה את הלוח לפי ערכיו החדשים
            int newYCell = startY, newMoveY = (int)(Math.Sqrt(3) * (newWidth / this.numOfLines / 2)),
                newXCell = startX, newMoveX = (int)((3 * newWidth / this.numOfLines) / 4);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i % 2 != 0)
                    newYCell = newYCell - (int)(newMoveY / 2);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].SetLocationAndSize(newXCell, newYCell, newWidth / this.numOfLines);
                    board[i, j].Draw();
                    newYCell = newYCell + newMoveY;
                }
                newXCell = newXCell + newMoveX;
                newYCell = startY;

            }
        }

        public Point WhichCellWasChosen(int xChose, int yChose)
        {
            //פעולה שבודקת בתוך איזה תא נקודה מסויימת נמצאת. אם נקודה זו לא נמצאת בתוך שום תא, הפעולה מחזרה נקודה שערכיה -1,-1
            for (int i = 0; i < numOfColumns; i++)
            {
                for (int j = 0; j < numOfLines; j++)
                {
                    if (board[i, j].IsInsideTheCell(xChose, yChose))
                        return new Point(i, j);
                }
            }
            return new Point(-1, -1);
        }

        public bool MouseClick(GameManager.Status status, MyImage.Status color, int isItChecked)
        {
            //פעולה שמבצעת מהלך משחק לאחר לחיצה על אחד מלחצני הצבע. פועלת לפי מי שהתור שלו כרגע (מחשב או שחקן) ולפני הצבע שנבחר
            if (status == GameManager.Status.computer)
            {

                ComputerChoseAllCellsInTheSameColor(color, board[board.GetLength(0) - 1, board.GetLength(1) - 1], isItChecked);
            }

            if (status == GameManager.Status.player)
            {
                PlayerChoseAllCellsInTheSameColor(color, board[0, 0], isItChecked);

            }
            return true;
        }

        public bool IsCorrectMove(int xChose, int yChose, GameManager.Status status)
        {
            //פעולה שבודקת האם צעד מסויים הוא תקין לפי חוקי המשחק
            //מחזירה אמת אם הצעד חוקי ושקר אחרת
            Point chosePoint = WhichCellWasChosen(xChose, yChose);
            return board[chosePoint.X, chosePoint.Y].CanBeChosen(status);

        }

        public void AllColorsThatPlayerBeChose(Button ButtonRed, Button buttonPurple, Button buttonGreen, Button buttonBlue)
        {
            //פעולה שבודקת אילו צבעים מבין ארבעת הצבעים יכולים להיבחר על ידי השחקן לפי חוקי המשחק והופכת את הכפתורים המתאימים לנראים ואת המשתנים הבוליאנים המתאימים לאמת
            //זאת אומרת אילו מבין ארבעת הצבעים נמצאים צמוד לאבן משחק שכבר נבחרה
            //אתחול ללחצנים
            ButtonRed.Visible = false;
            buttonPurple.Visible = false;
            buttonGreen.Visible = false;
            buttonBlue.Visible = false;
            //אתחול למשתנים שמייצגים את הלחצנים
            red = false;
            purple = false;
            green = false;
            blue = false;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].CellStatus == GameManager.Status.player)
                    {
                        for (int k = 0; k < board[i, j].FindNeighbours().Count; k++)
                        {
                            if (board[i, j].FindNeighbours()[k] != null)
                            {
                                if (board[i, j].FindNeighbours()[k].CellStatus == GameManager.Status.empty)
                                {
                                    if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Red)
                                    {
                                        ButtonRed.Visible = true;
                                        red = true;
                                    }
                                    if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Purple)
                                    {
                                        buttonPurple.Visible = true;
                                        purple = true;
                                    }
                                    if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Green)
                                    {
                                        buttonGreen.Visible = true;
                                        green = true;
                                    }
                                    if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Blue)
                                    {
                                        buttonBlue.Visible = true;
                                        blue = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AllColorsThatCanBeChose(GameManager.Status status)
        {
            //פעולה שבודקת אילו צבעים מבין ארבעת הצבעים יכולים להיבחר לפי חוקי המשחק והופכת את המשתנים הבוליאניים המתאימים לאמת
            //זאת אומרת אילו מבין ארבעת הצבעים נמצאים צמוד לאבן משחק שכבר נבחרה

            //אתחול למשתנים שמייצגים את הלחצנים
            red = false;
            purple = false;
            green = false;
            blue = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].CellStatus == status)
                    {
                        for (int k = 0; k < board[i, j].FindNeighbours().Count; k++)
                        {
                            if (board[i, j].FindNeighbours()[k] != null)
                            {
                                if (board[i, j].FindNeighbours()[k].CellStatus == GameManager.Status.empty)
                                {
                                    if (board[i, j].FindNeighbours()[k] != null)
                                    {

                                        if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Red)
                                        {
                                            red = true;
                                        }
                                        if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Purple)
                                        {
                                            purple = true;
                                        }
                                        if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Green)
                                        {
                                            green = true;
                                        }
                                        if (board[i, j].FindNeighbours()[k].CellColor == MyImage.Status.Blue)
                                        {
                                            blue = true;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PlayerChoseAllCellsInTheSameColor(MyImage.Status correntColor, GraphicsCell cell, int isItChecked)
        {
            //פעולה שמסמנת את כל התאים הסמוכים זה לזה שבאותו הצבע לפי חוקי המשחק לשחקן
            if (cell.CellStatus == GameManager.Status.player)
            {
                for (int k = 0; k < cell.FindNeighbours().Count; k++)
                {

                    if (cell.FindNeighbours()[k] != null)
                    {
                        if (cell.FindNeighbours()[k].CellStatus == GameManager.Status.player)
                        {
                            if (isItChecked != cell.FindNeighbours()[k].IsItChecked)
                            {
                                cell.FindNeighbours()[k].IsItChecked = isItChecked;
                                PlayerChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked);
                            }
                        }

                        else if (cell.FindNeighbours()[k].CellColor == correntColor &&
                        cell.FindNeighbours()[k].CellStatus == GameManager.Status.empty)
                        {
                            cell.FindNeighbours()[k].PlayerMouseClick();
                            playerTotalScore++;
                            PlayerChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked);
                        }

                    }
                }
            }
        }

        public void ComputerChoseAllCellsInTheSameColor(MyImage.Status correntColor, GraphicsCell cell, int isItChecked)
        {
            //פעולה שמסמנת את כל התאים הסמוכים זה לזה שבאותו הצבע לפי חוקי המשחק של המחשב
            if (cell.CellStatus == GameManager.Status.computer)
            {
                for (int k = 0; k < cell.FindNeighbours().Count; k++)
                {

                    if (cell.FindNeighbours()[k] != null)
                    {
                        if (cell.FindNeighbours()[k].CellStatus == GameManager.Status.computer)
                        {
                            if (isItChecked != cell.FindNeighbours()[k].IsItChecked)
                            {
                                cell.FindNeighbours()[k].IsItChecked = isItChecked;
                                ComputerChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked);
                            }
                        }
                        else if (cell.FindNeighbours()[k].CellColor == correntColor &&
                        cell.FindNeighbours()[k].CellStatus == GameManager.Status.empty)
                        {
                            cell.FindNeighbours()[k].ComputerMouseClick();
                            computerTotalScore++;
                            ComputerChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked);

                        }
                    }
                }
            }
        }

        public void Draw()
        {
            //פעולה שמציירת את לוח המשחק
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {

                    board[i, j].Draw();

                }
            }
        }

        public bool IsGameOver(Button buttonRed, Button buttonPurple, Button buttonGreen, Button buttonBlue)
        {
            //פעולה שבודקת אם לשחקן או למחשב אין עוד אופציות בחירה, זאת אומרת שאין לו עוד תאי משחק לבחור, המשחק נגמר
            if (red == false && purple == false && green == false && blue == false)
            {
                return true;
            }
            return false;
        }

    }
}
