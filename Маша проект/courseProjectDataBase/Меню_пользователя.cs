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
    public partial class Меню_пользователя : Form
    {
            Database b = new Database();
        public Меню_пользователя()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.DisplayPeopleInformAndWorkData(dataGridView1);
            b.DisplayPeopleDataAndAdressData(dataGridView2);
            b.DisplayPeopleDataAndPhoneData(dataGridView3);
        }
    }
}
