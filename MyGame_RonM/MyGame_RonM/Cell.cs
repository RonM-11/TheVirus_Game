using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyGame_RonM
{
    public class Cell
    {
        MyImage.Status color; /*צבע התא*/
        GameManager.Status status; /*האם התא תפוס על ידי השחקן, המשתמש או שהוא ריק*/
        List<Cell> neighbors; /*שמירת התאים שנמצאים בשכנות לתא*/
        Point placeInTheBoard; /*מיקום התא בתוך הלוח*/
        int isItChecked = 0; /*משתנה עזר לפונקציה שמסמנת תאים*/

        public Cell(MyImage.Status color0, GameManager.Status status0, Point placeInTheBoard0)
        {
            //פעולה בונה של תא
            color = color0;
            status = status0;
            placeInTheBoard = placeInTheBoard0;
            neighbors = new List<Cell>(); //רשימת התאים שנמצאים בשכנות לתא
        }

        public Cell(Cell cell)
        {
            //פעולה בונה מעתיקה של תא
            color = cell.Color;
            status = cell.Status;
        }

        public MyImage.Status Color
        {
            //מחזירה ומעדכנת את צבע התא
            get { return color; }
            set { color = value; }
        }

        public GameManager.Status Status
        {
            //מחזירה ומעדכנת את מי שבחר את התא
            get { return status; }
            set { status = value; }
        }

        public void AddNeighbor(Cell cell)
        {
            //פעולה שמוסיפה שכן מסוג Cell 
            //לאבן המשחק
            neighbors.Add(cell);
        }

        public int IsItChecked
        {
            //מחזירה ומעדכנת את בחירת התא (משתנה עזר שעוזר בסימון וספירת התאים)
            get { return isItChecked; }
            set { isItChecked = value; }
        }

        public List<Cell> FindNeighbours()
        //פעולה שמחזירה את הרשימה של כל אבני המשחק שנמצאים בשכנות לאבן המשחקן הנוכחית
        { return neighbors; }

        public Point GetPlaceInTheBoard()
        //פעולה שמחזירה את מיקום התא בתוך הלוח
        { return placeInTheBoard; }

    }
}
