using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Puzzle
{
    public partial class FormPuzzle : Form
    {
        Singleton Sngtn = Singleton.Instance(); //определение переменной класса Singleton
        public FormPuzzle()
        {
            InitializeComponent();
        }

        public struct rndcell
        {
            public int x;
            public int y;
        } // структура с координатами x, y
        public int difficulty = 4; // уровень сложности (по-умолчанию 4) 
        public int IndexDown; // индекс перетаскиваемого пазла
        public string PicPath; // путь к файлу картинки
        public double sek, min, hours; // секунды, минуты, часы
        public bool[] status = new bool[16]; // массив соответствия пазла со своей ячейкой
        public PictureBox[] FieldSites = new PictureBox[16]; // массив PictureBox'ов с картинками пазлов
        public PictureBox[] Puzzles = new PictureBox[16]; // массив PictureBox'ов с координатной сеткой
        public rndcell[] cells = new rndcell[16]; // массив структур со случайными координатами пазлов
        public int HintNumber, X, Y;
        
        private void загрузитьКартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.DeleteCells(this);                                                       // предварительная очистка игрового поля
            Facade.LoadPicture(this);                                                       // загрузка картинки
            Sngtn.StartGame(this);
        } // тут используется Facade
        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e) // тут используется Facade
        {
            timerPuzzle.Stop();
            if (PicPath != null)
                if (Facade.IfNewGame())                                                     // получение значения из класса Facade
                    Sngtn.StartGame(this);                                                  // запуск игрового процесса
                else { timerPuzzle.Start(); }
        }
        private void показатьОригиналToolStripMenuItem_Click(object sender, EventArgs e) // тут используется Facade
        {
            Facade.ShowOriginal(this);                                                      // окно с оригиналом картинки
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // тут используется Facade
        {
            Facade.IfExit();                                                                // запрос на выход
        }
        public void MouseUp2(object sender, MouseEventArgs e) // событие, происходящее при поднимании кнопки мыши
        {
            Sngtn.AttachCell_CheckEnd(this);                                                // приклейка паззла к сетке и проверка на сопадение пазла
        }
        public void MouseDown2(object sender, MouseEventArgs e) // событие, происходящее при нажатии кнопки мыши
        {
            IndexDown = ((PictureBox)sender).TabIndex;                                      //передача в глобальную переменную индекс переносимого пазла
            X = FieldSites[IndexDown].Location.X;
            Y = FieldSites[IndexDown].Location.Y;
            ((PictureBox)FieldSites[IndexDown]).BringToFront();
        }
        private void timerPuzzle_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(tt);                                                      //Создаем новый поток
            t.Start();
            toolStripStatusLabel2.Text = hours.ToString("00", CultureInfo.InvariantCulture) + ":" + min.ToString("00", CultureInfo.InvariantCulture) + ":" + sek.ToString("00", CultureInfo.InvariantCulture);
        }
        private void tt() // разбиение потока на часы/минуты/секунды
        {
            sek++;
            if (sek == 60)
            { sek = 0; min++; }
            else if (min == 60) { min = 0; hours++; }
        }
        private void SaveGame_Click(object sender, EventArgs e) // сохранение текущей игры
        {
            Sngtn.SaveGame(this);
        }
        private void LoadGame_Click(object sender, EventArgs e) // Загрузка сохраненной игры
        {
            Sngtn.LoadGame(this);
        }
        private void подсказкаToolStripMenuItem_Click(object sender, EventArgs e) // воспользоваться подсказкой
        {
            Sngtn.function_HintGame(this);
        }
    }
}
