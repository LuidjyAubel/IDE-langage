﻿using System;
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
using System.Threading.Tasks;

namespace IDE_langage
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
            Clear();
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
            string fileName = "file.temp";
            int bufferSize = 4096;
            var fileStream = System.IO.File.Create(fileName, bufferSize, System.IO.FileOptions.DeleteOnClose);
            var sr = new StreamWriter(fileStream);
            sr.WriteLine(openFileDialog1.FileName);

            Class2.LesVariables = new Variables();
            Class2.Compiler("C:/Users/AUBElui/Documents/text.txt");
            richTextBox2.Text += "Run "+openFileDialog1.FileName ;
            Class2.Leprogramme.afficher();
            Class2.LesVariables.Dump();
            //Class2.Leprogramme.afficher();
            Class2.Leprogramme.executer();

        }
        public void Clear()
        {
            richTextBox2.Text += "---------------------";
            richTextBox2.Text += "\n| Console           |";
            richTextBox2.Text += "\n---------------------\n";
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
            this.Close();
        }

        private async void Help_Click(object sender, EventArgs e)
        {
            richTextBox4.Text += "Documentation";
                using var client = new HttpClient();
                var content = await client.GetStringAsync("https://portfolioluidjyaubel.000webhostapp.com/text.txt");
            richTextBox4.Text = content;
        }
    }
}
