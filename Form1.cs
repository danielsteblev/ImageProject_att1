using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image,
                bmp1 = new Bitmap(bmp.Width, bmp.Height);
                int x, y, r, g, b, br;
                Color cl;
                for (y = 0; y < bmp.Height; ++y)
                    for (x = 0; x < bmp.Width; ++x)
                    {
                        cl = bmp.GetPixel(x, y);
                        r = cl.R; g = cl.G; b = cl.B;

                        br = (r + g + b) / 3;

                        cl = Color.FromArgb(br, br, br);
                        bmp1.SetPixel(x, y, cl);
                    }
                pictureBox2.Image = bmp1;
            }
            else
            {
                MessageBox.Show("Изображение не найдено!");
            }
        }


        // шум соль - перец
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image; // создаю копию исходного изображения

            Color white = Color.FromArgb(255, 255, 255);
            Color black = Color.FromArgb(0, 0, 0);

            int i;

            Random rnd = new Random();

            // парсим стринг в текст

            if (int.TryParse(textBox1.Text, out int error_pixels) & error_pixels > 0 & pictureBox1.Image != null) // если число - инт и > 0

            {

                for (i = 0; i < error_pixels; ++i)
                {

                    int x = rnd.Next(bmp.Width), y = rnd.Next(bmp.Height); // генерирую случайные координаты

                    // ставлю пиксели по этим координатам 
                    int b = rnd.Next(2);

                    if (b == 1)
                        bmp.SetPixel(x, y, white);
                    else
                        bmp.SetPixel(x, y, black);
                }

                pictureBox2.Image = bmp;
            }
            else
            {
                MessageBox.Show("Изображение не найдено или неверно введено число интенсивности!");
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

        private void buttonLab2_Click(object sender, EventArgs e) // синтез волны
        {

            if (pictureBox2.Image != null)
            {

                Bitmap bmp = (Bitmap)pictureBox1.Image; // копия исходника

                int[] br = { 0, 0, 0 }; // храним яркость
                float[] u = { 0.3f, 0, 0.05f };
                float[] v = { 0, 0.2f, 0.3f };

                int brM;

                for (int y = 0; y < bmp.Height; ++y)
                {
                    for (int x = 0; x < bmp.Width; ++x)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            // вычисление яркости для каждого пикселя
                            br[i] = Convert.ToInt32(50 * Math.Cos(u[i] * x + v[i] * y) + 100); // Формула синтеза из мудла

                            brM = (br[0] + br[1] + br[2]) / 3; // средняя яркость для оттенов серого

                            if (brM > 255) // Проверка на выход за диапазон 0-255
                            {
                                brM = 255;
                            }

                            else if (brM < 0) // Проверка на выход за диапазон 0-255
                            {
                                brM = 0;
                            }

                            Color cl = Color.FromArgb(brM, brM, brM);
                            bmp.SetPixel(x, y, cl);
                        }
                    }
                }

                pictureBox2.Image = bmp;
            }
            else
            {
                MessageBox.Show("Изображение не найдено!");
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }


        // фильтр нижних частот
        private void lowPassFilterButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image; // копия исходника

                int width = bmp.Width;
                int height = bmp.Height;

                double[,] filter = new double[,]
                    {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                    };

                double filterSum = 16; // Сумма всех коэффициентов фильтра

                for (int x = 1; x < width - 1; x++) // Начинаем с 1, чтобы избежать выхода за границы
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        double red = 0, green = 0, blue = 0;

                        // Применение фильтра
                        for (int fx = -1; fx <= 1; fx++)
                        {
                            for (int fy = -1; fy <= 1; fy++)
                            {
                                int pixelX = x + fx;
                                int pixelY = y + fy;

                                Color pixelColor = bmp.GetPixel(pixelX, pixelY);

                                red += pixelColor.R * filter[fx + 1, fy + 1];
                                green += pixelColor.G * filter[fx + 1, fy + 1];
                                blue += pixelColor.B * filter[fx + 1, fy + 1];
                            }
                        }

                        // Нормализуем значения и сохраняем новый пиксель
                        int r = (int)(red / filterSum);
                        int g = (int)(green / filterSum);
                        int b = (int)(blue / filterSum);

                        r = Math.Min(255, Math.Max(0, r));
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                pictureBox2.Image = bmp; // копируем новое фото
            }
            else
            {
                MessageBox.Show("Изображение не найдено!");
            }
        }

        private void additiveNoiseButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int sigma) & sigma > 0 & pictureBox1.Image != null)
            {
                Random rnd = new Random();
                Bitmap bmp = (Bitmap)pictureBox1.Image, // копия исходника
                bmp1 = new Bitmap(bmp.Width, bmp.Height);
                int x, y, r, g, b;
                Color cl;

                for (y = 0; y < bmp.Height; ++y)
                    for (x = 0; x < bmp.Width; ++x)
                    {
                        cl = bmp.GetPixel(x, y);
                        r = cl.R; g = cl.G; b = cl.B;
                        double d = 0;

                        for (int i = 0; i < 12; i++)
                        {
                            d += rnd.NextDouble();
                        }

                        d -= 6;

                        r += Convert.ToInt32(sigma * d);
                        g += Convert.ToInt32(sigma * d);
                        b += Convert.ToInt32(sigma * d);


                        // проверка на выход за диапазон
                        if (r < 0) r = 0; else if (r > 255) r = 255;
                        if (g < 0) g = 0; else if (g > 255) g = 255;
                        if (b < 0) b = 0; else if (b > 255) b = 255;

                        cl = Color.FromArgb(r, g, b);
                        bmp1.SetPixel(x, y, cl);
                    }
                pictureBox2.Image = bmp1;
            }
            else
            {
                MessageBox.Show("Изображение не найдено или введено неверное число интенсивности!");
            }
        }


        private void ColorNoiseButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int sigma) & sigma > 0 & pictureBox1.Image != null)
            {
                Random rnd = new Random();
                Bitmap bmp = (Bitmap)pictureBox1.Image, // копия исходника
                bmp1 = new Bitmap(bmp.Width, bmp.Height);
                int x, y, r, g, b;
                Color cl;

                for (y = 0; y < bmp.Height; ++y)
                    for (x = 0; x < bmp.Width; ++x)
                    {
                        cl = bmp.GetPixel(x, y);
                        r = cl.R; g = cl.G; b = cl.B;

                        double d = 0;

                        // r
                        for (int i = 0; i < 12; i++)
                        {
                            d += rnd.NextDouble();
                        }
                        d -= 6;
                        r += Convert.ToInt32(sigma * d);
                        d = 0;

                        // g
                        for (int i = 0; i < 12; i++)
                        {
                            d += rnd.NextDouble();
                        }
                        d -= 6;
                        r += Convert.ToInt32(sigma * d);
                        d = 0;

                        // b 
                        for (int i = 0; i < 12; i++)
                        {
                            d += rnd.NextDouble();
                        }
                        d -= 6;
                        b += Convert.ToInt32(sigma * d);

                        // проверка на выход за диапазон
                        if (r < 0) r = 0; else if (r > 255) r = 255;
                        if (g < 0) g = 0; else if (g > 255) g = 255;
                        if (b < 0) b = 0; else if (b > 255) b = 255;

                        cl = Color.FromArgb(r, g, b);
                        bmp1.SetPixel(x, y, cl);
                    }
                pictureBox2.Image = bmp1;
            }
            else
            {
                MessageBox.Show("Изображение не найдено или введено неверное число интенсивности!");
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image,
                    bmp1 = new Bitmap(bmp.Width, bmp.Height);
                int x, y, r, g, b; Color cl;

                for(y = 2; y <= bmp.Height - 3; ++y)
                    for(x = 2; x <= bmp.Width - 3; ++x)
                    {
                        double rs = 0, gs = 0, bs = 0;
                        for(int i = x - 2; i <= x + 2; ++i)
                            for(int j = y - 2; j <= y + 2; ++j)
                            {
                                cl = bmp.GetPixel(i, j);
                                r = cl.R; g = cl.G; b = cl.B;
                                rs += r; gs += g; bs += b;
                                
                            }
                        r = Convert.ToInt32(rs / 25);
                        g = Convert.ToInt32(gs / 25);
                        b = Convert.ToInt32(bs / 25);

                        if (r < 0) r = 0; else if (r > 255) r = 255;
                        if (g < 0) g = 0; else if (g > 255) g = 255;
                        if (b < 0) b = 0; else if (b > 255) b = 255;

                        cl = Color.FromArgb(r, g, b);
                        bmp1.SetPixel(x, y, cl);

                    }
                pictureBox2.Image = bmp1;
            }
            else
            {
                MessageBox.Show("Изображение не найдено!");
            }

        }


        // todo
    }


}
