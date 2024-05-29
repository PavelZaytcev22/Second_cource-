using _10LabLibrary;
using _12LabLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab__16_sharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //textBox1.Text = Form1.bb;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                int longHash;
                bool flag = Int32.TryParse(textBox1.Text, out longHash);
                if (flag)
                {
                    Form1.hashTable = new _12LabLibrary.HashTable<_10LabLibrary.Challenge>(longHash);
                    Challenge buff = new Challenge();

                    /*for (int i = 0; i < 20; i++) 
                    {
                        buff.RandomInit();
                        Form1.hashTable.Add(new Challenge(buff));
                    }*/

                    MessageBox.Show("Таблица инициализирована");
                }
                else
                {
                    MessageBox.Show("Неправильный ввод ");
                }
            }
            else 
            {
                MessageBox.Show("Поле пустое");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
