using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame_RonM
{
    public class ListTreeNode
    {
        //מחרוזות שמציגות את הדרך שבה הגיעו לבן הנוכחי לפי מסלול של מספרים סידורים של כל הצמתים לפניו ולפי מסלול של הצבעים שהיו צריכים להיבחר כדי להגיע לבן בהתאמה
        string path, road;
        List<ListTreeNode> children; /*רשימת כל הבנים של הצומת הנוכחית*/
        int depth, finalDepth; /*עומק הצומת הנוכחית והעומק הסופי שהוגדר*/
        TempBoard tempBoard, board; /*משתנה עזר של לוח זמני ולוח זמני*/
        GameManager.Status turn; /*מחזיק את בעל התור הנוכחי*/
        bool[] boardColors; /*משתנה עזר ששומר אילו מהצבעים יכולים להיבחר ובכך אילו בנים יווצרו*/
        int theValue; /*ערך המהלך הנוכחי*/

        public ListTreeNode(string path0, string road0, int depth0, int finalDepth0, TempBoard board0, GameManager.Status turn0, int theValue0)
        {
            //פעולה בונה של הצומת
            path = path0;
            depth = depth0;
            finalDepth = finalDepth0;
            board = board0;
            turn = turn0;
            road = road0;
            theValue = theValue0;
            Console.WriteLine(path + " " + theValue.ToString() + " " + road + " " + turn.ToString()); //כלי לצורך מעקב 
            children = new List<ListTreeNode>();
            int count = path.Length;//מוצא את העומק הנוכחי של העץ
            boardColors = new bool[4];
            //החלפת התור של השחקן למחשב או ההפך
            if (turn == GameManager.Status.computer)
                turn = GameManager.Status.player;
            else if (turn == GameManager.Status.player)
                turn = GameManager.Status.computer;
            if (count <= finalDepth) //בתנאי שהצומת לא הגיעה לרמה שגודרה לעץ, אותה צומת מורחבת על ידי כך שהבנים שלה נוצרים
            {
                Expand();//יצירת בנים של הצומת הנוכחית
            }
        }

        public void Expand()
        {
            //פעולה שמוסיפה לצומת את בניו
            board.AllColorsThatCanBeChose(turn);//אילו צבעים יכולים להיבחר
            boardColors[0] = board.Red;
            boardColors[1] = board.Blue;
            boardColors[2] = board.Green;
            boardColors[3] = board.Purple;
            int index = 0;
            int value;//ערך צומת
            for (int i = 0; i < boardColors.Length; i++)
            {
                if (boardColors[i] == true)//אם הצבע הזה יכול להיבחר אז הוא יכול להיות אחד הבנים של הצומת 
                {
                    tempBoard = new TempBoard(board);//בניית לוח עזר
                    value = tempBoard.PotentialMove((MyImage.Status)i, Convert.ToInt32(path + (index + 1)), turn);//מציאת הערך של המהלך האפשרי וסימון התאים שנבחרים במהלך הנוכחי
                    if (path.Length < finalDepth)//מכיוון שהערך צריך להכנס רק לעלים, אם הצומת היא לא עלה נכנס אליה ערך לא אפשר מבחינת המשחק
                        value = 1111;
                    children.Add(new ListTreeNode(path + (index + 1).ToString(), road + ((MyImage.Status)i).ToString(), depth++, finalDepth, tempBoard, turn, value));
                    index++;
                }
            }
        }

        public int GetTheValue()
        //מחזירה את ערך הצומת
        { return theValue; }

        public void SetTheValue(int newValue)
        //מעדכנת את ערך הצומת
        { this.theValue = newValue; }

        public string GetRoad()
        //מחזירה את מסלול הצבעים שנדרשו כדי להגיע לצומת הנוכחית
        { return road; }

        public GameManager.Status GetTurn()
        //מחזירה מי התור שהבנים אלו המהלכים שלו
        { return turn; }

        public TempBoard GetBoard()
        //מחזירה את הלוח הזמני
        { return board; }

        public List<ListTreeNode> GetChildren()
        //מחזירה את הבנים של הצומת
        { return children; }

    }
}
