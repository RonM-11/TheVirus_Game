using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame_RonM
{
    public class TempBoard
    {
        Cell[,] cells; /*לוח המשחק*/
        bool green, red, purple, blue; /*משתנים בולניארים ששומרים אלו מבין הצבעים הנ"ל יכולים להיבחר*/
        List<Cell>[,] neighbors; /*שומר את השכנים של כל התאים*/
        int movesValue; /*משתנה עזר לפונקציה היוריסטית*/
        int playerTotalScore = 0; /*שומר את הניקוד הכולל של השחקן*/
        int computerTotalScore = 0; /*שומר את הניקוד הכולל של המחשב*/

        public TempBoard(Board board)
        {
            //פעולה בונה של לוח זמני-לוח שמכיל בתוכו את המידע המינימלי שלקוח ממהלוח הרגיל ודרוש ליצירת עץ מהלכים
            neighbors = new List<Cell>[board.GetCellsBoard().GetLength(0), board.GetCellsBoard().GetLength(1)]; //הגדרת מערך דו מימדי ששומר את כל רשימות השכנים של התאים
            cells = new Cell[board.GetCellsBoard().GetLength(0), board.GetCellsBoard().GetLength(1)]; //הגדרת הלוח משחק
            movesValue = 0;
            playerTotalScore = board.PlayerTotalScore;
            computerTotalScore = board.ComputerTotalScore;
            //בניית התאים של הלוח הזמני
            for (int i = 0; i < board.GetCellsBoard().GetLength(0); i++)
            {
                for (int j = 0; j < board.GetCellsBoard().GetLength(1); j++)
                {
                    cells[i, j] = new Cell(board.GetCellsBoard()[i, j].CellColor, board.GetCellsBoard()[i, j].CellStatus, board.GetCellsBoard()[i, j].GetPlaceInTheBoard());
                }
            }

            //שומר את כל התאים שנמצאים בשכנות לכל תא
            for (int m = 0; m < board.GetCellsBoard().GetLength(0); m++)
            {
                for (int n = 0; n < board.GetCellsBoard().GetLength(1); n++)
                {
                    neighbors[m, n] = new List<Cell>();
                    if (n > 0)
                    {
                        neighbors[m, n].Add(cells[m, n - 1]);
                        cells[m, n].AddNeighbor(cells[m, n - 1]);
                    }
                    if (n < board.GetCellsBoard().GetLength(1) - 1)
                    {
                        neighbors[m, n].Add(cells[m, n + 1]);
                        cells[m, n].AddNeighbor(cells[m, n + 1]);
                    }
                    if (m > 0)
                    {
                        neighbors[m, n].Add(cells[m - 1, n]);
                        cells[m, n].AddNeighbor(cells[m - 1, n]);
                    }
                    if (m < board.GetCellsBoard().GetLength(0) - 1)
                    {
                        neighbors[m, n].Add(cells[m + 1, n]);
                        cells[m, n].AddNeighbor(cells[m + 1, n]);
                    }
                    if (m % 2 == 0)
                    {
                        if (m > 0 && n < board.GetCellsBoard().GetLength(1) - 1)
                        {
                            neighbors[m, n].Add(cells[m - 1, n + 1]);
                            cells[m, n].AddNeighbor(cells[m - 1, n + 1]);
                        }
                        if (m < board.GetCellsBoard().GetLength(0) - 1 && n < board.GetCellsBoard().GetLength(1) - 1)
                        {
                            neighbors[m, n].Add(cells[m + 1, n + 1]);
                            cells[m, n].AddNeighbor(cells[m + 1, n + 1]);
                        }
                    }
                    else
                    {
                        if (m < board.GetCellsBoard().GetLength(0) - 1 && n > 0)
                        {
                            neighbors[m, n].Add(cells[m + 1, n - 1]);
                            cells[m, n].AddNeighbor(cells[m + 1, n - 1]);
                        }
                        if (m > 0 && n > 0)
                        {
                            neighbors[m, n].Add(cells[m - 1, n - 1]);
                            cells[m, n].AddNeighbor(cells[m - 1, n - 1]);
                        }
                    }
                }
            }
        }

        public TempBoard(TempBoard board)
        {
            //פעולה בונה מעתיקה
            neighbors = new List<Cell>[board.GetCells().GetLength(0), board.GetCells().GetLength(1)];//הגדרת מערך דו מימדי ששומר את רשימות השכנים של כל התאים
            cells = new Cell[board.GetCells().GetLength(0), board.GetCells().GetLength(1)];//הגדרת הלוח משחק
            playerTotalScore = board.PlayerTotalScore;
            computerTotalScore = board.ComputerTotalScore;
            //בניית התאים של הלוח הזמני
            for (int i = 0; i < board.GetCells().GetLength(0); i++)
            {
                for (int j = 0; j < board.GetCells().GetLength(1); j++)
                {
                    cells[i, j] = new Cell(board.GetCells()[i, j].Color, board.GetCells()[i, j].Status, board.GetCells()[i, j].GetPlaceInTheBoard());
                }
            }

            //שומר את כל התאים שנמצאים בשכנות לתא
            for (int m = 0; m < board.GetCells().GetLength(0); m++)
            {
                for (int n = 0; n < board.GetCells().GetLength(1); n++)
                {
                    neighbors[m, n] = new List<Cell>();
                    if (n > 0)
                    {
                        neighbors[m, n].Add(cells[m, n - 1]);
                        cells[m, n].AddNeighbor(cells[m, n - 1]);
                    }
                    if (n < board.GetCells().GetLength(1) - 1)
                    {
                        neighbors[m, n].Add(cells[m, n + 1]);
                        cells[m, n].AddNeighbor(cells[m, n + 1]);
                    }
                    if (m > 0)
                    {
                        neighbors[m, n].Add(cells[m - 1, n]);
                        cells[m, n].AddNeighbor(cells[m - 1, n]);
                    }
                    if (m < board.GetCells().GetLength(0) - 1)
                    {
                        neighbors[m, n].Add(cells[m + 1, n]);
                        cells[m, n].AddNeighbor(cells[m + 1, n]);
                    }
                    if (m % 2 == 0)
                    {
                        if (m > 0 && n < board.GetCells().GetLength(1) - 1)
                        {
                            neighbors[m, n].Add(cells[m - 1, n + 1]);
                            cells[m, n].AddNeighbor(cells[m - 1, n + 1]);
                        }
                        if (m < board.GetCells().GetLength(0) - 1 && n < board.GetCells().GetLength(1) - 1)
                        {
                            neighbors[m, n].Add(cells[m + 1, n + 1]);
                            cells[m, n].AddNeighbor(cells[m + 1, n + 1]);
                        }
                    }
                    else
                    {
                        if (m < board.GetCells().GetLength(0) - 1 && n > 0)
                        {
                            neighbors[m, n].Add(cells[m + 1, n - 1]);
                            cells[m, n].AddNeighbor(cells[m + 1, n - 1]);
                        }
                        if (m > 0 && n > 0)
                        {
                            neighbors[m, n].Add(cells[m - 1, n - 1]);
                            cells[m, n].AddNeighbor(cells[m - 1, n - 1]);
                        }
                    }
                }
            }
        }

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

        public int MovesValue
        {
            //מחזירה את הניקוד של מהלך
            get { return movesValue; }
            //מעדכנת לאפס את הניקוד של המהלך
            set { movesValue = 0; }
        }

        //פעולות שמחזירות משתנים בוליאנים שמייצגים אם אפשר לבחור בצבע
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

        public Cell[,] GetCells()
        {
            //פעולה שמחזירה את הלוח
            return cells;
        }

        public void AllColorsThatCanBeChose(GameManager.Status turn)
        {
            //פעולה שבודקת אילו צבעים מבין ארבעת הצבעים יכולים להיבחר על ידי השחקן לפי חוקי המשחק והופכת את המשתנים המתאימים לאמת
            //זאת אומרת אילו מבין ארבעת הצבעים נמצאים צמוד לאבן משחק שכבר נבחרה
            //אתחול למשתנים שמייצגים את הלחצנים
            red = false;
            purple = false;
            green = false;
            blue = false;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].Status == turn)
                    {
                        for (int k = 0; k < neighbors[i, j].Count; k++)
                        {
                            if (neighbors[i, j][k] != null)
                            {
                                if (neighbors[i, j][k].Status == GameManager.Status.empty)
                                {
                                    if (neighbors[i, j][k].Color == MyImage.Status.Red)
                                    {
                                        red = true;
                                    }
                                    if (neighbors[i, j][k].Color == MyImage.Status.Purple)
                                    {
                                        purple = true;
                                    }
                                    if (neighbors[i, j][k].Color == MyImage.Status.Green)
                                    {
                                        green = true;
                                    }
                                    if (neighbors[i, j][k].Color == MyImage.Status.Blue)
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

        public int ChoseAllCellsInTheSameColor(MyImage.Status correntColor, Cell cell, int isItChecked, GameManager.Status currentTurn)
        {
            //פעולה שמסמנת את כל התאים הסמוכים זה לזה שבאותו הצבע לפי חוקי המשחק לשחקן
            if (cell.Status == currentTurn)
            {
                for (int k = 0; k < cell.FindNeighbours().Count; k++)
                {
                    if (cell.FindNeighbours()[k] != null)
                    {
                        if (cell.FindNeighbours()[k].Status == currentTurn)
                        {
                            if (isItChecked != cell.FindNeighbours()[k].IsItChecked)
                            {
                                cell.FindNeighbours()[k].IsItChecked = isItChecked;
                                return ChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked, currentTurn);
                            }
                        }
                        else if (cell.FindNeighbours()[k].Color == correntColor &&
                        cell.FindNeighbours()[k].Status == GameManager.Status.empty)
                        {
                            cell.FindNeighbours()[k].Status = currentTurn;
                            return 1 + ChoseAllCellsInTheSameColor(correntColor, cell.FindNeighbours()[k], isItChecked, currentTurn);
                        }
                    }
                }
            }
            return 0;
        }

        public void PotentialMove(MyImage.Status correntColor, Cell cell, int isItChecked, GameManager.Status currentTurn)
        {
            //פעולת עזר לפונקציה היוריסטית
            //פעולה שמחשבת את השווי של מהלך בודד ומוסיפה לניקוד של השחקן או המחשב
            if (cell.Status == currentTurn)
            {
                for (int k = 0; k < cell.FindNeighbours().Count; k++)
                {
                    if (cell.FindNeighbours()[k] != null)
                    {
                        if (cell.FindNeighbours()[k].Status == currentTurn)
                        {
                            if (isItChecked != cell.FindNeighbours()[k].IsItChecked)
                            {
                                cell.FindNeighbours()[k].IsItChecked = isItChecked;
                                PotentialMove(correntColor, cell.FindNeighbours()[k], isItChecked, currentTurn);
                            }
                        }
                        else if (cell.FindNeighbours()[k].Color == correntColor &&
                        cell.FindNeighbours()[k].Status == GameManager.Status.empty)
                        {
                            cell.FindNeighbours()[k].Status = currentTurn;
                            if (currentTurn == GameManager.Status.computer)
                            { computerTotalScore++; movesValue++; }
                            else
                            { playerTotalScore++; movesValue++; }
                            PotentialMove(correntColor, cell.FindNeighbours()[k], isItChecked, currentTurn);
                        }
                    }
                }
            }
        }

        public int PotentialMove(MyImage.Status correntColor, int isItChecked, GameManager.Status turn)
        {
            //פונקציה היורסטית שמחזירה את הערך של מהלך
            movesValue = 0;
            if (turn == GameManager.Status.player)
            {
                PotentialMove(correntColor, cells[0, 0], isItChecked, turn);
            }
            else if (turn == GameManager.Status.computer)
            {
                PotentialMove(correntColor, cells[cells.GetLength(0) - 1, cells.GetLength(1) - 1], isItChecked, turn);
            }

            return computerTotalScore - playerTotalScore;

        }
    }
}
