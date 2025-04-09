namespace ImageProject_att1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.EdgeBordersButton = new System.Windows.Forms.Button();
            this.MedianSquare = new System.Windows.Forms.Button();
            this.buttonLab2 = new System.Windows.Forms.Button();
            this.MedianCross = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.ColorNoiseButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.additiveNoiseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.EdgeBordersButton);
            this.panel1.Controls.Add(this.MedianSquare);
            this.panel1.Controls.Add(this.buttonLab2);
            this.panel1.Controls.Add(this.MedianCross);
            this.panel1.Controls.Add(this.filterButton);
            this.panel1.Controls.Add(this.ColorNoiseButton);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.additiveNoiseButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 627);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 187);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // EdgeBordersButton
            // 
            this.EdgeBordersButton.Location = new System.Drawing.Point(259, 126);
            this.EdgeBordersButton.Name = "EdgeBordersButton";
            this.EdgeBordersButton.Size = new System.Drawing.Size(196, 33);
            this.EdgeBordersButton.TabIndex = 14;
            this.EdgeBordersButton.Text = "Усиление границ";
            this.EdgeBordersButton.UseVisualStyleBackColor = true;
            this.EdgeBordersButton.Click += new System.EventHandler(this.EdgeBordersButton_Click);
            // 
            // MedianSquare
            // 
            this.MedianSquare.Location = new System.Drawing.Point(259, 88);
            this.MedianSquare.Name = "MedianSquare";
            this.MedianSquare.Size = new System.Drawing.Size(268, 32);
            this.MedianSquare.TabIndex = 13;
            this.MedianSquare.Text = "Медианный(квадратом)";
            this.MedianSquare.UseVisualStyleBackColor = true;
            this.MedianSquare.Click += new System.EventHandler(this.MedianSquare_Click);
            // 
            // buttonLab2
            // 
            this.buttonLab2.Location = new System.Drawing.Point(983, 8);
            this.buttonLab2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLab2.Name = "buttonLab2";
            this.buttonLab2.Size = new System.Drawing.Size(169, 37);
            this.buttonLab2.TabIndex = 5;
            this.buttonLab2.Text = "Синтез волны";
            this.buttonLab2.UseVisualStyleBackColor = true;
            this.buttonLab2.Click += new System.EventHandler(this.buttonLab2_Click);
            // 
            // MedianCross
            // 
            this.MedianCross.Location = new System.Drawing.Point(259, 49);
            this.MedianCross.Name = "MedianCross";
            this.MedianCross.Size = new System.Drawing.Size(268, 32);
            this.MedianCross.TabIndex = 12;
            this.MedianCross.Text = "Медианный(крестом)";
            this.MedianCross.UseVisualStyleBackColor = true;
            this.MedianCross.Click += new System.EventHandler(this.MedianCross_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(259, 10);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(268, 32);
            this.filterButton.TabIndex = 10;
            this.filterButton.Text = "Фильтр нижних (лекция)";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // ColorNoiseButton
            // 
            this.ColorNoiseButton.Location = new System.Drawing.Point(536, 132);
            this.ColorNoiseButton.Name = "ColorNoiseButton";
            this.ColorNoiseButton.Size = new System.Drawing.Size(188, 28);
            this.ColorNoiseButton.TabIndex = 9;
            this.ColorNoiseButton.Text = "Цветной шум";
            this.ColorNoiseButton.UseVisualStyleBackColor = true;
            this.ColorNoiseButton.Click += new System.EventHandler(this.ColorNoiseButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(729, 59);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 22);
            this.textBox2.TabIndex = 8;
            // 
            // additiveNoiseButton
            // 
            this.additiveNoiseButton.Location = new System.Drawing.Point(536, 52);
            this.additiveNoiseButton.Name = "additiveNoiseButton";
            this.additiveNoiseButton.Size = new System.Drawing.Size(185, 29);
            this.additiveNoiseButton.TabIndex = 7;
            this.additiveNoiseButton.Text = "Аддитивный шум";
            this.additiveNoiseButton.UseVisualStyleBackColor = true;
            this.additiveNoiseButton.Click += new System.EventHandler(this.additiveNoiseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(729, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(932, 132);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(220, 33);
            this.button4.TabIndex = 3;
            this.button4.Text = "Сохранить изображение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Помеха соль-перец";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Cyan;
            this.button2.Location = new System.Drawing.Point(536, 88);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Преобразовать в чб";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(13, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить изображение";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1179, 627);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 482);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_3);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox2.Location = new System.Drawing.Point(-35, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(442, 485);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1179, 814);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonLab2;
        private System.Windows.Forms.Button additiveNoiseButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button ColorNoiseButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button MedianCross;
        private System.Windows.Forms.Button MedianSquare;
        private System.Windows.Forms.Button EdgeBordersButton;
    }
}

