using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame_RonM
{
    public class MyImage
    {
        //מחלקה נסוג enum 
        //ששומרת את שמות הצבעים כך שאם אין מילה אחרי הצבע-
        //האבן משחק לא נבחרה על ידי אף אחד
        //אם יש סיומת של המילה "computer"
        //או "player" 
        //האבן משחק נבחרה על ידי המחשב או השחקן בהתאמה
        public enum Status
        {
            Red, Blue, Green, Purple,
            ComputerRed, computerBlue, ComputerGreen, ComputerPurple,
            PlayerRed, PlayerBlue, PlayerGreen, PlayerPurple,
            empty
        };

        Image image; /*תמונת אבן המשחק*/
        Status status; /*צבע ומצב אבן המשחק*/

        public MyImage(Status status0, Image image0)
        {
            //פעולה שבונה עצם שבו יש תמונה ומספר סידורי מתאים
            this.status = status0;
            this.image = image0;
        }

        public Status GetCellName()
        {
            //פעולה שמחזירה את הסטטוס של התמונה
            return this.status;
        }

        public Image GetCellImage()
        {
            //פעולה שמחזירה את התמונה
            return this.image;
        }

        public void SetImage(Image newImage)
        {
            //פעולה שמעדכנת תמונה
            image = newImage;
        }

        public void SetStatus(Status newStatus)
        {
            //פעולה שמעדכנת סטטוס תמונה
            status = newStatus;
        }
    }
}
