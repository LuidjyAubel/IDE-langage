
namespace IDE_langage
{
    partial class form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.run = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Help = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ouvrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(12, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(438, 247);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(558, 11);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(75, 23);
            this.run.TabIndex = 3;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(720, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox2.Location = new System.Drawing.Point(477, 41);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(420, 248);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox3.ForeColor = System.Drawing.Color.Red;
            this.richTextBox3.Location = new System.Drawing.Point(477, 292);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(420, 163);
            this.richTextBox3.TabIndex = 7;
            this.richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox4.ForeColor = System.Drawing.Color.Yellow;
            this.richTextBox4.Location = new System.Drawing.Point(12, 292);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(438, 163);
            this.richTextBox4.TabIndex = 8;
            this.richTextBox4.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pat";
            this.openFileDialog1.Filter = "\"Fichier P++ (*.pat)|*.pat|Tous les fichiers (*.*)|*.*\" (Parameter \'value\')";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pat";
            this.saveFileDialog1.FileName = "Unamed";
            this.saveFileDialog1.Filter = "\"Fichier P++ (*.pat)|*.pat|Tous les fichiers (*.*)|*.*\" (Parameter \'value\')";
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(822, 11);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(75, 23);
            this.Help.TabIndex = 9;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(428, 23);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(699, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "© Luidjy AUBEL";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Traduire";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(269, 461);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(477, 41);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(420, 248);
            this.richTextBox5.TabIndex = 15;
            this.richTextBox5.Text = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.Location = new System.Drawing.Point(12, 458);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(142, 24);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help online";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 489);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.run);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form1";
            this.Text = "IDE P++";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox Read;
    }
}

