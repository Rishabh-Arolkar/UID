using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hardware_Store_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=login_db";

        public void login()
        {
            string query = "SELECT * FROM login where Username='" + txtBoxUsername.Text + "' AND Password='" + txtBoxPassword.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Login Successful");
                        Items frm2 = new Items();
                        frm2.Show();
                        txtBoxUsername.Clear();
                        txtBoxPassword.Clear();
                        //this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Error! Invalid Username or Password");

                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            txtBoxUsername.Clear();
            txtBoxPassword.Clear();
        }
    }
}
