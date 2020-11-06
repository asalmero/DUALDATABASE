using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace DATAPASSING
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.valueText1;
            string connect = "datasource=localhost;port=3306;username=root;password=;database=almacen";
            string query = "SELECT * FROM articulos ";
            MySqlConnection databaseConnection = new MySqlConnection(connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                if (reader.HasRows) {
                
                    while (reader.Read())
                    {
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            String[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                            var Listviewitems = new ListViewItem(row);
                            listView1.Items.Add(Listviewitems);

                        }
                    }

                
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
