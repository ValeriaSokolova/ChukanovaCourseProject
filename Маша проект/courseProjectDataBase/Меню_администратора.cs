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
    public partial class Меню_администратора : Form
    {
        Database b = new Database();
        public Меню_администратора()
        {
            InitializeComponent();
            var allTypesOfPrices = b.getTypesOfPrices();
            foreach (var m in allTypesOfPrices)
            {
                comboBox4.Items.Add(m);
            }
            var allTypesOfPlastinka = b.getTypesOfPlastinka();
            foreach (var m in allTypesOfPlastinka)
            {
                comboBox2.Items.Add(m);
            }
            b.DisplayPlastinkaData(dataGridView1);

        }
        // добавить
        private void button2_Click(object sender, EventArgs e)
        {

            string albom = textBox2.Text;
            string singer = textBox3.Text;
            string size = textBox4.Text;
            string time = textBox5.Text;
            string startDate = textBox6.Text;


            //string sity = textBox7.Text;
            //int home = Convert.ToInt32(textBox8.Text);
            //string street = textBox9.Text;
            //int index = Convert.ToInt32(textBox10.Text);
            //int flat = Convert.ToInt32(textBox11.Text);
            //b.AddAdress(sity, home, street, index, flat);
            //int adres_id = b.getAdressId(sity, home, street, index, flat);

          


           
            //int dolgn_id = comboBox2.SelectedIndex + 1;
            //int mr_id = comboBox4.SelectedIndex + 1;
            DateTime date = new DateTime();
            date = DateTime.Parse(startDate);

            b.AddPlastinka(albom, singer, size, time, 1, 1, 1, date, dataGridView1);
        }
    

        
        // показать записи
        private void button1_Click(object sender, EventArgs e)
        {
            b.DisplayPlastinkaInformAndPriceData(dataGridView1);
        }
        // поиск по разным
        private void button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                string name = textBox13.Text;
                b.DisplayPeopleInformAndWorkDataWithName(dataGridView1,name);
            }
            else if (radioButton2.Checked)
            {
                string sername = textBox14.Text;
                b.DisplayPeopleInformAndWorkDataWithSername(dataGridView1, sername);
            }
            else
            {
                MessageBox.Show("Выберете поиск по имени или фамилии");
            }
        }
        // редактировать
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            if (0 == tabControl1.SelectedIndex)
            {
                List<string> human = new List<string>();
                human = b.GetHuman(id);
                textBox2.Text = human[0];
                textBox3.Text= human[1];
                textBox4.Text = human[2];
                textBox5.Text = human[3];
                textBox6.Text = human[4];
                comboBox2.SelectedItem = human[5];
                comboBox4.SelectedItem = human[6];
                textBox7.Text = human[7];
                textBox8.Text = human[8];
                textBox9.Text = human[9];
                textBox10.Text = human[10];
                textBox11.Text = human[11];
                
                textBox12.Text = human[13];
               
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                string sity = textBox7.Text;
                int home = Convert.ToInt32(textBox8.Text);
                string street = textBox9.Text;
                int index = Convert.ToInt32(textBox10.Text);
                int flat = Convert.ToInt32(textBox11.Text);
                b.AddAdress(sity, home, street, index, flat);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                string number = textBox12.Text;
               // b.AddNumber(number, dataGridView3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            b.DeleteHumanByID(id,dataGridView1);



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // having
        private void button6_Click(object sender, EventArgs e)
        {
            b.DisplayPeopleInformAndWorkDataWithConditionHaving(dataGridView1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
