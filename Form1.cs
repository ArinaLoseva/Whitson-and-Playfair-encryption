using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Tabel()
        {
            string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя._,-";
            string key = textBox1.Text;

            dataGridView1.ColumnCount = 6;
            dataGridView1.RowCount = 6;

            string inputWord = key.ToLower();
            string resultString = inputWord;
            foreach (char letter in alphabet)
            {
                if (!inputWord.Contains(letter))
                {
                    resultString += letter;
                }
            }
            int k = 0;
            for (int n = 0; n < 6; n++)
            {
                for (int m = 0; m < 6; m++)
                {
                    dataGridView1[m, n].Value = resultString[k];
                    k++;
                }
            }
            return resultString;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            string alphabet = Tabel();
            string text = textBox2.Text;

            if (text.Length % 2 != 0)
            {
                text = text + ".";
                textBox2.Text = text;
            }

            for (int i = 0; i < text.Length - 1; i++)
            {
                int a1 = 0, b1 = 0, a2 = 0, b2 = 0;

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (text[i] == Convert.ToChar(dataGridView1[b, a].Value))
                        {
                            a1 = a;
                            b1 = b;
                        }

                        if (text[i + 1] == Convert.ToChar(dataGridView1[b, a].Value))
                        {
                            a2 = a;
                            b2 = b;
                        }
                    }
                }

                if (a1 != a2 && b1 != b2)
                {
                    textBox3.Text = textBox3.Text + dataGridView1[b2, a1].Value + dataGridView1[b1, a2].Value;
                }
                else
                {
                    if (a1 == a2)
                    {
                        b1 = b1 - 1;
                        if (b1 < 0)
                            b1 = 5;

                        b2 = b2 - 1;
                        if (b2 < 0)
                            b2 = 5;
                        textBox3.Text = textBox3.Text + dataGridView1[b1, a1].Value + dataGridView1[b2, a2].Value;
                    }
                    if (b1 == b2)
                    {
                        a1 = a1 - 1;
                        if (a1 < 0)
                            a1 = 5;

                        a2 = a2 - 1;
                        if (a2 < 0)
                            a2 = 5;
                        textBox3.Text = textBox3.Text + dataGridView1[b1, a1].Value + dataGridView1[b2, a2].Value;
                    }
                }
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //первая таблица
            string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя._,-";
            string key1 = textBox3.Text;
            dataGridView2.ColumnCount = 13;
            dataGridView2.RowCount = 6;

            string inputWord = key1.ToLower();
            string resultString = inputWord;
            foreach (char letter in alphabet)
            {
                if (!inputWord.Contains(letter))
                {
                    resultString += letter;
                }
            }
            int k = 0;
            for (int n = 0; n < 6; n++)
            {
                for (int m = 0; m < 6; m++)
                {
                    dataGridView2[m, n].Value = resultString[k];
                    k++;
                }
            }

            //вторая таблица
            string key2 = textBox6.Text;
            string inputWord2 = key2.ToLower();
            string resultString2 = key2.ToLower();
            foreach (char letter in alphabet)
            {
                if (!inputWord2.Contains(letter))
                {
                    resultString2 += letter;
                }
            }
            int k2 = 0;
            for (int n = 0; n < 6; n++)
            {
                for (int m = 7; m < 13; m++)
                {
                    dataGridView2[m, n].Value = resultString2[k2];
                    k2++;
                }
            }

            //шифровка
            textBox5.Text = "";
            string text = textBox4.Text;

            if (text.Length % 2 != 0)
            {
                text = text + ".";
                textBox4.Text = text;
            }

            for (int i = 0; i < text.Length - 1; i++)
            {
                int a1 = 0, b1 = 0, a2 = 0, b2 = 0;

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (text[i] == Convert.ToChar(dataGridView2[b, a].Value))
                        {
                            a1 = a;
                            b1 = b;
                        }
                    }
                }

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 7; b < 13; b++)
                    {
                        if (text[i + 1] == Convert.ToChar(dataGridView2[b, a].Value))
                        {
                            a2 = a;
                            b2 = b;
                        }
                    }
                }

                if (a1 != a2 && b1 != b2)
                {
                    textBox5.Text = textBox5.Text + dataGridView2[b2, a1].Value + dataGridView2[b1, a2].Value;
                }
                else
                {
                    if (a1 == a2)
                    {
                        textBox5.Text = textBox5.Text + dataGridView2[b1 + 7, a1].Value + dataGridView2[b2 - 7, a1].Value;
                    }
                }
                i++;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(sfd.FileName, textBox5.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            string alphabet = Tabel();
            string text = textBox2.Text;

            if (text.Length % 2 != 0)
            {
                text = text + ".";
                textBox2.Text = text;
            }

            for (int i = 0; i < text.Length - 1; i++)
            {
                int a1 = 0, b1 = 0, a2 = 0, b2 = 0;

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (text[i] == Convert.ToChar(dataGridView1[b, a].Value))
                        {
                            a1 = a;
                            b1 = b;
                        }

                        if (text[i + 1] == Convert.ToChar(dataGridView1[b, a].Value))
                        {
                            a2 = a;
                            b2 = b;
                        }
                    }
                }

                if (a1 != a2 && b1 != b2)
                {
                    textBox6.Text = textBox6.Text + dataGridView1[b2, a1].Value + dataGridView1[b1, a2].Value;
                }
                else
                {
                    if (a1 == a2)
                    {
                        b1 = b1 - 1;
                        if (b1 < 0)
                            b1 = 5;

                        b2 = b2 - 1;
                        if (b2 < 0)
                            b2 = 5;
                        textBox6.Text = textBox6.Text + dataGridView1[b1, a1].Value + dataGridView1[b2, a2].Value;
                    }
                    if (b1 == b2)
                    {
                        a1 = a1 - 1;
                        if (a1 < 0)
                            a1 = 5;

                        a2 = a2 - 1;
                        if (a2 < 0)
                            a2 = 5;
                        textBox6.Text = textBox6.Text + dataGridView1[b1, a1].Value + dataGridView1[b2, a2].Value;
                    }
                }
                i++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = System.IO.File.ReadAllText(o.FileName, Encoding.Default);
            }

            textBox5.Text = "";
            string text = textBox4.Text;

            for (int i = 0; i < text.Length - 1; i++)
            {
                int a1 = 0, b1 = 0, a2 = 0, b2 = 0;

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 7; b < 13; b++)
                    {
                        if (text[i] == Convert.ToChar(dataGridView2[b, a].Value))
                        {
                            a1 = a;
                            b1 = b;
                        }
                    }
                }

                for (int a = 0; a < 6; a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (text[i+1] == Convert.ToChar(dataGridView2[b, a].Value))
                        {
                            a2 = a;
                            b2 = b;
                        }
                    }
                }

                if (a1 != a2 && b1 != b2)
                {
                    textBox5.Text = textBox5.Text + dataGridView2[b2, a1].Value + dataGridView2[b1, a2].Value;
                }
                else
                {
                    if (a1 == a2)
                    {
                        textBox5.Text = textBox5.Text + dataGridView2[b1-7, a1].Value + dataGridView2[b2+7, a1].Value;
                    }
                }
                i++;
            }
        }
    }
}
