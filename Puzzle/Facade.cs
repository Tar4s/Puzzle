using System;
using System.Windows.Forms;     //для messagebox
using System.Drawing;           //для переменной Image и Point
using System.IO;                //для использования Path
using System.Drawing.Drawing2D; //для InterpolationMode

namespace Puzzle
{
    internal class IntefaceGame : Functional
    {
        // Открытие окна для начала новой игры
        internal void Operation_LoadPicture(FormPuzzle form)                                         
        {
            Difficulty Diff = new Difficulty();
            Diff.Owner = form;
            Diff.ShowDialog();
        }

        // Всплывающий MassageBox при попытке начать игру заново
        internal bool Operation_IfNewGame()                                                          
        {
            return (MessageBox.Show("Вы действительно хотите начать заново? Текущий процесс будет утерян!", "Начать заново.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes);
        }

        // Открытие окна для демонстрации оригинала картинки
        internal void Operation_ShowOriginal(FormPuzzle form)
        {
            SourceImage SourceImg = new SourceImage();
            SourceImg.Owner = form;
            SourceImg.ShowDialog();
        }

        // Всплывающий MassageBox при попытке выйти из игры
        internal bool Operation_IfExit()
        {
            return (MessageBox.Show("Вы действительно хотите выйти из игры?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        // Генерирование массива с пазлами
        internal void Operation_CreatePuzzles(FormPuzzle form, string filename, int nx, int ny)
        {
            Random n = new Random();
            Image image = Image.FromFile(filename);
            image = ResizeImage(image, 400, 400);

            int w = image.Width;
            int h = image.Height;

            Array.Resize(ref form.FieldSites, form.difficulty * form.difficulty);
            Array.Resize(ref form.Puzzles, form.difficulty * form.difficulty);
            Array.Resize(ref form.status, form.difficulty * form.difficulty);
            Array.Resize(ref form.cells, form.difficulty * form.difficulty);

            form.HintNumber = form.difficulty;

            // координаты по X
            int[] x = new int[nx + 1];
            x[0] = 0;
            for (int i = 1; i <= nx; i++)
                x[i] = (w * i / nx);

            // координаты по Y
            int[] y = new int[ny + 1];
            y[0] = 0;
            for (int i = 1; i <= ny; i++)
                y[i] = (h * i / ny);

            int li = 0;
            while (li < form.cells.Length)
            {
            l1:
                int lx = n.Next(0, form.difficulty);                                     
                int ly = n.Next(0, form.difficulty);                                         
                for (int i = 0; i < li; i++)
                    if (form.cells[i].x == lx && form.cells[i].y == ly)
                        goto l1;

                form.cells[li].x = lx;
                form.cells[li].y = ly;

                li++;
            };

            // вспомогательные переменные
            Bitmap bmp;
            Graphics g;
            int k = -1;
            int size = 400 / form.difficulty;                                             

            // режем
            for (int j = 0; j < nx; j++)
            {
                for (int i = 0; i < ny; i++)
                {
                    // размеры тайла
                    w = x[i + 1] - x[i];
                    h = y[j + 1] - y[j];

                    // тайл
                    bmp = new Bitmap(w, h);

                    // рисуем
                    g = Graphics.FromImage(bmp);
                    g.DrawImage(image, new Rectangle(0, 0, w, h), new Rectangle(x[i], y[j], w, h), GraphicsUnit.Pixel);

                    // сохраняем результат
                    //bmp.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("image{0}_{1}.png", i, j)), System.Drawing.Imaging.ImageFormat.Png);


                    form.FieldSites[++k] = new PictureBox()
                    {
                        Image = bmp,
                        SizeMode = PictureBoxSizeMode.AutoSize,
                        Location = new Point(x[form.cells[k].x] + 13, y[form.cells[k].y] + 20),
                        BorderStyle = BorderStyle.None,
                        TabIndex = k
                    };
                        
                    form.FieldSites[k].MouseDown += new MouseEventHandler(form.MouseDown2);
                    form.FieldSites[k].MouseUp += new MouseEventHandler(form.MouseUp2);
                    form.groupBox1.Controls.Add(form.FieldSites[k]);
                    Move.LearnToMove(form.FieldSites[k]);
                }

            }
            image.Dispose();
        }
        internal void Operation_CreateGameCells(FormPuzzle form, int x, int y, PictureBox[] array)   // Генерирование массива с игровой сеткой
        {
            int x1 = x;
            int all = form.difficulty * form.difficulty;
            int size = 400 / form.difficulty;
            for (int i = 0; i < all; i++)
            {
                array[i] = new PictureBox();
                array[i].Size = new Size(size, size);
                array[i].Location = new Point(x, y);
                array[i].BorderStyle = BorderStyle.FixedSingle;
                array[i].TabIndex = i;
                form.groupBox1.Controls.Add(array[i]);
                array[i].MouseUp += new MouseEventHandler(form.MouseUp2);
                if ((i + 1) % form.difficulty == 0) { y += array[i].Height; x = x1; } else x += array[i].Width;
            }
        }
        internal void Operation_DeleteCells(FormPuzzle form)                                         // Генерирование массива с игровой сеткой
        {
            form.groupBox1.Enabled = true;
            Array.Clear(form.FieldSites, 0, form.FieldSites.Length);
            Array.Clear(form.Puzzles, 0, form.Puzzles.Length);
            Array.Clear(form.status, 0, form.status.Length);
            Array.Clear(form.cells, 0, form.cells.Length);

            form.groupBox1.Controls.Clear();
        }
    }

    internal class Functional
    {
        internal static Image ResizeImage(Image img, int newWidth, int newHeight)                    // Изменение размеров загружаемого изображения (400x400)
        {
            Image thumbImg = new Bitmap(newWidth, newHeight);

            using (Graphics gr = Graphics.FromImage(thumbImg))
            {
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            }
            return thumbImg;
        }
    }

    class Facade
    {
        static IntefaceGame Game = new IntefaceGame();

        public static void LoadPicture(FormPuzzle form)
        {
            Game.Operation_LoadPicture(form);
        }
        public static void ShowOriginal(FormPuzzle form)
        {
            Game.Operation_ShowOriginal(form);
        }
        public static bool IfNewGame()
        {
            if (Game.Operation_IfNewGame())
                return true;
            else
                return false;
        }
        public static void IfExit()
        {
            if (Game.Operation_IfExit())
                Application.Exit();
        }
        public static void CreatePuzzles(FormPuzzle form, string filename, int nx, int ny)
        {
            Game.Operation_CreatePuzzles(form, filename, nx, ny);
        }
        public static void CreateGameCells(FormPuzzle form, int x, int y, PictureBox[] array)
        {
            Game.Operation_CreateGameCells(form, x, y, array);
        }
        public static void DeleteCells(FormPuzzle form)
        {
            Game.Operation_DeleteCells(form);
        }
    }
}
