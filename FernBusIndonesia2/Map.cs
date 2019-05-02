using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FernBusIndonesia2
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string street = textBox1.Text;
            string city = textBox1.Text;
            string state = textBox1.Text;
            string zip = textBox1.Text;
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps?q=");
                if (street != string.Empty)
                {
                    queryaddress.Append(street+","+"+");
                }
                if (city != string.Empty)
                {
                    queryaddress.Append(city + "," + "+");
                }
                if (state != string.Empty)
                {
                    queryaddress.Append(state + "," + "+");
                }
                if (zip != string.Empty)
                {
                    queryaddress.Append(zip + "," + "+");
                }
                webBrowser1.Navigate(queryaddress.ToString());
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
