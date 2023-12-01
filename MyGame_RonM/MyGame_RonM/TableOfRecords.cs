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
    public partial class TableOfRecords : Form
    {
        static string recordsFile; /*שם הטופס ששומר בתוכו את הטבלת שיאים, השם של השמתמש שעשה את השיא ותאריך מתאימים*/
        string[,] lastScores; /*מערך ששומר את עשרת השיאים, השם של המשתמש שעשה את השיא ותאריך מתאימים*/
        static Game game; /*טופס התפריט ראשי של המשחק*/
        static FormGame formGame; /*טופס המשחק עצמו*/
        static FormBackgrounds formBackgrounds; /*טופס בחירת צבע רקע*/

        public TableOfRecords()
        {
            //פעולה בונה של טופס טבלת השיאים
            InitializeComponent();
            lastScores = new string[3, 10];//טבלת שיאים חדשה
            //////////כדי למחוק את הטבלת שיאים
            ////////for (int j = 0; j < lastScores.GetLength(1); j++)
            ////////{
            ////////    for (int i = 0; i < lastScores.GetLength(0); i++)
            ////////    {
            ////////        if (i == 0)
            ////////            lastScores[i, j] = "0";
            ////////        else if (i == 1)
            ////////            lastScores[i, j] = "00/00/0000";
            ////////        else
            ////////            lastScores[i, j] = "null";
            ////////    }
            ////////}
        }

        public static void SetMainPageForm(Game game0)
        { game = game0; }

        public static void SetFileName(string fileName0)
        { recordsFile = fileName0; }

        public static void SetGameForm(FormGame formGame0)
        { formGame = formGame0; }

        public static void SetFormBackgrounds(FormBackgrounds formBackgrounds0)
        { formBackgrounds = formBackgrounds0; }

        private void TableOfRecords_Shown(object sender, EventArgs e)
        {
            //פעולה שמעדכנת את הLabels בהתאם לנתונים במערך השיאים
            PutFillIntoArr();
            int i = 0;
            name1.Text = lastScores[2, i];
            i++;
            name2.Text = lastScores[2, i];
            i++;
            name3.Text = lastScores[2, i];
            i++;
            name4.Text = lastScores[2, i];
            i++;
            name5.Text = lastScores[2, i];
            i++;
            name6.Text = lastScores[2, i];
            i++;
            name7.Text = lastScores[2, i];
            i++;
            name8.Text = lastScores[2, i];
            i++;
            name9.Text = lastScores[2, i];
            i++;
            name10.Text = lastScores[2, i];
            i = 0;
            score1.Text = lastScores[0, i];
            i++;
            score2.Text = lastScores[0, i];
            i++;
            score3.Text = lastScores[0, i];
            i++;
            score4.Text = lastScores[0, i];
            i++;
            score5.Text = lastScores[0, i];
            i++;
            score6.Text = lastScores[0, i];
            i++;
            score7.Text = lastScores[0, i];
            i++;
            score8.Text = lastScores[0, i];
            i++;
            score9.Text = lastScores[0, i];
            i++;
            score10.Text = lastScores[0, i];
            i = 0;
            date1.Text = lastScores[1, i];
            i++;
            date2.Text = lastScores[1, i];
            i++;
            date3.Text = lastScores[1, i];
            i++;
            date4.Text = lastScores[1, i];
            i++;
            date5.Text = lastScores[1, i];
            i++;
            date6.Text = lastScores[1, i];
            i++;
            date7.Text = lastScores[1, i];
            i++;
            date8.Text = lastScores[1, i];
            i++;
            date9.Text = lastScores[1, i];
            i++;
            date10.Text = lastScores[1, i];
        }

        public void SetTwoLastScores(int[] twoScores, string[] twoNames)
        {
            //פעולה שמוסיפה את שני התוצאות האחרונות (של מחשב ושל שחקן), או רק תוצאה של אחד מהם, במידה והם מספיק גבוהים כדי להכנס לטבלת שיאים
            PutFillIntoArr();

            if (twoScores[0] >= Int32.Parse(lastScores[0, lastScores.GetLength(1) - 1]))
            {
                lastScores[0, lastScores.GetLength(1) - 1] = twoScores[0].ToString();
                lastScores[1, lastScores.GetLength(1) - 1] = DateTime.Now.ToString();
                lastScores[2, lastScores.GetLength(1) - 1] = twoNames[0];
            }
            Sorting();
            if (twoScores[1] >= Int32.Parse(lastScores[0, lastScores.GetLength(1) - 1]))
            {
                lastScores[0, lastScores.GetLength(1) - 1] = twoScores[1].ToString();
                lastScores[1, lastScores.GetLength(1) - 1] = DateTime.Now.ToString();
                lastScores[2, lastScores.GetLength(1) - 1] = twoNames[1];
            }
            Sorting();
            File.Delete(recordsFile);
            PutArrInFile();
        }

        public void Sorting()
        {
            //ממין מערך של טבלת שיאים
            int maxNum = 0;
            string[,] tempArr;
            int lastIndex = 0;
            tempArr = new string[lastScores.GetLength(0), lastScores.GetLength(1)];
            for (int k = 0; k < lastScores.GetLength(1); k++)
            {
                if (lastScores[0, k] != null)
                {
                    tempArr[0, k] = lastScores[0, k];
                    tempArr[1, k] = lastScores[1, k];
                    tempArr[2, k] = lastScores[2, k];
                }
            }

            for (int i = 0; i < lastScores.GetLength(1); i++)
            {
                maxNum = int.MinValue;
                for (int j = 0; j < tempArr.GetLength(1); j++)
                    if (tempArr[0, j] != null)
                    {
                        if (Int32.Parse(tempArr[0, j]) > maxNum)
                        {
                            maxNum = Int32.Parse(tempArr[0, j]);
                            lastScores[0, i] = tempArr[0, j];
                            lastScores[1, i] = tempArr[1, j];
                            lastScores[2, i] = tempArr[2, j];
                            lastIndex = j;
                        }
                    }
                tempArr[0, lastIndex] = int.MinValue.ToString();
            }

        }

        public void PutFillIntoArr()
        {
            //פעולה שמעבירה את הקובץ למערך
            string s = "";
            string alltext = "";
            if (!File.Exists(recordsFile))
                return;
            using (StreamReader streamReader = File.OpenText(recordsFile))
            {
                s = streamReader.ReadLine();
                while (s != null)
                {
                    alltext = alltext + s;
                    s = streamReader.ReadLine();
                }
            }

            int l = 0;
            string tempS1 = "", tempS2 = "";
            for (int m = 0; m < alltext.Length - 1; m++)
            {
                if (alltext[m] == '[')
                    m++;
                while (alltext[m] != ',')
                {
                    tempS1 = tempS1 + alltext[m];
                    m++;
                }
                lastScores[2, l] = tempS1;
                tempS1 = "";
                m++;
                while (alltext[m] != ',')
                {
                    tempS1 = tempS1 + alltext[m];
                    m++;
                }
                lastScores[0, l] = tempS1;
                tempS1 = "";
                m++;
                while (alltext[m] != ']')
                {
                    tempS2 = tempS2 + alltext[m];
                    m++;
                }
                lastScores[1, l] = tempS2;
                tempS2 = "";
                l++;
            }
            Sorting();
        }

        public void PutArrInFile()
        {
            //פעולה שמעבירה מערך לקובץ
            for (int j = 0; j < lastScores.GetLength(1); j++)
            {
                File.AppendAllText(recordsFile, string.Format("[" + lastScores[2, j] + "," + lastScores[0, j] + "," + lastScores[1, j] + "]", Environment.NewLine));
            }
        }

        private void TableOfRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
            //פעולה שסוגרת לגמרי את המשחק
            Application.Exit();
        }

        private void buttonExit_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור יציאה ומעבר למסך הראשי
            game.Show();
            this.Hide();
        }

        private void buttonNewGame_MouseClick(object sender, MouseEventArgs e)
        {
            //לחיצה על כפתור משחק חדש ומעבר לטופס המשחק עצמו
            formBackgrounds.Show();
            this.Hide();
        }
    }
}
