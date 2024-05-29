using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _10LabLibrary;
using _12LabLibrary;

namespace Lab__16_sharp
{
    public partial class Form1 : Form
    {
        public static string bb= "vvvvvv";
        public static HashTable<Challenge> hashTable=new HashTable<Challenge>(0);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 gg = new Form3();
            gg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileForm fileForm= new FileForm();
            fileForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
