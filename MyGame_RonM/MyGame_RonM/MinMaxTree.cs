using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyGame_RonM
{
    public class MinMaxTree
    {
        int depth; /*משתנה שמחזיק את העומק המקסימלי של העץ כפי שהוגדר*/
         TempBoard tempBoard; /*לוח זמני מסוג TempBoard
                               שמחזיק מידע מינימלי הדרוש לפיתוח העץ*/
        Board board; /*הלוח המקורי מסוג Board
                      שאחריו המחשב צריך לעשות מהלך*/
        GameManager.Status turn; /*התור של השורש*/
        ListTreeNode tree; /*עץ מינמקס*/
        string color; /*הצבע הנבחר למהלך האידיאלי של המחשב*/

        public MinMaxTree(int depth0, Board board0, GameManager.Status turn0)
        {
            //פעולה בונה של העץ מהלכים- עץ מינמקס
            depth = depth0;
            board=board0;
            turn=turn0;
            tempBoard = new TempBoard(board);//העתקת הלוח ללוח ששומר מידע מינמלי הדרוש לפיתוח עץ מהלכים
            tree = new ListTreeNode(0.ToString(), "", 0, depth, tempBoard, turn, -1);//בונה אתה שורש של העץ   
            color = TheIdealColor(); 
        }

        public int MinMaxValue(int max, int min, ListTreeNode child)
        {
            //מוצאת את הערך האידיאלי למהלך של המחשב
            if (child.GetChildren().Count==0)//אם מדובר בעלה, הפעולה מחזירה את הערך שלו
                return child.GetTheValue();

            if (child.GetTurn() == GameManager.Status.computer)//אם מדובר בצעד של המחשב, הפעולה מחזירה את הערך המקסימלי מבין בניו
            {
                foreach (ListTreeNode helper in child.GetChildren())
                {
                    max = Math.Max(max, MinMaxValue(max, min, helper));
                    helper.SetTheValue(max);
                    Console.WriteLine(helper.GetTheValue().ToString());//כלי למעקב
                }
                return max;
            }

            else//אם מדובר בשחקן, הפעולה מחזירה את הערך המינימלי מבין בניו
            {
                foreach (ListTreeNode helper in child.GetChildren())
                {                 
                    min = Math.Min(min, MinMaxValue(max, min, helper));
                    helper.SetTheValue(min);
                    Console.WriteLine(helper.GetTheValue().ToString());
                }
                return min;
            }
        }

        public String TheIdealColor()
        {
            //פעולה מחזירה את הצעד האידיאלי של המחשב בצורת מחרוזת שבה יש שם של צבע
            int idealValue = MinMaxValue(int.MinValue + 1, int.MaxValue - 1, tree);
            foreach(ListTreeNode helper in tree.GetChildren())
            {
                if (helper.GetTheValue() == idealValue)
                    return helper.GetRoad();
            }
            return "";
        }

        public MyImage.Status TranslatestringToStatus(string color)
        {
            //הפעולה ממירה שם של צבע לenum 
            //של המחלקה MyImage
            //שמייצג צבעים
            if (color == "")
                return MyImage.Status.empty;
            else if (color[0] == 'P')
                return MyImage.Status.Purple;
            else if (color[0] == 'R')
                return MyImage.Status.Red;
            else if (color[0] == 'B')
                return MyImage.Status.Blue;
            else
                return MyImage.Status.Green;
        }

        public MyImage.Status GetTheIdealColor()
        {
            //הפעולה שמחזירה את הצעד האידיאלי של המחשב 
            return TranslatestringToStatus(color);
        }

        public bool IsGameOver()
        {
            //הפעולה בודקת אם המשחק נגמר
            return tree.GetChildren().Count == 0; //אם אין בנים, זאת אומרת למחשב אין אופציות להתקדם ולכן לפי חוקי המשחק המשחק נגמר
        }

    }
}
