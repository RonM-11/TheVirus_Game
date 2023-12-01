using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace MyGame_RonM
{
    public class GraphicsCell
    {
        Graphics g; /*עצם מסוג המחלקה Graphics*/
        int locationX, locationY; /*ערכי האיקס והווי של מיקום התא על הלוח*/
        Point locationPoint; /*נקודת מיקום התא על הלוח*/
        Images images; /*עצם ששומר את כל התמונות האפשריות לתא*/
        int radius; /*רדיוס צורת המשושה שהיא צורת אבן המשחק*/
        Point[] vertices; /*מערך ששומר את נקודות ששת הקודקודיים של המשושה שהוא צורת אבן המשחק*/
        int imageSerialNumber; /*מספר הסידורי של התמונה במערך שנמצא בעצם images*/
        int xCenter, yCenter; /*נקודות האיקס והווי של מרכז המשושה*/
        private GameManager.Status cellStatus; /*אם האבן שייכת למחשב/שחקן/אף אחד*/
        List<GraphicsCell> neighbours; /*רשימת התאים שנמצאים בשכנות לתא*/
        MyImage.Status cellColor; /*צבע התא(שומר גם את מי ששייך לתא)*/
        Image cellImage; /*תמונת התא*/
        Point placeInTheBoard; /*מיקום התא בתוך לוח המשחק*/
        FormGame formGame; /*טופס המשחק*/
        GameManager gameManager; /*מנהל המשחק*/
        int width; /*אורך התא*/
        int isItChecked = 0; /*משתנה עזר לפעולת סימון התאים לפונקציה היוריסטית*/

        public GraphicsCell(FormGame formGame0, GameManager gameManager0, int locationX0, int locationY0, int width0, Graphics g, Image firstImage0,
            Images images0, int imageSerialNumber, Point placeInTheBoard0)
        {
            //פעולה בונה של אבן משחק
            //מימדי התא
            this.width = width0;
            radius = width / 2;
            this.locationX = locationX0;
            this.locationY = locationY0;
            locationPoint = new Point(this.locationX, this.locationY);
            this.images = images0;
            formGame = formGame0;
            gameManager = gameManager0;
            //בתחילה, כל תא ריק
            cellStatus = GameManager.Status.empty;
            cellColor = images.GetColor(imageSerialNumber);
            this.placeInTheBoard = placeInTheBoard0;
            this.cellImage = firstImage0;
            this.g = g;
            this.imageSerialNumber = imageSerialNumber;
            //.....................................................................................................
            xCenter = this.locationX + radius;
            yCenter = this.locationY + (int)(Math.Sqrt(3) * radius / 2);
            //מערך של נקודות ששומר את ערכי הקודקודים של תא בצורת משושה. מתחיל מהקודקוד השמאלי העליון עם כיוון השעון
            vertices = new Point[6];
            vertices[0] = new Point(this.locationX + (int)(radius / 2), this.locationY);
            vertices[1] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY);
            vertices[2] = new Point(this.locationX + (int)(2 * radius), this.locationY + (int)(Math.Sqrt(3) * radius / 2));
            vertices[3] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[4] = new Point(this.locationX + (int)(radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[5] = new Point(this.locationX, this.locationY + (int)(Math.Sqrt(3) * radius / 2));
            //שרשרת חוליות ששומרת את כל השכנים של התא.....................................................................................................
            neighbours = new List<GraphicsCell>();
            //.....................................................................................................
        }

        public GraphicsCell(GraphicsCell cell)
        {
            //פעולה בונה מעתיקה של אבן משחק
            //מימדי התא
            this.width = cell.GetWidth();
            radius = width / 2;
            this.locationX = cell.GetLocation().X;
            this.locationY = cell.GetLocation().Y;
            this.locationPoint = cell.GetLocation();
            this.g = cell.GetG();
            this.images = cell.GetImages();
            formGame = cell.GetFormGame();
            gameManager = cell.GetGameManager();
            cellStatus = cell.CellStatus;
            this.imageSerialNumber = cell.GetImageSerialNumber();
            this.placeInTheBoard = cell.GetPlaceInTheBoard();
            this.cellImage = cell.GetImage();
            cellColor = images.GetColor(imageSerialNumber);
            locationPoint = new Point(this.locationX, this.locationY);
            //.....................................................................................................
            xCenter = this.locationX + radius;
            yCenter = this.locationY + (int)(Math.Sqrt(3) * radius / 2);
            //מערך של נקודות ששומר את ערכי הקודקודים של תא בצורת משושה. מתחיל מהקודקוד השמאלי העליון עם כיוון השעון
            vertices = new Point[6];
            vertices[0] = new Point(this.locationX + (int)(radius / 2), this.locationY);
            vertices[1] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY);
            vertices[2] = new Point(this.locationX + (int)(2 * radius), this.locationY + (int)(Math.Sqrt(3) * radius / 2));
            vertices[3] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[4] = new Point(this.locationX + (int)(radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[5] = new Point(this.locationX, this.locationY + (int)(Math.Sqrt(3) * radius / 2));
            //שרשרת חוליות ששומרת את כל השכנים לאותו תא.....................................................................................................
            neighbours = new List<GraphicsCell>();
            //.....................................................................................................
        }

        public int GetImageSerialNumber() //פעולה שמחזירה את המספר הסידורי של התמונה
        { return this.imageSerialNumber; }

        public Point GetPlaceInTheBoard() //פעולה שמחזירה את המיקום של התא ביחד ללוח
        { return placeInTheBoard; }

        public Image GetImage() //פעולה שמחזירה את התמונה של התא
        { return this.cellImage; }

        public GameManager.Status CellStatus
        {
            //מחזירה ומעדכנת מי בחר את התא
            get { return cellStatus; }
            set { cellStatus = value; }
        }

        public MyImage.Status CellColor
        {
            //מחזירה ומעדכנת את צבע התא
            get { return cellColor; }
            set { cellColor = value; }
        }

        public int IsItChecked
        {
            //מחזירה ומעדכנת את בחירת התא (משתנה עזר שעוזר בסימון וספירת התאים)
            get { return isItChecked; }
            set { isItChecked = value; }
        }

        public Point[] Vertices
        {
            //פעולה שמחזירה את מערך הקודקודים של התא
            get { return vertices; }
        }

        public Point GetLocation() //פעולה שמחזירה את נקודת המיקום של התא
        { return new Point(locationPoint.X, locationPoint.Y); }

        public int GetWidth() //פעולה שמחזירה את האורך של התא
        { return width; }

        public Images GetImages()//פעולה שמחזירה את מערך של תמונות מסוג MyImage
        { return images; }

        public FormGame GetFormGame() //פעולה שמחזירה את טופס המשחק
        { return this.formGame; }

        public Graphics GetG() //פעולה שמחזירה את משתנה הגרפיקה
        { return this.g; }

        public GameManager GetGameManager() //פעולה שמחזירה את מנהל המשחק
        { return this.gameManager; }

        public void SetLocationAndSize(int newX, int newY, int newWidth)
        {
            //פעולה שמעדכנת את הגודל והמיקום של אבן משחק
            locationX = newX;
            locationY = newY;
            width = newWidth;
            radius = newWidth / 2;
        }

        public void ChangeCellImage(MyImage.Status status)
        {
            //פעולה שמשנה את התמונה של התא
            //לפי הסטטוס של תמונה רצויה אחרת
            this.cellImage = images.GetImageByItName(status);
        }

        public void SetFirstImageAndImageSerialNumber(Image image, int sNumber)
        {
            //פעולה שמשנה את התמונה של האבן משחק ואת המספר הסידורי של התמונה בהתאמה
            this.imageSerialNumber = sNumber;
            this.cellImage = image;
        }

        public int GetSerialNumber()//פעולה שמחזירה את המספר הסידורי של התמונה            
        { return this.imageSerialNumber; }

        //..........................................................................................
        //בהנחה שיש כ4 סוגי תמונות שונים ובמערך הם נמצאים כך שקודם נמצאים הארבעה ללא הסמל, 
        //אחריהם אותם ארבעה עם סמל של המחשב ולאחריהם ארבעה עם הסמל של השחקן
        //..........................................................................................
        public void PlayerMouseClick()
        {
            //פעולה שמשנה את אבן המשחק להיות אבן משחק שנבחרה על ידי השחקן
            this.cellImage = images.GetImageByItSerialNumber(this.imageSerialNumber + 8);
            cellStatus = GameManager.Status.player;
            this.Draw();
        }

        public void ComputerMouseClick()
        {
            //פעולה שמשנה את אבן המשחק להיות אבן משחק שנבחרה על ידי המחשב
            this.cellImage = images.GetImageByItSerialNumber(this.imageSerialNumber + 4);
            cellStatus = GameManager.Status.computer;
            this.Draw();
        }

        public bool IsInsideTheCell(int xChose, int yChose)
        {
            // הפעולה בודקת אם נקודה מסויימת נמצאת בתוך התא המשושה או לא
            //הפעולה מקבלת את הנקודה המסויימת ומחזירה אמת אם הנקודה בתוך המשושה ושקר אחרת
            double distance = Math.Sqrt(Math.Pow((xCenter - xChose), 2) + Math.Pow((yCenter - yChose), 2));
            if (distance < radius)
                return true;
            return false;
        }

        public void AddNeighbor(GraphicsCell cell)
        {
            //פעולה שמוסיפה שכן מסוג GraphicsCell 
            //לרשימת השכנים
            neighbours.Add(cell);
        }

        public List<GraphicsCell> FindNeighbours() //פעולה שמחזירה את שרשרת החוליות של כל אבני המשחק שנמצאים בשכנות לאבן המשחקן הנוכחית
        { return neighbours; }

        public bool CanBeChosen(GameManager.Status gameStatus)
        {
            //פעולה שבודקת אם השחקן או המחשב יכולים לבחור תא מסויים,
            //זאת אומרת, אם מסביב לתא הנ"ל יש תא שייך להם 
            //והתא עצמו ריק
            if (CellStatus != GameManager.Status.empty)
            { return false; }
            for (int i = 0; i < neighbours.Count; i++)
            { if (neighbours[i].CellStatus == gameStatus) { return true; } }
            return false;
        }

        public void Draw()
        {
            //פעולה שמציירת תא
            g = formGame.CreateGraphics();
            g.DrawImage(cellImage, locationX, locationY, width, (int)(Math.Sqrt(3) * radius));
            SetVertices();
            g.DrawPolygon(new Pen((Color.Black), 3), vertices);
        }

        public void SetVertices()
        {
            //פעולה שמעדכנת את מערך הקודקודים
            vertices[0] = new Point(this.locationX + (int)(radius / 2), this.locationY);
            vertices[1] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY);
            vertices[2] = new Point(this.locationX + (int)(2 * radius), this.locationY + (int)(Math.Sqrt(3) * radius / 2));
            vertices[3] = new Point(this.locationX + (int)(3 * radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[4] = new Point(this.locationX + (int)(radius / 2), this.locationY + (int)(Math.Sqrt(3) * radius));
            vertices[5] = new Point(this.locationX, this.locationY + (int)(Math.Sqrt(3) * radius / 2));
        }

    }
}
