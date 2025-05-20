namespace YSA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTrain = new Button();
            btnTest = new Button();
            lblSonuc = new Label();
            numHataOrani = new NumericUpDown();
            btnTemizle = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numHataOrani).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnTrain
            // 
            btnTrain.Location = new Point(21, 76);
            btnTrain.Name = "btnTrain";
            btnTrain.Size = new Size(110, 43);
            btnTrain.TabIndex = 35;
            btnTrain.Text = "Eğit";
            btnTrain.UseVisualStyleBackColor = true;
            btnTrain.Click += btnTrain_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(21, 134);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(110, 45);
            btnTest.TabIndex = 36;
            btnTest.Text = "Test Et";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Location = new Point(17, 75);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(50, 20);
            lblSonuc.TabIndex = 38;
            lblSonuc.Text = "label1";
            // 
            // numHataOrani
            // 
            numHataOrani.DecimalPlaces = 4;
            numHataOrani.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numHataOrani.Location = new Point(8, 31);
            numHataOrani.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numHataOrani.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numHataOrani.Name = "numHataOrani";
            numHataOrani.Size = new Size(150, 27);
            numHataOrani.TabIndex = 39;
            numHataOrani.Value = new decimal(new int[] { 1, 0, 0, 262144 });
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(21, 196);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(110, 46);
            btnTemizle.TabIndex = 40;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 192);
            panel2.Controls.Add(btnTemizle);
            panel2.Controls.Add(numHataOrani);
            panel2.Controls.Add(btnTest);
            panel2.Controls.Add(btnTrain);
            panel2.Location = new Point(221, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 273);
            panel2.TabIndex = 42;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 128, 128);
            panel3.Controls.Add(lblSonuc);
            panel3.Location = new Point(427, 18);
            panel3.Name = "panel3";
            panel3.Size = new Size(204, 272);
            panel3.TabIndex = 43;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(643, 312);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)numHataOrani).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnTrain;
        private Button btnTest;
        private Label lblSonuc;
        private NumericUpDown numHataOrani;
        private Button btnTemizle;
        private Panel panel2;
        private Panel panel3;
    }
}
