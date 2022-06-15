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


            string sity = textBox7.Text;
            int home = Convert.ToInt32(textBox8.Text);
            string street = textBox9.Text;
            int index = Convert.ToInt32(textBox10.Text);
            int flat = Convert.ToInt32(textBox11.Text);
            string nameOfStudio = textBox12.Text;
            b.AddStudio(sity, home, street, index, flat,nameOfStudio);
            int studio_id = b.getStudioId(sity, home, street, index, flat);





            int typeOfPlastinka = comboBox2.SelectedIndex + 1;
            int price = comboBox4.SelectedIndex + 1;
            DateTime date = new DateTime();
            date = DateTime.Parse(startDate);

            b.AddPlastinka(albom, singer, size, time, price, typeOfPlastinka, studio_id, date, dataGridView1);
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
                b.DisplayPlastinkaByAlbom(dataGridView1,name);
            }
            else if (radioButton2.Checked)
            {
                string singer = textBox14.Text;
                b.DisplayPlastinkaBySinger(dataGridView1, singer);
            }
            else
            {
                MessageBox.Show("Выберете поиск по имени или фамилии");
            }
        }
        // редактировать
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].FormattedValue);

            List<string> plastinka = new List<string>();
            plastinka = b.GetPlastinka(id);
            textBox2.Text = plastinka[0];
            textBox3.Text = plastinka[1];
            textBox4.Text = plastinka[2];
            textBox5.Text = plastinka[3];
            textBox6.Text = plastinka[4];
            comboBox2.SelectedItem = plastinka[5];
            comboBox4.SelectedItem = plastinka[6];
            textBox7.Text = plastinka[7];
            textBox8.Text = plastinka[8];
            textBox9.Text = plastinka[9];
            textBox10.Text = plastinka[10];
            textBox11.Text = plastinka[11];
            textBox12.Text = plastinka[12];
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
