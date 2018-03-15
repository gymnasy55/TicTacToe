using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 1);
            if(value == 1)
            {
                lblInfo.Visible = true;
                lblUser.Text = "Первый";
                lblUser.Visible = true;
            }
            else
            {
                lblInfo.Visible = true;
                lblUser.Text = "Второй";
                lblUser.Visible = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(lblInfo.Visible)
            {
                Form form = new GameForm();
                form.Show();
                this.Close();
            }
            else
            {
                MessageService.Warning("Выберите первого");
            }
        }
    }
}
