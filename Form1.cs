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


        // фильтр нижних частот на лекции
        private void filterButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                Bitmap bmp1 = new Bitmap(bmp.Width, bmp.Height);

                double[,] kernel = CreateKernel(0.440, 0.070, 0.000); // ввод значенмй

                // Сумма элементов ядра для нормализации
                double kernelSum = SumKernel(kernel);

                int x, y;
                int r, g, b;
                Color cl;

                // Итерация по каждому пикселю изображения (исключая границы)
                for (y = 2; y < bmp.Height - 2; ++y)
                {
                    for (x = 2; x < bmp.Width - 2; ++x)
                    {
                        double rs = 0, gs = 0, bs = 0;

                        // Применяем маску 5x5 к окрестности пикселя (x, y)
                        for (int i = -2; i <= 2; ++i)
                        {
                            for (int j = -2; j <= 2; ++j)
                            {
                                cl = bmp.GetPixel(x + i, y + j);
                                r = cl.R; g = cl.G; b = cl.B;

                                // Умножаем на вес маски и накапливаем
                                rs += r * kernel[i + 2, j + 2];
                                gs += g * kernel[i + 2, j + 2];
                                bs += b * kernel[i + 2, j + 2];
                            }
                        }

                        // Нормализуем результат
                        r = Convert.ToInt32(rs / kernelSum);
                        g = Convert.ToInt32(gs / kernelSum);
                        b = Convert.ToInt32(bs / kernelSum);

                        // Ограничиваем значения диапазоном [0, 255]
                        r = Math.Max(0, Math.Min(255, r));
                        g = Math.Max(0, Math.Min(255, g));
                        b = Math.Max(0, Math.Min(255, b));

                        // Устанавливаем обработанный пиксель в выходное изображение
                        cl = Color.FromArgb(r, g, b);
                        bmp1.SetPixel(x, y, cl);
                    }
                }

                // Отображаем обработанное изображение
                pictureBox2.Image = bmp1;
            }
            else
            {
                MessageBox.Show("Изображение не найдено!");
            }

        }

        // медианный квадратом
        private void MedianSquare_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Bitmap bmp1 = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 2; y < bmp.Height - 2; y++)
            {
                for (int x = 2; x < bmp.Width - 2; x++)
                {
                    List<int> redValues = new List<int>();
                    List<int> greenValues = new List<int>();
                    List<int> blueValues = new List<int>();

                    for (int fy = -2; fy <= 2; fy++)
                    {
                        for (int fx = -2; fx <= 2; fx++)
                        {
                            Color pixel = bmp.GetPixel(x + fx, y + fy);
                            redValues.Add(pixel.R);
                            greenValues.Add(pixel.G);
                            blueValues.Add(pixel.B);
                        }
                    }

                    redValues.Sort();
                    greenValues.Sort();
                    blueValues.Sort();

                    int medianRed = redValues[12];
                    int medianGreen = greenValues[12];
                    int medianBlue = blueValues[12];

                    bmp1.SetPixel(x, y, Color.FromArgb(medianRed, medianGreen, medianBlue));
                }
            }

            pictureBox2.Image = bmp1;
            MessageBox.Show("Медианный фильтр 5x5 применен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // медианный крестом
        private void MedianCross_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Сначала загрузите изображение!", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Bitmap resultBmp = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 2; y < bmp.Height - 2; y++)
            {
                for (int x = 2; x < bmp.Width - 2; x++)
                {
                    List<int> redValues = new List<int>();
                    List<int> greenValues = new List<int>();
                    List<int> blueValues = new List<int>();

                    for (int dy = -2; dy <= 2; dy++)
                    {
                        Color pixel = bmp.GetPixel(x, y + dy);
                        redValues.Add(pixel.R);
                        greenValues.Add(pixel.G);
                        blueValues.Add(pixel.B);
                    }

                    for (int dx = -2; dx <= 2; dx++)
                    {
                        if (dx == 0) continue;
                        Color pixel = bmp.GetPixel(x + dx, y);
                        redValues.Add(pixel.R);
                        greenValues.Add(pixel.G);
                        blueValues.Add(pixel.B);
                    }

                    redValues.Sort();
                    greenValues.Sort();
                    blueValues.Sort();

                    int medianIndex = redValues.Count / 2;
                    Color medianColor = Color.FromArgb(
                        redValues[medianIndex],
                        greenValues[medianIndex],
                        blueValues[medianIndex]);

                    resultBmp.SetPixel(x, y, medianColor);
                }
            }

            pictureBox2.Image = resultBmp;
            MessageBox.Show("Медианный фильтр (крест 5x5) применен!", "Готово",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void EdgeBordersButton_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Сначала загрузите изображение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap bmp = (Bitmap)pictureBox1.Image;
                Bitmap bmp1 = new Bitmap(bmp.Width, bmp.Height);

                int[,] filter = CreateEdgeKernel(2);

                int filterWidth = filter.GetLength(1);
                int filterHeight = filter.GetLength(0);
                int filterOffset = filterWidth / 2;

                int filterSum = 0;
                foreach (int value in filter)
                {
                    filterSum += value;
                }
                if (filterSum == 0) filterSum = 1;

                for (int y = filterOffset; y < bmp.Height - filterOffset; y++)
                {
                    for (int x = filterOffset; x < bmp.Width - filterOffset; x++)
                    {
                        int red = 0, green = 0, blue = 0;

                        for (int fy = 0; fy < filterHeight; fy++)
                        {
                            for (int fx = 0; fx < filterWidth; fx++)
                            {
                                Color pixel = bmp.GetPixel(x + fx - filterOffset, y + fy - filterOffset);
                                red += pixel.R * filter[fy, fx];
                                green += pixel.G * filter[fy, fx];
                                blue += pixel.B * filter[fy, fx];
                            }
                        }

                        red = Math.Max(0, Math.Min(255, red / filterSum));
                        green = Math.Max(0, Math.Min(255, green / filterSum));
                        blue = Math.Max(0, Math.Min(255, blue / filterSum));

                        bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }

                pictureBox2.Image = bmp1;
                MessageBox.Show($"Фильтр применен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private double[,] CreateKernel(double w1, double w2, double w3)
        {
            return new double[,] {
            { w3, w3, w3, w3, w3 },
            { w3, w2, w2, w2, w3 },
            { w3, w2, w1, w2, w3 },
            { w3, w2, w2, w2, w3 },
            { w3, w3, w3, w3, w3 }
        };
        }


        private int[,] CreateEdgeKernel(int maskNumber)
        {
            switch (maskNumber)
            {
                case 1: 
                    return new int[,]
                    {
                {  1, -2,  1 },
                { -2,  5, -2 },
                {  1, -2,  1 }
                    };

                case 2: 
                    return new int[,]
                    {
                { 0, -1, 0 },
                { -1,  5, -1 },
                { 0, -1, 0 }
                    };

                case 3: 
                    return new int[,]
                    {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
                    };

                default: 
                    return new int[,]
                    {
                {  1, -2,  1 },
                {  2, -5,  2 },
                {  1, -2,  1 }
                    };
            }
        }



        // Функция для вычисления суммы элементов ядра
        private double SumKernel(double[,] kernel)
        {
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += kernel[i, j];
                }
            }
            return sum;
        }

    }
}
