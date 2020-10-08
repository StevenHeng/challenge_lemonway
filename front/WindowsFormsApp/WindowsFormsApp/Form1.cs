using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        dynamic res;
        string input;
        localhost.WebService myLib;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myLib = new localhost.WebService();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;

            using (WaitForm frm = new WaitForm(StartFibonnaci))
            {
                frm.ShowDialog();
            }

            MessageBox.Show(res.ToString(), "Fibonnaci");
        }

        private void StartFibonnaci()
        {
            res = myLib.Fibonnaci(input);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            input = textBox6.Text;

            using (WaitForm frm = new WaitForm(StartConvertXml))
            {
                frm.ShowDialog();
            }

            try
            {
                JToken parsedJson = JToken.Parse(res);
                var beautified = parsedJson.ToString(Formatting.Indented);
                textBox7.Text = beautified;
            }
            catch (Exception ex)
            {
                textBox7.Text = ex.Message;
            }

        }

        private void StartConvertXml()
        {
            res = myLib.XmlToJson(input);
        }
    }
}

    


   
