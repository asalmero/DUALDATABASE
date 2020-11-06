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
    public partial class Form1 : Form
    {
        public static string valueText1 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void usrTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pswTxtBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void Sesion()
        {
            string connect = "datasource=localhost;port=3306;username=root;password=;database=control";
            string query = "Select * from login where user = '" + usrTxtBox.Text + "' AND password=SHA1('" + pswTxtBox.Text + "') ";

            MySqlConnection databaseConnection = new MySqlConnection(connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                  
                reader = commandDatabase.ExecuteReader();
                if (reader.Read()) {

                    MessageBox.Show("Bienvenido al Sistema");
                    valueText1 = usrTxtBox.Text;
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Usuario/Contraseña Erronea");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Sesion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
