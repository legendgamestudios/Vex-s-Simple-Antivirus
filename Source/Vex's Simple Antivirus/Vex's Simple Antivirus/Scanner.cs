using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace Vex_s_Simple_Antivirus
{
    public partial class Scanner : Form
    {
        public Scanner()
        {
            InitializeComponent();
        }
        private int viruses = 0;
        Point lastPoint;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Scanner scn = new Scanner();
            scn.Show();
            Visible = false;
        }

        private void Scanner_Load(object sender, EventArgs e)
        {
            button4.Hide();
            button5.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = "Selected Location : " + folderBrowserDialog1.SelectedPath;
            viruses = 0;
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            button2.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] search = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*");
            progressBar1.Maximum = search.Length;
            foreach (string item in search)
            {
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();
                    string[] virus = new string[] { "SUBSCRIBE", "LIKE", "COMMENT" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button5.Show();
                            label4.Text = "Detected : " + viruses.ToString();

                        }
                        progressBar1.Increment(1);
                    }
                }
                catch
                {
                    string read = item;
                    string[] virus = new string[] { "VIRUSES", "INFECTED", "HACKED" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button5.Show();
                            label4.Text = "Detected : " + viruses.ToString();

                        }
                        progressBar1.Increment(1);

                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Visible = false;
        }
    }
}
