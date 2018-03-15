using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToe
{
    public class Cell
    {
        public Label cell;
        public string Value = String.Empty;
        public static int Width { get; } = 60;
        public Point Location = new Point();
        public static Point Position { get; } = new Point()
        {
            X = 13,
            Y = 13,
        };

        public static void MouseEnter(object sender, EventArgs e)
        {
            Label cell = (Label)sender;
            cell.BorderStyle = BorderStyle.Fixed3D;
        }

        public static void MouseLeave(object sender, EventArgs e)
        {
            Label cell = (Label) sender;
            cell.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void MouseClick(object sender, MouseEventArgs e)
        {
            Label cell = (Label)sender;
            if(GameForm.User)
            {
                cell.Text = "X";
                cell.MouseClick -= Cell.MouseClick;
                GameForm.User = false;
            }
            else
            {
                cell.Text = "O";
                cell.MouseClick -= Cell.MouseClick;
                GameForm.User = true;
            }
            Field.CheckWin(GameForm.field.cells);
        }
    }

    public class Field
    {
        public Cell[,] cells;
        public static int Width { get; set; } = 3;

        public static void CheckWin(Cell[,] cells)
        {
            bool iswin2 = true, iswin3 = true;
            for (int i = 0; i < Field.Width; i++)
            {
                bool iswin = true, iswin1 = true; 
                if ((cells[i, i].cell.Text != cells[0, 0].cell.Text) || (cells[i, i].cell.Text == "")) { iswin2 = false; }
                if ((cells[i, Field.Width-1-i].cell.Text != cells[0, Field.Width-1].cell.Text) || (cells[i, Field.Width-1-i].cell.Text == "")) { iswin3 = false; }
                for (int j = 0; j < Field.Width; j++)
                {
                    if ((cells[i, j].cell.Text != cells[i, 0].cell.Text)|| (cells[i, j].cell.Text=="")) { iswin = false; }
                    if ((cells[j, i].cell.Text != cells[0, i].cell.Text)|| (cells[j, i].cell.Text == "")) { iswin1 = false; }
                }
                if (iswin)
                {
                    if(cells[i, 0].cell.Text == "X") { MessageService.Win("Победил первый"); }
                    else { MessageService.Win("Победил второй"); }
                }
                if (iswin1)
                {
                    if (cells[0, i].cell.Text == "X") { MessageService.Win("Победил первый"); }
                    else { MessageService.Win("Победил второй"); }
                }
            }
            if (iswin2)
            {
                if (cells[0, 0].cell.Text == "X") { MessageService.Win("Победил первый"); }
                else { MessageService.Win("Победил второй"); }
            }
            if (iswin3)
            {
                if (cells[0, Field.Width - 1].cell.Text == "X") { MessageService.Win("Победил первый"); }
                else { MessageService.Win("Победил второй"); }
            }
        }
    }

    public partial class GameForm
    {
        public static Field field = new Field();
    }

    class MessageService
    {
        public static void Information(string info)
        {
            MessageBox.Show(info, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string warning)
        {
            MessageBox.Show(warning, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Win(string info)
        {
            MessageBox.Show(info, "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (var item in GameForm.field.cells) { item.cell.Enabled = false; }
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }
    }
}
