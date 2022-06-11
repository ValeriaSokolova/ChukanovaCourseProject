using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КП_БД
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Меню_клиента f = new Меню_клиента();
                f.Show();
            }
            if (checkBox2.Checked)
            {

                Меню_администратора f = new Меню_администратора();
                f.Show();
            }
        }
    }
}
