using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hardware_Store_Management_System
{
    public partial class Items : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd;
        DataSet ds;
        MySqlDataAdapter adpt;
        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection("Database=Items_db; Data Source=localhost;User Id = root; password = ");
                conn.Open();
                loaddata(); //loads data from the table into the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database" + ex.ToString(), "NULL", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void loaddata()
        {
             adpt = new MySqlDataAdapter();
             cmd = new MySqlCommand();
             ds = new DataSet();
             cmd.CommandText = "select * from items";
             cmd.Connection = conn;
             adpt.SelectCommand = cmd;
             adpt.Fill(ds, "items");
             dataGridViewItems.DataSource = ds;
             dataGridViewItems.DataMember = "items";
             clear();
            
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {         
            cmd = new MySqlCommand();
            cmd.CommandText = "Insert into items values('" + (txtBoxCode.Text).Trim() + "', '" + (txtBoxName.Text).Trim() + "', '" + (txtBoxCategory.Text).Trim() + "', '" + (txtBoxPrice.Text).Trim() + "', '" + (txtBoxStock.Text).Trim() + "', '" + (txtBoxManufacture.Text).Trim() + "')";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            loaddata();
        }

        public void clear()
        {
            txtBoxCode.Clear();
            txtBoxName.Clear();
            txtBoxCategory.Clear();
            txtBoxPrice.Clear();
            txtBoxStock.Clear();
            txtBoxManufacture.Clear();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes;
            dlgRes = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            cmd = new MySqlCommand();
            cmd.CommandText = "Delete from items where itCode = '" + (txtBoxCode.Text).Trim() + "'";
            MessageBox.Show("Item deleted");
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            loaddata();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
