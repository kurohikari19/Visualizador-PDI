namespace Visualizador
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBoxLienzo = new PictureBox();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLienzo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(52, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 255);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(80, 320);
            button1.Name = "button1";
            button1.Size = new Size(199, 49);
            button1.TabIndex = 1;
            button1.Text = "UPLOAD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(323, 32);
            button2.Name = "button2";
            button2.Size = new Size(134, 26);
            button2.TabIndex = 2;
            button2.Text = "GRAY CONVERTER";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(323, 64);
            button3.Name = "button3";
            button3.Size = new Size(134, 25);
            button3.TabIndex = 3;
            button3.Text = "COLOR LINEAL";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(323, 95);
            button4.Name = "button4";
            button4.Size = new Size(134, 24);
            button4.TabIndex = 4;
            button4.Text = "HISTOGRAMA";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBoxLienzo
            // 
            pictureBoxLienzo.Location = new Point(688, 32);
            pictureBoxLienzo.Name = "pictureBoxLienzo";
            pictureBoxLienzo.Size = new Size(255, 255);
            pictureBoxLienzo.TabIndex = 5;
            pictureBoxLienzo.TabStop = false;
            pictureBoxLienzo.MouseClick += pictureBoxLienzo_MouseClick;
            // 
            // button5
            // 
            button5.Location = new Point(323, 125);
            button5.Name = "button5";
            button5.Size = new Size(134, 25);
            button5.TabIndex = 6;
            button5.Text = "Convertir S→L + Histograma";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(323, 156);
            button6.Name = "button6";
            button6.Size = new Size(134, 27);
            button6.TabIndex = 7;
            button6.Text = "Calcular Distancia A-B";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(323, 189);
            button7.Name = "button7";
            button7.Size = new Size(134, 24);
            button7.TabIndex = 8;
            button7.Text = "Reiniciar puntos";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(323, 219);
            button8.Name = "button8";
            button8.Size = new Size(134, 23);
            button8.TabIndex = 9;
            button8.Text = "Suavizado";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(323, 248);
            button9.Name = "button9";
            button9.Size = new Size(134, 23);
            button9.TabIndex = 10;
            button9.Text = "Filtro Box";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(479, 35);
            button10.Name = "button10";
            button10.Size = new Size(134, 23);
            button10.TabIndex = 11;
            button10.Text = "Filtro Gauss";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(479, 66);
            button11.Name = "button11";
            button11.Size = new Size(134, 23);
            button11.TabIndex = 12;
            button11.Text = "Laplace Bordes";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(479, 96);
            button12.Name = "button12";
            button12.Size = new Size(134, 23);
            button12.TabIndex = 13;
            button12.Text = "Laplace Realzar";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 450);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(pictureBoxLienzo);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLienzo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBoxLienzo;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
    }
}
