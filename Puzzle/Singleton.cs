using System;
using System.Drawing;           // для Point
using System.Windows.Forms;     // для Messagebox
using System.IO;                // для File

namespace Puzzle
{
    class Singleton : FuncSingleton
    {
        private static Singleton instance;
        private Singleton() { }
        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
                return instance;
            }
            return null;
        }

        public void AttachCell_CheckEnd(FormPuzzle form) // приклейка паззла к сетке и проверка на сопадение пазла
        {
            function_AttachCell_CheckEnd(form);
        }
        public void StartGame(FormPuzzle form)           // запуск игрового процесса
        {
            function_StartGame(form);
        }               
        public void SaveGame(FormPuzzle form)            // сохранение текущей игры
        {
            function_SaveGame(form);
        }
        public void LoadGame(FormPuzzle form)            // загрузка сохраненной игры
        {
            function_LoadGame(form);
        }
        public void HintGame(FormPuzzle form)            // подсказка
        {
            function_HintGame(form);
        }
    }

    internal class FuncSingleton
    {
        internal void function_AttachCell_CheckEnd(FormPuzzle form)
        {
            int all = form.difficulty * form.difficulty;
            int size = 400 / form.difficulty;

            for (int i = 0; i < all; i++)
            {
                //попал ли подводимый пазл в область сетки (и отдельного пазла) по координате X
                if ((form.FieldSites[form.IndexDown].Location.X >= form.Puzzles[i].Location.X) && (form.FieldSites[form.IndexDown].Location.X <= form.Puzzles[i].Location.X + size))
                    //попал ли подводимый пазл в область сетки (и отдельного пазла) по координате Y
                    if ((form.FieldSites[form.IndexDown].Location.Y >= form.Puzzles[i].Location.Y) && (form.FieldSites[form.IndexDown].Location.Y <= form.Puzzles[i].Location.Y + size))
                    {
                        //если да, то проверка подводящего пазла на зону крипежки сетки
                        if (Math.Abs((form.Puzzles[i].Location.X - form.FieldSites[form.IndexDown].Location.X)) <= (size - 1) && 
                            Math.Abs((form.Puzzles[i].Location.Y - form.FieldSites[form.IndexDown].Location.Y)) <= (size - 1))
                        {

                            form.FieldSites[form.IndexDown].Location = new Point(form.Puzzles[i].Location.X, form.Puzzles[i].Location.Y); //крипежка пазла на сетку

                            for (int j = 0; j < all; j++)
                            {
                                if (j != form.IndexDown && form.FieldSites[form.IndexDown].Location == form.FieldSites[j].Location)
                                {
                                    form.FieldSites[form.IndexDown].Location = new Point(form.X, form.Y); // если пазл занят, вернуть текущий на место
                                    break;
                                }
                            }


                            if (form.IndexDown == form.Puzzles[i].TabIndex) //если индексы ячеек совпали
                            {
                                form.status[form.IndexDown] = true;
                                form.FieldSites[form.IndexDown].Enabled = false;
                            }

                        }

                        if (IfEnd(form))
                        {
                            form.timerPuzzle.Stop();
                            MessageBox.Show("Поздравляю! Вы собрали пазл. Ваше время: " + form.toolStripStatusLabel2.Text, "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form.toolStripStatusLabel2.Text = "00:00:00";
                            form.groupBox1.Enabled = false;
                        }
                        break;
                    }
            }
        }
        internal void function_StartGame(FormPuzzle form)
        {
            if (form.PicPath != null)
            {
                Facade.DeleteCells(form);
                Facade.CreatePuzzles(form, form.PicPath, form.difficulty, form.difficulty);                //создание и вывод на экран массива пазлов (слева)
                Facade.CreateGameCells(form, 475, 20, form.Puzzles);                             //создание и вывод на экран массива секторов в роли игровой сетки (справа)

                form.sek = 0; form.min = 0; form.hours = 0;
                form.timerPuzzle.Start();
            }

        }
        internal bool IfEnd(FormPuzzle form)
        {
            bool flag = form.status[0];
            for (int i = 1; i < form.FieldSites.Length; i++)
            {
                flag = flag && form.status[i];

                if (!flag)
                    return false;
            }
            return true;
        }
        internal void function_SaveGame(FormPuzzle form)
        {
            if (form.PicPath != null && !IfEnd(form))
            {
                int number_of_puzzles = form.difficulty * form.difficulty;
                string FilePath = "FileGame";

                if (File.Exists(FilePath))
                    File.Delete(FilePath);

                using (StreamWriter fs =  new StreamWriter(FilePath))
                {
                    fs.WriteLine(form.PicPath);
                    fs.WriteLine(form.difficulty);
                    for (int i = 0; i < number_of_puzzles; i++)
                    {
                        fs.WriteLine(form.FieldSites[i].Location.X.ToString());
                        fs.WriteLine(form.FieldSites[i].Location.Y.ToString());
                        fs.WriteLine(form.status[i].ToString());
                    }
                }
                MessageBox.Show("Текущая игра сохранена", "Сохраниение...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Нечего сохранять", "Сохраниение...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        internal void function_LoadGame(FormPuzzle form)
        {
            if (MessageBox.Show("Вы действительно хотите загрузить ранее сохраненную игру? Текущий процесс будет утерян!", "Загрузка...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string FilePath = "FileGame";
                if (!File.Exists(FilePath))
                {
                    MessageBox.Show("Нет сохраненной игры!", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader sr = File.OpenText(FilePath))
                {
                    string X, Y = "";
                    int d, i = 0;

                    form.PicPath = sr.ReadLine();       // расположение к картинке
                    d = Convert.ToInt32(sr.ReadLine()); // уровень сложности
                    form.difficulty = d;

                    X = sr.ReadLine();
                    Y = sr.ReadLine();

                    Facade.DeleteCells(form);
                    Facade.CreatePuzzles(form, form.PicPath, d, d);
                    form.groupBox1.Controls.Clear();

                    while ((X) != null)
                    {
                        form.status[i] = Convert.ToBoolean(sr.ReadLine());
                        if (form.status[i]) form.FieldSites[i].Enabled = false; //если пазл был верен, то перемещать нельзя
                        form.FieldSites[i].Location = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
                        form.groupBox1.Controls.Add(form.FieldSites[i]);

                        i++;
                        X = sr.ReadLine();
                        Y = sr.ReadLine();
                    }
                    Facade.CreateGameCells(form, 475, 20, form.Puzzles);

                    form.IndexDown = 0;
                    form.sek = 0; form.min = 0; form.hours = 0;
                    form.timerPuzzle.Start();
                }
            }
        }
        internal void function_HintGame(FormPuzzle form)
        {
            if (form.PicPath != null)
            {
                Random Rnd = new Random();
                int a = 0;

                if (!IfEnd(form)) 
                {
                l_hint:
                        a = Rnd.Next(0, form.status.Length-1);

                    if (form.status[a] == false)
                    {
                        if (form.HintNumber != 0)
                        {
                            form.FieldSites[a].Location = new Point(form.Puzzles[a].Location.X, form.Puzzles[a].Location.Y);
                            form.FieldSites[a].Enabled = false;
                            form.status[a] = true;
                            form.HintNumber--;

                            MessageBox.Show("Осталось подсказок: " + form.HintNumber.ToString(), "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        goto l_hint;
                    function_AttachCell_CheckEnd(form); // проверка конца игры
                }
            }
        }
    }
}

