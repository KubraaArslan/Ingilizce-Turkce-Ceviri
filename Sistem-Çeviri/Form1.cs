using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Çeviri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebBrowser ceviri = new WebBrowser();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ceviri.Navigate("https://www.bing.com/translator?to=tr&setlang=tr");
                ceviri.ScriptErrorsSuppressed = true;
                //Bing translate yi webbrowser ile aç
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ceviri.Document.GetElementById("tta_input_ta").InnerText = textBox1.Text;
            timer1.Start();
            //TextBox1 e yazı yazılırken çevir.
        }

        private void btnOku1_Click(object sender, EventArgs e)
        {
            try
            {
                ceviri.Document.GetElementById("tta_playiconsrc").InvokeMember("click");
                //Girilen kelimeyi oku ---> oku1
                
            }
            catch
            {

            }
        }
        int say = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {   if (say == 2) timer1.Stop();
                textBox2.Text = ceviri.Document.GetElementById("tta_output_ta").InnerText;
                say++;
                //Çevirilen kelimeyi textbox2ye getir
            }
            catch
            {

            }
        }

        private void btnOku2_Click(object sender, EventArgs e)
        {
            try
            {
                ceviri.Document.GetElementById("tta_playicontgt").InvokeMember("click");
                //çevirilen kelimeyi oku
            }
            catch
            {

            }
        }

        private void btnCevir_Click(object sender, EventArgs e)
        {
            try
            {   if (label1.Text == "Türkçe") { label1.Text = "İngilizce"; label2.Text = "Türkçe"; }
                else { label2.Text = "İngilizce"; label1.Text = "Türkçe"; }
                ceviri.Document.GetElementById("tta_revIcon").InvokeMember("click");
                // Dilleri değiştir
            }
            catch
            {

            }
        }
    }
}
