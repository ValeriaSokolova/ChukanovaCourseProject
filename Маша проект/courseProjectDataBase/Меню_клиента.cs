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
            b.DisplayPeopleDataAndStudioData(dataGridView2);
            b.DisplayStudioData(dataGridView3);
        }
    }
}
