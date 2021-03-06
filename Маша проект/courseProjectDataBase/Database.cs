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


        // методы формы клиента
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
      
        public void DisplayPlastinkaDataAndStudioData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, СТУДИЯ.НАЗВАНИЕ, СТУДИЯ.ГОРОД, СТУДИЯ.ДОМ, СТУДИЯ.ИНДЕКС, СТУДИЯ.КВАРТИРА, СТУДИЯ.УЛИЦА   " +
                    "FROM ПЛАСТИНКА INNER JOIN СТУДИЯ ON ПЛАСТИНКА.СТУДИЯ_id = СТУДИЯ.id", connectionString); /// дописать джоин он по адресу и еще 1 п
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
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.id, ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, " +
                    "ЦЕНА.ЦЕНА FROM ПЛАСТИНКА INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                    "INNER JOIN  ЦЕНА ON  ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m " +
                    "Order by ПЛАСТИНКА.ИСПОЛНИТЕЛЬ ", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }

        public void DisplayStudioData(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT * From СТУДИЯ", connectionString);
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }




        // методы формы администратора
        public void DisplayBaskovAlboms(DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                DateTime date = new DateTime();
                date = DateTime.Parse("2002.01.01");
                adapter = new SqlDataAdapter("SELECT ИСПОЛНИТЕЛЬ, COUNT(ИСПОЛНИТЕЛЬ) AS КОЛИЧЕСТВО FROM ПЛАСТИНКА GROUP BY ИСПОЛНИТЕЛЬ HAVING ИСПОЛНИТЕЛЬ = 'Басков' ", connectionString);
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }


    
        public List<string> getTypesOfPrices()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 5;
                List<string> s = new List< string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from ЦЕНА", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["ЦЕНА"]) );
                }
                connection.Close();
                return s;
            }
        }

        public List<string> getTypesOfPlastinka()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 5;
                List<string> s = new List<string>();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from ТИП_ПЛАСТИНКИ", connectionString);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    s.Add(Convert.ToString(dr["ТИП_ПЛАСТИНКИ"]));
                }
                connection.Close();
                return s;
            }
        }
        public void AddPlastinka(string singer, string albom,  string size, string time, int price_ID, int typePlId, int studioID, DateTime date, DataGridView dataGrid)
        {
            if (singer != "" && albom != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand(
                        "insert into ПЛАСТИНКА (ИСПОЛНИТЕЛЬ, АЛЬБОМ, РАЗМЕР_ПЛАСТИНКИ, ВРЕМЯ_ПРОИГРЫВАНИЯ, ДАТА_ВЫПУСКА, ЦЕНА_id, ТИП_ПЛАСТИНКИ_ID, " +
                        "СТУДИЯ_id) values(@ИСПОЛНИТЕЛЬ, @АЛЬБОМ, @РАЗМЕР_ПЛАСТИНКИ, @ВРЕМЯ_ПРОИГРЫВАНИЯ,  @ДАТА_ВЫПУСКА, @ЦЕНА_id, " +
                        "@ТИП_ПЛАСТИНКИ_ID, @СТУДИЯ_id)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ИСПОЛНИТЕЛЬ", singer);
                    cmd.Parameters.AddWithValue("@АЛЬБОМ", albom);
                    cmd.Parameters.AddWithValue("@РАЗМЕР_ПЛАСТИНКИ", size);
                    cmd.Parameters.AddWithValue("@ВРЕМЯ_ПРОИГРЫВАНИЯ", time);
                    cmd.Parameters.AddWithValue("@ДАТА_ВЫПУСКА", date);
                    cmd.Parameters.AddWithValue("@ЦЕНА_id", price_ID);
                    cmd.Parameters.AddWithValue("@ТИП_ПЛАСТИНКИ_ID", typePlId);
                    cmd.Parameters.AddWithValue("@СТУДИЯ_id", studioID);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Добавлено");

                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        //  разобраться с адаптером и кмд для запроса по гет айди 
        // либо сделать список списков для людей и там искать уже относительно всей таблицы в памяти
        public List<string> GetPlastinka(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> list = new List<string>();
                DataTable dt = new DataTable();
                /*
                 ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, " +
                     "ЦЕНА.ЦЕНА FROM ПЛАСТИНКА INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                     "INNER JOIN  ЦЕНА ON  ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m
                 */
                adapter = new SqlDataAdapter("select ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ПЛАСТИНКА.ВРЕМЯ_ПРОИГРЫВАНИЯ," +
                    " ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, СТУДИЯ.НАЗВАНИЕ, " +
                    "ЦЕНА.ЦЕНА, СТУДИЯ.ГОРОД, СТУДИЯ.ИНДЕКС, СТУДИЯ.УЛИЦА, СТУДИЯ.ДОМ, СТУДИЯ.КВАРТИРА " +
                    "from ПЛАСТИНКА " +
                    "INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                    "INNER JOIN  ЦЕНА ON ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m " +
                    "INNER JOIN СТУДИЯ ON ПЛАСТИНКА.СТУДИЯ_id = СТУДИЯ.id " +
                    "AND ПЛАСТИНКА.id = " + id, connection);



                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToString(dr["ИСПОЛНИТЕЛЬ"]));
                    list.Add(Convert.ToString(dr["АЛЬБОМ"]));
                    list.Add(Convert.ToString(dr["РАЗМЕР_ПЛАСТИНКИ"]));
                    list.Add(Convert.ToString(dr["ВРЕМЯ_ПРОИГРЫВАНИЯ"]));
                    list.Add(Convert.ToString(dr["ДАТА_ВЫПУСКА"]));
                    list.Add(Convert.ToString(dr["ТИП_ПЛАСТИНКИ"]));
                    list.Add(Convert.ToString(dr["ЦЕНА"]));

                    list.Add(Convert.ToString(dr["ГОРОД"]));
                    list.Add(Convert.ToString(dr["ДОМ"]));
                    list.Add(Convert.ToString(dr["УЛИЦА"]));
                    list.Add(Convert.ToString(dr["ИНДЕКС"]));
                    list.Add(Convert.ToString(dr["КВАРТИРА"]));
                    list.Add(Convert.ToString(dr["НАЗВАНИЕ"]));
                }
                connection.Close();
                return list;

            }
        }
       
        public int getStudioId(string sity, int home, string street, int index, int flat)
        {
            if (sity != "" && street != "" )
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(
                       "select id from СТУДИЯ where ГОРОД = '"+ sity + "' and ИНДЕКС = " + index + " and УЛИЦА = '" + street + "' and ДОМ = " + home + " and КВАРТИРА = " + flat, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        connection.Close();
                        return (Convert.ToInt32(dr["id"]));
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
       
        public void AddStudio(string sity, int home, string street, int index, int flat, string nameOfstudio)
        {
            if (sity != "" && street != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand(
                        "insert into СТУДИЯ (НАЗВАНИЕ,ГОРОД,ИНДЕКС,УЛИЦА,ДОМ,КВАРТИРА) values(@НАЗВАНИЕ,@ГОРОД,@ИНДЕКС,@УЛИЦА,@ДОМ,@КВАРТИРА)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@НАЗВАНИЕ", nameOfstudio);
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
        
       
        public int getStudioIdByPlastinkaId(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(
                   "select * from ПЛАСТИНКА where id = " + Id, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    connection.Close();
                    return (Convert.ToInt32(dr["СТУДИЯ_id"]));
                }
                return -1;

            }
        }
       
        public void DisplayPlastinkaByAlbom(DataGridView dataGrid, string albom)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, " +
                    "ЦЕНА.ЦЕНА FROM ПЛАСТИНКА INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                    "INNER JOIN  ЦЕНА ON  ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m " +
                    "AND ПЛАСТИНКА.АЛЬБОМ = '" + albom + "'", connectionString);
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DisplayPlastinkaBySinger(DataGridView dataGrid, string singer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT ПЛАСТИНКА.АЛЬБОМ, ПЛАСТИНКА.ИСПОЛНИТЕЛЬ, ПЛАСТИНКА.РАЗМЕР_ПЛАСТИНКИ, ПЛАСТИНКА.ДАТА_ВЫПУСКА, ТИП_ПЛАСТИНКИ.ТИП_ПЛАСТИНКИ, " +
                    "ЦЕНА.ЦЕНА FROM ПЛАСТИНКА INNER JOIN ТИП_ПЛАСТИНКИ ON ПЛАСТИНКА.ТИП_ПЛАСТИНКИ_id = ТИП_ПЛАСТИНКИ.id " +
                    "INNER JOIN  ЦЕНА ON  ПЛАСТИНКА.ЦЕНА_id = ЦЕНА.id_m AND ПЛАСТИНКА.ИСПОЛНИТЕЛЬ = '" + singer+"'", connectionString); /// дописать джоин он по адресу и еще 1 по 
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
                connection.Close();
            }
        }
        public void DeletePlastinkaByID(int id, DataGridView dataGrid)
        {
            int adressId= getStudioIdByPlastinkaId(id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(
                    "delete from ПЛАСТИНКА where id = @id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            
        }
        public void ExportExcel(DataGridView dataGrid)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // создаем новый WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook =
            app.Workbooks.Add(Type.Missing);
            // новый Excelsheet в workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // задаем имя для worksheet
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGrid.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGrid.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] =
                    dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }
        }
        public void ExportWord(DataGridView DGV)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                //добавим поля и колонки
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }
                Microsoft.Office.Interop.Word.Document oDoc = new
                Microsoft.Office.Interop.Word.Document();
                oDoc.Application.Visible = true;
                //страницы
                oDoc.PageSetup.Orientation =
                Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";
                    }
                }
                //формат таблиц
                oRange.Text = oTemp;
                object Separator =
                Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior =
                Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                Type.Missing, Type.Missing, ref ApplyBorders,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, ref AutoFit, ref AutoFitBehavior,
                oRange.Select());
            }
        }
    }
}
