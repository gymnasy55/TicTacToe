using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        public static bool User = true; //true - X, false - O

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = (Cell.Position.X * 3) + (Field.Width * (Cell.Width + 1)); this.Height = (Cell.Position.Y * 5) + (Field.Width * (Cell.Width + 1)); int x = Cell.Position.X, y = Cell.Position.Y;
            field.cells = new Cell[Field.Width, Field.Width];
            for(int i = 0; i < Field.Width; i++)
            {
                for(int j = 0; j < Field.Width; j++)
                {
                    field.cells[i, j] = new Cell()
                    {
                        cell = new Label()
                        {
                            Height = Cell.Width,
                            Width = Cell.Width,
                            Top = y,
                            Left = x,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BorderStyle = BorderStyle.FixedSingle,
                            Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold),
                            Name = "",
                        }
                    };
                    field.cells[i, j].Location.X = Convert.ToInt32(Math.Truncate((field.cells[i, j].cell.Location.X - 13) / Convert.ToDouble(Cell.Width)));
                    field.cells[i, j].cell.MouseEnter +=  new EventHandler(Cell.MouseEnter);
                    field.cells[i, j].cell.MouseLeave += new EventHandler(Cell.MouseLeave);
                    field.cells[i, j].cell.MouseClick += new MouseEventHandler(Cell.MouseClick);
                    x += Cell.Width + 1;
                    this.Controls.Add(field.cells[i, j].cell);
                }
                x = 13;
                y += Cell.Width + 1;
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Process.Start("TicTacToe.exe");
        }
    }
}
