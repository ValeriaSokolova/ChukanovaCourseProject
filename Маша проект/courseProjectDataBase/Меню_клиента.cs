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
    public partial class Меню_клиента : Form
    {
            Database b = new Database();
        public Меню_клиента()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.DisplayPlastinkaInformAndPriceData(dataGridView1);
            b.DisplayPlastinkaDataAndStudioData(dataGridView2);
            b.DisplayStudioData(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                b.ExportWord(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                b.ExportWord(dataGridView2);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                b.ExportWord(dataGridView3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                b.ExportExcel(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                b.ExportExcel(dataGridView2);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                b.ExportExcel(dataGridView3);
            }
        }
    }
}
