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
using System.Diagnostics;


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
            var tempDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TempFileCollection coll = new TempFileCollection(tempDirectory, false); 
            string filename = coll.AddExtension("temp", false);
            progressBar1.Value = 10;
            StreamWriter sw = new StreamWriter(filename);
             sw.WriteLine(richTextBox1.Text);
             sw.Close();
            Class2.LesVariables = new Variables();
            Class2.Compiler(filename);
            progressBar1.Value = 50;
            richTextBox2.Text += "\nRun "+openFileDialog1.FileName+"\n" ;
            //Class2.Leprogramme.afficher();
            Class2.Leprogramme.executer();
            progressBar1.Value = 75;
            coll.Delete();
            //File.Delete(filename);
            //Class2.LesVariables.Dump();
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
            richTextBox3.Text += st+"\n";
        }
        public void ln()
        {
            richTextBox2.Text += "\n";
        }
        public void WriteTrad(string st)
        {
            richTextBox5.Text += st;
        }
        public void lnTrad()
        {
            richTextBox5.Text += "\n";
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
          try
            {
            using var client = new HttpClient();
            var content = await client.GetStringAsync("https://portfolioluidjyaubel.000webhostapp.com/documentation.php");
            richTextBox4.Text += content;
            }catch (Exception a)
            {
                richTextBox3.Text += "Exception: " + a.Message; //debug qui va disparaitre par la suite
             StreamReader sr = new StreamReader("C.txt");
             string line = sr.ReadLine();
             while (line != null)
             {
            richTextBox4.Text += line;
            richTextBox4.Text += "\n";
            line = sr.ReadLine();
            }
            sr.Close();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var tempDirectory = Directory.GetCurrentDirectory();
            TempFileCollection coll = new TempFileCollection(tempDirectory, true);
            string filename = coll.AddExtension("temp", true);
            progressBar1.Value = 10;
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            StreamReader sz = new StreamReader(filename);
            string a = sz.ReadToEnd();
            sz.Close();
            Class2.Compiler(filename);
            //Class2.Leprogramme.afficher();
            Class2.Leprogramme.traduire();
            richTextBox2.Text += "\nTraduction " + openFileDialog1.FileName + "\n";
            progressBar1.Value = 25;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
            StreamWriter sf = new StreamWriter(saveFileDialog1.FileName);
            sf.WriteLine("<?php");
            sf.WriteLine(richTextBox5.Text);
            progressBar1.Value = 50;
            sf.WriteLine("?>");
            progressBar1.Value = 51;
            sf.Close();
            progressBar1.Value = 75;
            File.Delete(filename);
            progressBar1.Value = 100;
            // Class2.LesVariables.Dump();
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
        private void resize()
        {
            Size = new Size(250, 200);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process Proce1 = new Process();
            Proce1 = Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://portfolioluidjyaubel.000webhostapp.com/documentation.php");
        }
    }
}
