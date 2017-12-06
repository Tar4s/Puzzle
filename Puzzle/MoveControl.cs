using System.Drawing;
using System.Windows.Forms;

namespace Puzzle
{
    public abstract class Move
    {
        static bool isPress = false;
        static Point startPst;

        //Функция выполняется при нажатии на перемещаемый контрол
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return; //проверка что нажата левая кнопка

            isPress = true;
            startPst = e.Location;
        }

        //Функция выполняется при отжатии перемещаемого контрола
        private static void mUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return; //проверка что нажата левая кнопка

            isPress = false;
        }

        //Функция выполняется при перемещении контрола
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (!isPress)
                return;

            Control control = (Control)sender;
            control.Top += e.Y - startPst.Y;
            control.Left += e.X - startPst.X;
        }

        //обучает контролы передвигаться
        public static void LearnToMove(object sender)
        {
            Control control = (Control)sender;
            control.MouseDown += new MouseEventHandler(mDown);
            control.MouseUp += new MouseEventHandler(mUp);
            control.MouseMove += new MouseEventHandler(mMove);
        }
    }
}