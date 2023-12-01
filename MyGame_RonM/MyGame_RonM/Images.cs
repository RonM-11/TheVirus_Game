using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame_RonM
{
    public class Images
    {
        //מערך מסוג MyImage
        MyImage[] imageArr;
        //מספר התמונות במערך התמונות
        int numOfImages = 12;

        public Images()
        {
            //פעולה בונה של עצם ובו יש מערך תמונות, כ12 תמונות בסך הכל
            imageArr = new MyImage[numOfImages];
            UploadImages();
        }

        private void UploadImages()
        {
            //פעולה שמעלה תמונות לפי הסדר הבא:
            //Red, Blue, Green, Purple,
            //ComputerRed, computerBlue, ComputerGreen, ComputerPurple,
            //PlayerRed, PlayerBlue, PlayerGreen, PlayerPurple
            int numOfImage1 = numOfImages - 1;
            //12
            imageArr[numOfImage1] = new MyImage(MyImage.Status.PlayerPurple, Image.FromFile("purplePlayer.png"));
            numOfImage1--;
            //11
            imageArr[numOfImage1] = new MyImage(MyImage.Status.PlayerGreen, Image.FromFile("GreenPlayer.png"));
            numOfImage1--;
            //10
            imageArr[numOfImage1] = new MyImage(MyImage.Status.PlayerBlue, Image.FromFile("bluePlayer.png"));
            numOfImage1--;
            //9
            imageArr[numOfImage1] = new MyImage(MyImage.Status.PlayerRed, Image.FromFile("redPlayer.png"));
            numOfImage1--;
            //8
            imageArr[numOfImage1] = new MyImage(MyImage.Status.ComputerPurple, Image.FromFile("purpleComputer.png"));
            numOfImage1--;
            //7
            imageArr[numOfImage1] = new MyImage(MyImage.Status.ComputerGreen, Image.FromFile("GreenComputer.png"));
            numOfImage1--;
            //6
            imageArr[numOfImage1] = new MyImage(MyImage.Status.computerBlue, Image.FromFile("blueComputer.png"));
            numOfImage1--;
            //5
            imageArr[numOfImage1] = new MyImage(MyImage.Status.ComputerRed, Image.FromFile("redComputer.png"));
            numOfImage1--;
            //4
            imageArr[numOfImage1] = new MyImage(MyImage.Status.Purple, Image.FromFile("purpleEmpty.png"));
            numOfImage1--;
            //3
            imageArr[numOfImage1] = new MyImage(MyImage.Status.Green, Image.FromFile("greenEmpty.png"));
            numOfImage1--;
            //2
            imageArr[numOfImage1] = new MyImage(MyImage.Status.Blue, Image.FromFile("blueEmpty.png"));
            numOfImage1--;
            //1
            imageArr[numOfImage1] = new MyImage(MyImage.Status.Red, Image.FromFile("redEmpty.png"));
        }

        public int GetNumOfImages()
        //פעולה שמחזירה כמה תמונות יש במערך התמונות
        {
            return numOfImages;
        }

        public Image GetImageByItName(MyImage.Status name)
        {
            //פעולה שמחזירה תמונה לפי שמה
            //במידה ואין תמונה בשם זה הפעולה מחזירה NULL
            for (int i = 0; i < numOfImages; i++)
            {
                if (imageArr[i].GetCellName().Equals(name))
                {
                    return imageArr[i].GetCellImage();
                }
            }
            return null;
        }

        public Image GetImageByItSerialNumber(int i0)
        {
            //פעולה שמחזירה תמונה לפי מספרה הסידורי
            //במידה ואין תמונה במספר סידורי זה הפעולה מחזירה NULL
            if (i0 < 0 || i0 >= numOfImages)
                return null;
            return imageArr[i0].GetCellImage();

        }

        public int GetSerialNumberByItName(MyImage.Status name)
        {
            //פעולה שמקבלת שם של תמונה מסוג enum 
            //ומחזירה את המספר הסידורי שלה
            for (int i = 0; i < numOfImages; i++)
            {
                if (name == imageArr[i].GetCellName())
                {
                    return i;
                }
            }
            return 0;
        }


        public MyImage.Status GetColor(int i0)
        {
            //פעולה שמחזירה את הצבע של המשבצת, הצבע מוחזר מסוג סטטוס
            return imageArr[i0].GetCellName();
        }

    }
}
