using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Difficulty : Form
    {
        public Difficulty()
        {
            InitializeComponent();
        }
        private void Button_Load_Play_Click(object sender, EventArgs e)
        {
            FormPuzzle Main = this.Owner as FormPuzzle;
            if (Main != null)
            {
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is RadioButton)
                        if (((RadioButton)control).Checked)
                        {
                            int diff = int.Parse(control.Tag.ToString());
                            Main.difficulty = diff;

                            break;
                        }
                }
            }

            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "jpg|*.jpg|bmp|*.bmp";
            Dialog.FilterIndex = 1;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Main.PicPath = Dialog.FileName;
                this.Close();
            }

        }
    }
}
