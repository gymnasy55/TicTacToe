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
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txtLoad.Text) <= 0) { MessageService.Error("Некорректно введён размер поля"); }
                else
                {
                    Field.Width = Convert.ToInt32(txtLoad.Text);
                    Form form = new ChooseForm();
                    form.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageService.Error("Некорректно введён размер поля");
            }
        }
    }
}
