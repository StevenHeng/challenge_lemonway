using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        localhost.WebService proxy;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            proxy = new localhost.WebService();
            proxy.FibonnaciCompleted += proxy_FibonacciCompleted;
           

            string message = test.ToString();
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Closes the parent form.
                this.Close();
            }
        }

        void proxy_FibonacciCompleted(object sender, proxy.FibonnaciEventArgs e)
        {

        }
    }
}
