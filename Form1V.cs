using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Valera_4_lab
{
    public partial class Form1 : Form
    {
        Stopwatch t = new Stopwatch();
        bool FilesBool = false;
        string Stroka;
        List<string> Files = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Текстовые файлы|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FilesBool = true;
                t.Start();

                //Чтение файла в виде строки
                string text = File.ReadAllText(fd.FileName);

                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится в списке
                    if (!Files.Contains(str))
                    {
                        Files.Add(str);
                    }
                }
                t.Stop();
                this.Visible = true;
                this.Text = "FileReadTime: " + t.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
            t.Reset();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (FilesBool == true)
            {
                t.Start();
                if (Files.Contains(Stroka))
                {
                    checkedListBox1.Items.Add(Stroka);
                    t.Stop();
                    MessageBox.Show("Совпадение обнаружено ");
                }
                else
                {
                    t.Stop();
                    MessageBox.Show("Совпадение не обнаружено ");
                }
                checkedListBox1.Items.Add(t.Elapsed.ToString());
                t.Reset();
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Stroka = textBox1.Text;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
