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
    public partial class SourceImage : Form
    {
        public SourceImage()
        {
            InitializeComponent();
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SourceImage_Load(object sender, EventArgs e)
        {
            FormPuzzle Main = this.Owner as FormPuzzle;
            if (Main != null)
            {
                if (Main.PicPath != null)
                {
                    Bitmap BitMP = new Bitmap(Main.PicPath);
                    pictureBoxSource.Image = BitMP;
                }
            }
        }
    }
}
