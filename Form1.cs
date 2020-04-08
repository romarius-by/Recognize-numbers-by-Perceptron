using System;
using System.Drawing;
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

        const int numLines = 900;
        const int numElementsInLine = 150;
        const int firstBound = 0;
        const int secondBound = 75;
        const int thirdBound = 150;

        int R1;
        int R2;
        int sum1;
        int sum2;

        int[,] Rij = new int[numLines, numElementsInLine];
        int[] lyambda = new int[numElementsInLine];
        int[] y = new int[numElementsInLine];
        int[] pictureArray = new int[numElementsInLine];

        static string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        string connectionsFile = Path.Combine(baseFolder, "connections.xls");
        string lyambdaFile = Path.Combine(baseFolder, "lyambda.xls");
        string yFile = Path.Combine(baseFolder, "y.xls");

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            listBoxBit.Items.Clear();
            labelResult.ResetText();
            uploadImageDialog.ShowDialog();
            string picture = uploadImageDialog.FileName;

            pictureBox1.Image = Image.FromFile(picture);
            pictureArray = CreateBit(pictureBox1.Image);

            if (!(File.Exists(connectionsFile) && File.Exists(lyambdaFile)))
                buttonCreateConsts.Enabled = true;
            if (buttonCreateConsts.Enabled)
                buttonDownloadConsts.Enabled = false;
        }

        private void ButtonCreateConsts_Click(object sender, EventArgs e)
        {
            Rij = Perceptrone.Create(numLines, numElementsInLine);
            Perceptrone.CreateXlsxFile(connectionsFile, Rij, numLines, numElementsInLine);

            lyambda = Perceptrone.Create(numElementsInLine);
            Perceptrone.CreateXlsxFile(lyambdaFile, lyambda, numElementsInLine);

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
            sum1 = Perceptrone.GetSum(firstBound, secondBound, lyambda, y);
            sum2 = Perceptrone.GetSum(secondBound, thirdBound, lyambda, y);
            labelR1.Text = "R1: " + R1;
            labelR2.Text = " R2: " + R2;
            labelSum1.Text = "Sum1: " + sum1;
            labelSum2.Text = " Sum2: " + sum2;
            if (TypeA.Checker(R1, R2))
                labelResult.Text = "Это 0";
            else if (TypeB.Checker(R1, R2))
                labelResult.Text = "Это 1";
            else if (TypeC.Checker(R1, R2))
                labelResult.Text = "Это 3";
            else if (TypeD.Checker(R1, R2))
                labelResult.Text = "Это 5";
        }

        private void ButtonDownloadConsts_Click(object sender, EventArgs e)
        {
            var sr1 = File.Open(connectionsFile, FileMode.Open, FileAccess.Read);
            Rij = Perceptrone.ReadFromFile(sr1, numLines, numElementsInLine);
            sr1.Close();

            var sr2 = File.Open(lyambdaFile, FileMode.Open, FileAccess.Read);
            lyambda = Perceptrone.ReadLyambdaFromFile(sr2, numLines, numElementsInLine);
            sr2.Close();
        }

        private void ButtonTeachA_Click(object sender, EventArgs e)
        {
            lyambda = Perceptrone.Teach(lyambda, y, TypeA.CalculateDelta(TypeA.R1), firstBound, secondBound);
            lyambda = Perceptrone.Teach(lyambda, y, TypeA.CalculateDelta(TypeA.R2), secondBound, thirdBound);

            Perceptrone.EditXlsxFile(lyambdaFile, lyambda, numElementsInLine);
            Perceptrone.EditXlsxFile(yFile, y, numElementsInLine);
        }

        private void ButtonTeachB_Click(object sender, EventArgs e)
        {
            lyambda = Perceptrone.Teach(lyambda, y, TypeB.CalculateDelta(TypeB.R1), firstBound, secondBound);
            lyambda = Perceptrone.Teach(lyambda, y, TypeB.CalculateDelta(TypeB.R2), secondBound, thirdBound);

            Perceptrone.EditXlsxFile(lyambdaFile, lyambda, numElementsInLine);
            Perceptrone.EditXlsxFile(yFile, y, numElementsInLine);
        }

        private void ButtonTeachC_Click(object sender, EventArgs e)
        {
            lyambda = Perceptrone.Teach(lyambda, y, TypeC.CalculateDelta(TypeC.R1), firstBound, secondBound);
            lyambda = Perceptrone.Teach(lyambda, y, TypeC.CalculateDelta(TypeC.R2), secondBound, thirdBound);

            Perceptrone.EditXlsxFile(lyambdaFile, lyambda, numElementsInLine);
            Perceptrone.EditXlsxFile(yFile, y, numElementsInLine);
        }

        private void ButtonTeachD_Click(object sender, EventArgs e)
        {
            lyambda = Perceptrone.Teach(lyambda, y, TypeD.CalculateDelta(TypeD.R1), firstBound, secondBound);
            lyambda = Perceptrone.Teach(lyambda, y, TypeD.CalculateDelta(TypeD.R2), secondBound, thirdBound);

            Perceptrone.EditXlsxFile(lyambdaFile, lyambda, numElementsInLine);
            Perceptrone.EditXlsxFile(yFile, y, numElementsInLine);
        }
    }
}