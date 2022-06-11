using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace КП_БД
{
    internal class Database
    {
        private SqlDataAdapter adapter;
        private SqlCommand cmd;
        public Database()
        { }



        private string connectionString = @"Data Source = HOME-PC\SQLEXPRESS; Initial Catalog = Музыкальный_магазин;Integrated Security = True;";
        public void DisplayPlastinkaData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from ПЛАСТИНКА", connectionString);
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }


        public void DisplayPeopleDataAndPhoneData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.ИМЯ, ПЛАСТИНКА.ФАМИЛИЯ, ПЛАСТИНКА.ОТЧЕСТВО, НОМЕР_ТЕЛЕФОНА.НОМЕР_ТЕЛЕФОНА, ТЕЛЕФОН.ТИП_ТЕЛЕФОНА FROM ПЛАСТИНКА INNER JOIN НОМЕР_ТЕЛЕФОНА ON ПЛАСТИНКА.НОМЕР_id = НОМЕР_ТЕЛЕФОНА.id_i INNER JOIN ТЕЛЕФОН ON ТЕЛЕФОН.id_t = НОМЕР_ТЕЛЕФОНА.id_i  ", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DisplayPeopleDataAndAdressData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.ИМЯ, ПЛАСТИНКА.ФАМИЛИЯ, ПЛАСТИНКА.ОТЧЕСТВО, АДРЕС.ГОРОД, АДРЕС.ДОМ, АДРЕС.ИНДЕКС, АДРЕС.КВАРТИРА, АДРЕС.УЛИЦА   " +
                    "FROM ПЛАСТИНКА INNER JOIN АДРЕС ON ПЛАСТИНКА.АДРЕС_ID = АДРЕС.id_h", connectionString); /// дописать джоин он по адресу и еще 1 п
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DisplayPlastinkaInformAndPriceData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, " +
                    "ЦЕНА.ЦЕНА FROM ПЛАСТИНКА INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                    "INNER JOIN  ЦЕНА ON  ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m " +
                    "Order by ПЛАСТИНКА.ИСПОЛНИТЕЛЬ ", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }


        public void DisplayPeopleInformAndWorkDataWithConditionHaving(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                DateTime date = new DateTime();
                date = DateTime.Parse("2002.01.01");
                adapter = new SqlDataAdapter("SELECT ФАМИЛИЯ, COUNT(ФАМИЛИЯ) AS КОЛИЧЕСТВО FROM ПЛАСТИНКА GROUP BY ФАМИЛИЯ HAVING ФАМИЛИЯ = 'Астахов' ", connectionString);
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }


        //public void DisplayAdressData(DataGridView dataGrid)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        adapter = new SqlDataAdapter("select * from АДРЕС", connectionString);
        //        adapter.Fill(dt);
        //        dataGrid.DataSource = dt;
        //        connection.Close();
        //    }
        //}

        //public void DisplayTelephoneData(DataGridView dataGrid)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        adapter = new SqlDataAdapter("select * from НОМЕР_ТЕЛЕФОНА", connectionString);
        //        adapter.Fill(dt);
        //        dataGrid.DataSource = dt;
        //        connection.Close();
        //    }
        //}
        //public void DisplayHuman(DataGridView dataGrid)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        adapter = new SqlDataAdapter("select * from ПЛАСТИНКА", connectionString);
        //        adapter.Fill(dt);
        //        dataGrid.DataSource = dt;
        //        connection.Close();
        //    }
        //}
        public List<string> getTypesOfWorkPlaces()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 5;
                List<string> s = new List< string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from МЕСТО_РАБОТЫ", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["МЕСТО_РАБОТЫ"]) );
                }
                connection.Close();
                return s;
            }
        }

        public List<string> getTypesOfJobTitle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 5;
                List<string> s = new List<string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from ДОЛЖНОСТЬ", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["ДОЛЖНОСТЬ"]));
                }
                connection.Close();
                return s;
            }
        }
        public List<string> getTypesOfStatus()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 3;
                List<string> s = new List<string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from СТАТУС", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["СТАТУС"]));
                }
                connection.Close();
                return s;
            }
        }
        public List<string> getTypesOfPhone()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 5;
                List<string> s = new List<string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from ТЕЛЕФОН", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["ТИП_ТЕЛЕФОНА"]));
                }
                connection.Close();
                return s;
            }
        }
        public void AddHuman(string sername, string first_name,  string patronymic, string sex, int mrID, int dolgID, int numTelID, int statusID, int adressID, DateTime date, DataGridView dataGrid)
        {
            if (first_name != "" && sername != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand(
                        "insert into ПЛАСТИНКА (ФАМИЛИЯ, ИМЯ, ОТЧЕСТВО, ПОЛ, ДАТА_РОЖДЕНИЯ, МЕСТО_РАБОТЫ_id, ДОЛЖНОСТЬ_ID, НОМЕР_ID, СТАТУС_ID, АДРЕС_ID) values(@ФАМИЛИЯ, @ИМЯ, @ОТЧЕСТВО, @ПОЛ,  @ДАТА_РОЖДЕНИЯ, @МЕСТО_РАБОТЫ_id, @ДОЛЖНОСТЬ_ID, @НОМЕР_ID, @СТАТУС_ID, @АДРЕС_ID)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ФАМИЛИЯ", sername);
                    cmd.Parameters.AddWithValue("@ИМЯ", first_name);
                    cmd.Parameters.AddWithValue("@ОТЧЕСТВО", patronymic);
                    cmd.Parameters.AddWithValue("@ПОЛ", sex);
                    cmd.Parameters.AddWithValue("@ДАТА_РОЖДЕНИЯ", date);
                    cmd.Parameters.AddWithValue("@МЕСТО_РАБОТЫ_id", mrID);
                    cmd.Parameters.AddWithValue("@ДОЛЖНОСТЬ_ID", dolgID);
                    cmd.Parameters.AddWithValue("@НОМЕР_ID", numTelID);
                    cmd.Parameters.AddWithValue("@СТАТУС_ID", statusID);
                    cmd.Parameters.AddWithValue("@АДРЕС_ID", adressID);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Добавлено");
                    //DisplayPeopleData(dataGrid);

                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        //  разобраться с адаптером и кмд для запроса по гет айди 
        // либо сделать список списков для людей и там искать уже относительно всей таблицы в памяти
        public List<string> GetHuman(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> list = new List<string>();
                DataTable dt = new DataTable();
                /*
                 
                 SELECT ЧЕЛОВЕК.ИМЯ, ЧЕЛОВЕК.ФАМИЛИЯ, ЧЕЛОВЕК.ОТЧЕСТВО, ЧЕЛОВЕК.ДАТА_РОЖДЕНИЯ, ДОЛЖНОСТЬ.ДОЛЖНОСТЬ, " +
                    "МЕСТО_РАБОТЫ.МЕСТО_РАБОТЫ, СТАТУС.СТАТУС FROM ЧЕЛОВЕК INNER JOIN ДОЛЖНОСТЬ ON ЧЕЛОВЕК.ДОЛЖНОСТЬ_id = ДОЛЖНОСТЬ.id_d " +
                    "INNER JOIN  МЕСТО_РАБОТЫ ON  ЧЕЛОВЕК.МЕСТО_РАБОТЫ_id = МЕСТО_РАБОТЫ.id_m " +
                    "INNER JOIN СТАТУС ON  ЧЕЛОВЕК.СТАТУС_id = СТАТУС.id_c
                 */
                //, СТАТУС.СТАТУС
                adapter = new SqlDataAdapter("select ПЛАСТИНКА.ИМЯ, ПЛАСТИНКА.ФАМИЛИЯ, ПЛАСТИНКА.ОТЧЕСТВО, ПЛАСТИНКА.ДАТА_РОЖДЕНИЯ, ПЛАСТИНКА.ПОЛ, ДОЛЖНОСТЬ.ДОЛЖНОСТЬ, НОМЕР_ТЕЛЕФОНА.НОМЕР_ТЕЛЕФОНА, " +
                    "МЕСТО_РАБОТЫ.МЕСТО_РАБОТЫ, АДРЕС.ГОРОД, АДРЕС.ИНДЕКС, АДРЕС.УЛИЦА, АДРЕС.ДОМ, АДРЕС.КВАРТИРА, СТАТУС.СТАТУС, ТЕЛЕФОН.ТИП_ТЕЛЕФОНА " +
                    "from ПЛАСТИНКА " +
                    "INNER JOIN ДОЛЖНОСТЬ ON ПЛАСТИНКА.ДОЛЖНОСТЬ_id = ДОЛЖНОСТЬ.id_d " +
                    "INNER JOIN  МЕСТО_РАБОТЫ ON ПЛАСТИНКА.МЕСТО_РАБОТЫ_id = МЕСТО_РАБОТЫ.id_m " +
                    "INNER JOIN АДРЕС ON ПЛАСТИНКА.АДРЕС_id = АДРЕС.id_h " +
                    "INNER JOIN СТАТУС ON ПЛАСТИНКА.СТАТУС_id = СТАТУС.id_c " +
                    "INNER JOIN НОМЕР_ТЕЛЕФОНА ON ПЛАСТИНКА.НОМЕР_id = НОМЕР_ТЕЛЕФОНА.id_i " +
                    "INNER JOIN ТЕЛЕФОН ON НОМЕР_ТЕЛЕФОНА.id_i = ТЕЛЕФОН.id_t " +
                    "AND ЧЕЛОВЕК.id_p = " + id, connection);



                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToString(dr["ФАМИЛИЯ"]));
                    list.Add(Convert.ToString(dr["ИМЯ"]));
                    list.Add(Convert.ToString(dr["ОТЧЕСТВО"]));
                    list.Add(Convert.ToString(dr["ПОЛ"]));
                    list.Add(Convert.ToString(dr["ДАТА_РОЖДЕНИЯ"]));
                    list.Add(Convert.ToString(dr["ДОЛЖНОСТЬ"]));
                    list.Add(Convert.ToString(dr["МЕСТО_РАБОТЫ"]));

                    list.Add(Convert.ToString(dr["ГОРОД"]));
                    list.Add(Convert.ToString(dr["ДОМ"]));
                    list.Add(Convert.ToString(dr["УЛИЦА"]));
                    list.Add(Convert.ToString(dr["ИНДЕКС"]));
                    list.Add(Convert.ToString(dr["КВАРТИРА"]));
                    list.Add(Convert.ToString(dr["СТАТУС"]));
                    list.Add(Convert.ToString(dr["НОМЕР_ТЕЛЕФОНА"]));
                    list.Add(Convert.ToString(dr["ТИП_ТЕЛЕФОНА"]));
                }
                connection.Close();
                return list;

            }
        }
        public List<string> GetHumanByName(string name)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> list = new List<string>();
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select * from ПЛАСТИНКА where ИМЯ = '" + name+" '", connection);
                cmd.Parameters.AddWithValue("@id", name);
                cmd.ExecuteNonQuery();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToString(dr["ФАМИЛИЯ"]));
                    list.Add(Convert.ToString(dr["ИМЯ"]));
                    list.Add(Convert.ToString(dr["ОТЧЕСТВО"]));
                    list.Add(Convert.ToString(dr["ПОЛ"]));
                    list.Add(Convert.ToString(dr["ДАТА_РОЖДЕНИЯ"]));
                }
                connection.Close();
                return list;

            }
        }
        public int getAdressId(string sity, int home, string street, int index, int flat)
        {
            if (sity != "" && street != "" )
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(
                       "select id_h from АДРЕС where ГОРОД = '"+ sity + "' and ИНДЕКС = " + index + " and УЛИЦА = '" + street + "' and ДОМ = " + home + " and КВАРТИРА = " + flat, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        connection.Close();
                        return (Convert.ToInt32(dr["id_h"]));
                    }
                    return -1;
                 
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
                return -1;
            }
        }
        public int getIdByNumber(string number)
        {
            if (number != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(
                       "select id_i from НОМЕР_ТЕЛЕФОНА where НОМЕР_ТЕЛЕФОНА = '" + number + "'", connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        connection.Close();
                        return (Convert.ToInt32(dr["id_i"]));
                    }
                    return -1;
                 
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
                return -1;
            }
        }
        public void AddAdress(string sity, int home, string street, int index, int flat)
        {
            if (sity != "" && street != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand(
                        "insert into АДРЕС (ГОРОД,ИНДЕКС,УЛИЦА,ДОМ,КВАРТИРА) values(@ГОРОД,@ИНДЕКС,@УЛИЦА,@ДОМ,@КВАРТИРА)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ГОРОД", sity);
                    cmd.Parameters.AddWithValue("@ИНДЕКС", index);
                    cmd.Parameters.AddWithValue("@УЛИЦА", street);
                    cmd.Parameters.AddWithValue("@ДОМ", home);
                    cmd.Parameters.AddWithValue("@КВАРТИРА", flat);
                    cmd.ExecuteNonQuery();
            
                    connection.Close();

                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
        public void AddNumber(string number)
        {
            if (number != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand(
                        "insert into НОМЕР_ТЕЛЕФОНА (НОМЕР_ТЕЛЕФОНА) values(@НОМЕР_ТЕЛЕФОНА)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@НОМЕР_ТЕЛЕФОНА", number);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
        public void DeleteAdressById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(
                    "delete from АДРЕС where id_h = @id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        public void DeletePhoneNumberById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(
                    "delete from НОМЕР_ТЕЛЕФОНА where id_i = @id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        public int getAdressIdByHumanId(int humanId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(
                   "select * from ПЛАСТИНКА where id_p = " + humanId, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    connection.Close();
                    return (Convert.ToInt32(dr["АДРЕС_ID"]));
                }
                return -1;

            }
        }
        public int getPhoneNumberIdByHumanId(int humanId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(
                   "select * from ПЛАСТИНКА where id_p = " + humanId, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    connection.Close();
                    return (Convert.ToInt32(dr["НОМЕР_ID"]));
                }
                return -1;

            }
        }
        public void DisplayPeopleInformAndWorkDataWithName(DataGridView dataGrid, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.ИМЯ, ПЛАСТИНКА.ФАМИЛИЯ, ПЛАСТИНКА.ОТЧЕСТВО, ПЛАСТИНКА.ДАТА_РОЖДЕНИЯ, ДОЛЖНОСТЬ.ДОЛЖНОСТЬ, " +
                    "МЕСТО_РАБОТЫ.МЕСТО_РАБОТЫ, СТАТУС.СТАТУС FROM ПЛАСТИНКА INNER JOIN ДОЛЖНОСТЬ ON ПЛАСТИНКА.ДОЛЖНОСТЬ_id = ДОЛЖНОСТЬ.id_d " +
                    "INNER JOIN  МЕСТО_РАБОТЫ ON  ПЛАСТИНКА.МЕСТО_РАБОТЫ_id = МЕСТО_РАБОТЫ.id_m " +
                    "INNER JOIN СТАТУС ON  ПЛАСТИНКА.СТАТУС_id = СТАТУС.id_c AND ПЛАСТИНКА.ИМЯ = '" + name+"'", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DisplayPeopleInformAndWorkDataWithSername(DataGridView dataGrid, string sername)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.ИМЯ, ПЛАСТИНКА.ФАМИЛИЯ, ПЛАСТИНКА.ОТЧЕСТВО, ПЛАСТИНКА.ДАТА_РОЖДЕНИЯ, ДОЛЖНОСТЬ.ДОЛЖНОСТЬ, " +
                    "МЕСТО_РАБОТЫ.МЕСТО_РАБОТЫ, СТАТУС.СТАТУС FROM ПЛАСТИНКА INNER JOIN ДОЛЖНОСТЬ ON ПЛАСТИНКА.ДОЛЖНОСТЬ_id = ДОЛЖНОСТЬ.id_d " +
                    "INNER JOIN  МЕСТО_РАБОТЫ ON  ПЛАСТИНКА.МЕСТО_РАБОТЫ_id = МЕСТО_РАБОТЫ.id_m " +
                    "INNER JOIN СТАТУС ON  ПЛАСТИНКА.СТАТУС_id = СТАТУС.id_c AND ПЛАСТИНКА.ФАМИЛИЯ = '" + sername+"'", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DeleteHumanByID(int id, DataGridView dataGrid)
        {
            int adressId= getAdressIdByHumanId(id);
            int phoneNumberId= getPhoneNumberIdByHumanId(id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(
                    "delete from ПЛАСТИНКА where id_p = @id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            DeleteAdressById(adressId);
            DeletePhoneNumberById(phoneNumberId);
            //DisplayPeopleData(dataGrid);
        }
    }
}
