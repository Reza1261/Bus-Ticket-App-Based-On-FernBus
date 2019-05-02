using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FernBusIndonesia2
{
    

    public partial class Form1 : Form
    {
        
        
        private OleDbConnection connection = new OleDbConnection();
        
        OleDbCommand Command;

        public Form1()
        {

            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Reza\source\repos\FernBusIndonesia2\FernBusIndonesia2\ScheduleBus.accdb; Persist Security Info=false;";
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            specialOrder1.BringToFront();
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            orderPage1.BringToFront();
            
            bunifuTransition1.ShowSync(orderPage1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            specialOrder1.BringToFront();
            bunifuTransition2.HideSync(orderPage1);
            bunifuTransition1.ShowSync(specialOrder1);
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            schedule1.BringToFront();
            bunifuTransition2.HideSync(orderPage1);
            bunifuTransition1.ShowSync(schedule1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            map3.BringToFront();
            bunifuTransition2.HideSync(schedule1);
            bunifuTransition1.ShowSync(map3);
        }

        private void specialOrder1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            connection.Open();
            Command = connection.CreateCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = "select PO from Tabel_Jadwal";
            Command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(Command);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["PO"].ToString());
            }
            connection.Close();
            // TODO: This line of code loads data into the 'scheduleBusDataSet3.Tabel_Jadwal' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'scheduleBusDataSet2.Tabel_Jadwal' table. You can move, or remove it, as needed.
     
        }
        

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabel_JadwalTableAdapter.FillBy(this.scheduleBusDataSet2.Tabel_Jadwal);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            panel4.BringToFront();
            bunifuTransition2.HideSync(map3);
            bunifuTransition1.ShowSync(panel4);
            label16.Text = textBox1.Text;
            label22.Text = comboBox1.Text;
            label17.Text = textBox2.Text;
            label19.Text = textBox3.Text;
            label20.Text = textBox4.Text;
            label21.Text = textBox5.Text;
            label24.Text = textBox6.Text;

            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox8.Image = qrcode.Draw(textBox1.Text, 40);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command = new OleDbCommand("select * FROM Tabel_Jadwal where PO='" + comboBox1.Text +  "'",connection);
            OleDbCommand command = new OleDbCommand();
            connection.Open();
            Command.ExecuteNonQuery();
            OleDbDataReader dr;
            dr = Command.ExecuteReader();
            while (dr.Read())
            {
                string Date = (string)dr["Date"].ToString();
                textBox2.Text = Date;
                string Time = (string)dr["Time"].ToString();
                textBox3.Text = Time;
                string Depart = (string)dr["Depart"].ToString();
                textBox4.Text = Depart;
                string Arrival = (string)dr["Arrival"].ToString();
                textBox5.Text = Arrival;
                string Price = (string)dr["Price"].ToString();
                textBox6.Text = Price;
            }
            connection.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            
        }

        private void label19_Click(object sender, EventArgs e)
        {
            
        }

        private void label20_Click(object sender, EventArgs e)
        {
            
        }

        private void label21_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX,mouseY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            
        }

       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0,0);
        }
        Bitmap bmp;
        private void button7_Click_3(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0,0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}
