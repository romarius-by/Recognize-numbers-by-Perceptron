using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kovaleva_lab_sem6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public NumberSign TypeA = new NumberSign(1, 1);
        public NumberSign TypeB = new NumberSign(0, 0);
        public NumberSign TypeC = new NumberSign(1, 0);
        public NumberSign TypeD = new NumberSign(0, 1);

        public MatrixMain Perceptrone = new MatrixMain();

        const int numLines = 900;
        const int numElementsInLine = 150;
        const int firstBound = 0;
        const int secondBound = 0;
        const int thirdBound = 0;

        int R1;
        int R2;

        int[,] Rij = new int[numLines, numElementsInLine];
        int[] lyambda = new int[numElementsInLine];
        int[] y = new int[numElementsInLine];
        int[] pictureArray = new int[numElementsInLine];

        static string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        string connectionsFile = Path.Combine(baseFolder, "connections.txt");
        string lyambdaFile = Path.Combine(baseFolder, "lyambda.txt");

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            uploadImageDialog.ShowDialog();
            string picture = uploadImageDialog.FileName;
            pictureBox1.Image = Image.FromFile(picture);
            pictureArray = CreateBit(pictureBox1.Image);

            if (!(File.Exists(connectionsFile) && File.Exists(lyambdaFile)))
                buttonCreateConsts.Enabled = true;
        }

        private void ButtonCreateConsts_Click(object sender, EventArgs e)
        {
            FileStream fs1 = File.Create(connectionsFile);
            StreamWriter sw1 = new StreamWriter(fs1);
            Rij = Perceptrone.Create(numLines, numElementsInLine);
            Perceptrone.WriteToFile(sw1, Rij, numLines, numElementsInLine);
            sw1.Close();

            FileStream fs2 = File.Create(lyambdaFile);
            StreamWriter sw2 = new StreamWriter(fs2);
            lyambda = Perceptrone.Create(numElementsInLine);
            Perceptrone.WriteToFile(sw2, lyambda, numElementsInLine);
            sw2.Close();

            buttonCreateConsts.Enabled = false;
        }

        public int[] CreateBit(Image pic)
        {
            Bitmap im = pic as Bitmap;
            int[] arrayPic = new int[900];
            int z = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    listBoxBit.Items.Add("");
                    int n = (im.GetPixel(i, j).R);
                    n = (n >= 250) ? 0 : 1;
                    arrayPic[z] = n;
                    z++;
                    listBoxBit.Items[j] = listBoxBit.Items[j] + "  " + Convert.ToString(n);
                }
            }
            return arrayPic;
        }

        private void ButtonRecognize_Click(object sender, EventArgs e)
        {
            y = Perceptrone.CalculateY(numLines, numElementsInLine, Rij, pictureArray);
            R1 = Perceptrone.GetSignal(firstBound, secondBound, lyambda, y);
            R2 = Perceptrone.GetSignal(secondBound, thirdBound, lyambda, y);
            if (TypeA.Checker(R1, R2))
                labelResult.Text = "Это 0";
            else if (TypeB.Checker(R1, R2))
                labelResult.Text = "Это 1";
            else if (TypeC.Checker(R1, R2))
                labelResult.Text = "Это 3";
            else if (TypeD.Checker(R1, R2))
                labelResult.Text = "Это 5";

        }
    }

    public class MatrixMain
    {

        public int[,] Create(int numLines, int numElementsInLine)
        {
            Random rand = new Random();
            int placeInLine;
            int decision;
            int[,] Rij = new int[numLines, numElementsInLine];

            for (int i = 0; i < numLines; i++)
            {
                for (int j = 0; j < numElementsInLine; j++)
                {
                    Rij[i, j] = 0;
                }
                placeInLine = rand.Next(0, numElementsInLine);
                decision = rand.Next(0, 2);
                Rij[i, placeInLine] = (decision == 0) ? 1 : -1;

            }
            return Rij;
        }

        public int[] Create(int numElementsInLine)
        {
            Random rand = new Random();
            int decision;
            int[] lyambda = new int[numElementsInLine];

            for (int j = 0; j < numElementsInLine; j++)
            {
                decision = rand.Next(0, 2);
                lyambda[j] = (decision == 0) ? 1 : -1;
            }
            return lyambda;
        }

        public void WriteToFile(StreamWriter sw, int[,] array2D, int numLines, int numElementsInLine)
        {
            for (int i = 0; i < numLines; i++)
            {
                for (int j = 0; j < numElementsInLine; j++)
                {
                    sw.Write(array2D[i, j] + " ");
                }
                sw.WriteLine();
            }
            sw.Flush();
        }

        public void WriteToFile(StreamWriter sw, int[] array, int numElementsInLine)
        {
            for (int j = 0; j < numElementsInLine; j++)
            {
                sw.Write(array[j] + " ");
            }
            sw.WriteLine();
            sw.Flush();
        }

        /* public void CreateConstMatrix(FileStream fs)
         {
             StreamWriter sw = new StreamWriter(fs);
             for (int i = 0; i < 900; i++)
             {
                 for (int j = 0; j < 150; j++)
                 {
                     Rij[i, j] = 0;
                 }
                 xplace = rand.Next(0, 150);
                 decision = rand.Next(0, 2);
                 Rij[i, xplace] = (decision == 0) ? 1 : -1;
             }

             for (int i = 0; i < 900; i++)
             {
                 for (int j = 0; j < 150; j++)
                 {
                     sw.Write(Rij[i, j] + " ");
                 }
                 sw.WriteLine();
             }
             sw.Flush();
         }

        public void CreateConstLyambda(FileStream fs)
        {
            StreamWriter sw = new StreamWriter(fs);
            for (int j = 0; j < 150; j++)
            {
                decision = rand.Next(0, 2);
                lyambda[j] = (decision == 0) ? 1 : -1;
                sw.Write(lyambda[j] + " ");
                Console.WriteLine(lyambda[j]);
            }
            sw.WriteLine();
            sw.Flush();
        }*/

        public int[,] ReadFromFile(StreamReader sr, int numLines, int numElementsInLine)
        {
            int[,] arrayRes = new int[numLines, numElementsInLine];
            for (int j = 0; j < numLines; j++)
            {
                string[] nums = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < numElementsInLine; i++)
                {
                    arrayRes[j, i] = int.Parse(nums[i]);
                    Console.Write(arrayRes[j, i]);
                }
                Console.WriteLine();
            }
            sr.Close();
            return arrayRes;
        }

        public int[] ReadFromFile(StreamReader sr)
        {
            string[] nums = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayRes = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                arrayRes[i] = int.Parse(nums[i]);
                Console.Write(arrayRes[i]);
            }
            Console.WriteLine();
            sr.Close();
            return arrayRes;
        }
        /*
        public void ReadConstLyambda(FileStream fs)
        {
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            for (int j = 0; j < 901; j++)
            {
                string[] words = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] array = new int[words.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(words[i]);
                    Console.Write(array[i]);
                }
                Console.WriteLine();
            }
            sr.Close();

        }*/

        public int[] CalculateY(int numLines, int numElementsInLine, int[,] Rij, int[] pictureArray)
        {
            int sumy;
            const int teta = 1;
            int[] y = new int[numElementsInLine];

            for (int j = 0; j < numElementsInLine; j++)
            {
                sumy = 0;
                for (int i = 0; i < numLines; i++)
                {
                    sumy += Rij[i, j] * pictureArray[i];
                }
                y[j] = (sumy - teta) >= 0 ? 1 : 0;
            }
            return y;
        }

        public int GetSignal(int lowerBound, int upperBound, int[] lyambda, int[] y)
        {
            int sum = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                sum += lyambda[i] * y[i];
            }
            int R = (sum) >= 0 ? 1 : 0;
            return R;
        }
    }

    public class NumberSign : MatrixMain
    {
        private int R1;
        private int R2;

        public NumberSign(int R1, int R2)
        {
            this.R1 = R1;
            this.R2 = R2;
        }

        public bool Checker(int testR1, int testR2)
        {
            if (R1 == testR1 && R2 == testR2)
                return true;
            else
                return false;
        }
    }
}
