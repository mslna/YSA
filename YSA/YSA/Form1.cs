using System;
using System.Drawing;
using System.Windows.Forms;

namespace YSA
{
    public partial class Form1 : Form
    {
        private MLPNetwork ag;
        private Button[,] gridButtons = new Button[7, 5];

        public Form1()
        {
            InitializeComponent();
            CreateGridButtons();
        }

        private void CreateGridButtons()
        {
            int startX = 20, startY = 20;
            int buttonSize = 30;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button();
                    btn.Width = btn.Height = buttonSize;
                    btn.Left = startX + j * (buttonSize + 5);
                    btn.Top = startY + i * (buttonSize + 5);
                    btn.Tag = false;

                    btn.Click += (s, e) =>
                    {
                        Button b = s as Button;
                        bool isOn = !(bool)b.Tag;
                        b.Tag = isOn;
                        b.BackColor = isOn ? Color.Black : SystemColors.Control;
                    };

                    this.Controls.Add(btn);
                    gridButtons[i, j] = btn;
                }
            }
        }

        private double[] GetInputFromButtons()
        {
            double[] input = new double[35];
            int index = 0;

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 5; j++)
                    input[index++] = (bool)gridButtons[i, j].Tag ? 1.0 : 0.0;

            return input;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            double epsilon = (double)numHataOrani.Value;
            double learningRate = 0.1; 

            double[][] egitim = new double[][]
            {
                new double[] { 0,0,1,0,0, 0,1,0,1,0, 1,0,0,0,1, 1,0,0,0,1, 1,1,1,1,1, 1,0,0,0,1, 1,0,0,0,1 },
                new double[] { 1,1,1,1,0, 1,0,0,0,1, 1,0,0,0,1, 1,1,1,1,0, 1,0,0,0,1, 1,0,0,0,1, 1,1,1,1,0 },
                new double[] { 0,0,1,1,1, 0,1,0,0,0, 1,0,0,0,0, 1,0,0,0,0, 1,0,0,0,0, 0,1,0,0,0, 0,0,1,1,1 },
                new double[] { 1,1,1,0,0, 1,0,0,1,0, 1,0,0,0,1, 1,0,0,0,1, 1,0,0,0,1, 1,0,0,1,0, 1,1,1,0,0 },
                new double[] { 1,1,1,1,1, 1,0,0,0,0, 1,0,0,0,0, 1,1,1,1,1, 1,0,0,0,0, 1,0,0,0,0, 1,1,1,1,1 }
            };

            double[][] ciktilar = new double[][]
            {
                new double[] { 1, 0, 0, 0, 0 },
                new double[] { 0, 1, 0, 0, 0 },
                new double[] { 0, 0, 1, 0, 0 },
                new double[] { 0, 0, 0, 1, 0 },
                new double[] { 0, 0, 0, 0, 1 }
            };

            ag = new MLPNetwork(35, 10, 5, learningRate);
            ag.Train(egitim, ciktilar, epsilon);

            lblSonuc.Text = $"Eğitim tamamlandı.\nHata oranı: {ag.LastError:F4}";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (ag == null)
            {
                lblSonuc.Text = "Lütfen önce eğitin.";
                return;
            }

            double[] input = GetInputFromButtons();
            double[] output = ag.Predict(input);

            string sonucMetni = "";
            char harf = 'A';
            int maxIndex = 0;

            
            for (int i = 0; i < output.Length; i++)
            {
                sonucMetni += $"{harf++} çıkışı = {output[i]:F10}\n";
                if (output[i] > output[maxIndex])
                    maxIndex = i;
            }

            char tahmin = (char)('A' + maxIndex);
            sonucMetni += $"\n→ Tahmin edilen harf: {tahmin}";

            lblSonuc.Text = sonucMetni;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 5; j++)
                {
                    gridButtons[i, j].Tag = false;
                    gridButtons[i, j].BackColor = SystemColors.Control;
                }

            lblSonuc.Text = "Matris temizlendi.";
        }
    }
}
