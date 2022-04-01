using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.IO;
using System.Security;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Globalization;


namespace IDE_langage
{
    public partial class form1 : Form
    {
        private string filePath = string.Empty;
        public bool wantStop = false;
        static public StreamReader fichierentre;
        public form1()
        {
            InitializeComponent();
            Clear();
            ClearError();
            ClearDocumentation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            //string tempDirectory = @"C:\Users\Public\Documents";
            var tempDirectory = Directory.GetCurrentDirectory();
            TempFileCollection coll = new TempFileCollection(tempDirectory, true); 
            string filename = coll.AddExtension("temp", true);
            progressBar1.Value = 10;
            StreamWriter sw = new StreamWriter(filename);
             sw.WriteLine(richTextBox1.Text);
             sw.Close();
            Class2.LesVariables = new Variables();
            Class2.Compiler(filename);
            progressBar1.Value = 50;
            richTextBox2.Text += "\nRun "+openFileDialog1.FileName+"\n" ;
            //Class2.Leprogramme.afficher();
            //Class2.Leprogramme.afficher();
            Class2.Leprogramme.executer();
            progressBar1.Value = 75;
            File.Delete(filename);
            Class2.LesVariables.Dump();
            progressBar1.Value = 100;
        }
        public void Clear()
        {
            richTextBox2.Text += "---------------------";
            richTextBox2.Text += "\n| Console           |";
            richTextBox2.Text += "\n---------------------";
        }
        public void ClearError()
        {
            richTextBox3.Text += "---------------------";
            richTextBox3.Text += "\n| Error             |";
            richTextBox3.Text += "\n---------------------\n";
        }
        public void ClearDocumentation()
        {
            richTextBox4.Text += "---------------------";
            richTextBox4.Text += "\n| Documentation     |";
            richTextBox4.Text += "\n---------------------\n";
        }
        public void Write(string st)
        {
            richTextBox2.Text += st;
        }
        public void WriteErreur(string st)
        {
            richTextBox3.Text += st;
        }
        public void ln()
        {
            richTextBox2.Text += "\n";
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Close();
            wantStop = true;
        }

        private async void Help_Click(object sender, EventArgs e)
        {
                using var client = new HttpClient();
            var content = await client.GetStringAsync("https://portfolioluidjyaubel.000webhostapp.com/documentation.php");
            richTextBox4.Text += content;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*StreamWriter sw = new StreamWriter("C:/Users/AUBElui/Documents/file.txt");
            sw.WriteLine("<?php");
            sw.WriteLine();
            sw.Close();*/
            // Class2.LesVariables.Dump();
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
    }
}
