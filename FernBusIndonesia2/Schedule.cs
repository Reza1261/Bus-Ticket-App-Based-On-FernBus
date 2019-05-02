using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FernBusIndonesia2
{
    public partial class Schedule : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public Schedule()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Reza\source\repos\FernBusIndonesia2\FernBusIndonesia2\ScheduleBus.accdb; Persist Security Info=false;";
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {

        }
        private void ClearData()
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand Command = new OleDbCommand();
                Command.Connection = connection;
                string query = "select * from Tabel_Jadwal";
                Command.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(Command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex); }
        }
    }
}


    

