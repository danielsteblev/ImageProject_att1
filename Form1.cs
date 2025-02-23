using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProject_att1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /// todo
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) // открываю модальное окно для выбора фото
            {
                dlg.Title = "Open Image";
                // dlg.Filter = "bmp files (*.bmp)|*.bmp"; могу добавить фильтр для расширений

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }

        }


        // метод для переделывания изображения в чб вариант
        private void button2_Click(object sender, EventArgs e) 
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image, bmp1 = new Bitmap(bmp.Width, bmp.Height);
            int x, y, r, g, b, br;
            Color cl;
            for(y=0; y<bmp.Height; ++y)
                for(x=0; x<bmp.Width; ++x)
                {
                    cl = bmp.GetPixel(x, y);
                    r = cl.R; g = cl.G; b = cl.B;

                    br = (r + g + b) / 3;

                    cl = Color.FromArgb(br, br, br);
                    bmp1.SetPixel(x, y, cl);
                }
            pictureBox2.Image = bmp1;
        }


        // соль - перец
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image); // создаю копию исходного изображения

            Color white = Color.FromArgb(255, 255, 255);
            Color black = Color.FromArgb(0, 0, 0);

            int i;

            Random rnd = new Random();

            // парсим стринг в текст

            if (int.TryParse(textBox1.Text, out int error_pixels)) // если число - инт
            {

                for (i = 0; i < error_pixels; ++i)
                {

                    int x = rnd.Next(bmp.Width), y = rnd.Next(bmp.Height); // генерирую случайные координаты

                    int b = rnd.Next(2); // реализация помехи соль - перец
                    if (b == 1)
                        bmp.SetPixel(x, y, white);
                    else
                        bmp.SetPixel(x, y, black);
                }

                pictureBox2.Image = bmp;
            }
            else
            {
                MessageBox.Show("Введите корректное число интенсивности!");
            }

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // кнопка сохранения изображения
        {
            if (pictureBox2.Image != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog()) // используем диалоговое окно
                {


                    sfd.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
                    sfd.FileName = "output_image";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = sfd.FileName;

                        switch (System.IO.Path.GetExtension(filePath).ToLowerInvariant())
                        {
                            case ".jpg":
                                pictureBox2.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case ".png":
                                pictureBox2.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case ".bmp":
                                pictureBox2.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;

                            default:
                                MessageBox.Show("Unsupported image format.");
                                return;
                        }

                        MessageBox.Show($"Изображение успешно сохранено по пути: {filePath}");
                    }
                }
            }

            else
            {
                MessageBox.Show("Изображение не найдено!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
